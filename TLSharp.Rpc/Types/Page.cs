using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Page : ITlType, IEquatable<Page>, IComparable<Page>, IComparable
    {
        public sealed class PartTag : ITlTypeTag, IEquatable<PartTag>, IComparable<PartTag>, IComparable
        {
            internal const uint TypeNumber = 0x8e3f9ebe;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.PageBlock> Blocks;
            public readonly Arr<T.Photo> Photos;
            public readonly Arr<T.Document> Documents;
            
            public PartTag(
                Some<Arr<T.PageBlock>> blocks,
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.Document>> documents
            ) {
                Blocks = blocks;
                Photos = photos;
                Documents = documents;
            }
            
            (Arr<T.PageBlock>, Arr<T.Photo>, Arr<T.Document>) CmpTuple =>
                (Blocks, Photos, Documents);

            public bool Equals(PartTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PartTag x && Equals(x);
            public static bool operator ==(PartTag x, PartTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PartTag x, PartTag y) => !(x == y);

            public int CompareTo(PartTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PartTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PartTag x, PartTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PartTag x, PartTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PartTag x, PartTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PartTag x, PartTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Blocks: {Blocks}, Photos: {Photos}, Documents: {Documents})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Blocks, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Photos, bw, WriteVector<T.Photo>(WriteSerializable));
                Write(Documents, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static PartTag DeserializeTag(BinaryReader br)
            {
                var blocks = Read(br, ReadVector(T.PageBlock.Deserialize));
                var photos = Read(br, ReadVector(T.Photo.Deserialize));
                var documents = Read(br, ReadVector(T.Document.Deserialize));
                return new PartTag(blocks, photos, documents);
            }
        }

        public sealed class FullTag : ITlTypeTag, IEquatable<FullTag>, IComparable<FullTag>, IComparable
        {
            internal const uint TypeNumber = 0x556ec7aa;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.PageBlock> Blocks;
            public readonly Arr<T.Photo> Photos;
            public readonly Arr<T.Document> Documents;
            
            public FullTag(
                Some<Arr<T.PageBlock>> blocks,
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.Document>> documents
            ) {
                Blocks = blocks;
                Photos = photos;
                Documents = documents;
            }
            
            (Arr<T.PageBlock>, Arr<T.Photo>, Arr<T.Document>) CmpTuple =>
                (Blocks, Photos, Documents);

            public bool Equals(FullTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FullTag x && Equals(x);
            public static bool operator ==(FullTag x, FullTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FullTag x, FullTag y) => !(x == y);

            public int CompareTo(FullTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FullTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FullTag x, FullTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FullTag x, FullTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FullTag x, FullTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FullTag x, FullTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Blocks: {Blocks}, Photos: {Photos}, Documents: {Documents})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Blocks, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Photos, bw, WriteVector<T.Photo>(WriteSerializable));
                Write(Documents, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static FullTag DeserializeTag(BinaryReader br)
            {
                var blocks = Read(br, ReadVector(T.PageBlock.Deserialize));
                var photos = Read(br, ReadVector(T.Photo.Deserialize));
                var documents = Read(br, ReadVector(T.Document.Deserialize));
                return new FullTag(blocks, photos, documents);
            }
        }

        readonly ITlTypeTag _tag;
        Page(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Page(PartTag tag) => new Page(tag);
        public static explicit operator Page(FullTag tag) => new Page(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Page Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case PartTag.TypeNumber: return (Page) PartTag.DeserializeTag(br);
                case FullTag.TypeNumber: return (Page) FullTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { PartTag.TypeNumber, FullTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<PartTag, T> partTag = null,
            Func<FullTag, T> fullTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case PartTag x when partTag != null: return partTag(x);
                case FullTag x when fullTag != null: return fullTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<PartTag, T> partTag,
            Func<FullTag, T> fullTag
        ) => Match(
            () => throw new Exception("WTF"),
            partTag ?? throw new ArgumentNullException(nameof(partTag)),
            fullTag ?? throw new ArgumentNullException(nameof(fullTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case PartTag _: return 0;
                case FullTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Page other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Page x && Equals(x);
        public static bool operator ==(Page x, Page y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Page x, Page y) => !(x == y);

        public int CompareTo(Page other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Page x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Page x, Page y) => x.CompareTo(y) <= 0;
        public static bool operator <(Page x, Page y) => x.CompareTo(y) < 0;
        public static bool operator >(Page x, Page y) => x.CompareTo(y) > 0;
        public static bool operator >=(Page x, Page y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Page.{_tag.GetType().Name}{_tag}";
    }
}