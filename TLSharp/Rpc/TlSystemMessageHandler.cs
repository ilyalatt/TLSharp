using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zlib;
using LanguageExt;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static LanguageExt.Prelude;

namespace TLSharp.Rpc
{
    class TlSystemMessageHandler
    {
        const uint MsgContainerTypeNumber = 0x73f1f8dc;
        const uint RpcResultTypeNumber = 0xf35c6d01;
        const uint GZipPackedTypeNumber = 0x3072cfa1;

        static Func<BinaryReader, T> Peek<T>(Func<BinaryReader, T> func) => br =>
        {
            var bs = br.BaseStream;
            var pos = bs.Position;

            var res = func(br);

            bs.Position = pos;
            return res;
        };

        static uint PeekTypeNumber(BinaryReader br) =>
            br.Apply(Peek(x => x.ReadUInt32()));

        static void EnsureTypeNumber(BinaryReader br, uint expectedTypeNumber)
        {
            if (br.ReadUInt32() != expectedTypeNumber) throw new Exception("WTF");
        }


        public struct Message
        {
            public readonly long Id;
            public readonly int SeqNo;
            public readonly BinaryReader Body;

            public Message(long id, int seqNo, BinaryReader body)
            {
                Id = id;
                SeqNo = seqNo;
                Body = body;
            }

            public static Func<Message, Message> WithBody(BinaryReader body) =>
                msg => new Message(msg.Id, msg.SeqNo, body);
        }

        public static Message ReadMsg(BinaryReader br)
        {
            var id = br.ReadInt64();
            var seqNo = br.ReadInt32();

            var bodyLength = br.ReadInt32();
            var body = br.ReadBytes(bodyLength);

            return new Message(id, seqNo, body.Apply(BtHelpers.Deserialize(identity)));
        }

        static IEnumerable<Message> ReadContainer(BinaryReader br)
        {
            EnsureTypeNumber(br, MsgContainerTypeNumber);
            var count = br.ReadInt32();
            return Range(0, count).Map(_ => ReadMsg(br));
        }

        static BinaryReader ReadGZipPacked(BinaryReader br)
        {
            EnsureTypeNumber(br, GZipPackedTypeNumber);
            var packedData = TlMarshal.ReadRawBytes(br);
            // TODO: IO.Compression
            return new BinaryReader(new MemoryStream(GZipStream.UncompressBuffer(packedData)));
        }




        static RpcResult HandleRpcResult(BinaryReader br)
        {
            EnsureTypeNumber(br, RpcResultTypeNumber);
            var reqMsgId = br.ReadInt64();
            var innerCode = PeekTypeNumber(br);

            switch (innerCode)
            {
                case RpcError.Tag.TypeNumber:
                    EnsureTypeNumber(br, RpcError.Tag.TypeNumber);
                    return RpcError.Tag.DeserializeTag(br)
                        .Apply(RpcResultErrorHandler.ToException)
                        .Apply(exc => RpcResult.OfFail(reqMsgId, exc));
                case GZipPackedTypeNumber:
                    return ReadGZipPacked(br).Apply(msgBr => RpcResult.OfSuccess(reqMsgId, msgBr));
                default:
                    return RpcResult.OfSuccess(reqMsgId, br);
            }
        }

        static RpcResult HandleBadMsgNotification(BinaryReader br)
        {
            EnsureTypeNumber(br, BadMsgNotification.Tag.TypeNumber);
            var badMsg = BadMsgNotification.Tag.DeserializeTag(br);
            return badMsg
                .Apply(RpcBadMsgNotificationHandler.ToException)
                .Apply(exc => RpcResult.OfFail(badMsg.BadMsgId, exc));
        }

        static RpcResult HandleBadServerSalt(Session session, BinaryReader br)
        {
            br.ReadInt32();
            var msg = BadMsgNotification.ServerSaltTag.DeserializeTag(br);

            session.Salt = msg.NewServerSalt;

            return RpcResult.OfFail(msg.BadMsgId, new TlBadSalt());
        }

        static RpcResult HandlePong(BinaryReader br)
        {
            var msg = br.Apply(Peek(Pong.Deserialize));
            var msgId = msg.Match(identity).MsgId;
            return RpcResult.OfSuccess(msgId, br);
        }

        static void HandleNewSessionCreated(Session session, BinaryReader messageReader)
        {
            messageReader.ReadInt32();
            var newSession = NewSession.CreatedTag.DeserializeTag(messageReader);

            session.Salt = newSession.ServerSalt;

            Console.WriteLine(newSession);
        }

        public static Func<Message, IEnumerable<RpcResult>> Handle(Session session) => message =>
        {
            var br = message.Body;
            var code = PeekTypeNumber(br);

            IEnumerable<RpcResult> Singleton(RpcResult res) => Enumerable.Repeat(res, 1);

            switch (code)
            {
                case GZipPackedTypeNumber:
                    return message.Apply(ReadGZipPacked(br).Apply(Message.WithBody)).Apply(Handle(session));
                case MsgContainerTypeNumber:
                    return ReadContainer(br).Collect(Handle(session));

                case RpcResultTypeNumber:
                    return HandleRpcResult(br).Apply(Singleton);
                case BadMsgNotification.Tag.TypeNumber:
                    return HandleBadMsgNotification(br).Apply(Singleton);
                case BadMsgNotification.ServerSaltTag.TypeNumber:
                    return HandleBadServerSalt(session, br).Apply(Singleton);
                case Pong.Tag.TypeNumber:
                    return HandlePong(br).Apply(Singleton);

                case NewSession.CreatedTag.TypeNumber:
                    HandleNewSessionCreated(session, br);
                    break;

                case MsgsAck.Tag.TypeNumber:
                    // var msg = br.Apply(MsgsAck.Deserialize);
                    // var ids = msg.Match(identity).MsgIds.Apply(xs => string.Join(", ", xs));
                    // Console.WriteLine("Ack: " + ids);
                    break;
                //case FutureSalts.Tag.TypeNumber:
                //case MsgDetailedInfo.Tag.TypeNumber:
                //case MsgDetailedInfo.NewTag.TypeNumber:

                default:
                    Console.WriteLine("Unhandled msg " + code.ToString("x8"));
                    break;
            }

            return Enumerable.Empty<RpcResult>();
        };
    }
}
