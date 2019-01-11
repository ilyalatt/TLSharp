using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMessagesViews : ITlFunc<Arr<int>>, IEquatable<GetMessagesViews>, IComparable<GetMessagesViews>, IComparable
    {
        public T.InputPeer Peer { get; }
        public Arr<int> Id { get; }
        public bool Increment { get; }
        
        public GetMessagesViews(
            Some<T.InputPeer> peer,
            Some<Arr<int>> id,
            bool increment
        ) {
            Peer = peer;
            Id = id;
            Increment = increment;
        }
        
        
        (T.InputPeer, Arr<int>, bool) CmpTuple =>
            (Peer, Id, Increment);

        public bool Equals(GetMessagesViews other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetMessagesViews x && Equals(x);
        public static bool operator ==(GetMessagesViews x, GetMessagesViews y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetMessagesViews x, GetMessagesViews y) => !(x == y);

        public int CompareTo(GetMessagesViews other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetMessagesViews x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetMessagesViews x, GetMessagesViews y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetMessagesViews x, GetMessagesViews y) => x.CompareTo(y) < 0;
        public static bool operator >(GetMessagesViews x, GetMessagesViews y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetMessagesViews x, GetMessagesViews y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Id: {Id}, Increment: {Increment})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc4c8a55d);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
            Write(Increment, bw, WriteBool);
        }
        
        Arr<int> ITlFunc<Arr<int>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadInt));
    }
}