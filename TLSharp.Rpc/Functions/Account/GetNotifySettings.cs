using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetNotifySettings : ITlFunc<T.PeerNotifySettings>, IEquatable<GetNotifySettings>, IComparable<GetNotifySettings>, IComparable
    {
        public T.InputNotifyPeer Peer { get; }
        
        public GetNotifySettings(
            Some<T.InputNotifyPeer> peer
        ) {
            Peer = peer;
        }
        
        
        T.InputNotifyPeer CmpTuple =>
            Peer;

        public bool Equals(GetNotifySettings other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetNotifySettings x && Equals(x);
        public static bool operator ==(GetNotifySettings x, GetNotifySettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetNotifySettings x, GetNotifySettings y) => !(x == y);

        public int CompareTo(GetNotifySettings other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetNotifySettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetNotifySettings x, GetNotifySettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetNotifySettings x, GetNotifySettings y) => x.CompareTo(y) < 0;
        public static bool operator >(GetNotifySettings x, GetNotifySettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetNotifySettings x, GetNotifySettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x12b3ad31);
            Write(Peer, bw, WriteSerializable);
        }
        
        T.PeerNotifySettings ITlFunc<T.PeerNotifySettings>.DeserializeResult(BinaryReader br) =>
            Read(br, T.PeerNotifySettings.Deserialize);
    }
}