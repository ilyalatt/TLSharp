using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class BotInlineResult : ITlType, IEquatable<BotInlineResult>, IComparable<BotInlineResult>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9bebaeb9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string Type { get; }
            public Option<string> Title { get; }
            public Option<string> Description { get; }
            public Option<string> Url { get; }
            public Option<string> ThumbUrl { get; }
            public Option<string> ContentUrl { get; }
            public Option<string> ContentType { get; }
            public Option<int> W { get; }
            public Option<int> H { get; }
            public Option<int> Duration { get; }
            public T.BotInlineMessage SendMessage { get; }
            
            public Tag(
                Some<string> id,
                Some<string> type,
                Option<string> title,
                Option<string> description,
                Option<string> url,
                Option<string> thumbUrl,
                Option<string> contentUrl,
                Option<string> contentType,
                Option<int> w,
                Option<int> h,
                Option<int> duration,
                Some<T.BotInlineMessage> sendMessage
            ) {
                Id = id;
                Type = type;
                Title = title;
                Description = description;
                Url = url;
                ThumbUrl = thumbUrl;
                ContentUrl = contentUrl;
                ContentType = contentType;
                W = w;
                H = h;
                Duration = duration;
                SendMessage = sendMessage;
            }
            
            (string, string, Option<string>, Option<string>, Option<string>, Option<string>, Option<string>, Option<string>, Option<int>, Option<int>, Option<int>, T.BotInlineMessage) CmpTuple =>
                (Id, Type, Title, Description, Url, ThumbUrl, ContentUrl, ContentType, W, H, Duration, SendMessage);

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

            public override string ToString() => $"(Id: {Id}, Type: {Type}, Title: {Title}, Description: {Description}, Url: {Url}, ThumbUrl: {ThumbUrl}, ContentUrl: {ContentUrl}, ContentType: {ContentType}, W: {W}, H: {H}, Duration: {Duration}, SendMessage: {SendMessage})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Title) | MaskBit(2, Description) | MaskBit(3, Url) | MaskBit(4, ThumbUrl) | MaskBit(5, ContentUrl) | MaskBit(5, ContentType) | MaskBit(6, W) | MaskBit(6, H) | MaskBit(7, Duration), bw, WriteInt);
                Write(Id, bw, WriteString);
                Write(Type, bw, WriteString);
                Write(Title, bw, WriteOption<string>(WriteString));
                Write(Description, bw, WriteOption<string>(WriteString));
                Write(Url, bw, WriteOption<string>(WriteString));
                Write(ThumbUrl, bw, WriteOption<string>(WriteString));
                Write(ContentUrl, bw, WriteOption<string>(WriteString));
                Write(ContentType, bw, WriteOption<string>(WriteString));
                Write(W, bw, WriteOption<int>(WriteInt));
                Write(H, bw, WriteOption<int>(WriteInt));
                Write(Duration, bw, WriteOption<int>(WriteInt));
                Write(SendMessage, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadString);
                var type = Read(br, ReadString);
                var title = Read(br, ReadOption(flags, 1, ReadString));
                var description = Read(br, ReadOption(flags, 2, ReadString));
                var url = Read(br, ReadOption(flags, 3, ReadString));
                var thumbUrl = Read(br, ReadOption(flags, 4, ReadString));
                var contentUrl = Read(br, ReadOption(flags, 5, ReadString));
                var contentType = Read(br, ReadOption(flags, 5, ReadString));
                var w = Read(br, ReadOption(flags, 6, ReadInt));
                var h = Read(br, ReadOption(flags, 6, ReadInt));
                var duration = Read(br, ReadOption(flags, 7, ReadInt));
                var sendMessage = Read(br, T.BotInlineMessage.Deserialize);
                return new Tag(id, type, title, description, url, thumbUrl, contentUrl, contentType, w, h, duration, sendMessage);
            }
        }

        public sealed class MediaTag : ITlTypeTag, IEquatable<MediaTag>, IComparable<MediaTag>, IComparable
        {
            internal const uint TypeNumber = 0x17db940b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string Type { get; }
            public Option<T.Photo> Photo { get; }
            public Option<T.Document> Document { get; }
            public Option<string> Title { get; }
            public Option<string> Description { get; }
            public T.BotInlineMessage SendMessage { get; }
            
            public MediaTag(
                Some<string> id,
                Some<string> type,
                Option<T.Photo> photo,
                Option<T.Document> document,
                Option<string> title,
                Option<string> description,
                Some<T.BotInlineMessage> sendMessage
            ) {
                Id = id;
                Type = type;
                Photo = photo;
                Document = document;
                Title = title;
                Description = description;
                SendMessage = sendMessage;
            }
            
            (string, string, Option<T.Photo>, Option<T.Document>, Option<string>, Option<string>, T.BotInlineMessage) CmpTuple =>
                (Id, Type, Photo, Document, Title, Description, SendMessage);

            public bool Equals(MediaTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MediaTag x && Equals(x);
            public static bool operator ==(MediaTag x, MediaTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaTag x, MediaTag y) => !(x == y);

            public int CompareTo(MediaTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is MediaTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaTag x, MediaTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaTag x, MediaTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaTag x, MediaTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaTag x, MediaTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Type: {Type}, Photo: {Photo}, Document: {Document}, Title: {Title}, Description: {Description}, SendMessage: {SendMessage})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Photo) | MaskBit(1, Document) | MaskBit(2, Title) | MaskBit(3, Description), bw, WriteInt);
                Write(Id, bw, WriteString);
                Write(Type, bw, WriteString);
                Write(Photo, bw, WriteOption<T.Photo>(WriteSerializable));
                Write(Document, bw, WriteOption<T.Document>(WriteSerializable));
                Write(Title, bw, WriteOption<string>(WriteString));
                Write(Description, bw, WriteOption<string>(WriteString));
                Write(SendMessage, bw, WriteSerializable);
            }
            
            internal static MediaTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadString);
                var type = Read(br, ReadString);
                var photo = Read(br, ReadOption(flags, 0, T.Photo.Deserialize));
                var document = Read(br, ReadOption(flags, 1, T.Document.Deserialize));
                var title = Read(br, ReadOption(flags, 2, ReadString));
                var description = Read(br, ReadOption(flags, 3, ReadString));
                var sendMessage = Read(br, T.BotInlineMessage.Deserialize);
                return new MediaTag(id, type, photo, document, title, description, sendMessage);
            }
        }

        readonly ITlTypeTag _tag;
        BotInlineResult(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator BotInlineResult(Tag tag) => new BotInlineResult(tag);
        public static explicit operator BotInlineResult(MediaTag tag) => new BotInlineResult(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static BotInlineResult Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (BotInlineResult) Tag.DeserializeTag(br);
                case MediaTag.TypeNumber: return (BotInlineResult) MediaTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, MediaTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<MediaTag, T> mediaTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case MediaTag x when mediaTag != null: return mediaTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<MediaTag, T> mediaTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            mediaTag ?? throw new ArgumentNullException(nameof(mediaTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case MediaTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(BotInlineResult other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is BotInlineResult x && Equals(x);
        public static bool operator ==(BotInlineResult x, BotInlineResult y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotInlineResult x, BotInlineResult y) => !(x == y);

        public int CompareTo(BotInlineResult other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotInlineResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) < 0;
        public static bool operator >(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotInlineResult.{_tag.GetType().Name}{_tag}";
    }
}