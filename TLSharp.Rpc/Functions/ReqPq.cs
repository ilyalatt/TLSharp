using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class ReqPq : Record<ReqPq>, ITlFunc<T.ResPq>
    {
        public Int128 Nonce { get; }
        
        public ReqPq(
            Int128 nonce
        ) {
            Nonce = nonce;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x60469778);
            Write(Nonce, bw, WriteInt128);
        }
        
        T.ResPq ITlFunc<T.ResPq>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ResPq.Deserialize);
    }
}