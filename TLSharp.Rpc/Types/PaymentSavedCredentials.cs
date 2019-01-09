using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PaymentSavedCredentials : ITlType, IEquatable<PaymentSavedCredentials>, IComparable<PaymentSavedCredentials>, IComparable
    {
        public sealed class CardTag : Record<CardTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xcdc27a1f;
            
            public string Id { get; }
            public string Title { get; }
            
            public CardTag(
                Some<string> id,
                Some<string> title
            ) {
                Id = id;
                Title = title;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteString);
                Write(Title, bw, WriteString);
            }
            
            internal static CardTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadString);
                var title = Read(br, ReadString);
                return new CardTag(id, title);
            }
        }

        readonly ITlTypeTag _tag;
        PaymentSavedCredentials(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PaymentSavedCredentials(CardTag tag) => new PaymentSavedCredentials(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PaymentSavedCredentials Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xcdc27a1f: return (PaymentSavedCredentials) CardTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xcdc27a1f });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<CardTag, T> cardTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case CardTag x when cardTag != null: return cardTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<CardTag, T> cardTag
        ) => Match(
            () => throw new Exception("WTF"),
            cardTag ?? throw new ArgumentNullException(nameof(cardTag))
        );

        public bool Equals(PaymentSavedCredentials other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PaymentSavedCredentials x && Equals(x);
        public static bool operator ==(PaymentSavedCredentials a, PaymentSavedCredentials b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PaymentSavedCredentials a, PaymentSavedCredentials b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case CardTag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PaymentSavedCredentials other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentSavedCredentials x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentSavedCredentials a, PaymentSavedCredentials b) => a.CompareTo(b) <= 0;
        public static bool operator <(PaymentSavedCredentials a, PaymentSavedCredentials b) => a.CompareTo(b) < 0;
        public static bool operator >(PaymentSavedCredentials a, PaymentSavedCredentials b) => a.CompareTo(b) > 0;
        public static bool operator >=(PaymentSavedCredentials a, PaymentSavedCredentials b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}