using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetAdminLog : ITlFunc<T.Channels.AdminLogResults>, IEquatable<GetAdminLog>, IComparable<GetAdminLog>, IComparable
    {
        public T.InputChannel Channel { get; }
        public string Q { get; }
        public Option<T.ChannelAdminLogEventsFilter> EventsFilter { get; }
        public Option<Arr<T.InputUser>> Admins { get; }
        public long MaxId { get; }
        public long MinId { get; }
        public int Limit { get; }
        
        public GetAdminLog(
            Some<T.InputChannel> channel,
            Some<string> q,
            Option<T.ChannelAdminLogEventsFilter> eventsFilter,
            Option<Arr<T.InputUser>> admins,
            long maxId,
            long minId,
            int limit
        ) {
            Channel = channel;
            Q = q;
            EventsFilter = eventsFilter;
            Admins = admins;
            MaxId = maxId;
            MinId = minId;
            Limit = limit;
        }
        
        
        (T.InputChannel, string, Option<T.ChannelAdminLogEventsFilter>, Option<Arr<T.InputUser>>, long, long, int) CmpTuple =>
            (Channel, Q, EventsFilter, Admins, MaxId, MinId, Limit);

        public bool Equals(GetAdminLog other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetAdminLog x && Equals(x);
        public static bool operator ==(GetAdminLog x, GetAdminLog y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAdminLog x, GetAdminLog y) => !(x == y);

        public int CompareTo(GetAdminLog other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetAdminLog x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAdminLog x, GetAdminLog y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAdminLog x, GetAdminLog y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAdminLog x, GetAdminLog y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAdminLog x, GetAdminLog y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Q: {Q}, EventsFilter: {EventsFilter}, Admins: {Admins}, MaxId: {MaxId}, MinId: {MinId}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x33ddf480);
            Write(MaskBit(0, EventsFilter) | MaskBit(1, Admins), bw, WriteInt);
            Write(Channel, bw, WriteSerializable);
            Write(Q, bw, WriteString);
            Write(EventsFilter, bw, WriteOption<T.ChannelAdminLogEventsFilter>(WriteSerializable));
            Write(Admins, bw, WriteOption<Arr<T.InputUser>>(WriteVector<T.InputUser>(WriteSerializable)));
            Write(MaxId, bw, WriteLong);
            Write(MinId, bw, WriteLong);
            Write(Limit, bw, WriteInt);
        }
        
        T.Channels.AdminLogResults ITlFunc<T.Channels.AdminLogResults>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Channels.AdminLogResults.Deserialize);
    }
}