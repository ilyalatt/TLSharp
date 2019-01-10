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
        public sealed class PhoneTag : Record<PhoneTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf392b7f4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long ClientId { get; }
            public string Phone { get; }
            public string FirstName { get; }
            public string LastName { get; }
            
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

        public bool Equals(InputContact other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputContact x && Equals(x);
        public static bool operator ==(InputContact a, InputContact b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputContact a, InputContact b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case PhoneTag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputContact other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputContact x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputContact a, InputContact b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputContact a, InputContact b) => a.CompareTo(b) < 0;
        public static bool operator >(InputContact a, InputContact b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputContact a, InputContact b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}