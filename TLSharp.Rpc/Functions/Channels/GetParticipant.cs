using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetParticipant : ITlFunc<T.Channels.ChannelParticipant>, IEquatable<GetParticipant>, IComparable<GetParticipant>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        
        public GetParticipant(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId
        ) {
            Channel = channel;
            UserId = userId;
        }
        
        
        (T.InputChannel, T.InputUser) CmpTuple =>
            (Channel, UserId);

        public bool Equals(GetParticipant other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetParticipant x && Equals(x);
        public static bool operator ==(GetParticipant x, GetParticipant y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetParticipant x, GetParticipant y) => !(x == y);

        public int CompareTo(GetParticipant other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetParticipant x, GetParticipant y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetParticipant x, GetParticipant y) => x.CompareTo(y) < 0;
        public static bool operator >(GetParticipant x, GetParticipant y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetParticipant x, GetParticipant y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x546dd7a6);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Channels.ChannelParticipant ITlFunc<T.Channels.ChannelParticipant>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Channels.ChannelParticipant.Deserialize);
    }
}