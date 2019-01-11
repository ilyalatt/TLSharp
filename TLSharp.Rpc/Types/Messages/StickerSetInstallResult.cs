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
        public sealed class SuccessTag : ITlTypeTag, IEquatable<SuccessTag>, IComparable<SuccessTag>, IComparable
        {
            internal const uint TypeNumber = 0x38641628;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SuccessTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(SuccessTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SuccessTag x && Equals(x);
            public static bool operator ==(SuccessTag x, SuccessTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SuccessTag x, SuccessTag y) => !(x == y);

            public int CompareTo(SuccessTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SuccessTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SuccessTag x, SuccessTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SuccessTag x, SuccessTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SuccessTag x, SuccessTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SuccessTag x, SuccessTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SuccessTag DeserializeTag(BinaryReader br)
            {

                return new SuccessTag();
            }
        }

        public sealed class ArchiveTag : ITlTypeTag, IEquatable<ArchiveTag>, IComparable<ArchiveTag>, IComparable
        {
            internal const uint TypeNumber = 0x35e410a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.StickerSetCovered> Sets;
            
            public ArchiveTag(
                Some<Arr<T.StickerSetCovered>> sets
            ) {
                Sets = sets;
            }
            
            Arr<T.StickerSetCovered> CmpTuple =>
                Sets;

            public bool Equals(ArchiveTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ArchiveTag x && Equals(x);
            public static bool operator ==(ArchiveTag x, ArchiveTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ArchiveTag x, ArchiveTag y) => !(x == y);

            public int CompareTo(ArchiveTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ArchiveTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ArchiveTag x, ArchiveTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ArchiveTag x, ArchiveTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ArchiveTag x, ArchiveTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ArchiveTag x, ArchiveTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Sets: {Sets})";
            
            
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

        public bool Equals(StickerSetInstallResult other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is StickerSetInstallResult x && Equals(x);
        public static bool operator ==(StickerSetInstallResult x, StickerSetInstallResult y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(StickerSetInstallResult x, StickerSetInstallResult y) => !(x == y);

        public int CompareTo(StickerSetInstallResult other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is StickerSetInstallResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSetInstallResult x, StickerSetInstallResult y) => x.CompareTo(y) <= 0;
        public static bool operator <(StickerSetInstallResult x, StickerSetInstallResult y) => x.CompareTo(y) < 0;
        public static bool operator >(StickerSetInstallResult x, StickerSetInstallResult y) => x.CompareTo(y) > 0;
        public static bool operator >=(StickerSetInstallResult x, StickerSetInstallResult y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"StickerSetInstallResult.{_tag.GetType().Name}{_tag}";
    }
}