using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class SendPaymentForm : Record<SendPaymentForm>, ITlFunc<T.Payments.PaymentResult>
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