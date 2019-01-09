using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Users
{
    public sealed class GetFullUser : Record<GetFullUser>, ITlFunc<T.UserFull>
    {
        public T.InputUser Id { get; }
        
        public GetFullUser(
            Some<T.InputUser> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xca30a5b1);
            Write(Id, bw, WriteSerializable);
        }
        
        T.UserFull ITlFunc<T.UserFull>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UserFull.Deserialize);
    }
}