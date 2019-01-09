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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x162ecc1f;
            
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

        public sealed class CachedTag : Record<CachedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9c750409;
            
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
                case 0x162ecc1f: return (FoundGif) Tag.DeserializeTag(br);
                case 0x9c750409: return (FoundGif) CachedTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x162ecc1f, 0x9c750409 });
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

        public bool Equals(FoundGif other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is FoundGif x && Equals(x);
        public static bool operator ==(FoundGif a, FoundGif b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(FoundGif a, FoundGif b) => !(a == b);

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

        public int CompareTo(FoundGif other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FoundGif x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FoundGif a, FoundGif b) => a.CompareTo(b) <= 0;
        public static bool operator <(FoundGif a, FoundGif b) => a.CompareTo(b) < 0;
        public static bool operator >(FoundGif a, FoundGif b) => a.CompareTo(b) > 0;
        public static bool operator >=(FoundGif a, FoundGif b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}