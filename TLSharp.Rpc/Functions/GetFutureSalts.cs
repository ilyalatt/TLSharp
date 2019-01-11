using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class GetFutureSalts : ITlFunc<T.FutureSalts>, IEquatable<GetFutureSalts>, IComparable<GetFutureSalts>, IComparable
    {
        public int Num { get; }
        
        public GetFutureSalts(
            int num
        ) {
            Num = num;
        }
        
        
        int CmpTuple =>
            Num;

        public bool Equals(GetFutureSalts other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetFutureSalts x && Equals(x);
        public static bool operator ==(GetFutureSalts x, GetFutureSalts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFutureSalts x, GetFutureSalts y) => !(x == y);

        public int CompareTo(GetFutureSalts other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetFutureSalts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFutureSalts x, GetFutureSalts y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFutureSalts x, GetFutureSalts y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFutureSalts x, GetFutureSalts y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFutureSalts x, GetFutureSalts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Num: {Num})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb921bd04);
            Write(Num, bw, WriteInt);
        }
        
        T.FutureSalts ITlFunc<T.FutureSalts>.DeserializeResult(BinaryReader br) =>
            Read(br, T.FutureSalts.Deserialize);
    }
}