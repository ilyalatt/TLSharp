using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zlib;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using TLSharp.Auth;
using TLSharp.Crypto;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static LanguageExt.Prelude;

namespace TLSharp.Network
{
    class MtProtoSender
    {
        private readonly TcpTransport _transport;
        private readonly Session _session;
        readonly Task _receiveLoopTask;

        public readonly List<long> NeedConfirmation = new List<long>();

        public MtProtoSender(TcpTransport transport, Session session)
        {
            _transport = transport;
            _session = session;
            _receiveLoopTask = ReceiveLoop();
        }

        private int GetSeqNum(bool inc) => inc ? _session.Sequence++ * 2 + 1 : _session.Sequence * 2;


        async Task<long> SendMsgBody(byte[] packet, bool incSeqNum)
        {
            var messageId = _session.GetNewMessageId();

            byte[] msgKey;
            byte[] cipherText;
            using (var plaintextPacket = makeMemory(8 + 8 + 8 + 4 + 4 + packet.Length))
            {
                using (var plaintextWriter = new BinaryWriter(plaintextPacket))
                {
                    plaintextWriter.Write(_session.Salt);
                    plaintextWriter.Write(_session.Id);
                    plaintextWriter.Write(messageId);
                    plaintextWriter.Write(GetSeqNum(incSeqNum));
                    plaintextWriter.Write(packet.Length);
                    plaintextWriter.Write(packet);

                    msgKey = Helpers.CalcMsgKey(plaintextPacket.GetBuffer());
                    cipherText = AES.EncryptAES(Helpers.CalcKey(_session.AuthKey.Key.ToArray(), msgKey, true),
                        plaintextPacket.GetBuffer());
                }
            }

            _session.Save();

            using (var cipherTextPacket = makeMemory(8 + 16 + cipherText.Length))
            {
                using (var writer = new BinaryWriter(cipherTextPacket))
                {
                    writer.Write(_session.AuthKey.KeyId);
                    writer.Write(msgKey);
                    writer.Write(cipherText);

                    await _transport.Send(cipherTextPacket.GetBuffer());
                }
            }

            return messageId;
        }

        async Task<long> SendMsg(ITlSerializable dto, bool incSeqNum)
        {
            var memory = new MemoryStream();
            var writer = new BinaryWriter(memory, Encoding.UTF8, leaveOpen: true);
            dto.Serialize(writer);

            return await SendMsgBody(memory.ToArray(), incSeqNum);
        }

        async Task SendConfirmations()
        {
            if (NeedConfirmation.Count == 0) return;

            var ack = (MsgsAck) new MsgsAck.Tag(NeedConfirmation.ToArr());
            await SendMsg(ack, incSeqNum: false);

            NeedConfirmation.Clear();
        }


        struct RpcFlow
        {
            public readonly TaskCompletionSource<Option<BinaryReader>> MsgReceived;

            public RpcFlow(TaskCompletionSource<Option<BinaryReader>> msgReceived)
            {
                MsgReceived = msgReceived;
            }

            public static RpcFlow Create() => new RpcFlow(
                new TaskCompletionSource<Option<BinaryReader>>()
            );
        }

        readonly Dictionary<long, RpcFlow> _rpcFlow = new Dictionary<long, RpcFlow>();

        void SetMsgResp(long msgId, Option<BinaryReader> resp)
        {
            if (!_rpcFlow.ContainsKey(msgId)) return;
            var flow = _rpcFlow[msgId];
            flow.MsgReceived.SetResult(resp);
        }

        void SetMsgExc(long msgId, Exception exception)
        {
            if (!_rpcFlow.ContainsKey(msgId)) return;
            var flow = _rpcFlow[msgId];
            flow.MsgReceived.SetException(exception);
        }


        readonly SemaphoreSlim _rpcQueue = new SemaphoreSlim(1, 1);

        async Task<T> WithRpcQueue<T>(Func<Task<T>> func)
        {
            await _rpcQueue.WaitAsync();
            try
            {
                return await func();
            }
            finally
            {
                _rpcQueue.Release(1);
            }
        }

