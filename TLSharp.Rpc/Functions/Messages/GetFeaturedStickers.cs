using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetFeaturedStickers : ITlFunc<T.Messages.FeaturedStickers>, IEquatable<GetFeaturedStickers>, IComparable<GetFeaturedStickers>, IComparable
    {
        public int Hash { get; }
        
        public GetFeaturedStickers(
            int hash
        ) {
            Hash = hash;
        }
        
        
        int CmpTuple =>
            Hash;

        public bool Equals(GetFeaturedStickers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetFeaturedStickers x && Equals(x);
        public static bool operator ==(GetFeaturedStickers x, GetFeaturedStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFeaturedStickers x, GetFeaturedStickers y) => !(x == y);

        public int CompareTo(GetFeaturedStickers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetFeaturedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFeaturedStickers x, GetFeaturedStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFeaturedStickers x, GetFeaturedStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFeaturedStickers x, GetFeaturedStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFeaturedStickers x, GetFeaturedStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2dacca4f);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.FeaturedStickers ITlFunc<T.Messages.FeaturedStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.FeaturedStickers.Deserialize);
    }
}