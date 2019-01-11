using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Bots
{
    public sealed class AnswerWebhookJsonQuery : ITlFunc<bool>, IEquatable<AnswerWebhookJsonQuery>, IComparable<AnswerWebhookJsonQuery>, IComparable
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
        
        
        (long, T.DataJson) CmpTuple =>
            (QueryId, Data);

        public bool Equals(AnswerWebhookJsonQuery other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is AnswerWebhookJsonQuery x && Equals(x);
        public static bool operator ==(AnswerWebhookJsonQuery x, AnswerWebhookJsonQuery y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AnswerWebhookJsonQuery x, AnswerWebhookJsonQuery y) => !(x == y);

        public int CompareTo(AnswerWebhookJsonQuery other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AnswerWebhookJsonQuery x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AnswerWebhookJsonQuery x, AnswerWebhookJsonQuery y) => x.CompareTo(y) <= 0;
        public static bool operator <(AnswerWebhookJsonQuery x, AnswerWebhookJsonQuery y) => x.CompareTo(y) < 0;
        public static bool operator >(AnswerWebhookJsonQuery x, AnswerWebhookJsonQuery y) => x.CompareTo(y) > 0;
        public static bool operator >=(AnswerWebhookJsonQuery x, AnswerWebhookJsonQuery y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(QueryId: {QueryId}, Data: {Data})";
        
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