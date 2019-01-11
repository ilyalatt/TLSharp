using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Payments
{
    public sealed class PaymentResult : ITlType, IEquatable<PaymentResult>, IComparable<PaymentResult>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x4e5f810d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.UpdatesType Updates { get; }
            
            public Tag(
                Some<T.UpdatesType> updates
            ) {
                Updates = updates;
            }
            
            T.UpdatesType CmpTuple =>
                Updates;

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

            public override string ToString() => $"(Updates: {Updates})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Updates, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var updates = Read(br, T.UpdatesType.Deserialize);
                return new Tag(updates);
            }
        }

        public sealed class VerficationNeededTag : ITlTypeTag, IEquatable<VerficationNeededTag>, IComparable<VerficationNeededTag>, IComparable
        {
            internal const uint TypeNumber = 0x6b56b921;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            
            public VerficationNeededTag(
                Some<string> url
            ) {
                Url = url;
            }
            
            string CmpTuple =>
                Url;

            public bool Equals(VerficationNeededTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is VerficationNeededTag x && Equals(x);
            public static bool operator ==(VerficationNeededTag x, VerficationNeededTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(VerficationNeededTag x, VerficationNeededTag y) => !(x == y);

            public int CompareTo(VerficationNeededTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is VerficationNeededTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(VerficationNeededTag x, VerficationNeededTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(VerficationNeededTag x, VerficationNeededTag y) => x.CompareTo(y) < 0;
            public static bool operator >(VerficationNeededTag x, VerficationNeededTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(VerficationNeededTag x, VerficationNeededTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
            }
            
            internal static VerficationNeededTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                return new VerficationNeededTag(url);
            }
        }

        readonly ITlTypeTag _tag;
        PaymentResult(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PaymentResult(Tag tag) => new PaymentResult(tag);
        public static explicit operator PaymentResult(VerficationNeededTag tag) => new PaymentResult(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PaymentResult Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PaymentResult) Tag.DeserializeTag(br);
                case VerficationNeededTag.TypeNumber: return (PaymentResult) VerficationNeededTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, VerficationNeededTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<VerficationNeededTag, T> verficationNeededTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case VerficationNeededTag x when verficationNeededTag != null: return verficationNeededTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<VerficationNeededTag, T> verficationNeededTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            verficationNeededTag ?? throw new ArgumentNullException(nameof(verficationNeededTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case VerficationNeededTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(PaymentResult other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PaymentResult x && Equals(x);
        public static bool operator ==(PaymentResult x, PaymentResult y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PaymentResult x, PaymentResult y) => !(x == y);

        public int CompareTo(PaymentResult other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentResult x, PaymentResult y) => x.CompareTo(y) <= 0;
        public static bool operator <(PaymentResult x, PaymentResult y) => x.CompareTo(y) < 0;
        public static bool operator >(PaymentResult x, PaymentResult y) => x.CompareTo(y) > 0;
        public static bool operator >=(PaymentResult x, PaymentResult y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PaymentResult.{_tag.GetType().Name}{_tag}";
    }
}