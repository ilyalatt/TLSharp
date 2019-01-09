using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PaymentCharge : ITlType, IEquatable<PaymentCharge>, IComparable<PaymentCharge>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xea02c27e;
            
            public string Id { get; }
            public string ProviderChargeId { get; }
            
            public Tag(
                Some<string> id,
                Some<string> providerChargeId
            ) {
                Id = id;
                ProviderChargeId = providerChargeId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteString);
                Write(ProviderChargeId, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadString);
                var providerChargeId = Read(br, ReadString);
                return new Tag(id, providerChargeId);
            }
        }

        readonly ITlTypeTag _tag;
        PaymentCharge(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PaymentCharge(Tag tag) => new PaymentCharge(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PaymentCharge Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xea02c27e: return (PaymentCharge) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xea02c27e });
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

        public bool Equals(PaymentCharge other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PaymentCharge x && Equals(x);
        public static bool operator ==(PaymentCharge a, PaymentCharge b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PaymentCharge a, PaymentCharge b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PaymentCharge other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentCharge x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentCharge a, PaymentCharge b) => a.CompareTo(b) <= 0;
        public static bool operator <(PaymentCharge a, PaymentCharge b) => a.CompareTo(b) < 0;
        public static bool operator >(PaymentCharge a, PaymentCharge b) => a.CompareTo(b) > 0;
        public static bool operator >=(PaymentCharge a, PaymentCharge b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}