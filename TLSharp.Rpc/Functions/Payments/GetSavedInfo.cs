using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class GetSavedInfo : ITlFunc<T.Payments.SavedInfo>, IEquatable<GetSavedInfo>, IComparable<GetSavedInfo>, IComparable
    {

        
        public GetSavedInfo(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetSavedInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetSavedInfo x && Equals(x);
        public static bool operator ==(GetSavedInfo x, GetSavedInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetSavedInfo x, GetSavedInfo y) => !(x == y);

        public int CompareTo(GetSavedInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetSavedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetSavedInfo x, GetSavedInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetSavedInfo x, GetSavedInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(GetSavedInfo x, GetSavedInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetSavedInfo x, GetSavedInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x227d824b);

        }
        
        T.Payments.SavedInfo ITlFunc<T.Payments.SavedInfo>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.SavedInfo.Deserialize);
    }
}