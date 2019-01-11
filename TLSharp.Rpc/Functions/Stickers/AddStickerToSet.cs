using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Stickers
{
    public sealed class AddStickerToSet : ITlFunc<T.Messages.StickerSet>, IEquatable<AddStickerToSet>, IComparable<AddStickerToSet>, IComparable
    {
        public T.InputStickerSet Stickerset { get; }
        public T.InputStickerSetItem Sticker { get; }
        
        public AddStickerToSet(
            Some<T.InputStickerSet> stickerset,
            Some<T.InputStickerSetItem> sticker
        ) {
            Stickerset = stickerset;
            Sticker = sticker;
        }
        
        
        (T.InputStickerSet, T.InputStickerSetItem) CmpTuple =>
            (Stickerset, Sticker);

        public bool Equals(AddStickerToSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is AddStickerToSet x && Equals(x);
        public static bool operator ==(AddStickerToSet x, AddStickerToSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AddStickerToSet x, AddStickerToSet y) => !(x == y);

        public int CompareTo(AddStickerToSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is AddStickerToSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AddStickerToSet x, AddStickerToSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(AddStickerToSet x, AddStickerToSet y) => x.CompareTo(y) < 0;
        public static bool operator >(AddStickerToSet x, AddStickerToSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(AddStickerToSet x, AddStickerToSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Stickerset: {Stickerset}, Sticker: {Sticker})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8653febe);
            Write(Stickerset, bw, WriteSerializable);
            Write(Sticker, bw, WriteSerializable);
        }
        
        T.Messages.StickerSet ITlFunc<T.Messages.StickerSet>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSet.Deserialize);
    }
}