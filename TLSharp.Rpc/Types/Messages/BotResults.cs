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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x947ca848;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Gallery;
            public readonly long QueryId;
            public readonly Option<string> NextOffset;
            public readonly Option<T.InlineBotSwitchPm> SwitchPm;
            public readonly Arr<T.BotInlineResult> Results;
            public readonly int CacheTime;
            public readonly Arr<T.User> Users;
            
            public Tag(
                bool gallery,
                long queryId,
                Option<string> nextOffset,
                Option<T.InlineBotSwitchPm> switchPm,
                Some<Arr<T.BotInlineResult>> results,
                int cacheTime,
                Some<Arr<T.User>> users
            ) {
                Gallery = gallery;
                QueryId = queryId;
                NextOffset = nextOffset;
                SwitchPm = switchPm;
                Results = results;
                CacheTime = cacheTime;
                Users = users;
            }
            
            (bool, long, Option<string>, Option<T.InlineBotSwitchPm>, Arr<T.BotInlineResult>, int, Arr<T.User>) CmpTuple =>
                (Gallery, QueryId, NextOffset, SwitchPm, Results, CacheTime, Users);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Gallery: {Gallery}, QueryId: {QueryId}, NextOffset: {NextOffset}, SwitchPm: {SwitchPm}, Results: {Results}, CacheTime: {CacheTime}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Gallery) | MaskBit(1, NextOffset) | MaskBit(2, SwitchPm), bw, WriteInt);
                Write(QueryId, bw, WriteLong);
                Write(NextOffset, bw, WriteOption<string>(WriteString));
                Write(SwitchPm, bw, WriteOption<T.InlineBotSwitchPm>(WriteSerializable));
                Write(Results, bw, WriteVector<T.BotInlineResult>(WriteSerializable));
                Write(CacheTime, bw, WriteInt);
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
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
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(gallery, queryId, nextOffset, switchPm, results, cacheTime, users);
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(BotResults other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is BotResults x && Equals(x);
        public static bool operator ==(BotResults x, BotResults y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotResults x, BotResults y) => !(x == y);

        public int CompareTo(BotResults other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is BotResults x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotResults x, BotResults y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotResults x, BotResults y) => x.CompareTo(y) < 0;
        public static bool operator >(BotResults x, BotResults y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotResults x, BotResults y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotResults.{_tag.GetType().Name}{_tag}";
    }
}