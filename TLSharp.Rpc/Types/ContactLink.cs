using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ContactLink : ITlType, IEquatable<ContactLink>, IComparable<ContactLink>, IComparable
    {
        public sealed class UnknownTag : ITlTypeTag, IEquatable<UnknownTag>, IComparable<UnknownTag>, IComparable
        {
            internal const uint TypeNumber = 0x5f4f9247;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public UnknownTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(UnknownTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UnknownTag x && Equals(x);
            public static bool operator ==(UnknownTag x, UnknownTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UnknownTag x, UnknownTag y) => !(x == y);

            public int CompareTo(UnknownTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UnknownTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UnknownTag x, UnknownTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UnknownTag x, UnknownTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UnknownTag x, UnknownTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UnknownTag x, UnknownTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UnknownTag DeserializeTag(BinaryReader br)
            {

                return new UnknownTag();
            }
        }

        public sealed class NoneTag : ITlTypeTag, IEquatable<NoneTag>, IComparable<NoneTag>, IComparable
        {
            internal const uint TypeNumber = 0xfeedd3ad;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NoneTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NoneTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NoneTag x && Equals(x);
            public static bool operator ==(NoneTag x, NoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoneTag x, NoneTag y) => !(x == y);

            public int CompareTo(NoneTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoneTag x, NoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoneTag x, NoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoneTag x, NoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoneTag x, NoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NoneTag DeserializeTag(BinaryReader br)
            {

                return new NoneTag();
            }
        }

        public sealed class HasPhoneTag : ITlTypeTag, IEquatable<HasPhoneTag>, IComparable<HasPhoneTag>, IComparable
        {
            internal const uint TypeNumber = 0x268f3f59;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public HasPhoneTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(HasPhoneTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is HasPhoneTag x && Equals(x);
            public static bool operator ==(HasPhoneTag x, HasPhoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(HasPhoneTag x, HasPhoneTag y) => !(x == y);

            public int CompareTo(HasPhoneTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is HasPhoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(HasPhoneTag x, HasPhoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(HasPhoneTag x, HasPhoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(HasPhoneTag x, HasPhoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(HasPhoneTag x, HasPhoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HasPhoneTag DeserializeTag(BinaryReader br)
            {

                return new HasPhoneTag();
            }
        }

        public sealed class ContactTag : ITlTypeTag, IEquatable<ContactTag>, IComparable<ContactTag>, IComparable
        {
            internal const uint TypeNumber = 0xd502c2d0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ContactTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ContactTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ContactTag x && Equals(x);
            public static bool operator ==(ContactTag x, ContactTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ContactTag x, ContactTag y) => !(x == y);

            public int CompareTo(ContactTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ContactTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ContactTag x, ContactTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ContactTag x, ContactTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ContactTag x, ContactTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ContactTag x, ContactTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ContactTag DeserializeTag(BinaryReader br)
            {

                return new ContactTag();
            }
        }

        readonly ITlTypeTag _tag;
        ContactLink(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ContactLink(UnknownTag tag) => new ContactLink(tag);
        public static explicit operator ContactLink(NoneTag tag) => new ContactLink(tag);
        public static explicit operator ContactLink(HasPhoneTag tag) => new ContactLink(tag);
        public static explicit operator ContactLink(ContactTag tag) => new ContactLink(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ContactLink Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case UnknownTag.TypeNumber: return (ContactLink) UnknownTag.DeserializeTag(br);
                case NoneTag.TypeNumber: return (ContactLink) NoneTag.DeserializeTag(br);
                case HasPhoneTag.TypeNumber: return (ContactLink) HasPhoneTag.DeserializeTag(br);
                case ContactTag.TypeNumber: return (ContactLink) ContactTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UnknownTag.TypeNumber, NoneTag.TypeNumber, HasPhoneTag.TypeNumber, ContactTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UnknownTag, T> unknownTag = null,
            Func<NoneTag, T> noneTag = null,
            Func<HasPhoneTag, T> hasPhoneTag = null,
            Func<ContactTag, T> contactTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UnknownTag x when unknownTag != null: return unknownTag(x);
                case NoneTag x when noneTag != null: return noneTag(x);
                case HasPhoneTag x when hasPhoneTag != null: return hasPhoneTag(x);
                case ContactTag x when contactTag != null: return contactTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UnknownTag, T> unknownTag,
            Func<NoneTag, T> noneTag,
            Func<HasPhoneTag, T> hasPhoneTag,
            Func<ContactTag, T> contactTag
        ) => Match(
            () => throw new Exception("WTF"),
            unknownTag ?? throw new ArgumentNullException(nameof(unknownTag)),
            noneTag ?? throw new ArgumentNullException(nameof(noneTag)),
            hasPhoneTag ?? throw new ArgumentNullException(nameof(hasPhoneTag)),
            contactTag ?? throw new ArgumentNullException(nameof(contactTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UnknownTag _: return 0;
                case NoneTag _: return 1;
                case HasPhoneTag _: return 2;
                case ContactTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ContactLink other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ContactLink x && Equals(x);
        public static bool operator ==(ContactLink x, ContactLink y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ContactLink x, ContactLink y) => !(x == y);

        public int CompareTo(ContactLink other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ContactLink x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ContactLink x, ContactLink y) => x.CompareTo(y) <= 0;
        public static bool operator <(ContactLink x, ContactLink y) => x.CompareTo(y) < 0;
        public static bool operator >(ContactLink x, ContactLink y) => x.CompareTo(y) > 0;
        public static bool operator >=(ContactLink x, ContactLink y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ContactLink.{_tag.GetType().Name}{_tag}";
    }
}