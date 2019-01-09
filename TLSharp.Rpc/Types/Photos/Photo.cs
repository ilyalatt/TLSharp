using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Photos
{
    public sealed class Photo : ITlType, IEquatable<Photo>, IComparable<Photo>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x20212ca8;
            
            public T.Photo Photo { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<T.Photo> photo,
                Some<Arr<T.User>> users
            ) {
                Photo = photo;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Photo, bw, WriteSerializable);
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var photo = Read(br, T.Photo.Deserialize);
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(photo, users);
            }
        }

        readonly ITlTypeTag _tag;
        Photo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

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
                case 0x20212ca8: return (Photo) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x20212ca8 });
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

        public bool Equals(Photo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Photo x && Equals(x);
        public static bool operator ==(Photo a, Photo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Photo a, Photo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
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