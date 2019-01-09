using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetPasswordSettings : Record<GetPasswordSettings>, ITlFunc<T.Account.PasswordSettings>
    {
        public Arr<byte> CurrentPasswordHash { get; }
        
        public GetPasswordSettings(
            Some<Arr<byte>> currentPasswordHash
        ) {
            CurrentPasswordHash = currentPasswordHash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbc8d11bb);
            Write(CurrentPasswordHash, bw, WriteBytes);
        }
        
        T.Account.PasswordSettings ITlFunc<T.Account.PasswordSettings>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.PasswordSettings.Deserialize);
    }
}