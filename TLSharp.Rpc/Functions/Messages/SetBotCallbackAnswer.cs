using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetBotCallbackAnswer : ITlFunc<bool>, IEquatable<SetBotCallbackAnswer>, IComparable<SetBotCallbackAnswer>, IComparable
    {
        public bool Alert { get; }
        public long QueryId { get; }
        public Option<string> Message { get; }
        public Option<string> Url { get; }
        public int CacheTime { get; }
        
        public SetBotCallbackAnswer(
            bool alert,
            long queryId,
            Option<string> message,
            Option<string> url,
            int cacheTime
        ) {
            Alert = alert;
            QueryId = queryId;
            Message = message;
            Url = url;
            CacheTime = cacheTime;
        }
        
        
        (bool, long, Option<string>, Option<string>, int) CmpTuple =>
            (Alert, QueryId, Message, Url, CacheTime);

        public bool Equals(SetBotCallbackAnswer other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SetBotCallbackAnswer x && Equals(x);
        public static bool operator ==(SetBotCallbackAnswer x, SetBotCallbackAnswer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetBotCallbackAnswer x, SetBotCallbackAnswer y) => !(x == y);

        public int CompareTo(SetBotCallbackAnswer other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetBotCallbackAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetBotCallbackAnswer x, SetBotCallbackAnswer y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetBotCallbackAnswer x, SetBotCallbackAnswer y) => x.CompareTo(y) < 0;
        public static bool operator >(SetBotCallbackAnswer x, SetBotCallbackAnswer y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetBotCallbackAnswer x, SetBotCallbackAnswer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Alert: {Alert}, QueryId: {QueryId}, Message: {Message}, Url: {Url}, CacheTime: {CacheTime})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd58f130a);
            Write(MaskBit(1, Alert) | MaskBit(0, Message) | MaskBit(2, Url), bw, WriteInt);
            Write(QueryId, bw, WriteLong);
            Write(Message, bw, WriteOption<string>(WriteString));
            Write(Url, bw, WriteOption<string>(WriteString));
            Write(CacheTime, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}