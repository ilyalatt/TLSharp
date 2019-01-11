using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetRecentStickers : ITlFunc<T.Messages.RecentStickers>, IEquatable<GetRecentStickers>, IComparable<GetRecentStickers>, IComparable
    {
        public bool Attached { get; }
        public int Hash { get; }
        
        public GetRecentStickers(
            bool attached,
            int hash
        ) {
            Attached = attached;
            Hash = hash;
        }
        
        
        (bool, int) CmpTuple =>
            (Attached, Hash);

        public bool Equals(GetRecentStickers other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetRecentStickers x && Equals(x);
        public static bool operator ==(GetRecentStickers x, GetRecentStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetRecentStickers x, GetRecentStickers y) => !(x == y);

        public int CompareTo(GetRecentStickers other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetRecentStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetRecentStickers x, GetRecentStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetRecentStickers x, GetRecentStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetRecentStickers x, GetRecentStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetRecentStickers x, GetRecentStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Attached: {Attached}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5ea192c9);
            Write(MaskBit(0, Attached), bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.RecentStickers ITlFunc<T.Messages.RecentStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.RecentStickers.Deserialize);
    }
}