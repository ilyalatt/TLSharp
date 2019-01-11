using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ResetTopPeerRating : ITlFunc<bool>, IEquatable<ResetTopPeerRating>, IComparable<ResetTopPeerRating>, IComparable
    {
        public T.TopPeerCategory Category { get; }
        public T.InputPeer Peer { get; }
        
        public ResetTopPeerRating(
            Some<T.TopPeerCategory> category,
            Some<T.InputPeer> peer
        ) {
            Category = category;
            Peer = peer;
        }
        
        
        (T.TopPeerCategory, T.InputPeer) CmpTuple =>
            (Category, Peer);

        public bool Equals(ResetTopPeerRating other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetTopPeerRating x && Equals(x);
        public static bool operator ==(ResetTopPeerRating x, ResetTopPeerRating y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetTopPeerRating x, ResetTopPeerRating y) => !(x == y);

        public int CompareTo(ResetTopPeerRating other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetTopPeerRating x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetTopPeerRating x, ResetTopPeerRating y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetTopPeerRating x, ResetTopPeerRating y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetTopPeerRating x, ResetTopPeerRating y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetTopPeerRating x, ResetTopPeerRating y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Category: {Category}, Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1ae373ac);
            Write(Category, bw, WriteSerializable);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}