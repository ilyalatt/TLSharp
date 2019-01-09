using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendEncryptedFile : Record<SendEncryptedFile>, ITlFunc<T.Messages.SentEncryptedMessage>
    {
        public T.InputEncryptedChat Peer { get; }
        public long RandomId { get; }
        public Arr<byte> Data { get; }
        public T.InputEncryptedFile File { get; }
        
        public SendEncryptedFile(
            Some<T.InputEncryptedChat> peer,
            long randomId,
            Some<Arr<byte>> data,
            Some<T.InputEncryptedFile> file
        ) {
            Peer = peer;
            RandomId = randomId;
            Data = data;
            File = file;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9a901b66);
            Write(Peer, bw, WriteSerializable);
            Write(RandomId, bw, WriteLong);
            Write(Data, bw, WriteBytes);
            Write(File, bw, WriteSerializable);
        }
        
        T.Messages.SentEncryptedMessage ITlFunc<T.Messages.SentEncryptedMessage>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.SentEncryptedMessage.Deserialize);
    }
}