        public async Task<T> Call<T>(ITlFunc<T> request)
        {
            async Task CheckReceiveLoop()
            {
                if (_receiveLoopTask.IsFaulted) await _receiveLoopTask;
            }

            while (true)
            {
                await CheckReceiveLoop();

                var msgId = await WithRpcQueue(async () =>
                {
                    await SendConfirmations();
                    return await SendMsg(request, incSeqNum: true);
                });
                // TODO: create a flow before Send
                var flow = RpcFlow.Create();
                _rpcFlow[msgId] = flow;
                var msgReceivedTask = flow.MsgReceived.Task;
                await Task.WhenAny(_receiveLoopTask, msgReceivedTask);
                await CheckReceiveLoop();

                var resp = await msgReceivedTask;
                var res = resp.Map(request.DeserializeResult);
                if (res.IsSome) return res.ValueUnsafe();
            }
        }

        async Task ReceiveLoop()
        {
            while (true)
            {
                var (item1, item2, item3) = DecodeMessage((await _transport.Receive()).Body);

                using (var messageStream = new MemoryStream(item1, false))
                using (var messageReader = new BinaryReader(messageStream))
                {
                    processMessage(item2, item3, messageReader);
                }
            }
        }

        (byte[], long, int) DecodeMessage(byte[] body)
        {
            byte[] message;
            long remoteMessageId;
            int remoteSequence;

            using (var inputStream = new MemoryStream(body))
            using (var inputReader = new BinaryReader(inputStream))
            {
                if (inputReader.BaseStream.Length < 8)
                    throw new InvalidOperationException($"Can't decode packet");

                var remoteAuthKeyId = inputReader.ReadUInt64(); // TODO: check auth key id
                var msgKey = inputReader.ReadBytes(16); // TODO: check msg_key correctness
                var keyData = Helpers.CalcKey(_session.AuthKey.Key.ToArray(), msgKey, false);

                var plaintext = AES.DecryptAES(keyData, inputReader.ReadBytes((int)(inputStream.Length - inputStream.Position)));

                using (var plaintextStream = new MemoryStream(plaintext))
                using (var plaintextReader = new BinaryReader(plaintextStream))
                {
                    var remoteSalt = plaintextReader.ReadUInt64();
                    var remoteSessionId = plaintextReader.ReadUInt64();
                    remoteMessageId = plaintextReader.ReadInt64();
                    remoteSequence = plaintextReader.ReadInt32();
                    var msgLen = plaintextReader.ReadInt32();
                    message = plaintextReader.ReadBytes(msgLen);
                }
            }
            return (message, remoteMessageId, remoteSequence);
        }

        async Task<Pong> SendPingAsync()
        {
            var ping = new Ping(Helpers.GenerateRandomLong());
            return await Call(ping);
        }

        private Unit processMessage(long messageId, int sequence, BinaryReader messageReader)
        {
            // TODO: check salt
            // TODO: check sessionid
            // TODO: check seqno

            //logger.debug("processMessage: msg_id {0}, sequence {1}, data {2}", BitConverter.ToString(((MemoryStream)messageReader.BaseStream).GetBuffer(), (int) messageReader.BaseStream.Position, (int) (messageReader.BaseStream.Length - messageReader.BaseStream.Position)).Replace("-","").ToLower());
            NeedConfirmation.Add(messageId);

            var code = messageReader.ReadUInt32();
            messageReader.BaseStream.Position -= 4;
            Console.WriteLine(code.ToString("x8"));
            switch (code)
            {
                case 0x73f1f8dc: // container
                    HandleContainer(messageId, sequence, messageReader);
                    break;
                case 0x7abe77ec: // ping
                    HandlePing(messageId, sequence, messageReader);
                    break;
                case 0xae500895: // future_salts
                    HandleFutureSalts(messageId, sequence, messageReader);
                    break;
                case 0x9ec20908: // new_session_created
                    HandleNewSessionCreated(messageId, sequence, messageReader);
                    break;
                case 0x62d6b459: // msgs_ack
                    HandleMsgsAck(messageId, sequence, messageReader);
                    break;
                case 0xedab447b: // bad_server_salt
                    HandleBadServerSalt(messageId, sequence, messageReader);
                    break;
                case 0xa7eff811: // bad_msg_notification
                    HandleBadMsgNotification(messageId, sequence, messageReader);
                    break;
                case 0x276d3ec6: // msg_detailed_info
                    HandleMsgDetailedInfo(messageId, sequence, messageReader);
                    break;
                case 0xf35c6d01: // rpc_result
                    HandleRpcResult(messageId, sequence, messageReader);
                    break;
                case 0x3072cfa1: // gzip_packed
                    HandleGzipPacked(messageId, sequence, messageReader);
                    break;
                case 0xe317af7e:
                case 0xd3f45784:
                case 0x2b2fbd4e:
                case 0x78d4dec1:
                case 0x725b04c3:
                case 0x74ae4240:
                    HandleUpdate(messageId, sequence, messageReader);
                    break;
                default:
                    SetMsgResp(messageId, messageReader);
                    break;
            }

            return unit;
        }

