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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfb834291;
            
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
                case 0xfb834291: return (TopPeerCategoryPeers) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xfb834291 });
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

        public bool Equals(TopPeerCategoryPeers other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is TopPeerCategoryPeers x && Equals(x);
        public static bool operator ==(TopPeerCategoryPeers a, TopPeerCategoryPeers b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(TopPeerCategoryPeers a, TopPeerCategoryPeers b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(TopPeerCategoryPeers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is TopPeerCategoryPeers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeerCategoryPeers a, TopPeerCategoryPeers b) => a.CompareTo(b) <= 0;
        public static bool operator <(TopPeerCategoryPeers a, TopPeerCategoryPeers b) => a.CompareTo(b) < 0;
        public static bool operator >(TopPeerCategoryPeers a, TopPeerCategoryPeers b) => a.CompareTo(b) > 0;
        public static bool operator >=(TopPeerCategoryPeers a, TopPeerCategoryPeers b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}