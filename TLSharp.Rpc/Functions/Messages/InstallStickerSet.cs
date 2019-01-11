using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class InstallStickerSet : ITlFunc<T.Messages.StickerSetInstallResult>, IEquatable<InstallStickerSet>, IComparable<InstallStickerSet>, IComparable
    {
        public T.InputStickerSet Stickerset { get; }
        public bool Archived { get; }
        
        public InstallStickerSet(
            Some<T.InputStickerSet> stickerset,
            bool archived
        ) {
            Stickerset = stickerset;
            Archived = archived;
        }
        
        
        (T.InputStickerSet, bool) CmpTuple =>
            (Stickerset, Archived);

        public bool Equals(InstallStickerSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is InstallStickerSet x && Equals(x);
        public static bool operator ==(InstallStickerSet x, InstallStickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InstallStickerSet x, InstallStickerSet y) => !(x == y);

        public int CompareTo(InstallStickerSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is InstallStickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InstallStickerSet x, InstallStickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(InstallStickerSet x, InstallStickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(InstallStickerSet x, InstallStickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(InstallStickerSet x, InstallStickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Stickerset: {Stickerset}, Archived: {Archived})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc78fe460);
            Write(Stickerset, bw, WriteSerializable);
            Write(Archived, bw, WriteBool);
        }
        
        T.Messages.StickerSetInstallResult ITlFunc<T.Messages.StickerSetInstallResult>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSetInstallResult.Deserialize);
    }
}