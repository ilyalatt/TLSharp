using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class Ping : ITlFunc<T.Pong>, IEquatable<Ping>, IComparable<Ping>, IComparable
    {
        public long PingId { get; }
        
        public Ping(
            long pingId
        ) {
            PingId = pingId;
        }
        
        
        long CmpTuple =>
            PingId;

        public bool Equals(Ping other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is Ping x && Equals(x);
        public static bool operator ==(Ping x, Ping y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Ping x, Ping y) => !(x == y);

        public int CompareTo(Ping other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Ping x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Ping x, Ping y) => x.CompareTo(y) <= 0;
        public static bool operator <(Ping x, Ping y) => x.CompareTo(y) < 0;
        public static bool operator >(Ping x, Ping y) => x.CompareTo(y) > 0;
        public static bool operator >=(Ping x, Ping y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PingId: {PingId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7abe77ec);
            Write(PingId, bw, WriteLong);
        }
        
        T.Pong ITlFunc<T.Pong>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Pong.Deserialize);
    }
}