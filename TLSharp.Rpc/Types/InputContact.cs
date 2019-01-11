using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputContact : ITlType, IEquatable<InputContact>, IComparable<InputContact>, IComparable
    {
        public sealed class PhoneTag : ITlTypeTag, IEquatable<PhoneTag>, IComparable<PhoneTag>, IComparable
        {
            internal const uint TypeNumber = 0xf392b7f4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long ClientId;
            public readonly string Phone;
            public readonly string FirstName;
            public readonly string LastName;
            
            public PhoneTag(
                long clientId,
                Some<string> phone,
                Some<string> firstName,
                Some<string> lastName
            ) {
                ClientId = clientId;
                Phone = phone;
                FirstName = firstName;
                LastName = lastName;
            }
            
            (long, string, string, string) CmpTuple =>
                (ClientId, Phone, FirstName, LastName);

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

            public override string ToString() => $"(ClientId: {ClientId}, Phone: {Phone}, FirstName: {FirstName}, LastName: {LastName})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ClientId, bw, WriteLong);
                Write(Phone, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
            }
            
            internal static PhoneTag DeserializeTag(BinaryReader br)
            {
                var clientId = Read(br, ReadLong);
                var phone = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                return new PhoneTag(clientId, phone, firstName, lastName);
            }
        }

        readonly ITlTypeTag _tag;
        InputContact(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputContact(PhoneTag tag) => new InputContact(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputContact Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case PhoneTag.TypeNumber: return (InputContact) PhoneTag.DeserializeTag(br);
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

        public bool Equals(InputContact other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputContact x && Equals(x);
        public static bool operator ==(InputContact x, InputContact y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputContact x, InputContact y) => !(x == y);

        public int CompareTo(InputContact other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputContact x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputContact x, InputContact y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputContact x, InputContact y) => x.CompareTo(y) < 0;
        public static bool operator >(InputContact x, InputContact y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputContact x, InputContact y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputContact.{_tag.GetType().Name}{_tag}";
    }
}