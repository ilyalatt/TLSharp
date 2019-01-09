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
        public sealed class UnknownTag : Record<UnknownTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x5f4f9247;
            

            
            public UnknownTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UnknownTag DeserializeTag(BinaryReader br)
            {

                return new UnknownTag();
            }
        }

        public sealed class NoneTag : Record<NoneTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfeedd3ad;
            

            
            public NoneTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NoneTag DeserializeTag(BinaryReader br)
            {

                return new NoneTag();
            }
        }

        public sealed class HasPhoneTag : Record<HasPhoneTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x268f3f59;
            

            
            public HasPhoneTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HasPhoneTag DeserializeTag(BinaryReader br)
            {

                return new HasPhoneTag();
            }
        }

        public sealed class ContactTag : Record<ContactTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xd502c2d0;
            

            
            public ContactTag(

            ) {

            }
            
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
                case 0x5f4f9247: return (ContactLink) UnknownTag.DeserializeTag(br);
                case 0xfeedd3ad: return (ContactLink) NoneTag.DeserializeTag(br);
                case 0x268f3f59: return (ContactLink) HasPhoneTag.DeserializeTag(br);
                case 0xd502c2d0: return (ContactLink) ContactTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x5f4f9247, 0xfeedd3ad, 0x268f3f59, 0xd502c2d0 });
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

        public bool Equals(ContactLink other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ContactLink x && Equals(x);
        public static bool operator ==(ContactLink a, ContactLink b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ContactLink a, ContactLink b) => !(a == b);

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

        public int CompareTo(ContactLink other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ContactLink x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ContactLink a, ContactLink b) => a.CompareTo(b) <= 0;
        public static bool operator <(ContactLink a, ContactLink b) => a.CompareTo(b) < 0;
        public static bool operator >(ContactLink a, ContactLink b) => a.CompareTo(b) > 0;
        public static bool operator >=(ContactLink a, ContactLink b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}