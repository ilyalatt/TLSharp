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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xc30aa358;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Test;
            public readonly bool NameRequested;
            public readonly bool PhoneRequested;
            public readonly bool EmailRequested;
            public readonly bool ShippingAddressRequested;
            public readonly bool Flexible;
            public readonly string Currency;
            public readonly Arr<T.LabeledPrice> Prices;
            
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
            
            (bool, bool, bool, bool, bool, bool, string, Arr<T.LabeledPrice>) CmpTuple =>
                (Test, NameRequested, PhoneRequested, EmailRequested, ShippingAddressRequested, Flexible, Currency, Prices);

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

            public override string ToString() => $"(Test: {Test}, NameRequested: {NameRequested}, PhoneRequested: {PhoneRequested}, EmailRequested: {EmailRequested}, ShippingAddressRequested: {ShippingAddressRequested}, Flexible: {Flexible}, Currency: {Currency}, Prices: {Prices})";
            
            
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
                case Tag.TypeNumber: return (Invoice) Tag.DeserializeTag(br);
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

        public bool Equals(Invoice other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Invoice x && Equals(x);
        public static bool operator ==(Invoice x, Invoice y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Invoice x, Invoice y) => !(x == y);

        public int CompareTo(Invoice other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Invoice x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Invoice x, Invoice y) => x.CompareTo(y) <= 0;
        public static bool operator <(Invoice x, Invoice y) => x.CompareTo(y) < 0;
        public static bool operator >(Invoice x, Invoice y) => x.CompareTo(y) > 0;
        public static bool operator >=(Invoice x, Invoice y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Invoice.{_tag.GetType().Name}{_tag}";
    }
}