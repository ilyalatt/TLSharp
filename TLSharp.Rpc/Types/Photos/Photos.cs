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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8dca6aa5;
            
            public Arr<T.Photo> Photos { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.User>> users
            ) {
                Photos = photos;
                Users = users;
            }
            
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

        public sealed class SliceTag : Record<SliceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x15051f54;
            
            public int Count { get; }
            public Arr<T.Photo> Photos { get; }
            public Arr<T.User> Users { get; }
            
            public SliceTag(
                int count,
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.User>> users
            ) {
                Count = count;
                Photos = photos;
                Users = users;
            }
            
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
                case 0x8dca6aa5: return (Photos) Tag.DeserializeTag(br);
                case 0x15051f54: return (Photos) SliceTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x8dca6aa5, 0x15051f54 });
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

        public bool Equals(Photos other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Photos x && Equals(x);
        public static bool operator ==(Photos a, Photos b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Photos a, Photos b) => !(a == b);

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

        public int CompareTo(Photos other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Photos x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Photos a, Photos b) => a.CompareTo(b) <= 0;
        public static bool operator <(Photos a, Photos b) => a.CompareTo(b) < 0;
        public static bool operator >(Photos a, Photos b) => a.CompareTo(b) > 0;
        public static bool operator >=(Photos a, Photos b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}