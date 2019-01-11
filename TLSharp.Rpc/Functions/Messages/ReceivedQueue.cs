using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReceivedQueue : ITlFunc<Arr<long>>, IEquatable<ReceivedQueue>, IComparable<ReceivedQueue>, IComparable
    {
        public int MaxQts { get; }
        
        public ReceivedQueue(
            int maxQts
        ) {
            MaxQts = maxQts;
        }
        
        
        int CmpTuple =>
            MaxQts;

        public bool Equals(ReceivedQueue other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReceivedQueue x && Equals(x);
        public static bool operator ==(ReceivedQueue x, ReceivedQueue y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReceivedQueue x, ReceivedQueue y) => !(x == y);

        public int CompareTo(ReceivedQueue other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReceivedQueue x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReceivedQueue x, ReceivedQueue y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReceivedQueue x, ReceivedQueue y) => x.CompareTo(y) < 0;
        public static bool operator >(ReceivedQueue x, ReceivedQueue y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReceivedQueue x, ReceivedQueue y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(MaxQts: {MaxQts})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x55a5bb66);
            Write(MaxQts, bw, WriteInt);
        }
        
        Arr<long> ITlFunc<Arr<long>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadLong));
    }
}