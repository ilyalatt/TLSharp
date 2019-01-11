using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    sealed class InvokeWithMessagesRange<TFunc, TFuncRes> : ITlFunc<TFuncRes> where TFunc : ITlFunc<TFuncRes>
    {
        public T.MessageRange Range { get; }
        public TFunc Query { get; }
        
        public InvokeWithMessagesRange(
            Some<T.MessageRange> range,
            Some<TFunc> query
        ) {
            Range = range;
            Query = query;
        }
        
        

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x365275f2);
            Write(Range, bw, WriteSerializable);
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}