using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PaymentRequestedInfo : ITlType, IEquatable<PaymentRequestedInfo>, IComparable<PaymentRequestedInfo>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x909c3f94;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<string> Name;
            public readonly Option<string> Phone;
            public readonly Option<string> Email;
            public readonly Option<T.PostAddress> ShippingAddress;
            
            public Tag(
                Option<string> name,
                Option<string> phone,
                Option<string> email,
                Option<T.PostAddress> shippingAddress
            ) {
                Name = name;
                Phone = phone;
                Email = email;
                ShippingAddress = shippingAddress;
            }
            
            (Option<string>, Option<string>, Option<string>, Option<T.PostAddress>) CmpTuple =>
                (Name, Phone, Email, ShippingAddress);

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

            public override string ToString() => $"(Name: {Name}, Phone: {Phone}, Email: {Email}, ShippingAddress: {ShippingAddress})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Name) | MaskBit(1, Phone) | MaskBit(2, Email) | MaskBit(3, ShippingAddress), bw, WriteInt);
                Write(Name, bw, WriteOption<string>(WriteString));
                Write(Phone, bw, WriteOption<string>(WriteString));
                Write(Email, bw, WriteOption<string>(WriteString));
                Write(ShippingAddress, bw, WriteOption<T.PostAddress>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var name = Read(br, ReadOption(flags, 0, ReadString));
                var phone = Read(br, ReadOption(flags, 1, ReadString));
                var email = Read(br, ReadOption(flags, 2, ReadString));
                var shippingAddress = Read(br, ReadOption(flags, 3, T.PostAddress.Deserialize));
                return new Tag(name, phone, email, shippingAddress);
            }
        }

        readonly ITlTypeTag _tag;
        PaymentRequestedInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PaymentRequestedInfo(Tag tag) => new PaymentRequestedInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PaymentRequestedInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PaymentRequestedInfo) Tag.DeserializeTag(br);
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

        public bool Equals(PaymentRequestedInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PaymentRequestedInfo x && Equals(x);
        public static bool operator ==(PaymentRequestedInfo x, PaymentRequestedInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PaymentRequestedInfo x, PaymentRequestedInfo y) => !(x == y);

        public int CompareTo(PaymentRequestedInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PaymentRequestedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentRequestedInfo x, PaymentRequestedInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(PaymentRequestedInfo x, PaymentRequestedInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(PaymentRequestedInfo x, PaymentRequestedInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(PaymentRequestedInfo x, PaymentRequestedInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PaymentRequestedInfo.{_tag.GetType().Name}{_tag}";
    }
}