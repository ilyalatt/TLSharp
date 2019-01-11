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
        
        public GetParticipants(
            Some<T.InputChannel> channel,
            Some<T.ChannelParticipantsFilter> filter,
            int offset,
            int limit
        ) {
            Channel = channel;
            Filter = filter;
            Offset = offset;
            Limit = limit;
        }
        
        
        (T.InputChannel, T.ChannelParticipantsFilter, int, int) CmpTuple =>
            (Channel, Filter, Offset, Limit);

        public bool Equals(GetParticipants other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetParticipants x && Equals(x);
        public static bool operator ==(GetParticipants x, GetParticipants y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetParticipants x, GetParticipants y) => !(x == y);

        public int CompareTo(GetParticipants other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetParticipants x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetParticipants x, GetParticipants y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetParticipants x, GetParticipants y) => x.CompareTo(y) < 0;
        public static bool operator >(GetParticipants x, GetParticipants y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetParticipants x, GetParticipants y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Filter: {Filter}, Offset: {Offset}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x24d98f92);
            Write(Channel, bw, WriteSerializable);
            Write(Filter, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Channels.ChannelParticipants ITlFunc<T.Channels.ChannelParticipants>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Channels.ChannelParticipants.Deserialize);
    }
}