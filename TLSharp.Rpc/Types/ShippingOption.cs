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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb6213cdf;
            
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
                case 0xb6213cdf: return (ShippingOption) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xb6213cdf });
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

        public bool Equals(ShippingOption other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ShippingOption x && Equals(x);
        public static bool operator ==(ShippingOption a, ShippingOption b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ShippingOption a, ShippingOption b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ShippingOption other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ShippingOption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ShippingOption a, ShippingOption b) => a.CompareTo(b) <= 0;
        public static bool operator <(ShippingOption a, ShippingOption b) => a.CompareTo(b) < 0;
        public static bool operator >(ShippingOption a, ShippingOption b) => a.CompareTo(b) > 0;
        public static bool operator >=(ShippingOption a, ShippingOption b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}