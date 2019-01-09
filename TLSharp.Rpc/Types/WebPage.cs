using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class WebPage : ITlType, IEquatable<WebPage>, IComparable<WebPage>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xeb1477e8;
            
            public long Id { get; }
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                return new EmptyTag(id);
            }
        }

        public sealed class PendingTag : Record<PendingTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc586da1c;
            
            public long Id { get; }
            public int Date { get; }
            
            public PendingTag(
                long id,
                int date
            ) {
                Id = id;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Date, bw, WriteInt);
            }
            
            internal static PendingTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                return new PendingTag(id, date);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x5f07b4bc;
            
            public long Id { get; }
            public string Url { get; }
            public string DisplayUrl { get; }
            public int Hash { get; }
            public Option<string> Type { get; }
            public Option<string> SiteName { get; }
            public Option<string> Title { get; }
            public Option<string> Description { get; }
            public Option<T.Photo> Photo { get; }
            public Option<string> EmbedUrl { get; }
            public Option<string> EmbedType { get; }
            public Option<int> EmbedWidth { get; }
            public Option<int> EmbedHeight { get; }
            public Option<int> Duration { get; }
            public Option<string> Author { get; }
            public Option<T.Document> Document { get; }
            public Option<T.Page> CachedPage { get; }
            
            public Tag(
                long id,
                Some<string> url,
                Some<string> displayUrl,
                int hash,
                Option<string> type,
                Option<string> siteName,
                Option<string> title,
                Option<string> description,
                Option<T.Photo> photo,
                Option<string> embedUrl,
                Option<string> embedType,
                Option<int> embedWidth,
                Option<int> embedHeight,
                Option<int> duration,
                Option<string> author,
                Option<T.Document> document,
                Option<T.Page> cachedPage
            ) {
                Id = id;
                Url = url;
                DisplayUrl = displayUrl;
                Hash = hash;
                Type = type;
                SiteName = siteName;
                Title = title;
                Description = description;
                Photo = photo;
                EmbedUrl = embedUrl;
                EmbedType = embedType;
                EmbedWidth = embedWidth;
                EmbedHeight = embedHeight;
                Duration = duration;
                Author = author;
                Document = document;
                CachedPage = cachedPage;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Type) | MaskBit(1, SiteName) | MaskBit(2, Title) | MaskBit(3, Description) | MaskBit(4, Photo) | MaskBit(5, EmbedUrl) | MaskBit(5, EmbedType) | MaskBit(6, EmbedWidth) | MaskBit(6, EmbedHeight) | MaskBit(7, Duration) | MaskBit(8, Author) | MaskBit(9, Document) | MaskBit(10, CachedPage), bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(Url, bw, WriteString);
                Write(DisplayUrl, bw, WriteString);
                Write(Hash, bw, WriteInt);
                Write(Type, bw, WriteOption<string>(WriteString));
                Write(SiteName, bw, WriteOption<string>(WriteString));
                Write(Title, bw, WriteOption<string>(WriteString));
                Write(Description, bw, WriteOption<string>(WriteString));
                Write(Photo, bw, WriteOption<T.Photo>(WriteSerializable));
                Write(EmbedUrl, bw, WriteOption<string>(WriteString));
                Write(EmbedType, bw, WriteOption<string>(WriteString));
                Write(EmbedWidth, bw, WriteOption<int>(WriteInt));
                Write(EmbedHeight, bw, WriteOption<int>(WriteInt));
                Write(Duration, bw, WriteOption<int>(WriteInt));
                Write(Author, bw, WriteOption<string>(WriteString));
                Write(Document, bw, WriteOption<T.Document>(WriteSerializable));
                Write(CachedPage, bw, WriteOption<T.Page>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadLong);
                var url = Read(br, ReadString);
                var displayUrl = Read(br, ReadString);
                var hash = Read(br, ReadInt);
                var type = Read(br, ReadOption(flags, 0, ReadString));
                var siteName = Read(br, ReadOption(flags, 1, ReadString));
                var title = Read(br, ReadOption(flags, 2, ReadString));
                var description = Read(br, ReadOption(flags, 3, ReadString));
                var photo = Read(br, ReadOption(flags, 4, T.Photo.Deserialize));
                var embedUrl = Read(br, ReadOption(flags, 5, ReadString));
                var embedType = Read(br, ReadOption(flags, 5, ReadString));
                var embedWidth = Read(br, ReadOption(flags, 6, ReadInt));
                var embedHeight = Read(br, ReadOption(flags, 6, ReadInt));
                var duration = Read(br, ReadOption(flags, 7, ReadInt));
                var author = Read(br, ReadOption(flags, 8, ReadString));
                var document = Read(br, ReadOption(flags, 9, T.Document.Deserialize));
                var cachedPage = Read(br, ReadOption(flags, 10, T.Page.Deserialize));
                return new Tag(id, url, displayUrl, hash, type, siteName, title, description, photo, embedUrl, embedType, embedWidth, embedHeight, duration, author, document, cachedPage);
            }
        }

        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x85849473;
            

            
            public NotModifiedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        readonly ITlTypeTag _tag;
        WebPage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator WebPage(EmptyTag tag) => new WebPage(tag);
        public static explicit operator WebPage(PendingTag tag) => new WebPage(tag);
        public static explicit operator WebPage(Tag tag) => new WebPage(tag);
        public static explicit operator WebPage(NotModifiedTag tag) => new WebPage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static WebPage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xeb1477e8: return (WebPage) EmptyTag.DeserializeTag(br);
                case 0xc586da1c: return (WebPage) PendingTag.DeserializeTag(br);
                case 0x5f07b4bc: return (WebPage) Tag.DeserializeTag(br);
                case 0x85849473: return (WebPage) NotModifiedTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xeb1477e8, 0xc586da1c, 0x5f07b4bc, 0x85849473 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<PendingTag, T> pendingTag = null,
            Func<Tag, T> tag = null,
            Func<NotModifiedTag, T> notModifiedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case PendingTag x when pendingTag != null: return pendingTag(x);
                case Tag x when tag != null: return tag(x);
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<PendingTag, T> pendingTag,
            Func<Tag, T> tag,
            Func<NotModifiedTag, T> notModifiedTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            pendingTag ?? throw new ArgumentNullException(nameof(pendingTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag))
        );

        public bool Equals(WebPage other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is WebPage x && Equals(x);
        public static bool operator ==(WebPage a, WebPage b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(WebPage a, WebPage b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case PendingTag _: return 1;
                case Tag _: return 2;
                case NotModifiedTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(WebPage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is WebPage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebPage a, WebPage b) => a.CompareTo(b) <= 0;
        public static bool operator <(WebPage a, WebPage b) => a.CompareTo(b) < 0;
        public static bool operator >(WebPage a, WebPage b) => a.CompareTo(b) > 0;
        public static bool operator >=(WebPage a, WebPage b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}