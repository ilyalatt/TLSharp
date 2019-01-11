using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class SendPaymentForm : ITlFunc<T.Payments.PaymentResult>, IEquatable<SendPaymentForm>, IComparable<SendPaymentForm>, IComparable
    {
        public int MsgId { get; }
        public Option<string> RequestedInfoId { get; }
        public Option<string> ShippingOptionId { get; }
        public T.InputPaymentCredentials Credentials { get; }
        
        public SendPaymentForm(
            int msgId,
            Option<string> requestedInfoId,
            Option<string> shippingOptionId,
            Some<T.InputPaymentCredentials> credentials
        ) {
            MsgId = msgId;
            RequestedInfoId = requestedInfoId;
            ShippingOptionId = shippingOptionId;
            Credentials = credentials;
        }
        
        
        (int, Option<string>, Option<string>, T.InputPaymentCredentials) CmpTuple =>
            (MsgId, RequestedInfoId, ShippingOptionId, Credentials);

        public bool Equals(SendPaymentForm other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendPaymentForm x && Equals(x);
        public static bool operator ==(SendPaymentForm x, SendPaymentForm y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendPaymentForm x, SendPaymentForm y) => !(x == y);

        public int CompareTo(SendPaymentForm other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendPaymentForm x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendPaymentForm x, SendPaymentForm y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendPaymentForm x, SendPaymentForm y) => x.CompareTo(y) < 0;
        public static bool operator >(SendPaymentForm x, SendPaymentForm y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendPaymentForm x, SendPaymentForm y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(MsgId: {MsgId}, RequestedInfoId: {RequestedInfoId}, ShippingOptionId: {ShippingOptionId}, Credentials: {Credentials})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2b8879b3);
            Write(MaskBit(0, RequestedInfoId) | MaskBit(1, ShippingOptionId), bw, WriteInt);
            Write(MsgId, bw, WriteInt);
            Write(RequestedInfoId, bw, WriteOption<string>(WriteString));
            Write(ShippingOptionId, bw, WriteOption<string>(WriteString));
            Write(Credentials, bw, WriteSerializable);
        }
        
        T.Payments.PaymentResult ITlFunc<T.Payments.PaymentResult>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.PaymentResult.Deserialize);
    }
}