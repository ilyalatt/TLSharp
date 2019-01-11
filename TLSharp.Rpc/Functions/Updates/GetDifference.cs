using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Updates
{
    public sealed class GetDifference : ITlFunc<T.Updates.Difference>, IEquatable<GetDifference>, IComparable<GetDifference>, IComparable
    {
        public int Pts { get; }
        public Option<int> PtsTotalLimit { get; }
        public int Date { get; }
        public int Qts { get; }
        
        public GetDifference(
            int pts,
            Option<int> ptsTotalLimit,
            int date,
            int qts
        ) {
            Pts = pts;
            PtsTotalLimit = ptsTotalLimit;
            Date = date;
            Qts = qts;
        }
        
        
        (int, Option<int>, int, int) CmpTuple =>
            (Pts, PtsTotalLimit, Date, Qts);

        public bool Equals(GetDifference other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetDifference x && Equals(x);
        public static bool operator ==(GetDifference x, GetDifference y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDifference x, GetDifference y) => !(x == y);

        public int CompareTo(GetDifference other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetDifference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDifference x, GetDifference y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDifference x, GetDifference y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDifference x, GetDifference y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDifference x, GetDifference y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Pts: {Pts}, PtsTotalLimit: {PtsTotalLimit}, Date: {Date}, Qts: {Qts})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x25939651);
            Write(MaskBit(0, PtsTotalLimit), bw, WriteInt);
            Write(Pts, bw, WriteInt);
            Write(PtsTotalLimit, bw, WriteOption<int>(WriteInt));
            Write(Date, bw, WriteInt);
            Write(Qts, bw, WriteInt);
        }
        
        T.Updates.Difference ITlFunc<T.Updates.Difference>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Updates.Difference.Deserialize);
    }
}