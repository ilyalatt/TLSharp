using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class RpcDropAnswer : Record<RpcDropAnswer>, ITlFunc<T.RpcDropAnswer>
    {
        public long ReqMsgId { get; }
        
        public RpcDropAnswer(
            long reqMsgId
        ) {
            ReqMsgId = reqMsgId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x58e4a740);
            Write(ReqMsgId, bw, WriteLong);
        }
        
        T.RpcDropAnswer ITlFunc<T.RpcDropAnswer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.RpcDropAnswer.Deserialize);
    }
}