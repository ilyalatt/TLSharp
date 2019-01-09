using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class GetPaymentForm : Record<GetPaymentForm>, ITlFunc<T.Payments.PaymentForm>
    {
        public int MsgId { get; }
        
        public GetPaymentForm(
            int msgId
        ) {
            MsgId = msgId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x99f09745);
            Write(MsgId, bw, WriteInt);
        }
        
        T.Payments.PaymentForm ITlFunc<T.Payments.PaymentForm>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.PaymentForm.Deserialize);
    }
}