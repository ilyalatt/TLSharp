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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9bebaeb9;
            
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

        public sealed class MediaTag : Record<MediaTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x17db940b;
            
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
                case 0x9bebaeb9: return (BotInlineResult) Tag.DeserializeTag(br);
                case 0x17db940b: return (BotInlineResult) MediaTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x9bebaeb9, 0x17db940b });
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

        public bool Equals(BotInlineResult other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is BotInlineResult x && Equals(x);
        public static bool operator ==(BotInlineResult a, BotInlineResult b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(BotInlineResult a, BotInlineResult b) => !(a == b);

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

        public int CompareTo(BotInlineResult other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotInlineResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotInlineResult a, BotInlineResult b) => a.CompareTo(b) <= 0;
        public static bool operator <(BotInlineResult a, BotInlineResult b) => a.CompareTo(b) < 0;
        public static bool operator >(BotInlineResult a, BotInlineResult b) => a.CompareTo(b) > 0;
        public static bool operator >=(BotInlineResult a, BotInlineResult b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}