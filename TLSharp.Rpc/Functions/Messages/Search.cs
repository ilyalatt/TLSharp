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
        public T.MessagesFilter Filter { get; }
        public int MinDate { get; }
        public int MaxDate { get; }
        public int Offset { get; }
        public int MaxId { get; }
        public int Limit { get; }
        
        public Search(
            Some<T.InputPeer> peer,
            Some<string> q,
            Some<T.MessagesFilter> filter,
            int minDate,
            int maxDate,
            int offset,
            int maxId,
            int limit
        ) {
            Peer = peer;
            Q = q;
            Filter = filter;
            MinDate = minDate;
            MaxDate = maxDate;
            Offset = offset;
            MaxId = maxId;
            Limit = limit;
        }
        
        
        (T.InputPeer, string, T.MessagesFilter, int, int, int, int, int) CmpTuple =>
            (Peer, Q, Filter, MinDate, MaxDate, Offset, MaxId, Limit);

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

        public override string ToString() => $"(Peer: {Peer}, Q: {Q}, Filter: {Filter}, MinDate: {MinDate}, MaxDate: {MaxDate}, Offset: {Offset}, MaxId: {MaxId}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd4569248);
            Write(0, bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(Q, bw, WriteString);
            Write(Filter, bw, WriteSerializable);
            Write(MinDate, bw, WriteInt);
            Write(MaxDate, bw, WriteInt);
            Write(Offset, bw, WriteInt);
            Write(MaxId, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}