        private bool HandleUpdate(long messageId, int sequence, BinaryReader messageReader)
        {
            return false;

            /*
			try
			{
				UpdatesEvent(TL.Parse<Updates>(messageReader));
				return true;
			}
			catch (Exception e)
			{
				logger.warning("update processing exception: {0}", e);
				return false;
			}
			*/
        }

        private bool HandleGzipPacked(long messageId, int sequence, BinaryReader messageReader)
        {
            var code = messageReader.ReadUInt32();
            var packedData = GZipStream.UncompressBuffer(TlMarshal.ReadBytes(messageReader).ToArray());
            using (var packedStream = new MemoryStream(packedData, false))
            using (var compressedReader = new BinaryReader(packedStream))
            {
                processMessage(messageId, sequence, compressedReader);
            }

            return true;
        }

        private bool HandleRpcResult(long messageId, int sequence, BinaryReader messageReader)
        {
            var code = messageReader.ReadUInt32();
            var reqMsgId = messageReader.ReadInt64();

            var innerCode = messageReader.ReadUInt32();
            if (innerCode == 0x2144ca19)
            { // rpc_error
                var errorCode = messageReader.ReadInt32();
                var errorMessage = TlMarshal.ReadString(messageReader);

                Exception GetExc()
                {
                    if (errorMessage.StartsWith("FLOOD_WAIT_"))
                    {
                        var resultString = Regex.Match(errorMessage, @"\d+").Value;
                        var seconds = int.Parse(resultString);
                        return new FloodException(TimeSpan.FromSeconds(seconds));
                    }

                    if (errorMessage.StartsWith("PHONE_MIGRATE_"))
                    {
                        var resultString = Regex.Match(errorMessage, @"\d+").Value;
                        var dcIdx = int.Parse(resultString);
                        return new PhoneMigrationException(dcIdx);
                    }
                    if (errorMessage.StartsWith("FILE_MIGRATE_"))
                    {
                        var resultString = Regex.Match(errorMessage, @"\d+").Value;
                        var dcIdx = int.Parse(resultString);
                        return new FileMigrationException(dcIdx);
                    }
                    if (errorMessage.StartsWith("USER_MIGRATE_"))
                    {
                        var resultString = Regex.Match(errorMessage, @"\d+").Value;
                        var dcIdx = int.Parse(resultString);
                        return new UserMigrationException(dcIdx);
                    }
                    if (errorMessage.StartsWith("NETWORK_MIGRATE_"))
                    {
                        var resultString = Regex.Match(errorMessage, @"\d+").Value;
                        var dcIdx = int.Parse(resultString);
                        return new NetworkMigrationException(dcIdx);
                    }
                    if (errorMessage == "PHONE_CODE_INVALID")
                    {
                        return new InvalidPhoneCodeException(
                            "The numeric code used to authenticate does not match the numeric code sent by SMS/Telegram");
                    }
                    if (errorMessage == "SESSION_PASSWORD_NEEDED")
                    {
                        return new CloudPasswordNeededException("This Account has Cloud Password !");
                    }
                    return new InvalidOperationException(errorMessage);
                }

                SetMsgExc(reqMsgId, GetExc());
            }
            else if (innerCode == 0x3072cfa1)
            {
                // gzip_packed
                var packedData = TlMarshal.ReadBytes(messageReader);
                using (var ms = new MemoryStream())
                {
                    using (var packedStream = new MemoryStream(packedData.ToArray(), false))
                    using (var zipStream = new GZipStream(packedStream, CompressionMode.Decompress))
                    {
                        zipStream.CopyTo(ms);
                        ms.Position = 0;
                    }
                    using (var compressedReader = new BinaryReader(ms))
                    {
                        SetMsgResp(reqMsgId, compressedReader);
                    }
                }
            }
            else
            {
                messageReader.BaseStream.Position -= 4;
                SetMsgResp(reqMsgId, messageReader);
            }

            return false;
        }

        private bool HandleMsgDetailedInfo(long messageId, int sequence, BinaryReader messageReader)
        {
            return false;
        }

