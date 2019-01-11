using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetInlineBotResults : ITlFunc<T.Messages.BotResults>, IEquatable<GetInlineBotResults>, IComparable<GetInlineBotResults>, IComparable
    {
        public T.InputUser Bot { get; }
        public T.InputPeer Peer { get; }
        public Option<T.InputGeoPoint> GeoPoint { get; }
        public string Query { get; }
        public string Offset { get; }
        
        public GetInlineBotResults(
            Some<T.InputUser> bot,
            Some<T.InputPeer> peer,
            Option<T.InputGeoPoint> geoPoint,
            Some<string> query,
            Some<string> offset
        ) {
            Bot = bot;
            Peer = peer;
            GeoPoint = geoPoint;
            Query = query;
            Offset = offset;
        }
        
        
        (T.InputUser, T.InputPeer, Option<T.InputGeoPoint>, string, string) CmpTuple =>
            (Bot, Peer, GeoPoint, Query, Offset);

        public bool Equals(GetInlineBotResults other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetInlineBotResults x && Equals(x);
        public static bool operator ==(GetInlineBotResults x, GetInlineBotResults y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetInlineBotResults x, GetInlineBotResults y) => !(x == y);

        public int CompareTo(GetInlineBotResults other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetInlineBotResults x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetInlineBotResults x, GetInlineBotResults y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetInlineBotResults x, GetInlineBotResults y) => x.CompareTo(y) < 0;
        public static bool operator >(GetInlineBotResults x, GetInlineBotResults y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetInlineBotResults x, GetInlineBotResults y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Bot: {Bot}, Peer: {Peer}, GeoPoint: {GeoPoint}, Query: {Query}, Offset: {Offset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x514e999d);
            Write(MaskBit(0, GeoPoint), bw, WriteInt);
            Write(Bot, bw, WriteSerializable);
            Write(Peer, bw, WriteSerializable);
            Write(GeoPoint, bw, WriteOption<T.InputGeoPoint>(WriteSerializable));
            Write(Query, bw, WriteString);
            Write(Offset, bw, WriteString);
        }
        
        T.Messages.BotResults ITlFunc<T.Messages.BotResults>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.BotResults.Deserialize);
    }
}