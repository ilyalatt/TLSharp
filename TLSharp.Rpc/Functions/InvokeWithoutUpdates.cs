using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    sealed class InvokeWithoutUpdates<TFunc, TFuncRes> : ITlFunc<TFuncRes> where TFunc : ITlFunc<TFuncRes>
    {
        public TFunc Query { get; }
        
        public InvokeWithoutUpdates(
            Some<TFunc> query
        ) {
            Query = query;
        }
        
        

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbf9459b7);
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}