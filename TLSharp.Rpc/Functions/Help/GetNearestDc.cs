using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetNearestDc : ITlFunc<T.NearestDc>, IEquatable<GetNearestDc>, IComparable<GetNearestDc>, IComparable
    {

        
        public GetNearestDc(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetNearestDc other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetNearestDc x && Equals(x);
        public static bool operator ==(GetNearestDc x, GetNearestDc y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetNearestDc x, GetNearestDc y) => !(x == y);

        public int CompareTo(GetNearestDc other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetNearestDc x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetNearestDc x, GetNearestDc y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetNearestDc x, GetNearestDc y) => x.CompareTo(y) < 0;
        public static bool operator >(GetNearestDc x, GetNearestDc y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetNearestDc x, GetNearestDc y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1fb33026);

        }
        
        T.NearestDc ITlFunc<T.NearestDc>.DeserializeResult(BinaryReader br) =>
            Read(br, T.NearestDc.Deserialize);
    }
}