using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class DropTempAuthKeys : ITlFunc<bool>, IEquatable<DropTempAuthKeys>, IComparable<DropTempAuthKeys>, IComparable
    {
        public Arr<long> ExceptAuthKeys { get; }
        
        public DropTempAuthKeys(
            Some<Arr<long>> exceptAuthKeys
        ) {
            ExceptAuthKeys = exceptAuthKeys;
        }
        
        
        Arr<long> CmpTuple =>
            ExceptAuthKeys;

        public bool Equals(DropTempAuthKeys other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is DropTempAuthKeys x && Equals(x);
        public static bool operator ==(DropTempAuthKeys x, DropTempAuthKeys y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DropTempAuthKeys x, DropTempAuthKeys y) => !(x == y);

        public int CompareTo(DropTempAuthKeys other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DropTempAuthKeys x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DropTempAuthKeys x, DropTempAuthKeys y) => x.CompareTo(y) <= 0;
        public static bool operator <(DropTempAuthKeys x, DropTempAuthKeys y) => x.CompareTo(y) < 0;
        public static bool operator >(DropTempAuthKeys x, DropTempAuthKeys y) => x.CompareTo(y) > 0;
        public static bool operator >=(DropTempAuthKeys x, DropTempAuthKeys y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ExceptAuthKeys: {ExceptAuthKeys})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8e48a188);
            Write(ExceptAuthKeys, bw, WriteVector<long>(WriteLong));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}