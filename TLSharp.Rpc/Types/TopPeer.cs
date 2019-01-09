using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class TopPeer : ITlType, IEquatable<TopPeer>, IComparable<TopPeer>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xedcdc05b;
            
            public T.Peer Peer { get; }
            public double Rating { get; }
            
            public Tag(
                Some<T.Peer> peer,
                double rating
            ) {
                Peer = peer;
                Rating = rating;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
                Write(Rating, bw, WriteDouble);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.Peer.Deserialize);
                var rating = Read(br, ReadDouble);
                return new Tag(peer, rating);
            }
        }

        readonly ITlTypeTag _tag;
        TopPeer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TopPeer(Tag tag) => new TopPeer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TopPeer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xedcdc05b: return (TopPeer) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xedcdc05b });
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

        public bool Equals(TopPeer other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is TopPeer x && Equals(x);
        public static bool operator ==(TopPeer a, TopPeer b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(TopPeer a, TopPeer b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(TopPeer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is TopPeer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeer a, TopPeer b) => a.CompareTo(b) <= 0;
        public static bool operator <(TopPeer a, TopPeer b) => a.CompareTo(b) < 0;
        public static bool operator >(TopPeer a, TopPeer b) => a.CompareTo(b) > 0;
        public static bool operator >=(TopPeer a, TopPeer b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}