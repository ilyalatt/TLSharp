using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class ValidateRequestedInfo : Record<ValidateRequestedInfo>, ITlFunc<T.Payments.ValidatedRequestedInfo>
    {
        public bool Save { get; }
        public int MsgId { get; }
        public T.PaymentRequestedInfo Info { get; }
        
        public ValidateRequestedInfo(
            bool save,
            int msgId,
            Some<T.PaymentRequestedInfo> info
        ) {
            Save = save;
            MsgId = msgId;
            Info = info;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x770a8e74);
            Write(MaskBit(0, Save), bw, WriteInt);
            Write(MsgId, bw, WriteInt);
            Write(Info, bw, WriteSerializable);
        }
        
        T.Payments.ValidatedRequestedInfo ITlFunc<T.Payments.ValidatedRequestedInfo>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.ValidatedRequestedInfo.Deserialize);
    }
}