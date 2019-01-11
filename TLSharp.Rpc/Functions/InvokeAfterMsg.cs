using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    sealed class InvokeAfterMsg<TFunc, TFuncRes> : ITlFunc<TFuncRes> where TFunc : ITlFunc<TFuncRes>
    {
        public long MsgId { get; }
        public TFunc Query { get; }
        
        public InvokeAfterMsg(
            long msgId,
            Some<TFunc> query
        ) {
            MsgId = msgId;
            Query = query;
        }
        
        

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcb9f372d);
            Write(MsgId, bw, WriteLong);
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}