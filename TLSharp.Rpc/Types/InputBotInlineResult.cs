using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputBotInlineResult : ITlType, IEquatable<InputBotInlineResult>, IComparable<InputBotInlineResult>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2cbbe15a;
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
            public T.InputBotInlineMessage SendMessage { get; }
            
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
                Some<T.InputBotInlineMessage> sendMessage
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
                var sendMessage = Read(br, T.InputBotInlineMessage.Deserialize);
                return new Tag(id, type, title, description, url, thumbUrl, contentUrl, contentType, w, h, duration, sendMessage);
            }
        }

        public sealed class PhotoTag : Record<PhotoTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa8d864a7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string Type { get; }
            public T.InputPhoto Photo { get; }
            public T.InputBotInlineMessage SendMessage { get; }
            
            public PhotoTag(
                Some<string> id,
                Some<string> type,
                Some<T.InputPhoto> photo,
                Some<T.InputBotInlineMessage> sendMessage
            ) {
                Id = id;
                Type = type;
                Photo = photo;
                SendMessage = sendMessage;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteString);
                Write(Type, bw, WriteString);
                Write(Photo, bw, WriteSerializable);
                Write(SendMessage, bw, WriteSerializable);
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadString);
                var type = Read(br, ReadString);
                var photo = Read(br, T.InputPhoto.Deserialize);
                var sendMessage = Read(br, T.InputBotInlineMessage.Deserialize);
                return new PhotoTag(id, type, photo, sendMessage);
            }
        }

        public sealed class DocumentTag : Record<DocumentTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xfff8fdc4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string Type { get; }
            public Option<string> Title { get; }
            public Option<string> Description { get; }
            public T.InputDocument Document { get; }
            public T.InputBotInlineMessage SendMessage { get; }
            
            public DocumentTag(
                Some<string> id,
                Some<string> type,
                Option<string> title,
                Option<string> description,
                Some<T.InputDocument> document,
                Some<T.InputBotInlineMessage> sendMessage
            ) {
                Id = id;
                Type = type;
                Title = title;
                Description = description;
                Document = document;
                SendMessage = sendMessage;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Title) | MaskBit(2, Description), bw, WriteInt);
                Write(Id, bw, WriteString);
                Write(Type, bw, WriteString);
                Write(Title, bw, WriteOption<string>(WriteString));
                Write(Description, bw, WriteOption<string>(WriteString));
                Write(Document, bw, WriteSerializable);
                Write(SendMessage, bw, WriteSerializable);
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadString);
                var type = Read(br, ReadString);
                var title = Read(br, ReadOption(flags, 1, ReadString));
                var description = Read(br, ReadOption(flags, 2, ReadString));
                var document = Read(br, T.InputDocument.Deserialize);
                var sendMessage = Read(br, T.InputBotInlineMessage.Deserialize);
                return new DocumentTag(id, type, title, description, document, sendMessage);
            }
        }

        public sealed class GameTag : Record<GameTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x4fa417f2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Id { get; }
            public string ShortName { get; }
            public T.InputBotInlineMessage SendMessage { get; }
            
            public GameTag(
                Some<string> id,
                Some<string> shortName,
                Some<T.InputBotInlineMessage> sendMessage
            ) {
                Id = id;
                ShortName = shortName;
                SendMessage = sendMessage;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteString);
                Write(ShortName, bw, WriteString);
                Write(SendMessage, bw, WriteSerializable);
            }
            
            internal static GameTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadString);
                var shortName = Read(br, ReadString);
                var sendMessage = Read(br, T.InputBotInlineMessage.Deserialize);
                return new GameTag(id, shortName, sendMessage);
            }
        }

        readonly ITlTypeTag _tag;
        InputBotInlineResult(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputBotInlineResult(Tag tag) => new InputBotInlineResult(tag);
        public static explicit operator InputBotInlineResult(PhotoTag tag) => new InputBotInlineResult(tag);
        public static explicit operator InputBotInlineResult(DocumentTag tag) => new InputBotInlineResult(tag);
        public static explicit operator InputBotInlineResult(GameTag tag) => new InputBotInlineResult(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputBotInlineResult Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputBotInlineResult) Tag.DeserializeTag(br);
                case PhotoTag.TypeNumber: return (InputBotInlineResult) PhotoTag.DeserializeTag(br);
                case DocumentTag.TypeNumber: return (InputBotInlineResult) DocumentTag.DeserializeTag(br);
                case GameTag.TypeNumber: return (InputBotInlineResult) GameTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, PhotoTag.TypeNumber, DocumentTag.TypeNumber, GameTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<PhotoTag, T> photoTag = null,
            Func<DocumentTag, T> documentTag = null,
            Func<GameTag, T> gameTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case PhotoTag x when photoTag != null: return photoTag(x);
                case DocumentTag x when documentTag != null: return documentTag(x);
                case GameTag x when gameTag != null: return gameTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<PhotoTag, T> photoTag,
            Func<DocumentTag, T> documentTag,
            Func<GameTag, T> gameTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            photoTag ?? throw new ArgumentNullException(nameof(photoTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag)),
            gameTag ?? throw new ArgumentNullException(nameof(gameTag))
        );

        public bool Equals(InputBotInlineResult other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputBotInlineResult x && Equals(x);
        public static bool operator ==(InputBotInlineResult a, InputBotInlineResult b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputBotInlineResult a, InputBotInlineResult b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case PhotoTag _: return 1;
                case DocumentTag _: return 2;
                case GameTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputBotInlineResult other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputBotInlineResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputBotInlineResult a, InputBotInlineResult b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputBotInlineResult a, InputBotInlineResult b) => a.CompareTo(b) < 0;
        public static bool operator >(InputBotInlineResult a, InputBotInlineResult b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputBotInlineResult a, InputBotInlineResult b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}