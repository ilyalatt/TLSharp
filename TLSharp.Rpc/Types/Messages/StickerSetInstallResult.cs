using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class StickerSetInstallResult : ITlType, IEquatable<StickerSetInstallResult>, IComparable<StickerSetInstallResult>, IComparable
    {
        public sealed class SuccessTag : Record<SuccessTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x38641628;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SuccessTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SuccessTag DeserializeTag(BinaryReader br)
            {

                return new SuccessTag();
            }
        }

        public sealed class ArchiveTag : Record<ArchiveTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x35e410a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.StickerSetCovered> Sets { get; }
            
            public ArchiveTag(
                Some<Arr<T.StickerSetCovered>> sets
            ) {
                Sets = sets;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Sets, bw, WriteVector<T.StickerSetCovered>(WriteSerializable));
            }
            
            internal static ArchiveTag DeserializeTag(BinaryReader br)
            {
                var sets = Read(br, ReadVector(T.StickerSetCovered.Deserialize));
                return new ArchiveTag(sets);
            }
        }

        readonly ITlTypeTag _tag;
        StickerSetInstallResult(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator StickerSetInstallResult(SuccessTag tag) => new StickerSetInstallResult(tag);
        public static explicit operator StickerSetInstallResult(ArchiveTag tag) => new StickerSetInstallResult(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static StickerSetInstallResult Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case SuccessTag.TypeNumber: return (StickerSetInstallResult) SuccessTag.DeserializeTag(br);
                case ArchiveTag.TypeNumber: return (StickerSetInstallResult) ArchiveTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { SuccessTag.TypeNumber, ArchiveTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<SuccessTag, T> successTag = null,
            Func<ArchiveTag, T> archiveTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case SuccessTag x when successTag != null: return successTag(x);
                case ArchiveTag x when archiveTag != null: return archiveTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<SuccessTag, T> successTag,
            Func<ArchiveTag, T> archiveTag
        ) => Match(
            () => throw new Exception("WTF"),
            successTag ?? throw new ArgumentNullException(nameof(successTag)),
            archiveTag ?? throw new ArgumentNullException(nameof(archiveTag))
        );

        public bool Equals(StickerSetInstallResult other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is StickerSetInstallResult x && Equals(x);
        public static bool operator ==(StickerSetInstallResult a, StickerSetInstallResult b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(StickerSetInstallResult a, StickerSetInstallResult b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case SuccessTag _: return 0;
                case ArchiveTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(StickerSetInstallResult other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is StickerSetInstallResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSetInstallResult a, StickerSetInstallResult b) => a.CompareTo(b) <= 0;
        public static bool operator <(StickerSetInstallResult a, StickerSetInstallResult b) => a.CompareTo(b) < 0;
        public static bool operator >(StickerSetInstallResult a, StickerSetInstallResult b) => a.CompareTo(b) > 0;
        public static bool operator >=(StickerSetInstallResult a, StickerSetInstallResult b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}