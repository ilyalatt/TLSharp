using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadFeaturedStickers : ITlFunc<bool>, IEquatable<ReadFeaturedStickers>, IComparable<ReadFeaturedStickers>, IComparable
    {
        public Arr<long> Id { get; }
        
        public ReadFeaturedStickers(
            Some<Arr<long>> id
        ) {
            Id = id;
        }
        
        
        Arr<long> CmpTuple =>
            Id;

        public bool Equals(ReadFeaturedStickers other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReadFeaturedStickers x && Equals(x);
        public static bool operator ==(ReadFeaturedStickers x, ReadFeaturedStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReadFeaturedStickers x, ReadFeaturedStickers y) => !(x == y);

        public int CompareTo(ReadFeaturedStickers other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReadFeaturedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReadFeaturedStickers x, ReadFeaturedStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReadFeaturedStickers x, ReadFeaturedStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(ReadFeaturedStickers x, ReadFeaturedStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReadFeaturedStickers x, ReadFeaturedStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5b118126);
            Write(Id, bw, WriteVector<long>(WriteLong));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}