using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetInlineBotResults : ITlFunc<bool>, IEquatable<SetInlineBotResults>, IComparable<SetInlineBotResults>, IComparable
    {
        public bool Gallery { get; }
        public bool Private { get; }
        public long QueryId { get; }
        public Arr<T.InputBotInlineResult> Results { get; }
        public int CacheTime { get; }
        public Option<string> NextOffset { get; }
        public Option<T.InlineBotSwitchPm> SwitchPm { get; }
        
        public SetInlineBotResults(
            bool gallery,
            bool @private,
            long queryId,
            Some<Arr<T.InputBotInlineResult>> results,
            int cacheTime,
            Option<string> nextOffset,
            Option<T.InlineBotSwitchPm> switchPm
        ) {
            Gallery = gallery;
            Private = @private;
            QueryId = queryId;
            Results = results;
            CacheTime = cacheTime;
            NextOffset = nextOffset;
            SwitchPm = switchPm;
        }
        
        
        (bool, bool, long, Arr<T.InputBotInlineResult>, int, Option<string>, Option<T.InlineBotSwitchPm>) CmpTuple =>
            (Gallery, Private, QueryId, Results, CacheTime, NextOffset, SwitchPm);

        public bool Equals(SetInlineBotResults other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SetInlineBotResults x && Equals(x);
        public static bool operator ==(SetInlineBotResults x, SetInlineBotResults y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetInlineBotResults x, SetInlineBotResults y) => !(x == y);

        public int CompareTo(SetInlineBotResults other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetInlineBotResults x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetInlineBotResults x, SetInlineBotResults y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetInlineBotResults x, SetInlineBotResults y) => x.CompareTo(y) < 0;
        public static bool operator >(SetInlineBotResults x, SetInlineBotResults y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetInlineBotResults x, SetInlineBotResults y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Gallery: {Gallery}, Private: {Private}, QueryId: {QueryId}, Results: {Results}, CacheTime: {CacheTime}, NextOffset: {NextOffset}, SwitchPm: {SwitchPm})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeb5ea206);
            Write(MaskBit(0, Gallery) | MaskBit(1, Private) | MaskBit(2, NextOffset) | MaskBit(3, SwitchPm), bw, WriteInt);
            Write(QueryId, bw, WriteLong);
            Write(Results, bw, WriteVector<T.InputBotInlineResult>(WriteSerializable));
            Write(CacheTime, bw, WriteInt);
            Write(NextOffset, bw, WriteOption<string>(WriteString));
            Write(SwitchPm, bw, WriteOption<T.InlineBotSwitchPm>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}