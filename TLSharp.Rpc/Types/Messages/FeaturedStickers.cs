using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class FeaturedStickers : ITlType, IEquatable<FeaturedStickers>, IComparable<FeaturedStickers>, IComparable
    {
        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x04ede3cf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NotModifiedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf89d88e5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Hash { get; }
            public Arr<T.StickerSetCovered> Sets { get; }
            public Arr<long> Unread { get; }
            
            public Tag(
                int hash,
                Some<Arr<T.StickerSetCovered>> sets,
                Some<Arr<long>> unread
            ) {
                Hash = hash;
                Sets = sets;
                Unread = unread;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteInt);
                Write(Sets, bw, WriteVector<T.StickerSetCovered>(WriteSerializable));
                Write(Unread, bw, WriteVector<long>(WriteLong));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadInt);
                var sets = Read(br, ReadVector(T.StickerSetCovered.Deserialize));
                var unread = Read(br, ReadVector(ReadLong));
                return new Tag(hash, sets, unread);
            }
        }

        readonly ITlTypeTag _tag;
        FeaturedStickers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FeaturedStickers(NotModifiedTag tag) => new FeaturedStickers(tag);
        public static explicit operator FeaturedStickers(Tag tag) => new FeaturedStickers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FeaturedStickers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NotModifiedTag.TypeNumber: return (FeaturedStickers) NotModifiedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (FeaturedStickers) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NotModifiedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NotModifiedTag, T> notModifiedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NotModifiedTag, T> notModifiedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(FeaturedStickers other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is FeaturedStickers x && Equals(x);
        public static bool operator ==(FeaturedStickers a, FeaturedStickers b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(FeaturedStickers a, FeaturedStickers b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NotModifiedTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(FeaturedStickers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FeaturedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FeaturedStickers a, FeaturedStickers b) => a.CompareTo(b) <= 0;
        public static bool operator <(FeaturedStickers a, FeaturedStickers b) => a.CompareTo(b) < 0;
        public static bool operator >(FeaturedStickers a, FeaturedStickers b) => a.CompareTo(b) > 0;
        public static bool operator >=(FeaturedStickers a, FeaturedStickers b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}