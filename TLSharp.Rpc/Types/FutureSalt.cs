using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class FutureSalt : ITlType, IEquatable<FutureSalt>, IComparable<FutureSalt>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x0949d9dc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ValidSince { get; }
            public int ValidUntil { get; }
            public long Salt { get; }
            
            public Tag(
                int validSince,
                int validUntil,
                long salt
            ) {
                ValidSince = validSince;
                ValidUntil = validUntil;
                Salt = salt;
            }
            
            (int, int, long) CmpTuple =>
                (ValidSince, ValidUntil, Salt);

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

            public override string ToString() => $"(ValidSince: {ValidSince}, ValidUntil: {ValidUntil}, Salt: {Salt})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ValidSince, bw, WriteInt);
                Write(ValidUntil, bw, WriteInt);
                Write(Salt, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var validSince = Read(br, ReadInt);
                var validUntil = Read(br, ReadInt);
                var salt = Read(br, ReadLong);
                return new Tag(validSince, validUntil, salt);
            }
        }

        readonly ITlTypeTag _tag;
        FutureSalt(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FutureSalt(Tag tag) => new FutureSalt(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FutureSalt Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (FutureSalt) Tag.DeserializeTag(br);
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

        public bool Equals(FutureSalt other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is FutureSalt x && Equals(x);
        public static bool operator ==(FutureSalt x, FutureSalt y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FutureSalt x, FutureSalt y) => !(x == y);

        public int CompareTo(FutureSalt other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FutureSalt x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FutureSalt x, FutureSalt y) => x.CompareTo(y) <= 0;
        public static bool operator <(FutureSalt x, FutureSalt y) => x.CompareTo(y) < 0;
        public static bool operator >(FutureSalt x, FutureSalt y) => x.CompareTo(y) > 0;
        public static bool operator >=(FutureSalt x, FutureSalt y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FutureSalt.{_tag.GetType().Name}{_tag}";
    }
}