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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x3ded6320;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class PhotoTag : ITlTypeTag, IEquatable<PhotoTag>, IComparable<PhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0x695150d7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<T.Photo> Photo;
            public readonly Option<int> TtlSeconds;
            
            public PhotoTag(
                Option<T.Photo> photo,
                Option<int> ttlSeconds
            ) {
                Photo = photo;
                TtlSeconds = ttlSeconds;
            }
            
            (Option<T.Photo>, Option<int>) CmpTuple =>
                (Photo, TtlSeconds);

            public bool Equals(PhotoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PhotoTag x && Equals(x);
            public static bool operator ==(PhotoTag x, PhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhotoTag x, PhotoTag y) => !(x == y);

            public int CompareTo(PhotoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhotoTag x, PhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhotoTag x, PhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhotoTag x, PhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhotoTag x, PhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Photo: {Photo}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Photo) | MaskBit(2, TtlSeconds), bw, WriteInt);
                Write(Photo, bw, WriteOption<T.Photo>(WriteSerializable));
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var photo = Read(br, ReadOption(flags, 0, T.Photo.Deserialize));
                var ttlSeconds = Read(br, ReadOption(flags, 2, ReadInt));
                return new PhotoTag(photo, ttlSeconds);
            }
        }

        public sealed class GeoTag : ITlTypeTag, IEquatable<GeoTag>, IComparable<GeoTag>, IComparable
        {
            internal const uint TypeNumber = 0x56e0d474;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.GeoPoint Geo;
            
            public GeoTag(
                Some<T.GeoPoint> geo
            ) {
                Geo = geo;
            }
            
            T.GeoPoint CmpTuple =>
                Geo;

            public bool Equals(GeoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GeoTag x && Equals(x);
            public static bool operator ==(GeoTag x, GeoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GeoTag x, GeoTag y) => !(x == y);

            public int CompareTo(GeoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is GeoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GeoTag x, GeoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GeoTag x, GeoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GeoTag x, GeoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GeoTag x, GeoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Geo: {Geo})";
            
            
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

        public sealed class ContactTag : ITlTypeTag, IEquatable<ContactTag>, IComparable<ContactTag>, IComparable
        {
            internal const uint TypeNumber = 0xcbf24940;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PhoneNumber;
            public readonly string FirstName;
            public readonly string LastName;
            public readonly string Vcard;
            public readonly int UserId;
            
            public ContactTag(
                Some<string> phoneNumber,
                Some<string> firstName,
                Some<string> lastName,
                Some<string> vcard,
                int userId
            ) {
                PhoneNumber = phoneNumber;
                FirstName = firstName;
                LastName = lastName;
                Vcard = vcard;
                UserId = userId;
            }
            
            (string, string, string, string, int) CmpTuple =>
                (PhoneNumber, FirstName, LastName, Vcard, UserId);

            public bool Equals(ContactTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ContactTag x && Equals(x);
            public static bool operator ==(ContactTag x, ContactTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ContactTag x, ContactTag y) => !(x == y);

            public int CompareTo(ContactTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ContactTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ContactTag x, ContactTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ContactTag x, ContactTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ContactTag x, ContactTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ContactTag x, ContactTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PhoneNumber: {PhoneNumber}, FirstName: {FirstName}, LastName: {LastName}, Vcard: {Vcard}, UserId: {UserId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhoneNumber, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
                Write(Vcard, bw, WriteString);
                Write(UserId, bw, WriteInt);
            }
            
            internal static ContactTag DeserializeTag(BinaryReader br)
            {
                var phoneNumber = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                var vcard = Read(br, ReadString);
                var userId = Read(br, ReadInt);
                return new ContactTag(phoneNumber, firstName, lastName, vcard, userId);
            }
        }

        public sealed class UnsupportedTag : ITlTypeTag, IEquatable<UnsupportedTag>, IComparable<UnsupportedTag>, IComparable
        {
            internal const uint TypeNumber = 0x9f84f49e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public UnsupportedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(UnsupportedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UnsupportedTag x && Equals(x);
            public static bool operator ==(UnsupportedTag x, UnsupportedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UnsupportedTag x, UnsupportedTag y) => !(x == y);

            public int CompareTo(UnsupportedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UnsupportedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UnsupportedTag x, UnsupportedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UnsupportedTag x, UnsupportedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UnsupportedTag x, UnsupportedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UnsupportedTag x, UnsupportedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UnsupportedTag DeserializeTag(BinaryReader br)
            {

                return new UnsupportedTag();
            }
        }

        public sealed class DocumentTag : ITlTypeTag, IEquatable<DocumentTag>, IComparable<DocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0x9cb070d7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<T.Document> Document;
            public readonly Option<int> TtlSeconds;
            
            public DocumentTag(
                Option<T.Document> document,
                Option<int> ttlSeconds
            ) {
                Document = document;
                TtlSeconds = ttlSeconds;
            }
            
            (Option<T.Document>, Option<int>) CmpTuple =>
                (Document, TtlSeconds);

            public bool Equals(DocumentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DocumentTag x && Equals(x);
            public static bool operator ==(DocumentTag x, DocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentTag x, DocumentTag y) => !(x == y);

            public int CompareTo(DocumentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DocumentTag x, DocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DocumentTag x, DocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DocumentTag x, DocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DocumentTag x, DocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Document: {Document}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Document) | MaskBit(2, TtlSeconds), bw, WriteInt);
                Write(Document, bw, WriteOption<T.Document>(WriteSerializable));
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var document = Read(br, ReadOption(flags, 0, T.Document.Deserialize));
                var ttlSeconds = Read(br, ReadOption(flags, 2, ReadInt));
                return new DocumentTag(document, ttlSeconds);
            }
        }

        public sealed class WebPageTag : ITlTypeTag, IEquatable<WebPageTag>, IComparable<WebPageTag>, IComparable
        {
            internal const uint TypeNumber = 0xa32dd600;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.WebPage Webpage;
            
            public WebPageTag(
                Some<T.WebPage> webpage
            ) {
                Webpage = webpage;
            }
            
            T.WebPage CmpTuple =>
                Webpage;

            public bool Equals(WebPageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is WebPageTag x && Equals(x);
            public static bool operator ==(WebPageTag x, WebPageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(WebPageTag x, WebPageTag y) => !(x == y);

            public int CompareTo(WebPageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is WebPageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(WebPageTag x, WebPageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(WebPageTag x, WebPageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(WebPageTag x, WebPageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(WebPageTag x, WebPageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Webpage: {Webpage})";
            
            
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

        public sealed class VenueTag : ITlTypeTag, IEquatable<VenueTag>, IComparable<VenueTag>, IComparable
        {
            internal const uint TypeNumber = 0x2ec0533f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.GeoPoint Geo;
            public readonly string Title;
            public readonly string Address;
            public readonly string Provider;
            public readonly string VenueId;
            public readonly string VenueType;
            
            public VenueTag(
                Some<T.GeoPoint> geo,
                Some<string> title,
                Some<string> address,
                Some<string> provider,
                Some<string> venueId,
                Some<string> venueType
            ) {
                Geo = geo;
                Title = title;
                Address = address;
                Provider = provider;
                VenueId = venueId;
                VenueType = venueType;
            }
            
            (T.GeoPoint, string, string, string, string, string) CmpTuple =>
                (Geo, Title, Address, Provider, VenueId, VenueType);

            public bool Equals(VenueTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is VenueTag x && Equals(x);
            public static bool operator ==(VenueTag x, VenueTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(VenueTag x, VenueTag y) => !(x == y);

            public int CompareTo(VenueTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is VenueTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(VenueTag x, VenueTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(VenueTag x, VenueTag y) => x.CompareTo(y) < 0;
            public static bool operator >(VenueTag x, VenueTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(VenueTag x, VenueTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Geo: {Geo}, Title: {Title}, Address: {Address}, Provider: {Provider}, VenueId: {VenueId}, VenueType: {VenueType})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Geo, bw, WriteSerializable);
                Write(Title, bw, WriteString);
                Write(Address, bw, WriteString);
                Write(Provider, bw, WriteString);
                Write(VenueId, bw, WriteString);
                Write(VenueType, bw, WriteString);
            }
            
            internal static VenueTag DeserializeTag(BinaryReader br)
            {
                var geo = Read(br, T.GeoPoint.Deserialize);
                var title = Read(br, ReadString);
                var address = Read(br, ReadString);
                var provider = Read(br, ReadString);
                var venueId = Read(br, ReadString);
                var venueType = Read(br, ReadString);
                return new VenueTag(geo, title, address, provider, venueId, venueType);
            }
        }

        public sealed class GameTag : ITlTypeTag, IEquatable<GameTag>, IComparable<GameTag>, IComparable
        {
            internal const uint TypeNumber = 0xfdb19008;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Game Game;
            
            public GameTag(
                Some<T.Game> game
            ) {
                Game = game;
            }
            
            T.Game CmpTuple =>
                Game;

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

            public override string ToString() => $"(Game: {Game})";
            
            
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

        public sealed class InvoiceTag : ITlTypeTag, IEquatable<InvoiceTag>, IComparable<InvoiceTag>, IComparable
        {
            internal const uint TypeNumber = 0x84551347;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool ShippingAddressRequested;
            public readonly bool Test;
            public readonly string Title;
            public readonly string Description;
            public readonly Option<T.WebDocument> Photo;
            public readonly Option<int> ReceiptMsgId;
            public readonly string Currency;
            public readonly long TotalAmount;
            public readonly string StartParam;
            
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
            
            (bool, bool, string, string, Option<T.WebDocument>, Option<int>, string, long, string) CmpTuple =>
                (ShippingAddressRequested, Test, Title, Description, Photo, ReceiptMsgId, Currency, TotalAmount, StartParam);

            public bool Equals(InvoiceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InvoiceTag x && Equals(x);
            public static bool operator ==(InvoiceTag x, InvoiceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InvoiceTag x, InvoiceTag y) => !(x == y);

            public int CompareTo(InvoiceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InvoiceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ShippingAddressRequested: {ShippingAddressRequested}, Test: {Test}, Title: {Title}, Description: {Description}, Photo: {Photo}, ReceiptMsgId: {ReceiptMsgId}, Currency: {Currency}, TotalAmount: {TotalAmount}, StartParam: {StartParam})";
            
            
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

        public sealed class GeoLiveTag : ITlTypeTag, IEquatable<GeoLiveTag>, IComparable<GeoLiveTag>, IComparable
        {
            internal const uint TypeNumber = 0x7c3c2609;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.GeoPoint Geo;
            public readonly int Period;
            
            public GeoLiveTag(
                Some<T.GeoPoint> geo,
                int period
            ) {
                Geo = geo;
                Period = period;
            }
            
            (T.GeoPoint, int) CmpTuple =>
                (Geo, Period);

            public bool Equals(GeoLiveTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GeoLiveTag x && Equals(x);
            public static bool operator ==(GeoLiveTag x, GeoLiveTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GeoLiveTag x, GeoLiveTag y) => !(x == y);

            public int CompareTo(GeoLiveTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is GeoLiveTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GeoLiveTag x, GeoLiveTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GeoLiveTag x, GeoLiveTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GeoLiveTag x, GeoLiveTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GeoLiveTag x, GeoLiveTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Geo: {Geo}, Period: {Period})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Geo, bw, WriteSerializable);
                Write(Period, bw, WriteInt);
            }
            
            internal static GeoLiveTag DeserializeTag(BinaryReader br)
            {
                var geo = Read(br, T.GeoPoint.Deserialize);
                var period = Read(br, ReadInt);
                return new GeoLiveTag(geo, period);
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
        public static explicit operator MessageMedia(GeoLiveTag tag) => new MessageMedia(tag);

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
                case EmptyTag.TypeNumber: return (MessageMedia) EmptyTag.DeserializeTag(br);
                case PhotoTag.TypeNumber: return (MessageMedia) PhotoTag.DeserializeTag(br);
                case GeoTag.TypeNumber: return (MessageMedia) GeoTag.DeserializeTag(br);
                case ContactTag.TypeNumber: return (MessageMedia) ContactTag.DeserializeTag(br);
                case UnsupportedTag.TypeNumber: return (MessageMedia) UnsupportedTag.DeserializeTag(br);
                case DocumentTag.TypeNumber: return (MessageMedia) DocumentTag.DeserializeTag(br);
                case WebPageTag.TypeNumber: return (MessageMedia) WebPageTag.DeserializeTag(br);
                case VenueTag.TypeNumber: return (MessageMedia) VenueTag.DeserializeTag(br);
                case GameTag.TypeNumber: return (MessageMedia) GameTag.DeserializeTag(br);
                case InvoiceTag.TypeNumber: return (MessageMedia) InvoiceTag.DeserializeTag(br);
                case GeoLiveTag.TypeNumber: return (MessageMedia) GeoLiveTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, PhotoTag.TypeNumber, GeoTag.TypeNumber, ContactTag.TypeNumber, UnsupportedTag.TypeNumber, DocumentTag.TypeNumber, WebPageTag.TypeNumber, VenueTag.TypeNumber, GameTag.TypeNumber, InvoiceTag.TypeNumber, GeoLiveTag.TypeNumber });
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
            Func<InvoiceTag, T> invoiceTag = null,
            Func<GeoLiveTag, T> geoLiveTag = null
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
                case GeoLiveTag x when geoLiveTag != null: return geoLiveTag(x);
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
            Func<InvoiceTag, T> invoiceTag,
            Func<GeoLiveTag, T> geoLiveTag
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
            invoiceTag ?? throw new ArgumentNullException(nameof(invoiceTag)),
            geoLiveTag ?? throw new ArgumentNullException(nameof(geoLiveTag))
        );

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
                case GeoLiveTag _: return 10;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(MessageMedia other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MessageMedia x && Equals(x);
        public static bool operator ==(MessageMedia x, MessageMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MessageMedia x, MessageMedia y) => !(x == y);

        public int CompareTo(MessageMedia other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MessageMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageMedia x, MessageMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(MessageMedia x, MessageMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(MessageMedia x, MessageMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(MessageMedia x, MessageMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MessageMedia.{_tag.GetType().Name}{_tag}";
    }
}