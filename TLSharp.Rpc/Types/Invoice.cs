using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Invoice : ITlType, IEquatable<Invoice>, IComparable<Invoice>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc30aa358;
            
            public bool Test { get; }
            public bool NameRequested { get; }
            public bool PhoneRequested { get; }
            public bool EmailRequested { get; }
            public bool ShippingAddressRequested { get; }
            public bool Flexible { get; }
            public string Currency { get; }
            public Arr<T.LabeledPrice> Prices { get; }
            
            public Tag(
                bool test,
                bool nameRequested,
                bool phoneRequested,
                bool emailRequested,
                bool shippingAddressRequested,
                bool flexible,
                Some<string> currency,
                Some<Arr<T.LabeledPrice>> prices
            ) {
                Test = test;
                NameRequested = nameRequested;
                PhoneRequested = phoneRequested;
                EmailRequested = emailRequested;
                ShippingAddressRequested = shippingAddressRequested;
                Flexible = flexible;
                Currency = currency;
                Prices = prices;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Test) | MaskBit(1, NameRequested) | MaskBit(2, PhoneRequested) | MaskBit(3, EmailRequested) | MaskBit(4, ShippingAddressRequested) | MaskBit(5, Flexible), bw, WriteInt);
                Write(Currency, bw, WriteString);
                Write(Prices, bw, WriteVector<T.LabeledPrice>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var test = Read(br, ReadOption(flags, 0));
                var nameRequested = Read(br, ReadOption(flags, 1));
                var phoneRequested = Read(br, ReadOption(flags, 2));
                var emailRequested = Read(br, ReadOption(flags, 3));
                var shippingAddressRequested = Read(br, ReadOption(flags, 4));
                var flexible = Read(br, ReadOption(flags, 5));
                var currency = Read(br, ReadString);
                var prices = Read(br, ReadVector(T.LabeledPrice.Deserialize));
                return new Tag(test, nameRequested, phoneRequested, emailRequested, shippingAddressRequested, flexible, currency, prices);
            }
        }

        readonly ITlTypeTag _tag;
        Invoice(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Invoice(Tag tag) => new Invoice(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Invoice Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xc30aa358: return (Invoice) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xc30aa358 });
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

        public bool Equals(Invoice other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Invoice x && Equals(x);
        public static bool operator ==(Invoice a, Invoice b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Invoice a, Invoice b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Invoice other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Invoice x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Invoice a, Invoice b) => a.CompareTo(b) <= 0;
        public static bool operator <(Invoice a, Invoice b) => a.CompareTo(b) < 0;
        public static bool operator >(Invoice a, Invoice b) => a.CompareTo(b) > 0;
        public static bool operator >=(Invoice a, Invoice b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}