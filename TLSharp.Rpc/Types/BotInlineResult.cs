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
            internal const uint TypeNumber = 0x11965f3a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Id;
            public readonly string Type;
            public readonly Option<string> Title;
            public readonly Option<string> Description;
            public readonly Option<string> Url;
            public readonly Option<T.WebDocument> Thumb;
            public readonly Option<T.WebDocument> Content;
            public readonly T.BotInlineMessage SendMessage;
            
            public Tag(
                Some<string> id,
                Some<string> type,
                Option<string> title,
                Option<string> description,
                Option<string> url,
                Option<T.WebDocument> thumb,
                Option<T.WebDocument> content,
                Some<T.BotInlineMessage> sendMessage
            ) {
                Id = id;
                Type = type;
                Title = title;
                Description = description;
                Url = url;
                Thumb = thumb;
                Content = content;
                SendMessage = sendMessage;
            }
            
            (string, string, Option<string>, Option<string>, Option<string>, Option<T.WebDocument>, Option<T.WebDocument>, T.BotInlineMessage) CmpTuple =>
                (Id, Type, Title, Description, Url, Thumb, Content, SendMessage);

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

            public override string ToString() => $"(Id: {Id}, Type: {Type}, Title: {Title}, Description: {Description}, Url: {Url}, Thumb: {Thumb}, Content: {Content}, SendMessage: {SendMessage})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Title) | MaskBit(2, Description) | MaskBit(3, Url) | MaskBit(4, Thumb) | MaskBit(5, Content), bw, WriteInt);
                Write(Id, bw, WriteString);
                Write(Type, bw, WriteString);
                Write(Title, bw, WriteOption<string>(WriteString));
                Write(Description, bw, WriteOption<string>(WriteString));
                Write(Url, bw, WriteOption<string>(WriteString));
                Write(Thumb, bw, WriteOption<T.WebDocument>(WriteSerializable));
                Write(Content, bw, WriteOption<T.WebDocument>(WriteSerializable));
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
                var thumb = Read(br, ReadOption(flags, 4, T.WebDocument.Deserialize));
                var content = Read(br, ReadOption(flags, 5, T.WebDocument.Deserialize));
                var sendMessage = Read(br, T.BotInlineMessage.Deserialize);
                return new Tag(id, type, title, description, url, thumb, content, sendMessage);
            }
        }

        public sealed class MediaTag : ITlTypeTag, IEquatable<MediaTag>, IComparable<MediaTag>, IComparable
        {
            internal const uint TypeNumber = 0x17db940b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Id;
            public readonly string Type;
            public readonly Option<T.Photo> Photo;
            public readonly Option<T.Document> Document;
            public readonly Option<string> Title;
            public readonly Option<string> Description;
            public readonly T.BotInlineMessage SendMessage;
            
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

            public bool Equals(MediaTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MediaTag x && Equals(x);
            public static bool operator ==(MediaTag x, MediaTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaTag x, MediaTag y) => !(x == y);

            public int CompareTo(MediaTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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

        public bool Equals(BotInlineResult other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is BotInlineResult x && Equals(x);
        public static bool operator ==(BotInlineResult x, BotInlineResult y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotInlineResult x, BotInlineResult y) => !(x == y);

        public int CompareTo(BotInlineResult other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is BotInlineResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) < 0;
        public static bool operator >(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotInlineResult x, BotInlineResult y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotInlineResult.{_tag.GetType().Name}{_tag}";
    }
}