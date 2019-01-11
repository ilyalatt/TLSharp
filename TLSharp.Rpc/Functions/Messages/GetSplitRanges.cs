using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetSplitRanges : ITlFunc<Arr<T.MessageRange>>, IEquatable<GetSplitRanges>, IComparable<GetSplitRanges>, IComparable
    {

        
        public GetSplitRanges(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetSplitRanges other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetSplitRanges x && Equals(x);
        public static bool operator ==(GetSplitRanges x, GetSplitRanges y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetSplitRanges x, GetSplitRanges y) => !(x == y);

        public int CompareTo(GetSplitRanges other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetSplitRanges x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetSplitRanges x, GetSplitRanges y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetSplitRanges x, GetSplitRanges y) => x.CompareTo(y) < 0;
        public static bool operator >(GetSplitRanges x, GetSplitRanges y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetSplitRanges x, GetSplitRanges y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1cff7e08);

        }
        
        Arr<T.MessageRange> ITlFunc<Arr<T.MessageRange>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.MessageRange.Deserialize));
    }
}