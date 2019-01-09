using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Users
{
    public sealed class GetUsers : Record<GetUsers>, ITlFunc<Arr<T.User>>
    {
        public Arr<T.InputUser> Id { get; }
        
        public GetUsers(
            Some<Arr<T.InputUser>> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0d91a548);
            Write(Id, bw, WriteVector<T.InputUser>(WriteSerializable));
        }
        
        Arr<T.User> ITlFunc<Arr<T.User>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.User.Deserialize));
    }
}