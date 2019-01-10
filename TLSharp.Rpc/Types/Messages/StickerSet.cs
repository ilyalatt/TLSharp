using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class StickerSet : ITlType, IEquatable<StickerSet>, IComparable<StickerSet>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb60a24a6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.StickerSet Set { get; }
            public Arr<T.StickerPack> Packs { get; }
            public Arr<T.Document> Documents { get; }
            
            public Tag(
                Some<T.StickerSet> set,
                Some<Arr<T.StickerPack>> packs,
                Some<Arr<T.Document>> documents
            ) {
                Set = set;
                Packs = packs;
                Documents = documents;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Set, bw, WriteSerializable);
                Write(Packs, bw, WriteVector<T.StickerPack>(WriteSerializable));
                Write(Documents, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var set = Read(br, T.StickerSet.Deserialize);
                var packs = Read(br, ReadVector(T.StickerPack.Deserialize));
                var documents = Read(br, ReadVector(T.Document.Deserialize));
                return new Tag(set, packs, documents);
            }
        }

        readonly ITlTypeTag _tag;
        StickerSet(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator StickerSet(Tag tag) => new StickerSet(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static StickerSet Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (StickerSet) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(StickerSet other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is StickerSet x && Equals(x);
        public static bool operator ==(StickerSet a, StickerSet b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(StickerSet a, StickerSet b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(StickerSet other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is StickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSet a, StickerSet b) => a.CompareTo(b) <= 0;
        public static bool operator <(StickerSet a, StickerSet b) => a.CompareTo(b) < 0;
        public static bool operator >(StickerSet a, StickerSet b) => a.CompareTo(b) > 0;
        public static bool operator >=(StickerSet a, StickerSet b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}