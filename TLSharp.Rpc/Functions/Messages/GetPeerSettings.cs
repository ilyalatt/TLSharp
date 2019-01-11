using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetPeerSettings : ITlFunc<T.PeerSettings>, IEquatable<GetPeerSettings>, IComparable<GetPeerSettings>, IComparable
    {
        public T.InputPeer Peer { get; }
        
        public GetPeerSettings(
            Some<T.InputPeer> peer
        ) {
            Peer = peer;
        }
        
        
        T.InputPeer CmpTuple =>
            Peer;

        public bool Equals(GetPeerSettings other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetPeerSettings x && Equals(x);
        public static bool operator ==(GetPeerSettings x, GetPeerSettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPeerSettings x, GetPeerSettings y) => !(x == y);

        public int CompareTo(GetPeerSettings other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetPeerSettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPeerSettings x, GetPeerSettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPeerSettings x, GetPeerSettings y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPeerSettings x, GetPeerSettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPeerSettings x, GetPeerSettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3672e09c);
            Write(Peer, bw, WriteSerializable);
        }
        
        T.PeerSettings ITlFunc<T.PeerSettings>.DeserializeResult(BinaryReader br) =>
            Read(br, T.PeerSettings.Deserialize);
    }
}