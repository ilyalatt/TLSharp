using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputBotInlineMessage : ITlType, IEquatable<InputBotInlineMessage>, IComparable<InputBotInlineMessage>, IComparable
    {
        public sealed class MediaAutoTag : Record<MediaAutoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x292fed13;
            
            public string Caption { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaAutoTag(
                Some<string> caption,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                Caption = caption;
                ReplyMarkup = replyMarkup;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(Caption, bw, WriteString);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static MediaAutoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var caption = Read(br, ReadString);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new MediaAutoTag(caption, replyMarkup);
            }
        }

        public sealed class TextTag : Record<TextTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3dcd7a87;
            
            public bool NoWebpage { get; }
            public string Message { get; }
            public Option<Arr<T.MessageEntity>> Entities { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public TextTag(
                bool noWebpage,
                Some<string> message,
                Option<Arr<T.MessageEntity>> entities,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                NoWebpage = noWebpage;
                Message = message;
                Entities = entities;
                ReplyMarkup = replyMarkup;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, NoWebpage) | MaskBit(1, Entities) | MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(Message, bw, WriteString);
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static TextTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var noWebpage = Read(br, ReadOption(flags, 0));
                var message = Read(br, ReadString);
                var entities = Read(br, ReadOption(flags, 1, ReadVector(T.MessageEntity.Deserialize)));
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new TextTag(noWebpage, message, entities, replyMarkup);
            }
        }

        public sealed class MediaGeoTag : Record<MediaGeoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf4a59de1;
            
            public T.InputGeoPoint GeoPoint { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaGeoTag(
                Some<T.InputGeoPoint> geoPoint,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                GeoPoint = geoPoint;
                ReplyMarkup = replyMarkup;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(GeoPoint, bw, WriteSerializable);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static MediaGeoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new MediaGeoTag(geoPoint, replyMarkup);
            }
        }

        public sealed class MediaVenueTag : Record<MediaVenueTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xaaafadc8;
            
            public T.InputGeoPoint GeoPoint { get; }
            public string Title { get; }
            public string Address { get; }
            public string Provider { get; }
            public string VenueId { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaVenueTag(
                Some<T.InputGeoPoint> geoPoint,
                Some<string> title,
                Some<string> address,
                Some<string> provider,
                Some<string> venueId,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                GeoPoint = geoPoint;
                Title = title;
                Address = address;
                Provider = provider;
                VenueId = venueId;
                ReplyMarkup = replyMarkup;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(GeoPoint, bw, WriteSerializable);
                Write(Title, bw, WriteString);
                Write(Address, bw, WriteString);
                Write(Provider, bw, WriteString);
                Write(VenueId, bw, WriteString);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static MediaVenueTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                var title = Read(br, ReadString);
                var address = Read(br, ReadString);
                var provider = Read(br, ReadString);
                var venueId = Read(br, ReadString);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new MediaVenueTag(geoPoint, title, address, provider, venueId, replyMarkup);
            }
        }

        public sealed class MediaContactTag : Record<MediaContactTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x2daf01a7;
            
            public string PhoneNumber { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaContactTag(
                Some<string> phoneNumber,
                Some<string> firstName,
                Some<string> lastName,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                PhoneNumber = phoneNumber;
                FirstName = firstName;
                LastName = lastName;
                ReplyMarkup = replyMarkup;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(PhoneNumber, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static MediaContactTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var phoneNumber = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new MediaContactTag(phoneNumber, firstName, lastName, replyMarkup);
            }
        }

        public sealed class GameTag : Record<GameTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x4b425864;
            
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public GameTag(
                Option<T.ReplyMarkup> replyMarkup
            ) {
                ReplyMarkup = replyMarkup;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static GameTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new GameTag(replyMarkup);
            }
        }

        readonly ITlTypeTag _tag;
        InputBotInlineMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputBotInlineMessage(MediaAutoTag tag) => new InputBotInlineMessage(tag);
        public static explicit operator InputBotInlineMessage(TextTag tag) => new InputBotInlineMessage(tag);
        public static explicit operator InputBotInlineMessage(MediaGeoTag tag) => new InputBotInlineMessage(tag);
        public static explicit operator InputBotInlineMessage(MediaVenueTag tag) => new InputBotInlineMessage(tag);
        public static explicit operator InputBotInlineMessage(MediaContactTag tag) => new InputBotInlineMessage(tag);
        public static explicit operator InputBotInlineMessage(GameTag tag) => new InputBotInlineMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputBotInlineMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x292fed13: return (InputBotInlineMessage) MediaAutoTag.DeserializeTag(br);
                case 0x3dcd7a87: return (InputBotInlineMessage) TextTag.DeserializeTag(br);
                case 0xf4a59de1: return (InputBotInlineMessage) MediaGeoTag.DeserializeTag(br);
                case 0xaaafadc8: return (InputBotInlineMessage) MediaVenueTag.DeserializeTag(br);
                case 0x2daf01a7: return (InputBotInlineMessage) MediaContactTag.DeserializeTag(br);
                case 0x4b425864: return (InputBotInlineMessage) GameTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x292fed13, 0x3dcd7a87, 0xf4a59de1, 0xaaafadc8, 0x2daf01a7, 0x4b425864 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<MediaAutoTag, T> mediaAutoTag = null,
            Func<TextTag, T> textTag = null,
            Func<MediaGeoTag, T> mediaGeoTag = null,
            Func<MediaVenueTag, T> mediaVenueTag = null,
            Func<MediaContactTag, T> mediaContactTag = null,
            Func<GameTag, T> gameTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case MediaAutoTag x when mediaAutoTag != null: return mediaAutoTag(x);
                case TextTag x when textTag != null: return textTag(x);
                case MediaGeoTag x when mediaGeoTag != null: return mediaGeoTag(x);
                case MediaVenueTag x when mediaVenueTag != null: return mediaVenueTag(x);
                case MediaContactTag x when mediaContactTag != null: return mediaContactTag(x);
                case GameTag x when gameTag != null: return gameTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<MediaAutoTag, T> mediaAutoTag,
            Func<TextTag, T> textTag,
            Func<MediaGeoTag, T> mediaGeoTag,
            Func<MediaVenueTag, T> mediaVenueTag,
            Func<MediaContactTag, T> mediaContactTag,
            Func<GameTag, T> gameTag
        ) => Match(
            () => throw new Exception("WTF"),
            mediaAutoTag ?? throw new ArgumentNullException(nameof(mediaAutoTag)),
            textTag ?? throw new ArgumentNullException(nameof(textTag)),
            mediaGeoTag ?? throw new ArgumentNullException(nameof(mediaGeoTag)),
            mediaVenueTag ?? throw new ArgumentNullException(nameof(mediaVenueTag)),
            mediaContactTag ?? throw new ArgumentNullException(nameof(mediaContactTag)),
            gameTag ?? throw new ArgumentNullException(nameof(gameTag))
        );

        public bool Equals(InputBotInlineMessage other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputBotInlineMessage x && Equals(x);
        public static bool operator ==(InputBotInlineMessage a, InputBotInlineMessage b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputBotInlineMessage a, InputBotInlineMessage b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case MediaAutoTag _: return 0;
                case TextTag _: return 1;
                case MediaGeoTag _: return 2;
                case MediaVenueTag _: return 3;
                case MediaContactTag _: return 4;
                case GameTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputBotInlineMessage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputBotInlineMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputBotInlineMessage a, InputBotInlineMessage b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputBotInlineMessage a, InputBotInlineMessage b) => a.CompareTo(b) < 0;
        public static bool operator >(InputBotInlineMessage a, InputBotInlineMessage b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputBotInlineMessage a, InputBotInlineMessage b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}