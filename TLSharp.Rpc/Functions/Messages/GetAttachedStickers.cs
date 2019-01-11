using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetAttachedStickers : ITlFunc<Arr<T.StickerSetCovered>>, IEquatable<GetAttachedStickers>, IComparable<GetAttachedStickers>, IComparable
    {
        public T.InputStickeredMedia Media { get; }
        
        public GetAttachedStickers(
            Some<T.InputStickeredMedia> media
        ) {
            Media = media;
        }
        
        
        T.InputStickeredMedia CmpTuple =>
            Media;

        public bool Equals(GetAttachedStickers other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetAttachedStickers x && Equals(x);
        public static bool operator ==(GetAttachedStickers x, GetAttachedStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAttachedStickers x, GetAttachedStickers y) => !(x == y);

        public int CompareTo(GetAttachedStickers other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetAttachedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAttachedStickers x, GetAttachedStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAttachedStickers x, GetAttachedStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAttachedStickers x, GetAttachedStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAttachedStickers x, GetAttachedStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Media: {Media})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcc5b67cc);
            Write(Media, bw, WriteSerializable);
        }
        
        Arr<T.StickerSetCovered> ITlFunc<Arr<T.StickerSetCovered>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.StickerSetCovered.Deserialize));
    }
}