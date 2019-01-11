using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class FinishTakeoutSession : ITlFunc<bool>, IEquatable<FinishTakeoutSession>, IComparable<FinishTakeoutSession>, IComparable
    {
        public bool Success { get; }
        
        public FinishTakeoutSession(
            bool success
        ) {
            Success = success;
        }
        
        
        bool CmpTuple =>
            Success;

        public bool Equals(FinishTakeoutSession other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is FinishTakeoutSession x && Equals(x);
        public static bool operator ==(FinishTakeoutSession x, FinishTakeoutSession y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FinishTakeoutSession x, FinishTakeoutSession y) => !(x == y);

        public int CompareTo(FinishTakeoutSession other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is FinishTakeoutSession x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FinishTakeoutSession x, FinishTakeoutSession y) => x.CompareTo(y) <= 0;
        public static bool operator <(FinishTakeoutSession x, FinishTakeoutSession y) => x.CompareTo(y) < 0;
        public static bool operator >(FinishTakeoutSession x, FinishTakeoutSession y) => x.CompareTo(y) > 0;
        public static bool operator >=(FinishTakeoutSession x, FinishTakeoutSession y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Success: {Success})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1d2652ee);
            Write(MaskBit(0, Success), bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}