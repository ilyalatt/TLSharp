using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class PingDelayDisconnect : ITlFunc<T.Pong>, IEquatable<PingDelayDisconnect>, IComparable<PingDelayDisconnect>, IComparable
    {
        public long PingId { get; }
        public int DisconnectDelay { get; }
        
        public PingDelayDisconnect(
            long pingId,
            int disconnectDelay
        ) {
            PingId = pingId;
            DisconnectDelay = disconnectDelay;
        }
        
        
        (long, int) CmpTuple =>
            (PingId, DisconnectDelay);

        public bool Equals(PingDelayDisconnect other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is PingDelayDisconnect x && Equals(x);
        public static bool operator ==(PingDelayDisconnect x, PingDelayDisconnect y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PingDelayDisconnect x, PingDelayDisconnect y) => !(x == y);

        public int CompareTo(PingDelayDisconnect other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PingDelayDisconnect x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PingDelayDisconnect x, PingDelayDisconnect y) => x.CompareTo(y) <= 0;
        public static bool operator <(PingDelayDisconnect x, PingDelayDisconnect y) => x.CompareTo(y) < 0;
        public static bool operator >(PingDelayDisconnect x, PingDelayDisconnect y) => x.CompareTo(y) > 0;
        public static bool operator >=(PingDelayDisconnect x, PingDelayDisconnect y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PingId: {PingId}, DisconnectDelay: {DisconnectDelay})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf3427b8c);
            Write(PingId, bw, WriteLong);
            Write(DisconnectDelay, bw, WriteInt);
        }
        
        T.Pong ITlFunc<T.Pong>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Pong.Deserialize);
    }
}