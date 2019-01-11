using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class GetPaymentForm : ITlFunc<T.Payments.PaymentForm>, IEquatable<GetPaymentForm>, IComparable<GetPaymentForm>, IComparable
    {
        public int MsgId { get; }
        
        public GetPaymentForm(
            int msgId
        ) {
            MsgId = msgId;
        }
        
        
        int CmpTuple =>
            MsgId;

        public bool Equals(GetPaymentForm other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetPaymentForm x && Equals(x);
        public static bool operator ==(GetPaymentForm x, GetPaymentForm y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPaymentForm x, GetPaymentForm y) => !(x == y);

        public int CompareTo(GetPaymentForm other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetPaymentForm x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPaymentForm x, GetPaymentForm y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPaymentForm x, GetPaymentForm y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPaymentForm x, GetPaymentForm y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPaymentForm x, GetPaymentForm y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(MsgId: {MsgId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x99f09745);
            Write(MsgId, bw, WriteInt);
        }
        
        T.Payments.PaymentForm ITlFunc<T.Payments.PaymentForm>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.PaymentForm.Deserialize);
    }
}