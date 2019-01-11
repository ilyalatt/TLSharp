using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    sealed class InvokeWithTakeout<TFunc, TFuncRes> : ITlFunc<TFuncRes> where TFunc : ITlFunc<TFuncRes>
    {
        public long TakeoutId { get; }
        public TFunc Query { get; }
        
        public InvokeWithTakeout(
            long takeoutId,
            Some<TFunc> query
        ) {
            TakeoutId = takeoutId;
            Query = query;
        }
        
        

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xaca9fd2e);
            Write(TakeoutId, bw, WriteLong);
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}