using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class GetPaymentReceipt : ITlFunc<T.Payments.PaymentReceipt>, IEquatable<GetPaymentReceipt>, IComparable<GetPaymentReceipt>, IComparable
    {
        public int MsgId { get; }
        
        public GetPaymentReceipt(
            int msgId
        ) {
            MsgId = msgId;
        }
        
        
        int CmpTuple =>
            MsgId;

        public bool Equals(GetPaymentReceipt other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetPaymentReceipt x && Equals(x);
        public static bool operator ==(GetPaymentReceipt x, GetPaymentReceipt y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPaymentReceipt x, GetPaymentReceipt y) => !(x == y);

        public int CompareTo(GetPaymentReceipt other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetPaymentReceipt x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPaymentReceipt x, GetPaymentReceipt y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPaymentReceipt x, GetPaymentReceipt y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPaymentReceipt x, GetPaymentReceipt y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPaymentReceipt x, GetPaymentReceipt y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(MsgId: {MsgId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa092a980);
            Write(MsgId, bw, WriteInt);
        }
        
        T.Payments.PaymentReceipt ITlFunc<T.Payments.PaymentReceipt>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.PaymentReceipt.Deserialize);
    }
}