using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DeleteHistory : ITlFunc<T.Messages.AffectedHistory>, IEquatable<DeleteHistory>, IComparable<DeleteHistory>, IComparable
    {
        public bool JustClear { get; }
        public T.InputPeer Peer { get; }
        public int MaxId { get; }
        
        public DeleteHistory(
            bool justClear,
            Some<T.InputPeer> peer,
            int maxId
        ) {
            JustClear = justClear;
            Peer = peer;
            MaxId = maxId;
        }
        
        
        (bool, T.InputPeer, int) CmpTuple =>
            (JustClear, Peer, MaxId);

        public bool Equals(DeleteHistory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteHistory x && Equals(x);
        public static bool operator ==(DeleteHistory x, DeleteHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteHistory x, DeleteHistory y) => !(x == y);

        public int CompareTo(DeleteHistory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteHistory x, DeleteHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(JustClear: {JustClear}, Peer: {Peer}, MaxId: {MaxId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1c015b09);
            Write(MaskBit(0, JustClear), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        T.Messages.AffectedHistory ITlFunc<T.Messages.AffectedHistory>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedHistory.Deserialize);
    }
}