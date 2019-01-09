using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class RequestEncryption : Record<RequestEncryption>, ITlFunc<T.EncryptedChat>
    {
        public T.InputUser UserId { get; }
        public int RandomId { get; }
        public Arr<byte> Ga { get; }
        
        public RequestEncryption(
            Some<T.InputUser> userId,
            int randomId,
            Some<Arr<byte>> ga
        ) {
            UserId = userId;
            RandomId = randomId;
            Ga = ga;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf64daf43);
            Write(UserId, bw, WriteSerializable);
            Write(RandomId, bw, WriteInt);
            Write(Ga, bw, WriteBytes);
        }
        
        T.EncryptedChat ITlFunc<T.EncryptedChat>.DeserializeResult(BinaryReader br) =>
            Read(br, T.EncryptedChat.Deserialize);
    }
}