using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Stickers
{
    public sealed class ChangeStickerPosition : ITlFunc<T.Messages.StickerSet>, IEquatable<ChangeStickerPosition>, IComparable<ChangeStickerPosition>, IComparable
    {
        public T.InputDocument Sticker { get; }
        public int Position { get; }
        
        public ChangeStickerPosition(
            Some<T.InputDocument> sticker,
            int position
        ) {
            Sticker = sticker;
            Position = position;
        }
        
        
        (T.InputDocument, int) CmpTuple =>
            (Sticker, Position);

        public bool Equals(ChangeStickerPosition other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ChangeStickerPosition x && Equals(x);
        public static bool operator ==(ChangeStickerPosition x, ChangeStickerPosition y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChangeStickerPosition x, ChangeStickerPosition y) => !(x == y);

        public int CompareTo(ChangeStickerPosition other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ChangeStickerPosition x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChangeStickerPosition x, ChangeStickerPosition y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChangeStickerPosition x, ChangeStickerPosition y) => x.CompareTo(y) < 0;
        public static bool operator >(ChangeStickerPosition x, ChangeStickerPosition y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChangeStickerPosition x, ChangeStickerPosition y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Sticker: {Sticker}, Position: {Position})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xffb6d4ca);
            Write(Sticker, bw, WriteSerializable);
            Write(Position, bw, WriteInt);
        }
        
        T.Messages.StickerSet ITlFunc<T.Messages.StickerSet>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSet.Deserialize);
    }
}