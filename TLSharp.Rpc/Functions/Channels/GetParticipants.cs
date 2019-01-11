using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetParticipants : ITlFunc<T.Channels.ChannelParticipants>, IEquatable<GetParticipants>, IComparable<GetParticipants>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.ChannelParticipantsFilter Filter { get; }
        public int Offset { get; }
        public int Limit { get; }
        public int Hash { get; }
        
        public GetParticipants(
            Some<T.InputChannel> channel,
            Some<T.ChannelParticipantsFilter> filter,
            int offset,
            int limit,
            int hash
        ) {
            Channel = channel;
            Filter = filter;
            Offset = offset;
            Limit = limit;
            Hash = hash;
        }
        
        
        (T.InputChannel, T.ChannelParticipantsFilter, int, int, int) CmpTuple =>
            (Channel, Filter, Offset, Limit, Hash);

        public bool Equals(GetParticipants other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetParticipants x && Equals(x);
        public static bool operator ==(GetParticipants x, GetParticipants y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetParticipants x, GetParticipants y) => !(x == y);

        public int CompareTo(GetParticipants other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetParticipants x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetParticipants x, GetParticipants y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetParticipants x, GetParticipants y) => x.CompareTo(y) < 0;
        public static bool operator >(GetParticipants x, GetParticipants y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetParticipants x, GetParticipants y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Filter: {Filter}, Offset: {Offset}, Limit: {Limit}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x123e05e9);
            Write(Channel, bw, WriteSerializable);
            Write(Filter, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Channels.ChannelParticipants ITlFunc<T.Channels.ChannelParticipants>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Channels.ChannelParticipants.Deserialize);
    }
}