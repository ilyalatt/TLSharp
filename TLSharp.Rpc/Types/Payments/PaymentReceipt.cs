using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Payments
{
    public sealed class PaymentReceipt : ITlType, IEquatable<PaymentReceipt>, IComparable<PaymentReceipt>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x500911e1;
            
            public int Date { get; }
            public int BotId { get; }
            public T.Invoice Invoice { get; }
            public int ProviderId { get; }
            public Option<T.PaymentRequestedInfo> Info { get; }
            public Option<T.ShippingOption> Shipping { get; }
            public string Currency { get; }
            public long TotalAmount { get; }
            public string CredentialsTitle { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                int date,
                int botId,
                Some<T.Invoice> invoice,
                int providerId,
                Option<T.PaymentRequestedInfo> info,
                Option<T.ShippingOption> shipping,
                Some<string> currency,
                long totalAmount,
                Some<string> credentialsTitle,
                Some<Arr<T.User>> users
            ) {
                Date = date;
                BotId = botId;
                Invoice = invoice;
                ProviderId = providerId;
                Info = info;
                Shipping = shipping;
                Currency = currency;
                TotalAmount = totalAmount;
                CredentialsTitle = credentialsTitle;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Info) | MaskBit(1, Shipping), bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(BotId, bw, WriteInt);
                Write(Invoice, bw, WriteSerializable);
                Write(ProviderId, bw, WriteInt);
                Write(Info, bw, WriteOption<T.PaymentRequestedInfo>(WriteSerializable));
                Write(Shipping, bw, WriteOption<T.ShippingOption>(WriteSerializable));
                Write(Currency, bw, WriteString);
                Write(TotalAmount, bw, WriteLong);
                Write(CredentialsTitle, bw, WriteString);
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var botId = Read(br, ReadInt);
                var invoice = Read(br, T.Invoice.Deserialize);
                var providerId = Read(br, ReadInt);
                var info = Read(br, ReadOption(flags, 0, T.PaymentRequestedInfo.Deserialize));
                var shipping = Read(br, ReadOption(flags, 1, T.ShippingOption.Deserialize));
                var currency = Read(br, ReadString);
                var totalAmount = Read(br, ReadLong);
                var credentialsTitle = Read(br, ReadString);
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(date, botId, invoice, providerId, info, shipping, currency, totalAmount, credentialsTitle, users);
            }
        }

        readonly ITlTypeTag _tag;
        PaymentReceipt(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PaymentReceipt(Tag tag) => new PaymentReceipt(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PaymentReceipt Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x500911e1: return (PaymentReceipt) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x500911e1 });
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

        public bool Equals(PaymentReceipt other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PaymentReceipt x && Equals(x);
        public static bool operator ==(PaymentReceipt a, PaymentReceipt b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PaymentReceipt a, PaymentReceipt b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PaymentReceipt other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PaymentReceipt x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PaymentReceipt a, PaymentReceipt b) => a.CompareTo(b) <= 0;
        public static bool operator <(PaymentReceipt a, PaymentReceipt b) => a.CompareTo(b) < 0;
        public static bool operator >(PaymentReceipt a, PaymentReceipt b) => a.CompareTo(b) > 0;
        public static bool operator >=(PaymentReceipt a, PaymentReceipt b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}