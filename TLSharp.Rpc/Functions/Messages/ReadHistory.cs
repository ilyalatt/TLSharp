using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadHistory : ITlFunc<T.Messages.AffectedMessages>, IEquatable<ReadHistory>, IComparable<ReadHistory>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int MaxId { get; }
        
        public ReadHistory(
            Some<T.InputPeer> peer,
            int maxId
        ) {
            Peer = peer;
            MaxId = maxId;
        }
        
        
        (T.InputPeer, int) CmpTuple =>
            (Peer, MaxId);

        public bool Equals(ReadHistory other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReadHistory x && Equals(x);
        public static bool operator ==(ReadHistory x, ReadHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReadHistory x, ReadHistory y) => !(x == y);

        public int CompareTo(ReadHistory other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReadHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReadHistory x, ReadHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReadHistory x, ReadHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(ReadHistory x, ReadHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReadHistory x, ReadHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, MaxId: {MaxId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0e306d3a);
            Write(Peer, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}