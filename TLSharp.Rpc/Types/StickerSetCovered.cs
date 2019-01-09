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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x6410a5d2;
            
            public T.StickerSet Set { get; }
            public T.Document Cover { get; }
            
            public Tag(
                Some<T.StickerSet> set,
                Some<T.Document> cover
            ) {
                Set = set;
                Cover = cover;
            }
            
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

        public sealed class MultiTag : Record<MultiTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3407e51b;
            
            public T.StickerSet Set { get; }
            public Arr<T.Document> Covers { get; }
            
            public MultiTag(
                Some<T.StickerSet> set,
                Some<Arr<T.Document>> covers
            ) {
                Set = set;
                Covers = covers;
            }
            
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
                case 0x6410a5d2: return (StickerSetCovered) Tag.DeserializeTag(br);
                case 0x3407e51b: return (StickerSetCovered) MultiTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x6410a5d2, 0x3407e51b });
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

        public bool Equals(StickerSetCovered other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is StickerSetCovered x && Equals(x);
        public static bool operator ==(StickerSetCovered a, StickerSetCovered b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(StickerSetCovered a, StickerSetCovered b) => !(a == b);

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

        public int CompareTo(StickerSetCovered other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is StickerSetCovered x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSetCovered a, StickerSetCovered b) => a.CompareTo(b) <= 0;
        public static bool operator <(StickerSetCovered a, StickerSetCovered b) => a.CompareTo(b) < 0;
        public static bool operator >(StickerSetCovered a, StickerSetCovered b) => a.CompareTo(b) > 0;
        public static bool operator >=(StickerSetCovered a, StickerSetCovered b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}