        private void HandleBadMsgNotification(long messageId, int sequence, BinaryReader br)
        {
            br.ReadUInt32();
            var badMsg = BadMsgNotification.Tag.DeserializeTag(br);

            Exception GetException()
            {
                switch (badMsg.ErrorCode)
                {
                    case 16:
                        return new InvalidOperationException(
                            "msg_id too low (most likely, client time is wrong; it would be worthwhile to synchronize it using msg_id notifications and re-send the original message with the “correct” msg_id or wrap it in a container with a new msg_id if the original message had waited too long on the client to be transmitted)");
                    case 17:
                        return new InvalidOperationException(
                            "msg_id too high (similar to the previous case, the client time has to be synchronized, and the message re-sent with the correct msg_id)");
                    case 18:
                        return new InvalidOperationException(
                            "incorrect two lower order msg_id bits (the server expects client message msg_id to be divisible by 4)");
                    case 19:
                        return new InvalidOperationException(
                            "container msg_id is the same as msg_id of a previously received message (this must never happen)");
                    case 20:
                        return new InvalidOperationException(
                            "message too old, and it cannot be verified whether the server has received a message with this msg_id or not");
                    case 32:
                        return new InvalidOperationException(
                            "msg_seqno too low (the server has already received a message with a lower msg_id but with either a higher or an equal and odd seqno)");
                    case 33:
                        return new InvalidOperationException(
                            " msg_seqno too high (similarly, there is a message with a higher msg_id but with either a lower or an equal and odd seqno)");
                    case 34:
                        return new InvalidOperationException(
                            "an even msg_seqno expected (irrelevant message), but odd received");
                    case 35:
                        return new InvalidOperationException(
                            "odd msg_seqno expected (relevant message), but even received");
                    case 48:
                        return new InvalidOperationException(
                            "incorrect server salt (in this case, the bad_server_salt response is received with the correct salt, and the message is to be re-sent with it)");
                    case 64:
                        return new InvalidOperationException("invalid container");
                    default:
                        return new NotImplementedException("This should never happens");
                }
            }

            SetMsgExc(badMsg.BadMsgId, GetException());

            /*
			logger.debug("bad_msg_notification: msgid {0}, seq {1}, errorcode {2}", requestId, requestSequence,
						 errorCode);
			*/
            /*
			if (!runningRequests.ContainsKey(requestId))
			{
				logger.debug("bad msg notification on unknown request");
				return true;
			}
			*/

            //OnBrokenSessionEvent();
            //MTProtoRequest request = runningRequests[requestId];
            //request.OnException(new MTProtoBadMessageException(errorCode));
        }

        private bool HandleBadServerSalt(long messageId, int sequence, BinaryReader br)
        {
            br.ReadInt32();
            var msg = BadMsgNotification.ServerSaltTag.DeserializeTag(br);

            _session.Salt = msg.NewServerSalt;
            SetMsgResp(msg.BadMsgId, None);

            return true;
        }

        private bool HandleMsgsAck(long messageId, int sequence, BinaryReader messageReader)
        {
            return false;
        }

        private bool HandleNewSessionCreated(long messageId, int sequence, BinaryReader messageReader)
        {
            return false;
        }

        private bool HandleFutureSalts(long messageId, int sequence, BinaryReader messageReader)
        {
            var code = messageReader.ReadUInt32();
            var requestId = messageReader.ReadUInt64();

            messageReader.BaseStream.Position -= 12;

            throw new NotImplementedException("Handle future server salts function isn't implemented.");
            /*
			if (!runningRequests.ContainsKey(requestId))
			{
				logger.info("future salts on unknown request");
				return false;
			}
			*/

            //	MTProtoRequest request = runningRequests[requestId];
            //	runningRequests.Remove(requestId);
            //	request.OnResponse(messageReader);
        }

        private bool HandlePing(long messageId, int sequence, BinaryReader messageReader)
        {
            return false;
        }

        private bool HandleContainer(long messageId, int sequence, BinaryReader messageReader)
        {
            var code = messageReader.ReadUInt32();
            var size = messageReader.ReadInt32();
            for (var i = 0; i < size; i++)
            {
                var innerMessageId = messageReader.ReadInt64();
                var innerSequence = messageReader.ReadInt32();
                var innerLength = messageReader.ReadInt32();
                var bts = messageReader.ReadBytes(innerLength);
                bts.Apply(BtHelpers.Deserialize(br => processMessage(innerMessageId, sequence, br)));
            }

            return false;
        }

        private MemoryStream makeMemory(int len)
        {
            return new MemoryStream(new byte[len], 0, len, true, true);
        }
    }
}
