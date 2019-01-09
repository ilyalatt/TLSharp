using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetTmpPassword : Record<GetTmpPassword>, ITlFunc<T.Account.TmpPassword>
    {
        public Arr<byte> PasswordHash { get; }
        public int Period { get; }
        
        public GetTmpPassword(
            Some<Arr<byte>> passwordHash,
            int period
        ) {
            PasswordHash = passwordHash;
            Period = period;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4a82327e);
            Write(PasswordHash, bw, WriteBytes);
            Write(Period, bw, WriteInt);
        }
        
        T.Account.TmpPassword ITlFunc<T.Account.TmpPassword>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.TmpPassword.Deserialize);
    }
}