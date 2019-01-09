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
        public sealed class PartTag : Record<PartTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8dee6c44;
            
            public Arr<T.PageBlock> Blocks { get; }
            public Arr<T.Photo> Photos { get; }
            public Arr<T.Document> Videos { get; }
            
            public PartTag(
                Some<Arr<T.PageBlock>> blocks,
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.Document>> videos
            ) {
                Blocks = blocks;
                Photos = photos;
                Videos = videos;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Blocks, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Photos, bw, WriteVector<T.Photo>(WriteSerializable));
                Write(Videos, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static PartTag DeserializeTag(BinaryReader br)
            {
                var blocks = Read(br, ReadVector(T.PageBlock.Deserialize));
                var photos = Read(br, ReadVector(T.Photo.Deserialize));
                var videos = Read(br, ReadVector(T.Document.Deserialize));
                return new PartTag(blocks, photos, videos);
            }
        }

        public sealed class FullTag : Record<FullTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xd7a19d69;
            
            public Arr<T.PageBlock> Blocks { get; }
            public Arr<T.Photo> Photos { get; }
            public Arr<T.Document> Videos { get; }
            
            public FullTag(
                Some<Arr<T.PageBlock>> blocks,
                Some<Arr<T.Photo>> photos,
                Some<Arr<T.Document>> videos
            ) {
                Blocks = blocks;
                Photos = photos;
                Videos = videos;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Blocks, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Photos, bw, WriteVector<T.Photo>(WriteSerializable));
                Write(Videos, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static FullTag DeserializeTag(BinaryReader br)
            {
                var blocks = Read(br, ReadVector(T.PageBlock.Deserialize));
                var photos = Read(br, ReadVector(T.Photo.Deserialize));
                var videos = Read(br, ReadVector(T.Document.Deserialize));
                return new FullTag(blocks, photos, videos);
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
                case 0x8dee6c44: return (Page) PartTag.DeserializeTag(br);
                case 0xd7a19d69: return (Page) FullTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x8dee6c44, 0xd7a19d69 });
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

        public bool Equals(Page other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Page x && Equals(x);
        public static bool operator ==(Page a, Page b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Page a, Page b) => !(a == b);

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

        public int CompareTo(Page other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Page x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Page a, Page b) => a.CompareTo(b) <= 0;
        public static bool operator <(Page a, Page b) => a.CompareTo(b) < 0;
        public static bool operator >(Page a, Page b) => a.CompareTo(b) > 0;
        public static bool operator >=(Page a, Page b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}