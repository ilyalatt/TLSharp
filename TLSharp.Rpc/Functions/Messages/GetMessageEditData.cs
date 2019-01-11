using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMessageEditData : ITlFunc<T.Messages.MessageEditData>, IEquatable<GetMessageEditData>, IComparable<GetMessageEditData>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int Id { get; }
        
        public GetMessageEditData(
            Some<T.InputPeer> peer,
            int id
        ) {
            Peer = peer;
            Id = id;
        }
        
        
        (T.InputPeer, int) CmpTuple =>
            (Peer, Id);

        public bool Equals(GetMessageEditData other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetMessageEditData x && Equals(x);
        public static bool operator ==(GetMessageEditData x, GetMessageEditData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetMessageEditData x, GetMessageEditData y) => !(x == y);

        public int CompareTo(GetMessageEditData other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetMessageEditData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetMessageEditData x, GetMessageEditData y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetMessageEditData x, GetMessageEditData y) => x.CompareTo(y) < 0;
        public static bool operator >(GetMessageEditData x, GetMessageEditData y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetMessageEditData x, GetMessageEditData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfda68d36);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
        }
        
        T.Messages.MessageEditData ITlFunc<T.Messages.MessageEditData>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.MessageEditData.Deserialize);
    }
}