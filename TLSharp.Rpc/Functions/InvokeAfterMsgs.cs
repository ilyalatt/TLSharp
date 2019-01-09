using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    sealed class InvokeAfterMsgs<TFunc, TFuncRes> : ITlFunc<TFuncRes> where TFunc : ITlFunc<TFuncRes>
    {
        public Arr<long> MsgIds { get; }
        public TFunc Query { get; }
        
        public InvokeAfterMsgs(
            Some<Arr<long>> msgIds,
            Some<TFunc> query
        ) {
            MsgIds = msgIds;
            Query = query;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3dc4b4f0);
            Write(MsgIds, bw, WriteVector<long>(WriteLong));
            Write(Query, bw, WriteSerializable);
        }
        
        TFuncRes ITlFunc<TFuncRes>.DeserializeResult(BinaryReader br) =>
            Query.DeserializeResult(br);
    }
}