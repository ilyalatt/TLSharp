using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Payments
{
    public sealed class ValidatedRequestedInfo : ITlType, IEquatable<ValidatedRequestedInfo>, IComparable<ValidatedRequestedInfo>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xd1451883;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<string> Id;
            public readonly Option<Arr<T.ShippingOption>> ShippingOptions;
            
            public Tag(
                Option<string> id,
                Option<Arr<T.ShippingOption>> shippingOptions
            ) {
                Id = id;
                ShippingOptions = shippingOptions;
            }
            
            (Option<string>, Option<Arr<T.ShippingOption>>) CmpTuple =>
                (Id, ShippingOptions);

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

            public override string ToString() => $"(Id: {Id}, ShippingOptions: {ShippingOptions})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Id) | MaskBit(1, ShippingOptions), bw, WriteInt);
                Write(Id, bw, WriteOption<string>(WriteString));
                Write(ShippingOptions, bw, WriteOption<Arr<T.ShippingOption>>(WriteVector<T.ShippingOption>(WriteSerializable)));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadOption(flags, 0, ReadString));
                var shippingOptions = Read(br, ReadOption(flags, 1, ReadVector(T.ShippingOption.Deserialize)));
                return new Tag(id, shippingOptions);
            }
        }

        readonly ITlTypeTag _tag;
        ValidatedRequestedInfo(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ValidatedRequestedInfo(Tag tag) => new ValidatedRequestedInfo(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ValidatedRequestedInfo Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ValidatedRequestedInfo) Tag.DeserializeTag(br);
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

        public bool Equals(ValidatedRequestedInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ValidatedRequestedInfo x && Equals(x);
        public static bool operator ==(ValidatedRequestedInfo x, ValidatedRequestedInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ValidatedRequestedInfo x, ValidatedRequestedInfo y) => !(x == y);

        public int CompareTo(ValidatedRequestedInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ValidatedRequestedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ValidatedRequestedInfo x, ValidatedRequestedInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(ValidatedRequestedInfo x, ValidatedRequestedInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(ValidatedRequestedInfo x, ValidatedRequestedInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(ValidatedRequestedInfo x, ValidatedRequestedInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ValidatedRequestedInfo.{_tag.GetType().Name}{_tag}";
    }
}