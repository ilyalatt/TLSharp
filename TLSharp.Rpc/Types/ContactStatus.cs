using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ContactStatus : ITlType, IEquatable<ContactStatus>, IComparable<ContactStatus>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd3680c61;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public T.UserStatus Status { get; }
            
            public Tag(
                int userId,
                Some<T.UserStatus> status
            ) {
                UserId = userId;
                Status = status;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Status, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var status = Read(br, T.UserStatus.Deserialize);
                return new Tag(userId, status);
            }
        }

        readonly ITlTypeTag _tag;
        ContactStatus(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ContactStatus(Tag tag) => new ContactStatus(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ContactStatus Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ContactStatus) Tag.DeserializeTag(br);
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

        public bool Equals(ContactStatus other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ContactStatus x && Equals(x);
        public static bool operator ==(ContactStatus a, ContactStatus b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ContactStatus a, ContactStatus b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ContactStatus other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ContactStatus x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ContactStatus a, ContactStatus b) => a.CompareTo(b) <= 0;
        public static bool operator <(ContactStatus a, ContactStatus b) => a.CompareTo(b) < 0;
        public static bool operator >(ContactStatus a, ContactStatus b) => a.CompareTo(b) > 0;
        public static bool operator >=(ContactStatus a, ContactStatus b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}