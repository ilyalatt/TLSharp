using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Bots
{
    public sealed class AnswerWebhookJsonQuery : Record<AnswerWebhookJsonQuery>, ITlFunc<bool>
    {
        public long QueryId { get; }
        public T.DataJson Data { get; }
        
        public AnswerWebhookJsonQuery(
            long queryId,
            Some<T.DataJson> data
        ) {
            QueryId = queryId;
            Data = data;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe6213f4d);
            Write(QueryId, bw, WriteLong);
            Write(Data, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}