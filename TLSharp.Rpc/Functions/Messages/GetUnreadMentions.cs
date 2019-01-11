using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetUnreadMentions : ITlFunc<T.Messages.Messages>, IEquatable<GetUnreadMentions>, IComparable<GetUnreadMentions>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int OffsetId { get; }
        public int AddOffset { get; }
        public int Limit { get; }
        public int MaxId { get; }
        public int MinId { get; }
        
        public GetUnreadMentions(
            Some<T.InputPeer> peer,
            int offsetId,
            int addOffset,
            int limit,
            int maxId,
            int minId
        ) {
            Peer = peer;
            OffsetId = offsetId;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;
        }
        
        
        (T.InputPeer, int, int, int, int, int) CmpTuple =>
            (Peer, OffsetId, AddOffset, Limit, MaxId, MinId);

        public bool Equals(GetUnreadMentions other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetUnreadMentions x && Equals(x);
        public static bool operator ==(GetUnreadMentions x, GetUnreadMentions y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetUnreadMentions x, GetUnreadMentions y) => !(x == y);

        public int CompareTo(GetUnreadMentions other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetUnreadMentions x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetUnreadMentions x, GetUnreadMentions y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetUnreadMentions x, GetUnreadMentions y) => x.CompareTo(y) < 0;
        public static bool operator >(GetUnreadMentions x, GetUnreadMentions y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetUnreadMentions x, GetUnreadMentions y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, OffsetId: {OffsetId}, AddOffset: {AddOffset}, Limit: {Limit}, MaxId: {MaxId}, MinId: {MinId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x46578472);
            Write(Peer, bw, WriteSerializable);
            Write(OffsetId, bw, WriteInt);
            Write(AddOffset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
            Write(MaxId, bw, WriteInt);
            Write(MinId, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}