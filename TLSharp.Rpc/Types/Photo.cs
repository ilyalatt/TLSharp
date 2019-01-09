using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Photo : ITlType, IEquatable<Photo>, IComparable<Photo>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x2331b22d;
            
            public long Id { get; }
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                return new EmptyTag(id);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9288dd29;
            
            public bool HasStickers { get; }
            public long Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public Arr<T.PhotoSize> Sizes { get; }
            
            public Tag(
                bool hasStickers,
                long id,
                long accessHash,
                int date,
                Some<Arr<T.PhotoSize>> sizes
            ) {
                HasStickers = hasStickers;
                Id = id;
                AccessHash = accessHash;
                Date = date;
                Sizes = sizes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, HasStickers), bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(Sizes, bw, WriteVector<T.PhotoSize>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var hasStickers = Read(br, ReadOption(flags, 0));
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var sizes = Read(br, ReadVector(T.PhotoSize.Deserialize));
                return new Tag(hasStickers, id, accessHash, date, sizes);
            }
        }

        readonly ITlTypeTag _tag;
        Photo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Photo(EmptyTag tag) => new Photo(tag);
        public static explicit operator Photo(Tag tag) => new Photo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Photo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x2331b22d: return (Photo) EmptyTag.DeserializeTag(br);
                case 0x9288dd29: return (Photo) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x2331b22d, 0x9288dd29 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(Photo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Photo x && Equals(x);
        public static bool operator ==(Photo a, Photo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Photo a, Photo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Photo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Photo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Photo a, Photo b) => a.CompareTo(b) <= 0;
        public static bool operator <(Photo a, Photo b) => a.CompareTo(b) < 0;
        public static bool operator >(Photo a, Photo b) => a.CompareTo(b) > 0;
        public static bool operator >=(Photo a, Photo b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}