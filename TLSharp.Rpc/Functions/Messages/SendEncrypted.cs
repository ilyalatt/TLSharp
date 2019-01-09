using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendEncrypted : Record<SendEncrypted>, ITlFunc<T.Messages.SentEncryptedMessage>
    {
        public T.InputEncryptedChat Peer { get; }
        public long RandomId { get; }
        public Arr<byte> Data { get; }
        
        public SendEncrypted(
            Some<T.InputEncryptedChat> peer,
            long randomId,
            Some<Arr<byte>> data
        ) {
            Peer = peer;
            RandomId = randomId;
            Data = data;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa9776773);
            Write(Peer, bw, WriteSerializable);
            Write(RandomId, bw, WriteLong);
            Write(Data, bw, WriteBytes);
        }
        
        T.Messages.SentEncryptedMessage ITlFunc<T.Messages.SentEncryptedMessage>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.SentEncryptedMessage.Deserialize);
    }
}