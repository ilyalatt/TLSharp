using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetHistory : ITlFunc<T.Messages.Messages>, IEquatable<GetHistory>, IComparable<GetHistory>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int OffsetId { get; }
        public int OffsetDate { get; }
        public int AddOffset { get; }
        public int Limit { get; }
        public int MaxId { get; }
        public int MinId { get; }
        public int Hash { get; }
        
        public GetHistory(
            Some<T.InputPeer> peer,
            int offsetId,
            int offsetDate,
            int addOffset,
            int limit,
            int maxId,
            int minId,
            int hash
        ) {
            Peer = peer;
            OffsetId = offsetId;
            OffsetDate = offsetDate;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;
            Hash = hash;
        }
        
        
        (T.InputPeer, int, int, int, int, int, int, int) CmpTuple =>
            (Peer, OffsetId, OffsetDate, AddOffset, Limit, MaxId, MinId, Hash);

        public bool Equals(GetHistory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetHistory x && Equals(x);
        public static bool operator ==(GetHistory x, GetHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetHistory x, GetHistory y) => !(x == y);

        public int CompareTo(GetHistory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetHistory x, GetHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetHistory x, GetHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(GetHistory x, GetHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetHistory x, GetHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, OffsetId: {OffsetId}, OffsetDate: {OffsetDate}, AddOffset: {AddOffset}, Limit: {Limit}, MaxId: {MaxId}, MinId: {MinId}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdcbb8260);
            Write(Peer, bw, WriteSerializable);
            Write(OffsetId, bw, WriteInt);
            Write(OffsetDate, bw, WriteInt);
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