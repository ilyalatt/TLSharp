using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class UserProfilePhoto : ITlType, IEquatable<UserProfilePhoto>, IComparable<UserProfilePhoto>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x4f11bae1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

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

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xd559d8c8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long PhotoId;
            public readonly T.FileLocation PhotoSmall;
            public readonly T.FileLocation PhotoBig;
            
            public Tag(
                long photoId,
                Some<T.FileLocation> photoSmall,
                Some<T.FileLocation> photoBig
            ) {
                PhotoId = photoId;
                PhotoSmall = photoSmall;
                PhotoBig = photoBig;
            }
            
            (long, T.FileLocation, T.FileLocation) CmpTuple =>
                (PhotoId, PhotoSmall, PhotoBig);

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

            public override string ToString() => $"(PhotoId: {PhotoId}, PhotoSmall: {PhotoSmall}, PhotoBig: {PhotoBig})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhotoId, bw, WriteLong);
                Write(PhotoSmall, bw, WriteSerializable);
                Write(PhotoBig, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var photoId = Read(br, ReadLong);
                var photoSmall = Read(br, T.FileLocation.Deserialize);
                var photoBig = Read(br, T.FileLocation.Deserialize);
                return new Tag(photoId, photoSmall, photoBig);
            }
        }

        readonly ITlTypeTag _tag;
        UserProfilePhoto(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator UserProfilePhoto(EmptyTag tag) => new UserProfilePhoto(tag);
        public static explicit operator UserProfilePhoto(Tag tag) => new UserProfilePhoto(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static UserProfilePhoto Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (UserProfilePhoto) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (UserProfilePhoto) Tag.DeserializeTag(br);
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

        public bool Equals(UserProfilePhoto other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is UserProfilePhoto x && Equals(x);
        public static bool operator ==(UserProfilePhoto x, UserProfilePhoto y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UserProfilePhoto x, UserProfilePhoto y) => !(x == y);

        public int CompareTo(UserProfilePhoto other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is UserProfilePhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UserProfilePhoto x, UserProfilePhoto y) => x.CompareTo(y) <= 0;
        public static bool operator <(UserProfilePhoto x, UserProfilePhoto y) => x.CompareTo(y) < 0;
        public static bool operator >(UserProfilePhoto x, UserProfilePhoto y) => x.CompareTo(y) > 0;
        public static bool operator >=(UserProfilePhoto x, UserProfilePhoto y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"UserProfilePhoto.{_tag.GetType().Name}{_tag}";
    }
}