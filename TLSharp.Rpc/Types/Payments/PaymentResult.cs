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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x4e5f810d;
            
            public T.UpdatesType Updates { get; }
            
            public Tag(
                Some<T.UpdatesType> updates
            ) {
                Updates = updates;
            }
            
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

        public sealed class VerficationNeededTag : Record<VerficationNeededTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x6b56b921;
            
            public string Url { get; }
            
            public VerficationNeededTag(
                Some<string> url
            ) {
                Url = url;
            }
            
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
                case 0x4e5f810d: return (PaymentResult) Tag.DeserializeTag(br);
                case 0x6b56b921: return (PaymentResult) VerficationNeededTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x4e5f810d, 0x6b56b921 });
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

        public bool Equals(PaymentResult other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PaymentResult x && Equals(x);
        public static bool operator ==(PaymentResult a, PaymentResult b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PaymentResult a, PaymentResult b) => !(a == b);

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

        public int CompareTo(PaymentResult other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentResult a, PaymentResult b) => a.CompareTo(b) <= 0;
        public static bool operator <(PaymentResult a, PaymentResult b) => a.CompareTo(b) < 0;
        public static bool operator >(PaymentResult a, PaymentResult b) => a.CompareTo(b) > 0;
        public static bool operator >=(PaymentResult a, PaymentResult b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}