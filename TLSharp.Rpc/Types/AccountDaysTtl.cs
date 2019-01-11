using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class AccountDaysTtl : ITlType, IEquatable<AccountDaysTtl>, IComparable<AccountDaysTtl>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb8d0afdf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Days { get; }
            
            public Tag(
                int days
            ) {
                Days = days;
            }
            
            int CmpTuple =>
                Days;

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

            public override string ToString() => $"(Days: {Days})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Days, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var days = Read(br, ReadInt);
                return new Tag(days);
            }
        }

        readonly ITlTypeTag _tag;
        AccountDaysTtl(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator AccountDaysTtl(Tag tag) => new AccountDaysTtl(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static AccountDaysTtl Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (AccountDaysTtl) Tag.DeserializeTag(br);
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

        public bool Equals(AccountDaysTtl other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is AccountDaysTtl x && Equals(x);
        public static bool operator ==(AccountDaysTtl x, AccountDaysTtl y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AccountDaysTtl x, AccountDaysTtl y) => !(x == y);

        public int CompareTo(AccountDaysTtl other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AccountDaysTtl x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AccountDaysTtl x, AccountDaysTtl y) => x.CompareTo(y) <= 0;
        public static bool operator <(AccountDaysTtl x, AccountDaysTtl y) => x.CompareTo(y) < 0;
        public static bool operator >(AccountDaysTtl x, AccountDaysTtl y) => x.CompareTo(y) > 0;
        public static bool operator >=(AccountDaysTtl x, AccountDaysTtl y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"AccountDaysTtl.{_tag.GetType().Name}{_tag}";
    }
}