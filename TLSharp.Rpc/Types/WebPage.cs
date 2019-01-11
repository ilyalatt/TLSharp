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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xeb1477e8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            long CmpTuple =>
                Id;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
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

        public sealed class PendingTag : ITlTypeTag, IEquatable<PendingTag>, IComparable<PendingTag>, IComparable
        {
            internal const uint TypeNumber = 0xc586da1c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public int Date { get; }
            
            public PendingTag(
                long id,
                int date
            ) {
                Id = id;
                Date = date;
            }
            
            (long, int) CmpTuple =>
                (Id, Date);

            public bool Equals(PendingTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PendingTag x && Equals(x);
            public static bool operator ==(PendingTag x, PendingTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PendingTag x, PendingTag y) => !(x == y);

            public int CompareTo(PendingTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PendingTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PendingTag x, PendingTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PendingTag x, PendingTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PendingTag x, PendingTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PendingTag x, PendingTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Date: {Date})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x5f07b4bc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (long, string, string, int, Option<string>, Option<string>, Option<string>, Option<string>, Option<T.Photo>, Option<string>, Option<string>, Option<int>, Option<int>, Option<int>, Option<string>, Option<T.Document>, Option<T.Page>) CmpTuple =>
                (Id, Url, DisplayUrl, Hash, Type, SiteName, Title, Description, Photo, EmbedUrl, EmbedType, EmbedWidth, EmbedHeight, Duration, Author, Document, CachedPage);

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

            public override string ToString() => $"(Id: {Id}, Url: {Url}, DisplayUrl: {DisplayUrl}, Hash: {Hash}, Type: {Type}, SiteName: {SiteName}, Title: {Title}, Description: {Description}, Photo: {Photo}, EmbedUrl: {EmbedUrl}, EmbedType: {EmbedType}, EmbedWidth: {EmbedWidth}, EmbedHeight: {EmbedHeight}, Duration: {Duration}, Author: {Author}, Document: {Document}, CachedPage: {CachedPage})";
            
            
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

        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0x85849473;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NotModifiedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NotModifiedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NotModifiedTag x && Equals(x);
            public static bool operator ==(NotModifiedTag x, NotModifiedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NotModifiedTag x, NotModifiedTag y) => !(x == y);

            public int CompareTo(NotModifiedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NotModifiedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
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
                case EmptyTag.TypeNumber: return (WebPage) EmptyTag.DeserializeTag(br);
                case PendingTag.TypeNumber: return (WebPage) PendingTag.DeserializeTag(br);
                case Tag.TypeNumber: return (WebPage) Tag.DeserializeTag(br);
                case NotModifiedTag.TypeNumber: return (WebPage) NotModifiedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, PendingTag.TypeNumber, Tag.TypeNumber, NotModifiedTag.TypeNumber });
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

        public bool Equals(WebPage other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is WebPage x && Equals(x);
        public static bool operator ==(WebPage x, WebPage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(WebPage x, WebPage y) => !(x == y);

        public int CompareTo(WebPage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is WebPage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebPage x, WebPage y) => x.CompareTo(y) <= 0;
        public static bool operator <(WebPage x, WebPage y) => x.CompareTo(y) < 0;
        public static bool operator >(WebPage x, WebPage y) => x.CompareTo(y) > 0;
        public static bool operator >=(WebPage x, WebPage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"WebPage.{_tag.GetType().Name}{_tag}";
    }
}