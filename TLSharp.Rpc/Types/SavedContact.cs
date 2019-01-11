using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SavedContact : ITlType, IEquatable<SavedContact>, IComparable<SavedContact>, IComparable
    {
        public sealed class PhoneTag : ITlTypeTag, IEquatable<PhoneTag>, IComparable<PhoneTag>, IComparable
        {
            internal const uint TypeNumber = 0x1142bd56;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Phone;
            public readonly string FirstName;
            public readonly string LastName;
            public readonly int Date;
            
            public PhoneTag(
                Some<string> phone,
                Some<string> firstName,
                Some<string> lastName,
                int date
            ) {
                Phone = phone;
                FirstName = firstName;
                LastName = lastName;
                Date = date;
            }
            
            (string, string, string, int) CmpTuple =>
                (Phone, FirstName, LastName, Date);

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

            public override string ToString() => $"(Phone: {Phone}, FirstName: {FirstName}, LastName: {LastName}, Date: {Date})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Phone, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
                Write(Date, bw, WriteInt);
            }
            
            internal static PhoneTag DeserializeTag(BinaryReader br)
            {
                var phone = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                var date = Read(br, ReadInt);
                return new PhoneTag(phone, firstName, lastName, date);
            }
        }

        readonly ITlTypeTag _tag;
        SavedContact(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SavedContact(PhoneTag tag) => new SavedContact(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SavedContact Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case PhoneTag.TypeNumber: return (SavedContact) PhoneTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { PhoneTag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<PhoneTag, T> phoneTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case PhoneTag x when phoneTag != null: return phoneTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<PhoneTag, T> phoneTag
        ) => Match(
            () => throw new Exception("WTF"),
            phoneTag ?? throw new ArgumentNullException(nameof(phoneTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case PhoneTag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(SavedContact other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SavedContact x && Equals(x);
        public static bool operator ==(SavedContact x, SavedContact y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SavedContact x, SavedContact y) => !(x == y);

        public int CompareTo(SavedContact other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SavedContact x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SavedContact x, SavedContact y) => x.CompareTo(y) <= 0;
        public static bool operator <(SavedContact x, SavedContact y) => x.CompareTo(y) < 0;
        public static bool operator >(SavedContact x, SavedContact y) => x.CompareTo(y) > 0;
        public static bool operator >=(SavedContact x, SavedContact y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SavedContact.{_tag.GetType().Name}{_tag}";
    }
}