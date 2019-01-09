using System;
using System.IO;
using System.Threading.Tasks;
using TLSharp.Rpc;
using TLSharp.Utils;

namespace TLSharp.Network
{
    class MtProtoPlainSender
    {
        long _lastMessageId;
        readonly Random _random;
        readonly TcpTransport _transport;

        public MtProtoPlainSender(TcpTransport transport)
        {
            _transport = transport;
            _random = new Random();
        }

        async Task Send(byte[] data)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write((long) 0);
                    binaryWriter.Write(GetNewMessageId());
                    binaryWriter.Write(data.Length);
                    binaryWriter.Write(data);

                    var packet = memoryStream.ToArray();

                    await _transport.Send(packet);
                }
            }
        }

        async Task<byte[]> Receive()
        {
            var result = await _transport.Receive();

            using (var memoryStream = new MemoryStream(result.Body))
            {
                using (var binaryReader = new BinaryReader(memoryStream))
                {
                    var authKeyId = binaryReader.ReadInt64();
                    var messageId = binaryReader.ReadInt64();
                    var messageLength = binaryReader.ReadInt32();

                    var response = binaryReader.ReadBytes(messageLength);

                    return response;
                }
            }
        }

        public async Task<T> Call<T>(ITlFunc<T> func)
        {
            var ms1 = new MemoryStream();
            var bw = new BinaryWriter(ms1);
            TlMarshal.WriteSerializable(bw, func);
            await Send(ms1.ToArray());

            var ms2 = new MemoryStream(await Receive());
            var br = new BinaryReader(ms2);
            return func.DeserializeResult(br);
        }

        public long GetNewMessageId() =>
            _lastMessageId = Helpers.GetNewMessageId(_lastMessageId, timeOffset: 0);
    }
}
