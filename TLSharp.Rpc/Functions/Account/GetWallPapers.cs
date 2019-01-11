using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetWallPapers : ITlFunc<Arr<T.WallPaper>>, IEquatable<GetWallPapers>, IComparable<GetWallPapers>, IComparable
    {

        
        public GetWallPapers(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetWallPapers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetWallPapers x && Equals(x);
        public static bool operator ==(GetWallPapers x, GetWallPapers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetWallPapers x, GetWallPapers y) => !(x == y);

        public int CompareTo(GetWallPapers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetWallPapers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetWallPapers x, GetWallPapers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetWallPapers x, GetWallPapers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetWallPapers x, GetWallPapers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetWallPapers x, GetWallPapers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc04cfac2);

        }
        
        Arr<T.WallPaper> ITlFunc<Arr<T.WallPaper>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.WallPaper.Deserialize));
    }
}