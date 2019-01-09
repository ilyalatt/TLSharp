using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MessageMedia : ITlType, IEquatable<MessageMedia>, IComparable<MessageMedia>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3ded6320;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class PhotoTag : Record<PhotoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3d8ce53d;
            
            public T.Photo Photo { get; }
            public string Caption { get; }
            
            public PhotoTag(
                Some<T.Photo> photo,
                Some<string> caption
            ) {
                Photo = photo;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Photo, bw, WriteSerializable);
                Write(Caption, bw, WriteString);
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var photo = Read(br, T.Photo.Deserialize);
                var caption = Read(br, ReadString);
                return new PhotoTag(photo, caption);
            }
        }

        public sealed class GeoTag : Record<GeoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x56e0d474;
            
            public T.GeoPoint Geo { get; }
            
            public GeoTag(
                Some<T.GeoPoint> geo
            ) {
                Geo = geo;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Geo, bw, WriteSerializable);
            }
            
            internal static GeoTag DeserializeTag(BinaryReader br)
            {
                var geo = Read(br, T.GeoPoint.Deserialize);
                return new GeoTag(geo);
            }
        }

        public sealed class ContactTag : Record<ContactTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x5e7d2f39;
            
            public string PhoneNumber { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public int UserId { get; }
            
            public ContactTag(
                Some<string> phoneNumber,
                Some<string> firstName,
                Some<string> lastName,
                int userId
            ) {
                PhoneNumber = phoneNumber;
                FirstName = firstName;
                LastName = lastName;
                UserId = userId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhoneNumber, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
                Write(UserId, bw, WriteInt);
            }
            
            internal static ContactTag DeserializeTag(BinaryReader br)
            {
                var phoneNumber = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                var userId = Read(br, ReadInt);
                return new ContactTag(phoneNumber, firstName, lastName, userId);
            }
        }

        public sealed class UnsupportedTag : Record<UnsupportedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9f84f49e;
            

            
            public UnsupportedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UnsupportedTag DeserializeTag(BinaryReader br)
            {

                return new UnsupportedTag();
            }
        }

        public sealed class DocumentTag : Record<DocumentTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf3e02ea8;
            
            public T.Document Document { get; }
            public string Caption { get; }
            
            public DocumentTag(
                Some<T.Document> document,
                Some<string> caption
            ) {
                Document = document;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Document, bw, WriteSerializable);
                Write(Caption, bw, WriteString);
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var document = Read(br, T.Document.Deserialize);
                var caption = Read(br, ReadString);
                return new DocumentTag(document, caption);
            }
        }

        public sealed class WebPageTag : Record<WebPageTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa32dd600;
            
            public T.WebPage Webpage { get; }
            
            public WebPageTag(
                Some<T.WebPage> webpage
            ) {
                Webpage = webpage;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Webpage, bw, WriteSerializable);
            }
            
            internal static WebPageTag DeserializeTag(BinaryReader br)
            {
                var webpage = Read(br, T.WebPage.Deserialize);
                return new WebPageTag(webpage);
            }
        }

        public sealed class VenueTag : Record<VenueTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7912b71f;
            
            public T.GeoPoint Geo { get; }
            public string Title { get; }
            public string Address { get; }
            public string Provider { get; }
            public string VenueId { get; }
            
            public VenueTag(
                Some<T.GeoPoint> geo,
                Some<string> title,
                Some<string> address,
                Some<string> provider,
                Some<string> venueId
            ) {
                Geo = geo;
                Title = title;
                Address = address;
                Provider = provider;
                VenueId = venueId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Geo, bw, WriteSerializable);
                Write(Title, bw, WriteString);
                Write(Address, bw, WriteString);
                Write(Provider, bw, WriteString);
                Write(VenueId, bw, WriteString);
            }
            
            internal static VenueTag DeserializeTag(BinaryReader br)
            {
                var geo = Read(br, T.GeoPoint.Deserialize);
                var title = Read(br, ReadString);
                var address = Read(br, ReadString);
                var provider = Read(br, ReadString);
                var venueId = Read(br, ReadString);
                return new VenueTag(geo, title, address, provider, venueId);
            }
        }

        public sealed class GameTag : Record<GameTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfdb19008;
            
            public T.Game Game { get; }
            
            public GameTag(
                Some<T.Game> game
            ) {
                Game = game;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Game, bw, WriteSerializable);
            }
            
            internal static GameTag DeserializeTag(BinaryReader br)
            {
                var game = Read(br, T.Game.Deserialize);
                return new GameTag(game);
            }
        }

        public sealed class InvoiceTag : Record<InvoiceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x84551347;
            
            public bool ShippingAddressRequested { get; }
            public bool Test { get; }
            public string Title { get; }
            public string Description { get; }
            public Option<T.WebDocument> Photo { get; }
            public Option<int> ReceiptMsgId { get; }
            public string Currency { get; }
            public long TotalAmount { get; }
            public string StartParam { get; }
            
            public InvoiceTag(
                bool shippingAddressRequested,
                bool test,
                Some<string> title,
                Some<string> description,
                Option<T.WebDocument> photo,
                Option<int> receiptMsgId,
                Some<string> currency,
                long totalAmount,
                Some<string> startParam
            ) {
                ShippingAddressRequested = shippingAddressRequested;
                Test = test;
                Title = title;
                Description = description;
                Photo = photo;
                ReceiptMsgId = receiptMsgId;
                Currency = currency;
                TotalAmount = totalAmount;
                StartParam = startParam;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, ShippingAddressRequested) | MaskBit(3, Test) | MaskBit(0, Photo) | MaskBit(2, ReceiptMsgId), bw, WriteInt);
                Write(Title, bw, WriteString);
                Write(Description, bw, WriteString);
                Write(Photo, bw, WriteOption<T.WebDocument>(WriteSerializable));
                Write(ReceiptMsgId, bw, WriteOption<int>(WriteInt));
                Write(Currency, bw, WriteString);
                Write(TotalAmount, bw, WriteLong);
                Write(StartParam, bw, WriteString);
            }
            
            internal static InvoiceTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var shippingAddressRequested = Read(br, ReadOption(flags, 1));
                var test = Read(br, ReadOption(flags, 3));
                var title = Read(br, ReadString);
                var description = Read(br, ReadString);
                var photo = Read(br, ReadOption(flags, 0, T.WebDocument.Deserialize));
                var receiptMsgId = Read(br, ReadOption(flags, 2, ReadInt));
                var currency = Read(br, ReadString);
                var totalAmount = Read(br, ReadLong);
                var startParam = Read(br, ReadString);
                return new InvoiceTag(shippingAddressRequested, test, title, description, photo, receiptMsgId, currency, totalAmount, startParam);
            }
        }

        readonly ITlTypeTag _tag;
        MessageMedia(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MessageMedia(EmptyTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(PhotoTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(GeoTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(ContactTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(UnsupportedTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(DocumentTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(WebPageTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(VenueTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(GameTag tag) => new MessageMedia(tag);
        public static explicit operator MessageMedia(InvoiceTag tag) => new MessageMedia(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MessageMedia Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x3ded6320: return (MessageMedia) EmptyTag.DeserializeTag(br);
                case 0x3d8ce53d: return (MessageMedia) PhotoTag.DeserializeTag(br);
                case 0x56e0d474: return (MessageMedia) GeoTag.DeserializeTag(br);
                case 0x5e7d2f39: return (MessageMedia) ContactTag.DeserializeTag(br);
                case 0x9f84f49e: return (MessageMedia) UnsupportedTag.DeserializeTag(br);
                case 0xf3e02ea8: return (MessageMedia) DocumentTag.DeserializeTag(br);
                case 0xa32dd600: return (MessageMedia) WebPageTag.DeserializeTag(br);
                case 0x7912b71f: return (MessageMedia) VenueTag.DeserializeTag(br);
                case 0xfdb19008: return (MessageMedia) GameTag.DeserializeTag(br);
                case 0x84551347: return (MessageMedia) InvoiceTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x3ded6320, 0x3d8ce53d, 0x56e0d474, 0x5e7d2f39, 0x9f84f49e, 0xf3e02ea8, 0xa32dd600, 0x7912b71f, 0xfdb19008, 0x84551347 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<PhotoTag, T> photoTag = null,
            Func<GeoTag, T> geoTag = null,
            Func<ContactTag, T> contactTag = null,
            Func<UnsupportedTag, T> unsupportedTag = null,
            Func<DocumentTag, T> documentTag = null,
            Func<WebPageTag, T> webPageTag = null,
            Func<VenueTag, T> venueTag = null,
            Func<GameTag, T> gameTag = null,
            Func<InvoiceTag, T> invoiceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case PhotoTag x when photoTag != null: return photoTag(x);
                case GeoTag x when geoTag != null: return geoTag(x);
                case ContactTag x when contactTag != null: return contactTag(x);
                case UnsupportedTag x when unsupportedTag != null: return unsupportedTag(x);
                case DocumentTag x when documentTag != null: return documentTag(x);
                case WebPageTag x when webPageTag != null: return webPageTag(x);
                case VenueTag x when venueTag != null: return venueTag(x);
                case GameTag x when gameTag != null: return gameTag(x);
                case InvoiceTag x when invoiceTag != null: return invoiceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<PhotoTag, T> photoTag,
            Func<GeoTag, T> geoTag,
            Func<ContactTag, T> contactTag,
            Func<UnsupportedTag, T> unsupportedTag,
            Func<DocumentTag, T> documentTag,
            Func<WebPageTag, T> webPageTag,
            Func<VenueTag, T> venueTag,
            Func<GameTag, T> gameTag,
            Func<InvoiceTag, T> invoiceTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            photoTag ?? throw new ArgumentNullException(nameof(photoTag)),
            geoTag ?? throw new ArgumentNullException(nameof(geoTag)),
            contactTag ?? throw new ArgumentNullException(nameof(contactTag)),
            unsupportedTag ?? throw new ArgumentNullException(nameof(unsupportedTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag)),
            webPageTag ?? throw new ArgumentNullException(nameof(webPageTag)),
            venueTag ?? throw new ArgumentNullException(nameof(venueTag)),
            gameTag ?? throw new ArgumentNullException(nameof(gameTag)),
            invoiceTag ?? throw new ArgumentNullException(nameof(invoiceTag))
        );

        public bool Equals(MessageMedia other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MessageMedia x && Equals(x);
        public static bool operator ==(MessageMedia a, MessageMedia b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MessageMedia a, MessageMedia b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case PhotoTag _: return 1;
                case GeoTag _: return 2;
                case ContactTag _: return 3;
                case UnsupportedTag _: return 4;
                case DocumentTag _: return 5;
                case WebPageTag _: return 6;
                case VenueTag _: return 7;
                case GameTag _: return 8;
                case InvoiceTag _: return 9;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MessageMedia other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MessageMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageMedia a, MessageMedia b) => a.CompareTo(b) <= 0;
        public static bool operator <(MessageMedia a, MessageMedia b) => a.CompareTo(b) < 0;
        public static bool operator >(MessageMedia a, MessageMedia b) => a.CompareTo(b) > 0;
        public static bool operator >=(MessageMedia a, MessageMedia b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}