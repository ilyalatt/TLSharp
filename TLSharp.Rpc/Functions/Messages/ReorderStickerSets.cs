using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReorderStickerSets : ITlFunc<bool>, IEquatable<ReorderStickerSets>, IComparable<ReorderStickerSets>, IComparable
    {
        public bool Masks { get; }
        public Arr<long> Order { get; }
        
        public ReorderStickerSets(
            bool masks,
            Some<Arr<long>> order
        ) {
            Masks = masks;
            Order = order;
        }
        
        
        (bool, Arr<long>) CmpTuple =>
            (Masks, Order);

        public bool Equals(ReorderStickerSets other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReorderStickerSets x && Equals(x);
        public static bool operator ==(ReorderStickerSets x, ReorderStickerSets y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReorderStickerSets x, ReorderStickerSets y) => !(x == y);

        public int CompareTo(ReorderStickerSets other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReorderStickerSets x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReorderStickerSets x, ReorderStickerSets y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReorderStickerSets x, ReorderStickerSets y) => x.CompareTo(y) < 0;
        public static bool operator >(ReorderStickerSets x, ReorderStickerSets y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReorderStickerSets x, ReorderStickerSets y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Masks: {Masks}, Order: {Order})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x78337739);
            Write(MaskBit(0, Masks), bw, WriteInt);
            Write(Order, bw, WriteVector<long>(WriteLong));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}