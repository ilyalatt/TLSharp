using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class BotResults : ITlType, IEquatable<BotResults>, IComparable<BotResults>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xccd3563d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Gallery { get; }
            public long QueryId { get; }
            public Option<string> NextOffset { get; }
            public Option<T.InlineBotSwitchPm> SwitchPm { get; }
            public Arr<T.BotInlineResult> Results { get; }
            public int CacheTime { get; }
            
            public Tag(
                bool gallery,
                long queryId,
                Option<string> nextOffset,
                Option<T.InlineBotSwitchPm> switchPm,
                Some<Arr<T.BotInlineResult>> results,
                int cacheTime
            ) {
                Gallery = gallery;
                QueryId = queryId;
                NextOffset = nextOffset;
                SwitchPm = switchPm;
                Results = results;
                CacheTime = cacheTime;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Gallery) | MaskBit(1, NextOffset) | MaskBit(2, SwitchPm), bw, WriteInt);
                Write(QueryId, bw, WriteLong);
                Write(NextOffset, bw, WriteOption<string>(WriteString));
                Write(SwitchPm, bw, WriteOption<T.InlineBotSwitchPm>(WriteSerializable));
                Write(Results, bw, WriteVector<T.BotInlineResult>(WriteSerializable));
                Write(CacheTime, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var gallery = Read(br, ReadOption(flags, 0));
                var queryId = Read(br, ReadLong);
                var nextOffset = Read(br, ReadOption(flags, 1, ReadString));
                var switchPm = Read(br, ReadOption(flags, 2, T.InlineBotSwitchPm.Deserialize));
                var results = Read(br, ReadVector(T.BotInlineResult.Deserialize));
                var cacheTime = Read(br, ReadInt);
                return new Tag(gallery, queryId, nextOffset, switchPm, results, cacheTime);
            }
        }

        readonly ITlTypeTag _tag;
        BotResults(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator BotResults(Tag tag) => new BotResults(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static BotResults Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (BotResults) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(BotResults other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is BotResults x && Equals(x);
        public static bool operator ==(BotResults a, BotResults b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(BotResults a, BotResults b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(BotResults other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotResults x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotResults a, BotResults b) => a.CompareTo(b) <= 0;
        public static bool operator <(BotResults a, BotResults b) => a.CompareTo(b) < 0;
        public static bool operator >(BotResults a, BotResults b) => a.CompareTo(b) > 0;
        public static bool operator >=(BotResults a, BotResults b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}