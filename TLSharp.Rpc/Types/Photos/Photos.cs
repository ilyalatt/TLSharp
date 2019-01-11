using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Photos
{
    public sealed class Photos : ITlType, IEquatable<Photos>, IComparable<Photos>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x8dca6aa5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.Photo> Photos;
            public readonly Arr<T.User> Users;
            
            public Tag(
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.User>> users
            ) {
                Photos = photos;
                Users = users;
            }
            
            (Arr<T.Photo>, Arr<T.User>) CmpTuple =>
                (Photos, Users);

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

            public override string ToString() => $"(Photos: {Photos}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Photos, bw, WriteVector<T.Photo>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var photos = Read(br, ReadVector(T.Photo.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(photos, users);
            }
        }

        public sealed class SliceTag : ITlTypeTag, IEquatable<SliceTag>, IComparable<SliceTag>, IComparable
        {
            internal const uint TypeNumber = 0x15051f54;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Count;
            public readonly Arr<T.Photo> Photos;
            public readonly Arr<T.User> Users;
            
            public SliceTag(
                int count,
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.User>> users
            ) {
                Count = count;
                Photos = photos;
                Users = users;
            }
            
            (int, Arr<T.Photo>, Arr<T.User>) CmpTuple =>
                (Count, Photos, Users);

            public bool Equals(SliceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SliceTag x && Equals(x);
            public static bool operator ==(SliceTag x, SliceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SliceTag x, SliceTag y) => !(x == y);

            public int CompareTo(SliceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SliceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SliceTag x, SliceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SliceTag x, SliceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SliceTag x, SliceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SliceTag x, SliceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Count: {Count}, Photos: {Photos}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Count, bw, WriteInt);
                Write(Photos, bw, WriteVector<T.Photo>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static SliceTag DeserializeTag(BinaryReader br)
            {
                var count = Read(br, ReadInt);
                var photos = Read(br, ReadVector(T.Photo.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new SliceTag(count, photos, users);
            }
        }

        readonly ITlTypeTag _tag;
        Photos(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Photos(Tag tag) => new Photos(tag);
        public static explicit operator Photos(SliceTag tag) => new Photos(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Photos Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Photos) Tag.DeserializeTag(br);
                case SliceTag.TypeNumber: return (Photos) SliceTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, SliceTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SliceTag, T> sliceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SliceTag x when sliceTag != null: return sliceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SliceTag, T> sliceTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            sliceTag ?? throw new ArgumentNullException(nameof(sliceTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SliceTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Photos other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Photos x && Equals(x);
        public static bool operator ==(Photos x, Photos y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Photos x, Photos y) => !(x == y);

        public int CompareTo(Photos other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Photos x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Photos x, Photos y) => x.CompareTo(y) <= 0;
        public static bool operator <(Photos x, Photos y) => x.CompareTo(y) < 0;
        public static bool operator >(Photos x, Photos y) => x.CompareTo(y) > 0;
        public static bool operator >=(Photos x, Photos y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Photos.{_tag.GetType().Name}{_tag}";
    }
}