using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class CheckPassword : Record<CheckPassword>, ITlFunc<T.Auth.Authorization>
    {
        public Arr<byte> PasswordHash { get; }
        
        public CheckPassword(
            Some<Arr<byte>> passwordHash
        ) {
            PasswordHash = passwordHash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0a63011e);
            Write(PasswordHash, bw, WriteBytes);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}