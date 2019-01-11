using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class FoundGif : ITlType, IEquatable<FoundGif>, IComparable<FoundGif>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x162ecc1f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public string ThumbUrl { get; }
            public string ContentUrl { get; }
            public string ContentType { get; }
            public int W { get; }
            public int H { get; }
            
            public Tag(
                Some<string> url,
                Some<string> thumbUrl,
                Some<string> contentUrl,
                Some<string> contentType,
                int w,
                int h
            ) {
                Url = url;
                ThumbUrl = thumbUrl;
                ContentUrl = contentUrl;
                ContentType = contentType;
                W = w;
                H = h;
            }
            
            (string, string, string, string, int, int) CmpTuple =>
                (Url, ThumbUrl, ContentUrl, ContentType, W, H);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, ThumbUrl: {ThumbUrl}, ContentUrl: {ContentUrl}, ContentType: {ContentType}, W: {W}, H: {H})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(ThumbUrl, bw, WriteString);
                Write(ContentUrl, bw, WriteString);
                Write(ContentType, bw, WriteString);
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var thumbUrl = Read(br, ReadString);
                var contentUrl = Read(br, ReadString);
                var contentType = Read(br, ReadString);
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                return new Tag(url, thumbUrl, contentUrl, contentType, w, h);
            }
        }

        public sealed class CachedTag : ITlTypeTag, IEquatable<CachedTag>, IComparable<CachedTag>, IComparable
        {
            internal const uint TypeNumber = 0x9c750409;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public T.Photo Photo { get; }
            public T.Document Document { get; }
            
            public CachedTag(
                Some<string> url,
                Some<T.Photo> photo,
                Some<T.Document> document
            ) {
                Url = url;
                Photo = photo;
                Document = document;
            }
            
            (string, T.Photo, T.Document) CmpTuple =>
                (Url, Photo, Document);

            public bool Equals(CachedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CachedTag x && Equals(x);
            public static bool operator ==(CachedTag x, CachedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CachedTag x, CachedTag y) => !(x == y);

            public int CompareTo(CachedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is CachedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CachedTag x, CachedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CachedTag x, CachedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CachedTag x, CachedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CachedTag x, CachedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, Photo: {Photo}, Document: {Document})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Photo, bw, WriteSerializable);
                Write(Document, bw, WriteSerializable);
            }
            
            internal static CachedTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var photo = Read(br, T.Photo.Deserialize);
                var document = Read(br, T.Document.Deserialize);
                return new CachedTag(url, photo, document);
            }
        }

        readonly ITlTypeTag _tag;
        FoundGif(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FoundGif(Tag tag) => new FoundGif(tag);
        public static explicit operator FoundGif(CachedTag tag) => new FoundGif(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FoundGif Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (FoundGif) Tag.DeserializeTag(br);
                case CachedTag.TypeNumber: return (FoundGif) CachedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, CachedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<CachedTag, T> cachedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case CachedTag x when cachedTag != null: return cachedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<CachedTag, T> cachedTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            cachedTag ?? throw new ArgumentNullException(nameof(cachedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case CachedTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(FoundGif other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is FoundGif x && Equals(x);
        public static bool operator ==(FoundGif x, FoundGif y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FoundGif x, FoundGif y) => !(x == y);

        public int CompareTo(FoundGif other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FoundGif x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FoundGif x, FoundGif y) => x.CompareTo(y) <= 0;
        public static bool operator <(FoundGif x, FoundGif y) => x.CompareTo(y) < 0;
        public static bool operator >(FoundGif x, FoundGif y) => x.CompareTo(y) > 0;
        public static bool operator >=(FoundGif x, FoundGif y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FoundGif.{_tag.GetType().Name}{_tag}";
    }
}