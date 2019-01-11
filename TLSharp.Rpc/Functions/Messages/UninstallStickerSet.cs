using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class UninstallStickerSet : ITlFunc<bool>, IEquatable<UninstallStickerSet>, IComparable<UninstallStickerSet>, IComparable
    {
        public T.InputStickerSet Stickerset { get; }
        
        public UninstallStickerSet(
            Some<T.InputStickerSet> stickerset
        ) {
            Stickerset = stickerset;
        }
        
        
        T.InputStickerSet CmpTuple =>
            Stickerset;

        public bool Equals(UninstallStickerSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UninstallStickerSet x && Equals(x);
        public static bool operator ==(UninstallStickerSet x, UninstallStickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UninstallStickerSet x, UninstallStickerSet y) => !(x == y);

        public int CompareTo(UninstallStickerSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UninstallStickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UninstallStickerSet x, UninstallStickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(UninstallStickerSet x, UninstallStickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(UninstallStickerSet x, UninstallStickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(UninstallStickerSet x, UninstallStickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Stickerset: {Stickerset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf96e55de);
            Write(Stickerset, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}