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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x909c3f94;
            
            public Option<string> Name { get; }
            public Option<string> Phone { get; }
            public Option<string> Email { get; }
            public Option<T.PostAddress> ShippingAddress { get; }
            
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
                case 0x909c3f94: return (PaymentRequestedInfo) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x909c3f94 });
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

        public bool Equals(PaymentRequestedInfo other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PaymentRequestedInfo x && Equals(x);
        public static bool operator ==(PaymentRequestedInfo a, PaymentRequestedInfo b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PaymentRequestedInfo a, PaymentRequestedInfo b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PaymentRequestedInfo other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentRequestedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentRequestedInfo a, PaymentRequestedInfo b) => a.CompareTo(b) <= 0;
        public static bool operator <(PaymentRequestedInfo a, PaymentRequestedInfo b) => a.CompareTo(b) < 0;
        public static bool operator >(PaymentRequestedInfo a, PaymentRequestedInfo b) => a.CompareTo(b) > 0;
        public static bool operator >=(PaymentRequestedInfo a, PaymentRequestedInfo b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}