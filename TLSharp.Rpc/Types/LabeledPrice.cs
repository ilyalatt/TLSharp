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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xcb296bf8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Label { get; }
            public long Amount { get; }
            
            public Tag(
                Some<string> label,
                long amount
            ) {
                Label = label;
                Amount = amount;
            }
            
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

        public bool Equals(LabeledPrice other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is LabeledPrice x && Equals(x);
        public static bool operator ==(LabeledPrice a, LabeledPrice b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(LabeledPrice a, LabeledPrice b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(LabeledPrice other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is LabeledPrice x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LabeledPrice a, LabeledPrice b) => a.CompareTo(b) <= 0;
        public static bool operator <(LabeledPrice a, LabeledPrice b) => a.CompareTo(b) < 0;
        public static bool operator >(LabeledPrice a, LabeledPrice b) => a.CompareTo(b) > 0;
        public static bool operator >=(LabeledPrice a, LabeledPrice b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}