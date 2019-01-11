using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class ValidateRequestedInfo : ITlFunc<T.Payments.ValidatedRequestedInfo>, IEquatable<ValidateRequestedInfo>, IComparable<ValidateRequestedInfo>, IComparable
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
        
        
        (bool, int, T.PaymentRequestedInfo) CmpTuple =>
            (Save, MsgId, Info);

        public bool Equals(ValidateRequestedInfo other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ValidateRequestedInfo x && Equals(x);
        public static bool operator ==(ValidateRequestedInfo x, ValidateRequestedInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ValidateRequestedInfo x, ValidateRequestedInfo y) => !(x == y);

        public int CompareTo(ValidateRequestedInfo other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ValidateRequestedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ValidateRequestedInfo x, ValidateRequestedInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(ValidateRequestedInfo x, ValidateRequestedInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(ValidateRequestedInfo x, ValidateRequestedInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(ValidateRequestedInfo x, ValidateRequestedInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Save: {Save}, MsgId: {MsgId}, Info: {Info})";
        
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