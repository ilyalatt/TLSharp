using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetStickerSet : ITlFunc<T.Messages.StickerSet>, IEquatable<GetStickerSet>, IComparable<GetStickerSet>, IComparable
    {
        public T.InputStickerSet Stickerset { get; }
        
        public GetStickerSet(
            Some<T.InputStickerSet> stickerset
        ) {
            Stickerset = stickerset;
        }
        
        
        T.InputStickerSet CmpTuple =>
            Stickerset;

        public bool Equals(GetStickerSet other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetStickerSet x && Equals(x);
        public static bool operator ==(GetStickerSet x, GetStickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetStickerSet x, GetStickerSet y) => !(x == y);

        public int CompareTo(GetStickerSet other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetStickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetStickerSet x, GetStickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetStickerSet x, GetStickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(GetStickerSet x, GetStickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetStickerSet x, GetStickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Stickerset: {Stickerset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2619a90e);
            Write(Stickerset, bw, WriteSerializable);
        }
        
        T.Messages.StickerSet ITlFunc<T.Messages.StickerSet>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSet.Deserialize);
    }
}