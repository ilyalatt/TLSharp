using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class TmpPassword : ITlType, IEquatable<TmpPassword>, IComparable<TmpPassword>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xdb64fd34;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<byte> TmpPassword { get; }
            public int ValidUntil { get; }
            
            public Tag(
                Some<Arr<byte>> tmpPassword,
                int validUntil
            ) {
                TmpPassword = tmpPassword;
                ValidUntil = validUntil;
            }
            
            (Arr<byte>, int) CmpTuple =>
                (TmpPassword, ValidUntil);

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

            public override string ToString() => $"(TmpPassword: {TmpPassword}, ValidUntil: {ValidUntil})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(TmpPassword, bw, WriteBytes);
                Write(ValidUntil, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var tmpPassword = Read(br, ReadBytes);
                var validUntil = Read(br, ReadInt);
                return new Tag(tmpPassword, validUntil);
            }
        }

        readonly ITlTypeTag _tag;
        TmpPassword(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TmpPassword(Tag tag) => new TmpPassword(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TmpPassword Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (TmpPassword) Tag.DeserializeTag(br);
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

        public bool Equals(TmpPassword other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is TmpPassword x && Equals(x);
        public static bool operator ==(TmpPassword x, TmpPassword y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TmpPassword x, TmpPassword y) => !(x == y);

        public int CompareTo(TmpPassword other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is TmpPassword x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TmpPassword x, TmpPassword y) => x.CompareTo(y) <= 0;
        public static bool operator <(TmpPassword x, TmpPassword y) => x.CompareTo(y) < 0;
        public static bool operator >(TmpPassword x, TmpPassword y) => x.CompareTo(y) > 0;
        public static bool operator >=(TmpPassword x, TmpPassword y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"TmpPassword.{_tag.GetType().Name}{_tag}";
    }
}