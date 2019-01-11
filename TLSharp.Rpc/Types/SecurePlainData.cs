using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecurePlainData : ITlType, IEquatable<SecurePlainData>, IComparable<SecurePlainData>, IComparable
    {
        public sealed class PhoneTag : ITlTypeTag, IEquatable<PhoneTag>, IComparable<PhoneTag>, IComparable
        {
            internal const uint TypeNumber = 0x7d6099dd;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Phone;
            
            public PhoneTag(
                Some<string> phone
            ) {
                Phone = phone;
            }
            
            string CmpTuple =>
                Phone;

            public bool Equals(PhoneTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PhoneTag x && Equals(x);
            public static bool operator ==(PhoneTag x, PhoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhoneTag x, PhoneTag y) => !(x == y);

            public int CompareTo(PhoneTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PhoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhoneTag x, PhoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhoneTag x, PhoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhoneTag x, PhoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhoneTag x, PhoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Phone: {Phone})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Phone, bw, WriteString);
            }
            
            internal static PhoneTag DeserializeTag(BinaryReader br)
            {
                var phone = Read(br, ReadString);
                return new PhoneTag(phone);
            }
        }

        public sealed class EmailTag : ITlTypeTag, IEquatable<EmailTag>, IComparable<EmailTag>, IComparable
        {
            internal const uint TypeNumber = 0x21ec5a5f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Email;
            
            public EmailTag(
                Some<string> email
            ) {
                Email = email;
            }
            
            string CmpTuple =>
                Email;

            public bool Equals(EmailTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmailTag x && Equals(x);
            public static bool operator ==(EmailTag x, EmailTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmailTag x, EmailTag y) => !(x == y);

            public int CompareTo(EmailTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmailTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmailTag x, EmailTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmailTag x, EmailTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmailTag x, EmailTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmailTag x, EmailTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Email: {Email})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Email, bw, WriteString);
            }
            
            internal static EmailTag DeserializeTag(BinaryReader br)
            {
                var email = Read(br, ReadString);
                return new EmailTag(email);
            }
        }

        readonly ITlTypeTag _tag;
        SecurePlainData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecurePlainData(PhoneTag tag) => new SecurePlainData(tag);
        public static explicit operator SecurePlainData(EmailTag tag) => new SecurePlainData(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecurePlainData Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case PhoneTag.TypeNumber: return (SecurePlainData) PhoneTag.DeserializeTag(br);
                case EmailTag.TypeNumber: return (SecurePlainData) EmailTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { PhoneTag.TypeNumber, EmailTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<PhoneTag, T> phoneTag = null,
            Func<EmailTag, T> emailTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case PhoneTag x when phoneTag != null: return phoneTag(x);
                case EmailTag x when emailTag != null: return emailTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<PhoneTag, T> phoneTag,
            Func<EmailTag, T> emailTag
        ) => Match(
            () => throw new Exception("WTF"),
            phoneTag ?? throw new ArgumentNullException(nameof(phoneTag)),
            emailTag ?? throw new ArgumentNullException(nameof(emailTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case PhoneTag _: return 0;
                case EmailTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(SecurePlainData other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecurePlainData x && Equals(x);
        public static bool operator ==(SecurePlainData x, SecurePlainData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecurePlainData x, SecurePlainData y) => !(x == y);

        public int CompareTo(SecurePlainData other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecurePlainData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecurePlainData x, SecurePlainData y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecurePlainData x, SecurePlainData y) => x.CompareTo(y) < 0;
        public static bool operator >(SecurePlainData x, SecurePlainData y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecurePlainData x, SecurePlainData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecurePlainData.{_tag.GetType().Name}{_tag}";
    }
}