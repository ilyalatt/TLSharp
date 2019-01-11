using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class BotInlineMessage : ITlType, IEquatable<BotInlineMessage>, IComparable<BotInlineMessage>, IComparable
    {
        public sealed class MediaAutoTag : ITlTypeTag, IEquatable<MediaAutoTag>, IComparable<MediaAutoTag>, IComparable
        {
            internal const uint TypeNumber = 0x0a74b15b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Caption { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaAutoTag(
                Some<string> caption,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                Caption = caption;
                ReplyMarkup = replyMarkup;
            }
            
            (string, Option<T.ReplyMarkup>) CmpTuple =>
                (Caption, ReplyMarkup);

            public bool Equals(MediaAutoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MediaAutoTag x && Equals(x);
            public static bool operator ==(MediaAutoTag x, MediaAutoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaAutoTag x, MediaAutoTag y) => !(x == y);

            public int CompareTo(MediaAutoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
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
            internal const uint TypeNumber = 0x8c7f65e2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (bool, string, Option<Arr<T.MessageEntity>>, Option<T.ReplyMarkup>) CmpTuple =>
                (NoWebpage, Message, Entities, ReplyMarkup);

            public bool Equals(TextTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is TextTag x && Equals(x);
            public static bool operator ==(TextTag x, TextTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TextTag x, TextTag y) => !(x == y);

            public int CompareTo(TextTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
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
            internal const uint TypeNumber = 0x3a8fd8b8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.GeoPoint Geo { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaGeoTag(
                Some<T.GeoPoint> geo,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                Geo = geo;
                ReplyMarkup = replyMarkup;
            }
            
            (T.GeoPoint, Option<T.ReplyMarkup>) CmpTuple =>
                (Geo, ReplyMarkup);

            public bool Equals(MediaGeoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MediaGeoTag x && Equals(x);
            public static bool operator ==(MediaGeoTag x, MediaGeoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaGeoTag x, MediaGeoTag y) => !(x == y);

            public int CompareTo(MediaGeoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is MediaGeoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaGeoTag x, MediaGeoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Geo: {Geo}, ReplyMarkup: {ReplyMarkup})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(Geo, bw, WriteSerializable);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static MediaGeoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var geo = Read(br, T.GeoPoint.Deserialize);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new MediaGeoTag(geo, replyMarkup);
            }
        }

        public sealed class MediaVenueTag : ITlTypeTag, IEquatable<MediaVenueTag>, IComparable<MediaVenueTag>, IComparable
        {
            internal const uint TypeNumber = 0x4366232e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.GeoPoint Geo { get; }
            public string Title { get; }
            public string Address { get; }
            public string Provider { get; }
            public string VenueId { get; }
            public Option<T.ReplyMarkup> ReplyMarkup { get; }
            
            public MediaVenueTag(
                Some<T.GeoPoint> geo,
                Some<string> title,
                Some<string> address,
                Some<string> provider,
                Some<string> venueId,
                Option<T.ReplyMarkup> replyMarkup
            ) {
                Geo = geo;
                Title = title;
                Address = address;
                Provider = provider;
                VenueId = venueId;
                ReplyMarkup = replyMarkup;
            }
            
            (T.GeoPoint, string, string, string, string, Option<T.ReplyMarkup>) CmpTuple =>
                (Geo, Title, Address, Provider, VenueId, ReplyMarkup);

            public bool Equals(MediaVenueTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MediaVenueTag x && Equals(x);
            public static bool operator ==(MediaVenueTag x, MediaVenueTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaVenueTag x, MediaVenueTag y) => !(x == y);

            public int CompareTo(MediaVenueTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is MediaVenueTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MediaVenueTag x, MediaVenueTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Geo: {Geo}, Title: {Title}, Address: {Address}, Provider: {Provider}, VenueId: {VenueId}, ReplyMarkup: {ReplyMarkup})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, ReplyMarkup), bw, WriteInt);
                Write(Geo, bw, WriteSerializable);
                Write(Title, bw, WriteString);
                Write(Address, bw, WriteString);
                Write(Provider, bw, WriteString);
                Write(VenueId, bw, WriteString);
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            }
            
            internal static MediaVenueTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var geo = Read(br, T.GeoPoint.Deserialize);
                var title = Read(br, ReadString);
                var address = Read(br, ReadString);
                var provider = Read(br, ReadString);
                var venueId = Read(br, ReadString);
                var replyMarkup = Read(br, ReadOption(flags, 2, T.ReplyMarkup.Deserialize));
                return new MediaVenueTag(geo, title, address, provider, venueId, replyMarkup);
            }
        }

        public sealed class MediaContactTag : ITlTypeTag, IEquatable<MediaContactTag>, IComparable<MediaContactTag>, IComparable
        {
            internal const uint TypeNumber = 0x35edb4d4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (string, string, string, Option<T.ReplyMarkup>) CmpTuple =>
                (PhoneNumber, FirstName, LastName, ReplyMarkup);

            public bool Equals(MediaContactTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MediaContactTag x && Equals(x);
            public static bool operator ==(MediaContactTag x, MediaContactTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MediaContactTag x, MediaContactTag y) => !(x == y);

            public int CompareTo(MediaContactTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
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

        readonly ITlTypeTag _tag;
        BotInlineMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator BotInlineMessage(MediaAutoTag tag) => new BotInlineMessage(tag);
        public static explicit operator BotInlineMessage(TextTag tag) => new BotInlineMessage(tag);
        public static explicit operator BotInlineMessage(MediaGeoTag tag) => new BotInlineMessage(tag);
        public static explicit operator BotInlineMessage(MediaVenueTag tag) => new BotInlineMessage(tag);
        public static explicit operator BotInlineMessage(MediaContactTag tag) => new BotInlineMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static BotInlineMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case MediaAutoTag.TypeNumber: return (BotInlineMessage) MediaAutoTag.DeserializeTag(br);
                case TextTag.TypeNumber: return (BotInlineMessage) TextTag.DeserializeTag(br);
                case MediaGeoTag.TypeNumber: return (BotInlineMessage) MediaGeoTag.DeserializeTag(br);
                case MediaVenueTag.TypeNumber: return (BotInlineMessage) MediaVenueTag.DeserializeTag(br);
                case MediaContactTag.TypeNumber: return (BotInlineMessage) MediaContactTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { MediaAutoTag.TypeNumber, TextTag.TypeNumber, MediaGeoTag.TypeNumber, MediaVenueTag.TypeNumber, MediaContactTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<MediaAutoTag, T> mediaAutoTag = null,
            Func<TextTag, T> textTag = null,
            Func<MediaGeoTag, T> mediaGeoTag = null,
            Func<MediaVenueTag, T> mediaVenueTag = null,
            Func<MediaContactTag, T> mediaContactTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case MediaAutoTag x when mediaAutoTag != null: return mediaAutoTag(x);
                case TextTag x when textTag != null: return textTag(x);
                case MediaGeoTag x when mediaGeoTag != null: return mediaGeoTag(x);
                case MediaVenueTag x when mediaVenueTag != null: return mediaVenueTag(x);
                case MediaContactTag x when mediaContactTag != null: return mediaContactTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<MediaAutoTag, T> mediaAutoTag,
            Func<TextTag, T> textTag,
            Func<MediaGeoTag, T> mediaGeoTag,
            Func<MediaVenueTag, T> mediaVenueTag,
            Func<MediaContactTag, T> mediaContactTag
        ) => Match(
            () => throw new Exception("WTF"),
            mediaAutoTag ?? throw new ArgumentNullException(nameof(mediaAutoTag)),
            textTag ?? throw new ArgumentNullException(nameof(textTag)),
            mediaGeoTag ?? throw new ArgumentNullException(nameof(mediaGeoTag)),
            mediaVenueTag ?? throw new ArgumentNullException(nameof(mediaVenueTag)),
            mediaContactTag ?? throw new ArgumentNullException(nameof(mediaContactTag))
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
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(BotInlineMessage other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is BotInlineMessage x && Equals(x);
        public static bool operator ==(BotInlineMessage x, BotInlineMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BotInlineMessage x, BotInlineMessage y) => !(x == y);

        public int CompareTo(BotInlineMessage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BotInlineMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BotInlineMessage x, BotInlineMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(BotInlineMessage x, BotInlineMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(BotInlineMessage x, BotInlineMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(BotInlineMessage x, BotInlineMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"BotInlineMessage.{_tag.GetType().Name}{_tag}";
    }
}