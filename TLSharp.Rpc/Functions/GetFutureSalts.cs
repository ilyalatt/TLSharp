using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class GetFutureSalts : Record<GetFutureSalts>, ITlFunc<T.FutureSalts>
    {
        public int Num { get; }
        
        public GetFutureSalts(
            int num
        ) {
            Num = num;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb921bd04);
            Write(Num, bw, WriteInt);
        }
        
        T.FutureSalts ITlFunc<T.FutureSalts>.DeserializeResult(BinaryReader br) =>
            Read(br, T.FutureSalts.Deserialize);
    }
}