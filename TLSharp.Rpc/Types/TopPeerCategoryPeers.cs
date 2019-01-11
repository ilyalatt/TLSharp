using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class TopPeerCategoryPeers : ITlType, IEquatable<TopPeerCategoryPeers>, IComparable<TopPeerCategoryPeers>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xfb834291;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.TopPeerCategory Category { get; }
            public int Count { get; }
            public Arr<T.TopPeer> Peers { get; }
            
            public Tag(
                Some<T.TopPeerCategory> category,
                int count,
                Some<Arr<T.TopPeer>> peers
            ) {
                Category = category;
                Count = count;
                Peers = peers;
            }
            
            (T.TopPeerCategory, int, Arr<T.TopPeer>) CmpTuple =>
                (Category, Count, Peers);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Category: {Category}, Count: {Count}, Peers: {Peers})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Category, bw, WriteSerializable);
                Write(Count, bw, WriteInt);
                Write(Peers, bw, WriteVector<T.TopPeer>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var category = Read(br, T.TopPeerCategory.Deserialize);
                var count = Read(br, ReadInt);
                var peers = Read(br, ReadVector(T.TopPeer.Deserialize));
                return new Tag(category, count, peers);
            }
        }

        readonly ITlTypeTag _tag;
        TopPeerCategoryPeers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TopPeerCategoryPeers(Tag tag) => new TopPeerCategoryPeers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TopPeerCategoryPeers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (TopPeerCategoryPeers) Tag.DeserializeTag(br);
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

        public bool Equals(TopPeerCategoryPeers other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is TopPeerCategoryPeers x && Equals(x);
        public static bool operator ==(TopPeerCategoryPeers x, TopPeerCategoryPeers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TopPeerCategoryPeers x, TopPeerCategoryPeers y) => !(x == y);

        public int CompareTo(TopPeerCategoryPeers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is TopPeerCategoryPeers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeerCategoryPeers x, TopPeerCategoryPeers y) => x.CompareTo(y) <= 0;
        public static bool operator <(TopPeerCategoryPeers x, TopPeerCategoryPeers y) => x.CompareTo(y) < 0;
        public static bool operator >(TopPeerCategoryPeers x, TopPeerCategoryPeers y) => x.CompareTo(y) > 0;
        public static bool operator >=(TopPeerCategoryPeers x, TopPeerCategoryPeers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"TopPeerCategoryPeers.{_tag.GetType().Name}{_tag}";
    }
}