using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Updates
{
    public sealed class GetChannelDifference : ITlFunc<T.Updates.ChannelDifference>, IEquatable<GetChannelDifference>, IComparable<GetChannelDifference>, IComparable
    {
        public bool Force { get; }
        public T.InputChannel Channel { get; }
        public T.ChannelMessagesFilter Filter { get; }
        public int Pts { get; }
        public int Limit { get; }
        
        public GetChannelDifference(
            bool force,
            Some<T.InputChannel> channel,
            Some<T.ChannelMessagesFilter> filter,
            int pts,
            int limit
        ) {
            Force = force;
            Channel = channel;
            Filter = filter;
            Pts = pts;
            Limit = limit;
        }
        
        
        (bool, T.InputChannel, T.ChannelMessagesFilter, int, int) CmpTuple =>
            (Force, Channel, Filter, Pts, Limit);

        public bool Equals(GetChannelDifference other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetChannelDifference x && Equals(x);
        public static bool operator ==(GetChannelDifference x, GetChannelDifference y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetChannelDifference x, GetChannelDifference y) => !(x == y);

        public int CompareTo(GetChannelDifference other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetChannelDifference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetChannelDifference x, GetChannelDifference y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetChannelDifference x, GetChannelDifference y) => x.CompareTo(y) < 0;
        public static bool operator >(GetChannelDifference x, GetChannelDifference y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetChannelDifference x, GetChannelDifference y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Force: {Force}, Channel: {Channel}, Filter: {Filter}, Pts: {Pts}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x03173d78);
            Write(MaskBit(0, Force), bw, WriteInt);
            Write(Channel, bw, WriteSerializable);
            Write(Filter, bw, WriteSerializable);
            Write(Pts, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Updates.ChannelDifference ITlFunc<T.Updates.ChannelDifference>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Updates.ChannelDifference.Deserialize);
    }
}