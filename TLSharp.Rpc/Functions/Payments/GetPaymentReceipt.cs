using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class GetPaymentReceipt : Record<GetPaymentReceipt>, ITlFunc<T.Payments.PaymentReceipt>
    {
        public int MsgId { get; }
        
        public GetPaymentReceipt(
            int msgId
        ) {
            MsgId = msgId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa092a980);
            Write(MsgId, bw, WriteInt);
        }
        
        T.Payments.PaymentReceipt ITlFunc<T.Payments.PaymentReceipt>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.PaymentReceipt.Deserialize);
    }
}