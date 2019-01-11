using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecureValueType : ITlType, IEquatable<SecureValueType>, IComparable<SecureValueType>, IComparable
    {
        public sealed class PersonalDetailsTag : ITlTypeTag, IEquatable<PersonalDetailsTag>, IComparable<PersonalDetailsTag>, IComparable
        {
            internal const uint TypeNumber = 0x9d2a81e3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PersonalDetailsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PersonalDetailsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PersonalDetailsTag x && Equals(x);
            public static bool operator ==(PersonalDetailsTag x, PersonalDetailsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PersonalDetailsTag x, PersonalDetailsTag y) => !(x == y);

            public int CompareTo(PersonalDetailsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PersonalDetailsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PersonalDetailsTag x, PersonalDetailsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PersonalDetailsTag x, PersonalDetailsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PersonalDetailsTag x, PersonalDetailsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PersonalDetailsTag x, PersonalDetailsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PersonalDetailsTag DeserializeTag(BinaryReader br)
            {

                return new PersonalDetailsTag();
            }
        }

        public sealed class PassportTag : ITlTypeTag, IEquatable<PassportTag>, IComparable<PassportTag>, IComparable
        {
            internal const uint TypeNumber = 0x3dac6a00;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PassportTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PassportTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PassportTag x && Equals(x);
            public static bool operator ==(PassportTag x, PassportTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PassportTag x, PassportTag y) => !(x == y);

            public int CompareTo(PassportTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PassportTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PassportTag x, PassportTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PassportTag x, PassportTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PassportTag x, PassportTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PassportTag x, PassportTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PassportTag DeserializeTag(BinaryReader br)
            {

                return new PassportTag();
            }
        }

        public sealed class DriverLicenseTag : ITlTypeTag, IEquatable<DriverLicenseTag>, IComparable<DriverLicenseTag>, IComparable
        {
            internal const uint TypeNumber = 0x06e425c4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public DriverLicenseTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(DriverLicenseTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DriverLicenseTag x && Equals(x);
            public static bool operator ==(DriverLicenseTag x, DriverLicenseTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DriverLicenseTag x, DriverLicenseTag y) => !(x == y);

            public int CompareTo(DriverLicenseTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DriverLicenseTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DriverLicenseTag x, DriverLicenseTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DriverLicenseTag x, DriverLicenseTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DriverLicenseTag x, DriverLicenseTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DriverLicenseTag x, DriverLicenseTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static DriverLicenseTag DeserializeTag(BinaryReader br)
            {

                return new DriverLicenseTag();
            }
        }

        public sealed class IdentityCardTag : ITlTypeTag, IEquatable<IdentityCardTag>, IComparable<IdentityCardTag>, IComparable
        {
            internal const uint TypeNumber = 0xa0d0744b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public IdentityCardTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(IdentityCardTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is IdentityCardTag x && Equals(x);
            public static bool operator ==(IdentityCardTag x, IdentityCardTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(IdentityCardTag x, IdentityCardTag y) => !(x == y);

            public int CompareTo(IdentityCardTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is IdentityCardTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(IdentityCardTag x, IdentityCardTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(IdentityCardTag x, IdentityCardTag y) => x.CompareTo(y) < 0;
            public static bool operator >(IdentityCardTag x, IdentityCardTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(IdentityCardTag x, IdentityCardTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static IdentityCardTag DeserializeTag(BinaryReader br)
            {

                return new IdentityCardTag();
            }
        }

        public sealed class InternalPassportTag : ITlTypeTag, IEquatable<InternalPassportTag>, IComparable<InternalPassportTag>, IComparable
        {
            internal const uint TypeNumber = 0x99a48f23;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public InternalPassportTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(InternalPassportTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InternalPassportTag x && Equals(x);
            public static bool operator ==(InternalPassportTag x, InternalPassportTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InternalPassportTag x, InternalPassportTag y) => !(x == y);

            public int CompareTo(InternalPassportTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InternalPassportTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InternalPassportTag x, InternalPassportTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InternalPassportTag x, InternalPassportTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InternalPassportTag x, InternalPassportTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InternalPassportTag x, InternalPassportTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static InternalPassportTag DeserializeTag(BinaryReader br)
            {

                return new InternalPassportTag();
            }
        }

        public sealed class AddressTag : ITlTypeTag, IEquatable<AddressTag>, IComparable<AddressTag>, IComparable
        {
            internal const uint TypeNumber = 0xcbe31e26;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AddressTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AddressTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AddressTag x && Equals(x);
            public static bool operator ==(AddressTag x, AddressTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AddressTag x, AddressTag y) => !(x == y);

            public int CompareTo(AddressTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AddressTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AddressTag x, AddressTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AddressTag x, AddressTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AddressTag x, AddressTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AddressTag x, AddressTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AddressTag DeserializeTag(BinaryReader br)
            {

                return new AddressTag();
            }
        }

        public sealed class UtilityBillTag : ITlTypeTag, IEquatable<UtilityBillTag>, IComparable<UtilityBillTag>, IComparable
        {
            internal const uint TypeNumber = 0xfc36954e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public UtilityBillTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(UtilityBillTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UtilityBillTag x && Equals(x);
            public static bool operator ==(UtilityBillTag x, UtilityBillTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UtilityBillTag x, UtilityBillTag y) => !(x == y);

            public int CompareTo(UtilityBillTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UtilityBillTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UtilityBillTag x, UtilityBillTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UtilityBillTag x, UtilityBillTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UtilityBillTag x, UtilityBillTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UtilityBillTag x, UtilityBillTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UtilityBillTag DeserializeTag(BinaryReader br)
            {

                return new UtilityBillTag();
            }
        }

        public sealed class BankStatementTag : ITlTypeTag, IEquatable<BankStatementTag>, IComparable<BankStatementTag>, IComparable
        {
            internal const uint TypeNumber = 0x89137c0d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BankStatementTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(BankStatementTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BankStatementTag x && Equals(x);
            public static bool operator ==(BankStatementTag x, BankStatementTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BankStatementTag x, BankStatementTag y) => !(x == y);

            public int CompareTo(BankStatementTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BankStatementTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BankStatementTag x, BankStatementTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BankStatementTag x, BankStatementTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BankStatementTag x, BankStatementTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BankStatementTag x, BankStatementTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BankStatementTag DeserializeTag(BinaryReader br)
            {

                return new BankStatementTag();
            }
        }

        public sealed class RentalAgreementTag : ITlTypeTag, IEquatable<RentalAgreementTag>, IComparable<RentalAgreementTag>, IComparable
        {
            internal const uint TypeNumber = 0x8b883488;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RentalAgreementTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RentalAgreementTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is RentalAgreementTag x && Equals(x);
            public static bool operator ==(RentalAgreementTag x, RentalAgreementTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RentalAgreementTag x, RentalAgreementTag y) => !(x == y);

            public int CompareTo(RentalAgreementTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is RentalAgreementTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RentalAgreementTag x, RentalAgreementTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RentalAgreementTag x, RentalAgreementTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RentalAgreementTag x, RentalAgreementTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RentalAgreementTag x, RentalAgreementTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RentalAgreementTag DeserializeTag(BinaryReader br)
            {

                return new RentalAgreementTag();
            }
        }

        public sealed class PassportRegistrationTag : ITlTypeTag, IEquatable<PassportRegistrationTag>, IComparable<PassportRegistrationTag>, IComparable
        {
            internal const uint TypeNumber = 0x99e3806a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PassportRegistrationTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PassportRegistrationTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PassportRegistrationTag x && Equals(x);
            public static bool operator ==(PassportRegistrationTag x, PassportRegistrationTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PassportRegistrationTag x, PassportRegistrationTag y) => !(x == y);

            public int CompareTo(PassportRegistrationTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PassportRegistrationTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PassportRegistrationTag x, PassportRegistrationTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PassportRegistrationTag x, PassportRegistrationTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PassportRegistrationTag x, PassportRegistrationTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PassportRegistrationTag x, PassportRegistrationTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PassportRegistrationTag DeserializeTag(BinaryReader br)
            {

                return new PassportRegistrationTag();
            }
        }

        public sealed class TemporaryRegistrationTag : ITlTypeTag, IEquatable<TemporaryRegistrationTag>, IComparable<TemporaryRegistrationTag>, IComparable
        {
            internal const uint TypeNumber = 0xea02ec33;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public TemporaryRegistrationTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(TemporaryRegistrationTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TemporaryRegistrationTag x && Equals(x);
            public static bool operator ==(TemporaryRegistrationTag x, TemporaryRegistrationTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TemporaryRegistrationTag x, TemporaryRegistrationTag y) => !(x == y);

            public int CompareTo(TemporaryRegistrationTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TemporaryRegistrationTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TemporaryRegistrationTag x, TemporaryRegistrationTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TemporaryRegistrationTag x, TemporaryRegistrationTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TemporaryRegistrationTag x, TemporaryRegistrationTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TemporaryRegistrationTag x, TemporaryRegistrationTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static TemporaryRegistrationTag DeserializeTag(BinaryReader br)
            {

                return new TemporaryRegistrationTag();
            }
        }

        public sealed class PhoneTag : ITlTypeTag, IEquatable<PhoneTag>, IComparable<PhoneTag>, IComparable
        {
            internal const uint TypeNumber = 0xb320aadb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PhoneTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

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

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PhoneTag DeserializeTag(BinaryReader br)
            {

                return new PhoneTag();
            }
        }

        public sealed class EmailTag : ITlTypeTag, IEquatable<EmailTag>, IComparable<EmailTag>, IComparable
        {
            internal const uint TypeNumber = 0x8e3ca7ee;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmailTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

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

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmailTag DeserializeTag(BinaryReader br)
            {

                return new EmailTag();
            }
        }

        readonly ITlTypeTag _tag;
        SecureValueType(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecureValueType(PersonalDetailsTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(PassportTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(DriverLicenseTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(IdentityCardTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(InternalPassportTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(AddressTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(UtilityBillTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(BankStatementTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(RentalAgreementTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(PassportRegistrationTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(TemporaryRegistrationTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(PhoneTag tag) => new SecureValueType(tag);
        public static explicit operator SecureValueType(EmailTag tag) => new SecureValueType(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecureValueType Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case PersonalDetailsTag.TypeNumber: return (SecureValueType) PersonalDetailsTag.DeserializeTag(br);
                case PassportTag.TypeNumber: return (SecureValueType) PassportTag.DeserializeTag(br);
                case DriverLicenseTag.TypeNumber: return (SecureValueType) DriverLicenseTag.DeserializeTag(br);
                case IdentityCardTag.TypeNumber: return (SecureValueType) IdentityCardTag.DeserializeTag(br);
                case InternalPassportTag.TypeNumber: return (SecureValueType) InternalPassportTag.DeserializeTag(br);
                case AddressTag.TypeNumber: return (SecureValueType) AddressTag.DeserializeTag(br);
                case UtilityBillTag.TypeNumber: return (SecureValueType) UtilityBillTag.DeserializeTag(br);
                case BankStatementTag.TypeNumber: return (SecureValueType) BankStatementTag.DeserializeTag(br);
                case RentalAgreementTag.TypeNumber: return (SecureValueType) RentalAgreementTag.DeserializeTag(br);
                case PassportRegistrationTag.TypeNumber: return (SecureValueType) PassportRegistrationTag.DeserializeTag(br);
                case TemporaryRegistrationTag.TypeNumber: return (SecureValueType) TemporaryRegistrationTag.DeserializeTag(br);
                case PhoneTag.TypeNumber: return (SecureValueType) PhoneTag.DeserializeTag(br);
                case EmailTag.TypeNumber: return (SecureValueType) EmailTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { PersonalDetailsTag.TypeNumber, PassportTag.TypeNumber, DriverLicenseTag.TypeNumber, IdentityCardTag.TypeNumber, InternalPassportTag.TypeNumber, AddressTag.TypeNumber, UtilityBillTag.TypeNumber, BankStatementTag.TypeNumber, RentalAgreementTag.TypeNumber, PassportRegistrationTag.TypeNumber, TemporaryRegistrationTag.TypeNumber, PhoneTag.TypeNumber, EmailTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<PersonalDetailsTag, T> personalDetailsTag = null,
            Func<PassportTag, T> passportTag = null,
            Func<DriverLicenseTag, T> driverLicenseTag = null,
            Func<IdentityCardTag, T> identityCardTag = null,
            Func<InternalPassportTag, T> internalPassportTag = null,
            Func<AddressTag, T> addressTag = null,
            Func<UtilityBillTag, T> utilityBillTag = null,
            Func<BankStatementTag, T> bankStatementTag = null,
            Func<RentalAgreementTag, T> rentalAgreementTag = null,
            Func<PassportRegistrationTag, T> passportRegistrationTag = null,
            Func<TemporaryRegistrationTag, T> temporaryRegistrationTag = null,
            Func<PhoneTag, T> phoneTag = null,
            Func<EmailTag, T> emailTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case PersonalDetailsTag x when personalDetailsTag != null: return personalDetailsTag(x);
                case PassportTag x when passportTag != null: return passportTag(x);
                case DriverLicenseTag x when driverLicenseTag != null: return driverLicenseTag(x);
                case IdentityCardTag x when identityCardTag != null: return identityCardTag(x);
                case InternalPassportTag x when internalPassportTag != null: return internalPassportTag(x);
                case AddressTag x when addressTag != null: return addressTag(x);
                case UtilityBillTag x when utilityBillTag != null: return utilityBillTag(x);
                case BankStatementTag x when bankStatementTag != null: return bankStatementTag(x);
                case RentalAgreementTag x when rentalAgreementTag != null: return rentalAgreementTag(x);
                case PassportRegistrationTag x when passportRegistrationTag != null: return passportRegistrationTag(x);
                case TemporaryRegistrationTag x when temporaryRegistrationTag != null: return temporaryRegistrationTag(x);
                case PhoneTag x when phoneTag != null: return phoneTag(x);
                case EmailTag x when emailTag != null: return emailTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<PersonalDetailsTag, T> personalDetailsTag,
            Func<PassportTag, T> passportTag,
            Func<DriverLicenseTag, T> driverLicenseTag,
            Func<IdentityCardTag, T> identityCardTag,
            Func<InternalPassportTag, T> internalPassportTag,
            Func<AddressTag, T> addressTag,
            Func<UtilityBillTag, T> utilityBillTag,
            Func<BankStatementTag, T> bankStatementTag,
            Func<RentalAgreementTag, T> rentalAgreementTag,
            Func<PassportRegistrationTag, T> passportRegistrationTag,
            Func<TemporaryRegistrationTag, T> temporaryRegistrationTag,
            Func<PhoneTag, T> phoneTag,
            Func<EmailTag, T> emailTag
        ) => Match(
            () => throw new Exception("WTF"),
            personalDetailsTag ?? throw new ArgumentNullException(nameof(personalDetailsTag)),
            passportTag ?? throw new ArgumentNullException(nameof(passportTag)),
            driverLicenseTag ?? throw new ArgumentNullException(nameof(driverLicenseTag)),
            identityCardTag ?? throw new ArgumentNullException(nameof(identityCardTag)),
            internalPassportTag ?? throw new ArgumentNullException(nameof(internalPassportTag)),
            addressTag ?? throw new ArgumentNullException(nameof(addressTag)),
            utilityBillTag ?? throw new ArgumentNullException(nameof(utilityBillTag)),
            bankStatementTag ?? throw new ArgumentNullException(nameof(bankStatementTag)),
            rentalAgreementTag ?? throw new ArgumentNullException(nameof(rentalAgreementTag)),
            passportRegistrationTag ?? throw new ArgumentNullException(nameof(passportRegistrationTag)),
            temporaryRegistrationTag ?? throw new ArgumentNullException(nameof(temporaryRegistrationTag)),
            phoneTag ?? throw new ArgumentNullException(nameof(phoneTag)),
            emailTag ?? throw new ArgumentNullException(nameof(emailTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case PersonalDetailsTag _: return 0;
                case PassportTag _: return 1;
                case DriverLicenseTag _: return 2;
                case IdentityCardTag _: return 3;
                case InternalPassportTag _: return 4;
                case AddressTag _: return 5;
                case UtilityBillTag _: return 6;
                case BankStatementTag _: return 7;
                case RentalAgreementTag _: return 8;
                case PassportRegistrationTag _: return 9;
                case TemporaryRegistrationTag _: return 10;
                case PhoneTag _: return 11;
                case EmailTag _: return 12;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(SecureValueType other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecureValueType x && Equals(x);
        public static bool operator ==(SecureValueType x, SecureValueType y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecureValueType x, SecureValueType y) => !(x == y);

        public int CompareTo(SecureValueType other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecureValueType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecureValueType x, SecureValueType y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecureValueType x, SecureValueType y) => x.CompareTo(y) < 0;
        public static bool operator >(SecureValueType x, SecureValueType y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecureValueType x, SecureValueType y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecureValueType.{_tag.GetType().Name}{_tag}";
    }
}