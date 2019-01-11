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
        public sealed class MediaAutoTag : ITlTypeTag, IEquatable<MediaAutoTag>, IComparable<MediaAutoTag>, IComparable
        {
            internal const uint TypeNumber = 0x292fed13;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Caption;
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            
            public MediaAutoTag(
                Some<string> caption,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                Caption = caption;
                ReplyMarkup = replyMarkup;
            }
            
            (string, Option<T.ReplyMarkup>) CmpTuple =>
                (Caption, ReplyMarkup);

            public bool Equals(MediaAutoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MediaAutoTag x && Equals(x);
            public static bool operator ==(MediaAutoTag x, MediaAutoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaAutoTag x, MediaAutoTag y) => !(x == y);

            public int CompareTo(MediaAutoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MediaAutoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaAutoTag x, MediaAutoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaAutoTag x, MediaAutoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaAutoTag x, MediaAutoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaAutoTag x, MediaAutoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Caption: {Caption}, ReplyMarkup: {ReplyMarkup})";
            
            
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

        public sealed class TextTag : ITlTypeTag, IEquatable<TextTag>, IComparable<TextTag>, IComparable
        {
            internal const uint TypeNumber = 0x3dcd7a87;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool NoWebpage;
            public readonly string Message;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            
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
            
            (bool, string, Option<Arr<T.MessageEntity>>, Option<T.ReplyMarkup>) CmpTuple =>
                (NoWebpage, Message, Entities, ReplyMarkup);

            public bool Equals(TextTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TextTag x && Equals(x);
            public static bool operator ==(TextTag x, TextTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TextTag x, TextTag y) => !(x == y);

            public int CompareTo(TextTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TextTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TextTag x, TextTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TextTag x, TextTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TextTag x, TextTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TextTag x, TextTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NoWebpage: {NoWebpage}, Message: {Message}, Entities: {Entities}, ReplyMarkup: {ReplyMarkup})";
            
            
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

        public sealed class MediaGeoTag : ITlTypeTag, IEquatable<MediaGeoTag>, IComparable<MediaGeoTag>, IComparable
        {
            internal const uint TypeNumber = 0xf4a59de1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGeoPoint GeoPoint;
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            
            public MediaGeoTag(
                Some<T.InputGeoPoint> geoPoint,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                GeoPoint = geoPoint;
                ReplyMarkup = replyMarkup;
            }
            
            (T.InputGeoPoint, Option<T.ReplyMarkup>) CmpTuple =>
                (GeoPoint, ReplyMarkup);

            public bool Equals(MediaGeoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MediaGeoTag x && Equals(x);
            public static bool operator ==(MediaGeoTag x, MediaGeoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaGeoTag x, MediaGeoTag y) => !(x == y);

            public int CompareTo(MediaGeoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MediaGeoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(GeoPoint: {GeoPoint}, ReplyMarkup: {ReplyMarkup})";
            
            
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

        public sealed class MediaVenueTag : ITlTypeTag, IEquatable<MediaVenueTag>, IComparable<MediaVenueTag>, IComparable
        {
            internal const uint TypeNumber = 0xaaafadc8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGeoPoint GeoPoint;
            public readonly string Title;
            public readonly string Address;
            public readonly string Provider;
            public readonly string VenueId;
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            
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
            
            (T.InputGeoPoint, string, string, string, string, Option<T.ReplyMarkup>) CmpTuple =>
                (GeoPoint, Title, Address, Provider, VenueId, ReplyMarkup);

            public bool Equals(MediaVenueTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MediaVenueTag x && Equals(x);
            public static bool operator ==(MediaVenueTag x, MediaVenueTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaVenueTag x, MediaVenueTag y) => !(x == y);

            public int CompareTo(MediaVenueTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MediaVenueTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(GeoPoint: {GeoPoint}, Title: {Title}, Address: {Address}, Provider: {Provider}, VenueId: {VenueId}, ReplyMarkup: {ReplyMarkup})";
            
            
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

        public sealed class MediaContactTag : ITlTypeTag, IEquatable<MediaContactTag>, IComparable<MediaContactTag>, IComparable
        {
            internal const uint TypeNumber = 0x2daf01a7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PhoneNumber;
            public readonly string FirstName;
            public readonly string LastName;
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            
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
            
            (string, string, string, Option<T.ReplyMarkup>) CmpTuple =>
                (PhoneNumber, FirstName, LastName, ReplyMarkup);

            public bool Equals(MediaContactTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MediaContactTag x && Equals(x);
            public static bool operator ==(MediaContactTag x, MediaContactTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaContactTag x, MediaContactTag y) => !(x == y);

            public int CompareTo(MediaContactTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MediaContactTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaContactTag x, MediaContactTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaContactTag x, MediaContactTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaContactTag x, MediaContactTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaContactTag x, MediaContactTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PhoneNumber: {PhoneNumber}, FirstName: {FirstName}, LastName: {LastName}, ReplyMarkup: {ReplyMarkup})";
            
            
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

        public sealed class GameTag : ITlTypeTag, IEquatable<GameTag>, IComparable<GameTag>, IComparable
        {
            internal const uint TypeNumber = 0x4b425864;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            
            public GameTag(
                Option<T.ReplyMarkup> replyMarkup
            ) {
                ReplyMarkup = replyMarkup;
            }
            
            Option<T.ReplyMarkup> CmpTuple =>
                ReplyMarkup;

            public bool Equals(GameTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GameTag x && Equals(x);
            public static bool operator ==(GameTag x, GameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GameTag x, GameTag y) => !(x == y);

            public int CompareTo(GameTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is GameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GameTag x, GameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GameTag x, GameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GameTag x, GameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GameTag x, GameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ReplyMarkup: {ReplyMarkup})";
            
            
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
                case MediaAutoTag.TypeNumber: return (InputBotInlineMessage) MediaAutoTag.DeserializeTag(br);
                case TextTag.TypeNumber: return (InputBotInlineMessage) TextTag.DeserializeTag(br);
                case MediaGeoTag.TypeNumber: return (InputBotInlineMessage) MediaGeoTag.DeserializeTag(br);
                case MediaVenueTag.TypeNumber: return (InputBotInlineMessage) MediaVenueTag.DeserializeTag(br);
                case MediaContactTag.TypeNumber: return (InputBotInlineMessage) MediaContactTag.DeserializeTag(br);
                case GameTag.TypeNumber: return (InputBotInlineMessage) GameTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { MediaAutoTag.TypeNumber, TextTag.TypeNumber, MediaGeoTag.TypeNumber, MediaVenueTag.TypeNumber, MediaContactTag.TypeNumber, GameTag.TypeNumber });
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

        public bool Equals(InputBotInlineMessage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputBotInlineMessage x && Equals(x);
        public static bool operator ==(InputBotInlineMessage x, InputBotInlineMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputBotInlineMessage x, InputBotInlineMessage y) => !(x == y);

        public int CompareTo(InputBotInlineMessage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputBotInlineMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputBotInlineMessage x, InputBotInlineMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputBotInlineMessage x, InputBotInlineMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(InputBotInlineMessage x, InputBotInlineMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputBotInlineMessage x, InputBotInlineMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputBotInlineMessage.{_tag.GetType().Name}{_tag}";
    }
}