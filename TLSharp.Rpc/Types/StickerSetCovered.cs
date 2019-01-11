using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class StickerSetCovered : ITlType, IEquatable<StickerSetCovered>, IComparable<StickerSetCovered>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x6410a5d2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.StickerSet Set;
            public readonly T.Document Cover;
            
            public Tag(
                Some<T.StickerSet> set,
                Some<T.Document> cover
            ) {
                Set = set;
                Cover = cover;
            }
            
            (T.StickerSet, T.Document) CmpTuple =>
                (Set, Cover);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Set: {Set}, Cover: {Cover})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Set, bw, WriteSerializable);
                Write(Cover, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var set = Read(br, T.StickerSet.Deserialize);
                var cover = Read(br, T.Document.Deserialize);
                return new Tag(set, cover);
            }
        }

        public sealed class MultiTag : ITlTypeTag, IEquatable<MultiTag>, IComparable<MultiTag>, IComparable
        {
            internal const uint TypeNumber = 0x3407e51b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.StickerSet Set;
            public readonly Arr<T.Document> Covers;
            
            public MultiTag(
                Some<T.StickerSet> set,
                Some<Arr<T.Document>> covers
            ) {
                Set = set;
                Covers = covers;
            }
            
            (T.StickerSet, Arr<T.Document>) CmpTuple =>
                (Set, Covers);

            public bool Equals(MultiTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MultiTag x && Equals(x);
            public static bool operator ==(MultiTag x, MultiTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MultiTag x, MultiTag y) => !(x == y);

            public int CompareTo(MultiTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MultiTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MultiTag x, MultiTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MultiTag x, MultiTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MultiTag x, MultiTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MultiTag x, MultiTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Set: {Set}, Covers: {Covers})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Set, bw, WriteSerializable);
                Write(Covers, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static MultiTag DeserializeTag(BinaryReader br)
            {
                var set = Read(br, T.StickerSet.Deserialize);
                var covers = Read(br, ReadVector(T.Document.Deserialize));
                return new MultiTag(set, covers);
            }
        }

        readonly ITlTypeTag _tag;
        StickerSetCovered(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator StickerSetCovered(Tag tag) => new StickerSetCovered(tag);
        public static explicit operator StickerSetCovered(MultiTag tag) => new StickerSetCovered(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static StickerSetCovered Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (StickerSetCovered) Tag.DeserializeTag(br);
                case MultiTag.TypeNumber: return (StickerSetCovered) MultiTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, MultiTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<MultiTag, T> multiTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case MultiTag x when multiTag != null: return multiTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<MultiTag, T> multiTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            multiTag ?? throw new ArgumentNullException(nameof(multiTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case MultiTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(StickerSetCovered other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is StickerSetCovered x && Equals(x);
        public static bool operator ==(StickerSetCovered x, StickerSetCovered y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(StickerSetCovered x, StickerSetCovered y) => !(x == y);

        public int CompareTo(StickerSetCovered other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is StickerSetCovered x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSetCovered x, StickerSetCovered y) => x.CompareTo(y) <= 0;
        public static bool operator <(StickerSetCovered x, StickerSetCovered y) => x.CompareTo(y) < 0;
        public static bool operator >(StickerSetCovered x, StickerSetCovered y) => x.CompareTo(y) > 0;
        public static bool operator >=(StickerSetCovered x, StickerSetCovered y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"StickerSetCovered.{_tag.GetType().Name}{_tag}";
    }
}