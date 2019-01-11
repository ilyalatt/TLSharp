using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class LabeledPrice : ITlType, IEquatable<LabeledPrice>, IComparable<LabeledPrice>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xcb296bf8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Label;
            public readonly long Amount;
            
            public Tag(
                Some<string> label,
                long amount
            ) {
                Label = label;
                Amount = amount;
            }
            
            (string, long) CmpTuple =>
                (Label, Amount);

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

            public override string ToString() => $"(Label: {Label}, Amount: {Amount})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Label, bw, WriteString);
                Write(Amount, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var label = Read(br, ReadString);
                var amount = Read(br, ReadLong);
                return new Tag(label, amount);
            }
        }

        readonly ITlTypeTag _tag;
        LabeledPrice(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator LabeledPrice(Tag tag) => new LabeledPrice(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static LabeledPrice Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (LabeledPrice) Tag.DeserializeTag(br);
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

        public bool Equals(LabeledPrice other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is LabeledPrice x && Equals(x);
        public static bool operator ==(LabeledPrice x, LabeledPrice y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(LabeledPrice x, LabeledPrice y) => !(x == y);

        public int CompareTo(LabeledPrice other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is LabeledPrice x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LabeledPrice x, LabeledPrice y) => x.CompareTo(y) <= 0;
        public static bool operator <(LabeledPrice x, LabeledPrice y) => x.CompareTo(y) < 0;
        public static bool operator >(LabeledPrice x, LabeledPrice y) => x.CompareTo(y) > 0;
        public static bool operator >=(LabeledPrice x, LabeledPrice y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"LabeledPrice.{_tag.GetType().Name}{_tag}";
    }
}