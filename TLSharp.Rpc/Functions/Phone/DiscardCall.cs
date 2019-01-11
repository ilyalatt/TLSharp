using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class DiscardCall : ITlFunc<T.UpdatesType>, IEquatable<DiscardCall>, IComparable<DiscardCall>, IComparable
    {
        public T.InputPhoneCall Peer { get; }
        public int Duration { get; }
        public T.PhoneCallDiscardReason Reason { get; }
        public long ConnectionId { get; }
        
        public DiscardCall(
            Some<T.InputPhoneCall> peer,
            int duration,
            Some<T.PhoneCallDiscardReason> reason,
            long connectionId
        ) {
            Peer = peer;
            Duration = duration;
            Reason = reason;
            ConnectionId = connectionId;
        }
        
        
        (T.InputPhoneCall, int, T.PhoneCallDiscardReason, long) CmpTuple =>
            (Peer, Duration, Reason, ConnectionId);

        public bool Equals(DiscardCall other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DiscardCall x && Equals(x);
        public static bool operator ==(DiscardCall x, DiscardCall y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DiscardCall x, DiscardCall y) => !(x == y);

        public int CompareTo(DiscardCall other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DiscardCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DiscardCall x, DiscardCall y) => x.CompareTo(y) <= 0;
        public static bool operator <(DiscardCall x, DiscardCall y) => x.CompareTo(y) < 0;
        public static bool operator >(DiscardCall x, DiscardCall y) => x.CompareTo(y) > 0;
        public static bool operator >=(DiscardCall x, DiscardCall y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Duration: {Duration}, Reason: {Reason}, ConnectionId: {ConnectionId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x78d413a6);
            Write(Peer, bw, WriteSerializable);
            Write(Duration, bw, WriteInt);
            Write(Reason, bw, WriteSerializable);
            Write(ConnectionId, bw, WriteLong);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}