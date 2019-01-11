using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetRecentLocations : ITlFunc<T.Messages.Messages>, IEquatable<GetRecentLocations>, IComparable<GetRecentLocations>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int Limit { get; }
        public int Hash { get; }
        
        public GetRecentLocations(
            Some<T.InputPeer> peer,
            int limit,
            int hash
        ) {
            Peer = peer;
            Limit = limit;
            Hash = hash;
        }
        
        
        (T.InputPeer, int, int) CmpTuple =>
            (Peer, Limit, Hash);

        public bool Equals(GetRecentLocations other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetRecentLocations x && Equals(x);
        public static bool operator ==(GetRecentLocations x, GetRecentLocations y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetRecentLocations x, GetRecentLocations y) => !(x == y);

        public int CompareTo(GetRecentLocations other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetRecentLocations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetRecentLocations x, GetRecentLocations y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetRecentLocations x, GetRecentLocations y) => x.CompareTo(y) < 0;
        public static bool operator >(GetRecentLocations x, GetRecentLocations y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetRecentLocations x, GetRecentLocations y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Limit: {Limit}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbbc45b09);
            Write(Peer, bw, WriteSerializable);
            Write(Limit, bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}