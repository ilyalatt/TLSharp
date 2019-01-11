using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ShippingOption : ITlType, IEquatable<ShippingOption>, IComparable<ShippingOption>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb6213cdf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string Title { get; }
            public Arr<T.LabeledPrice> Prices { get; }
            
            public Tag(
                Some<string> id,
                Some<string> title,
                Some<Arr<T.LabeledPrice>> prices
            ) {
                Id = id;
                Title = title;
                Prices = prices;
            }
            
            (string, string, Arr<T.LabeledPrice>) CmpTuple =>
                (Id, Title, Prices);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Title: {Title}, Prices: {Prices})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteString);
                Write(Title, bw, WriteString);
                Write(Prices, bw, WriteVector<T.LabeledPrice>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadString);
                var title = Read(br, ReadString);
                var prices = Read(br, ReadVector(T.LabeledPrice.Deserialize));
                return new Tag(id, title, prices);
            }
        }

        readonly ITlTypeTag _tag;
        ShippingOption(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ShippingOption(Tag tag) => new ShippingOption(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ShippingOption Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ShippingOption) Tag.DeserializeTag(br);
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

        public bool Equals(ShippingOption other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ShippingOption x && Equals(x);
        public static bool operator ==(ShippingOption x, ShippingOption y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ShippingOption x, ShippingOption y) => !(x == y);

        public int CompareTo(ShippingOption other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ShippingOption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ShippingOption x, ShippingOption y) => x.CompareTo(y) <= 0;
        public static bool operator <(ShippingOption x, ShippingOption y) => x.CompareTo(y) < 0;
        public static bool operator >(ShippingOption x, ShippingOption y) => x.CompareTo(y) > 0;
        public static bool operator >=(ShippingOption x, ShippingOption y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ShippingOption.{_tag.GetType().Name}{_tag}";
    }
}