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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x2331b22d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            long CmpTuple =>
                Id;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9288dd29;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool HasStickers;
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Date;
            public readonly Arr<T.PhotoSize> Sizes;
            
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
            
            (bool, long, long, int, Arr<T.PhotoSize>) CmpTuple =>
                (HasStickers, Id, AccessHash, Date, Sizes);

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

            public override string ToString() => $"(HasStickers: {HasStickers}, Id: {Id}, AccessHash: {AccessHash}, Date: {Date}, Sizes: {Sizes})";
            
            
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
                case EmptyTag.TypeNumber: return (Photo) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (Photo) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber });
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

        public bool Equals(Photo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Photo x && Equals(x);
        public static bool operator ==(Photo x, Photo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Photo x, Photo y) => !(x == y);

        public int CompareTo(Photo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Photo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Photo x, Photo y) => x.CompareTo(y) <= 0;
        public static bool operator <(Photo x, Photo y) => x.CompareTo(y) < 0;
        public static bool operator >(Photo x, Photo y) => x.CompareTo(y) > 0;
        public static bool operator >=(Photo x, Photo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Photo.{_tag.GetType().Name}{_tag}";
    }
}