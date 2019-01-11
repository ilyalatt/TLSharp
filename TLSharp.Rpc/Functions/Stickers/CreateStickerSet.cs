using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Stickers
{
    public sealed class CreateStickerSet : ITlFunc<T.Messages.StickerSet>, IEquatable<CreateStickerSet>, IComparable<CreateStickerSet>, IComparable
    {
        public bool Masks { get; }
        public T.InputUser UserId { get; }
        public string Title { get; }
        public string ShortName { get; }
        public Arr<T.InputStickerSetItem> Stickers { get; }
        
        public CreateStickerSet(
            bool masks,
            Some<T.InputUser> userId,
            Some<string> title,
            Some<string> shortName,
            Some<Arr<T.InputStickerSetItem>> stickers
        ) {
            Masks = masks;
            UserId = userId;
            Title = title;
            ShortName = shortName;
            Stickers = stickers;
        }
        
        
        (bool, T.InputUser, string, string, Arr<T.InputStickerSetItem>) CmpTuple =>
            (Masks, UserId, Title, ShortName, Stickers);

        public bool Equals(CreateStickerSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is CreateStickerSet x && Equals(x);
        public static bool operator ==(CreateStickerSet x, CreateStickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CreateStickerSet x, CreateStickerSet y) => !(x == y);

        public int CompareTo(CreateStickerSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is CreateStickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CreateStickerSet x, CreateStickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(CreateStickerSet x, CreateStickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(CreateStickerSet x, CreateStickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(CreateStickerSet x, CreateStickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Masks: {Masks}, UserId: {UserId}, Title: {Title}, ShortName: {ShortName}, Stickers: {Stickers})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9bd86e6a);
            Write(MaskBit(0, Masks), bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
            Write(Title, bw, WriteString);
            Write(ShortName, bw, WriteString);
            Write(Stickers, bw, WriteVector<T.InputStickerSetItem>(WriteSerializable));
        }
        
        T.Messages.StickerSet ITlFunc<T.Messages.StickerSet>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSet.Deserialize);
    }
}