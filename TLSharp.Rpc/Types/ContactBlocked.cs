using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ContactBlocked : ITlType, IEquatable<ContactBlocked>, IComparable<ContactBlocked>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x561bc879;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            public readonly int Date;
            
            public Tag(
                int userId,
                int date
            ) {
                UserId = userId;
                Date = date;
            }
            
            (int, int) CmpTuple =>
                (UserId, Date);

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

            public override string ToString() => $"(UserId: {UserId}, Date: {Date})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new Tag(userId, date);
            }
        }

        readonly ITlTypeTag _tag;
        ContactBlocked(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ContactBlocked(Tag tag) => new ContactBlocked(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ContactBlocked Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ContactBlocked) Tag.DeserializeTag(br);
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

        public bool Equals(ContactBlocked other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ContactBlocked x && Equals(x);
        public static bool operator ==(ContactBlocked x, ContactBlocked y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ContactBlocked x, ContactBlocked y) => !(x == y);

        public int CompareTo(ContactBlocked other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ContactBlocked x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ContactBlocked x, ContactBlocked y) => x.CompareTo(y) <= 0;
        public static bool operator <(ContactBlocked x, ContactBlocked y) => x.CompareTo(y) < 0;
        public static bool operator >(ContactBlocked x, ContactBlocked y) => x.CompareTo(y) > 0;
        public static bool operator >=(ContactBlocked x, ContactBlocked y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ContactBlocked.{_tag.GetType().Name}{_tag}";
    }
}