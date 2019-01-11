using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetPeerDialogs : ITlFunc<T.Messages.PeerDialogs>, IEquatable<GetPeerDialogs>, IComparable<GetPeerDialogs>, IComparable
    {
        public Arr<T.InputPeer> Peers { get; }
        
        public GetPeerDialogs(
            Some<Arr<T.InputPeer>> peers
        ) {
            Peers = peers;
        }
        
        
        Arr<T.InputPeer> CmpTuple =>
            Peers;

        public bool Equals(GetPeerDialogs other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetPeerDialogs x && Equals(x);
        public static bool operator ==(GetPeerDialogs x, GetPeerDialogs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPeerDialogs x, GetPeerDialogs y) => !(x == y);

        public int CompareTo(GetPeerDialogs other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetPeerDialogs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPeerDialogs x, GetPeerDialogs y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPeerDialogs x, GetPeerDialogs y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPeerDialogs x, GetPeerDialogs y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPeerDialogs x, GetPeerDialogs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peers: {Peers})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2d9776b9);
            Write(Peers, bw, WriteVector<T.InputPeer>(WriteSerializable));
        }
        
        T.Messages.PeerDialogs ITlFunc<T.Messages.PeerDialogs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.PeerDialogs.Deserialize);
    }
}