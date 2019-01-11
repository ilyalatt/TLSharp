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
        public sealed class CardTag : ITlTypeTag, IEquatable<CardTag>, IComparable<CardTag>, IComparable
        {
            internal const uint TypeNumber = 0xcdc27a1f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string Title { get; }
            
            public CardTag(
                Some<string> id,
                Some<string> title
            ) {
                Id = id;
                Title = title;
            }
            
            (string, string) CmpTuple =>
                (Id, Title);

            public bool Equals(CardTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CardTag x && Equals(x);
            public static bool operator ==(CardTag x, CardTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CardTag x, CardTag y) => !(x == y);

            public int CompareTo(CardTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is CardTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CardTag x, CardTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CardTag x, CardTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CardTag x, CardTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CardTag x, CardTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Title: {Title})";
            
            
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
                case CardTag.TypeNumber: return (PaymentSavedCredentials) CardTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { CardTag.TypeNumber });
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case CardTag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(PaymentSavedCredentials other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PaymentSavedCredentials x && Equals(x);
        public static bool operator ==(PaymentSavedCredentials x, PaymentSavedCredentials y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PaymentSavedCredentials x, PaymentSavedCredentials y) => !(x == y);

        public int CompareTo(PaymentSavedCredentials other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentSavedCredentials x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentSavedCredentials x, PaymentSavedCredentials y) => x.CompareTo(y) <= 0;
        public static bool operator <(PaymentSavedCredentials x, PaymentSavedCredentials y) => x.CompareTo(y) < 0;
        public static bool operator >(PaymentSavedCredentials x, PaymentSavedCredentials y) => x.CompareTo(y) > 0;
        public static bool operator >=(PaymentSavedCredentials x, PaymentSavedCredentials y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PaymentSavedCredentials.{_tag.GetType().Name}{_tag}";
    }
}