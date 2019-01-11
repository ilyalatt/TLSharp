using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Stickers
{
    public sealed class RemoveStickerFromSet : ITlFunc<T.Messages.StickerSet>, IEquatable<RemoveStickerFromSet>, IComparable<RemoveStickerFromSet>, IComparable
    {
        public T.InputDocument Sticker { get; }
        
        public RemoveStickerFromSet(
            Some<T.InputDocument> sticker
        ) {
            Sticker = sticker;
        }
        
        
        T.InputDocument CmpTuple =>
            Sticker;

        public bool Equals(RemoveStickerFromSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is RemoveStickerFromSet x && Equals(x);
        public static bool operator ==(RemoveStickerFromSet x, RemoveStickerFromSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RemoveStickerFromSet x, RemoveStickerFromSet y) => !(x == y);

        public int CompareTo(RemoveStickerFromSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is RemoveStickerFromSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RemoveStickerFromSet x, RemoveStickerFromSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(RemoveStickerFromSet x, RemoveStickerFromSet y) => x.CompareTo(y) < 0;
        public static bool operator >(RemoveStickerFromSet x, RemoveStickerFromSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(RemoveStickerFromSet x, RemoveStickerFromSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Sticker: {Sticker})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf7760f51);
            Write(Sticker, bw, WriteSerializable);
        }
        
        T.Messages.StickerSet ITlFunc<T.Messages.StickerSet>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSet.Deserialize);
    }
}