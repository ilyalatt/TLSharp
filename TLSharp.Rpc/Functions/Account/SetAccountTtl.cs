using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SetAccountTtl : Record<SetAccountTtl>, ITlFunc<bool>
    {
        public T.AccountDaysTtl Ttl { get; }
        
        public SetAccountTtl(
            Some<T.AccountDaysTtl> ttl
        ) {
            Ttl = ttl;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2442485e);
            Write(Ttl, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}