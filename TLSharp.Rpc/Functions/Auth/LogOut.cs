using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class LogOut : ITlFunc<bool>, IEquatable<LogOut>, IComparable<LogOut>, IComparable
    {

        
        public LogOut(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(LogOut other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is LogOut x && Equals(x);
        public static bool operator ==(LogOut x, LogOut y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(LogOut x, LogOut y) => !(x == y);

        public int CompareTo(LogOut other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is LogOut x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LogOut x, LogOut y) => x.CompareTo(y) <= 0;
        public static bool operator <(LogOut x, LogOut y) => x.CompareTo(y) < 0;
        public static bool operator >(LogOut x, LogOut y) => x.CompareTo(y) > 0;
        public static bool operator >=(LogOut x, LogOut y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5717da40);

        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}