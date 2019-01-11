using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class Search : ITlFunc<T.Messages.Messages>, IEquatable<Search>, IComparable<Search>, IComparable
    {
        public T.InputPeer Peer { get; }
        public string Q { get; }
        public Option<T.InputUser> FromId { get; }
        public T.MessagesFilter Filter { get; }
        public int MinDate { get; }
        public int MaxDate { get; }
        public int OffsetId { get; }
        public int AddOffset { get; }
        public int Limit { get; }
        public int MaxId { get; }
        public int MinId { get; }
        public int Hash { get; }
        
        public Search(
            Some<T.InputPeer> peer,
            Some<string> q,
            Option<T.InputUser> fromId,
            Some<T.MessagesFilter> filter,
            int minDate,
            int maxDate,
            int offsetId,
            int addOffset,
            int limit,
            int maxId,
            int minId,
            int hash
        ) {
            Peer = peer;
            Q = q;
            FromId = fromId;
            Filter = filter;
            MinDate = minDate;
            MaxDate = maxDate;
            OffsetId = offsetId;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;
            Hash = hash;
        }
        
        
        (T.InputPeer, string, Option<T.InputUser>, T.MessagesFilter, int, int, int, int, int, int, int, int) CmpTuple =>
            (Peer, Q, FromId, Filter, MinDate, MaxDate, OffsetId, AddOffset, Limit, MaxId, MinId, Hash);

        public bool Equals(Search other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is Search x && Equals(x);
        public static bool operator ==(Search x, Search y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Search x, Search y) => !(x == y);

        public int CompareTo(Search other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is Search x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Search x, Search y) => x.CompareTo(y) <= 0;
        public static bool operator <(Search x, Search y) => x.CompareTo(y) < 0;
        public static bool operator >(Search x, Search y) => x.CompareTo(y) > 0;
        public static bool operator >=(Search x, Search y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Q: {Q}, FromId: {FromId}, Filter: {Filter}, MinDate: {MinDate}, MaxDate: {MaxDate}, OffsetId: {OffsetId}, AddOffset: {AddOffset}, Limit: {Limit}, MaxId: {MaxId}, MinId: {MinId}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8614ef68);
            Write(MaskBit(0, FromId), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(Q, bw, WriteString);
            Write(FromId, bw, WriteOption<T.InputUser>(WriteSerializable));
            Write(Filter, bw, WriteSerializable);
            Write(MinDate, bw, WriteInt);
            Write(MaxDate, bw, WriteInt);
            Write(OffsetId, bw, WriteInt);
            Write(AddOffset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
            Write(MaxId, bw, WriteInt);
            Write(MinId, bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}