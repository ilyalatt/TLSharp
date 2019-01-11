using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ForwardMessage : ITlFunc<T.UpdatesType>, IEquatable<ForwardMessage>, IComparable<ForwardMessage>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int Id { get; }
        public long RandomId { get; }
        
        public ForwardMessage(
            Some<T.InputPeer> peer,
            int id,
            long randomId
        ) {
            Peer = peer;
            Id = id;
            RandomId = randomId;
        }
        
        
        (T.InputPeer, int, long) CmpTuple =>
            (Peer, Id, RandomId);

        public bool Equals(ForwardMessage other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ForwardMessage x && Equals(x);
        public static bool operator ==(ForwardMessage x, ForwardMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ForwardMessage x, ForwardMessage y) => !(x == y);

        public int CompareTo(ForwardMessage other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ForwardMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ForwardMessage x, ForwardMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(ForwardMessage x, ForwardMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(ForwardMessage x, ForwardMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(ForwardMessage x, ForwardMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Id: {Id}, RandomId: {RandomId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x33963bf9);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
            Write(RandomId, bw, WriteLong);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}