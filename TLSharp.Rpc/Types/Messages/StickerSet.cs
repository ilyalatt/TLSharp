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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb60a24a6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.StickerSet Set;
            public readonly Arr<T.StickerPack> Packs;
            public readonly Arr<T.Document> Documents;
            
            public Tag(
                Some<T.StickerSet> set,
                Some<Arr<T.StickerPack>> packs,
                Some<Arr<T.Document>> documents
            ) {
                Set = set;
                Packs = packs;
                Documents = documents;
            }
            
            (T.StickerSet, Arr<T.StickerPack>, Arr<T.Document>) CmpTuple =>
                (Set, Packs, Documents);

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

            public override string ToString() => $"(Set: {Set}, Packs: {Packs}, Documents: {Documents})";
            
            
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(StickerSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is StickerSet x && Equals(x);
        public static bool operator ==(StickerSet x, StickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(StickerSet x, StickerSet y) => !(x == y);

        public int CompareTo(StickerSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is StickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSet x, StickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(StickerSet x, StickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(StickerSet x, StickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(StickerSet x, StickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"StickerSet.{_tag.GetType().Name}{_tag}";
    }
}