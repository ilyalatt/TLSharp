using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputMedia : ITlType, IEquatable<InputMedia>, IComparable<InputMedia>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9664f57f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
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

        public sealed class UploadedPhotoTag : Record<UploadedPhotoTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x630c9af1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputFile File { get; }
            public string Caption { get; }
            public Option<Arr<T.InputDocument>> Stickers { get; }
            
            public UploadedPhotoTag(
                Some<T.InputFile> file,
                Some<string> caption,
                Option<Arr<T.InputDocument>> stickers
            ) {
                File = file;
                Caption = caption;
                Stickers = stickers;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Stickers), bw, WriteInt);
                Write(File, bw, WriteSerializable);
                Write(Caption, bw, WriteString);
                Write(Stickers, bw, WriteOption<Arr<T.InputDocument>>(WriteVector<T.InputDocument>(WriteSerializable)));
            }
            
            internal static UploadedPhotoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var file = Read(br, T.InputFile.Deserialize);
                var caption = Read(br, ReadString);
                var stickers = Read(br, ReadOption(flags, 0, ReadVector(T.InputDocument.Deserialize)));
                return new UploadedPhotoTag(file, caption, stickers);
            }
        }

        public sealed class PhotoTag : Record<PhotoTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe9bfb4f3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputPhoto Id { get; }
            public string Caption { get; }
            
            public PhotoTag(
                Some<T.InputPhoto> id,
                Some<string> caption
            ) {
                Id = id;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteSerializable);
                Write(Caption, bw, WriteString);
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, T.InputPhoto.Deserialize);
                var caption = Read(br, ReadString);
                return new PhotoTag(id, caption);
            }
        }

        public sealed class GeoPointTag : Record<GeoPointTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf9c44144;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputGeoPoint GeoPoint { get; }
            
            public GeoPointTag(
                Some<T.InputGeoPoint> geoPoint
            ) {
                GeoPoint = geoPoint;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(GeoPoint, bw, WriteSerializable);
            }
            
            internal static GeoPointTag DeserializeTag(BinaryReader br)
            {
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                return new GeoPointTag(geoPoint);
            }
        }

        public sealed class ContactTag : Record<ContactTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa6e45987;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string PhoneNumber { get; }
            public string FirstName { get; }
            public string LastName { get; }
            
            public ContactTag(
                Some<string> phoneNumber,
                Some<string> firstName,
                Some<string> lastName
            ) {
                PhoneNumber = phoneNumber;
                FirstName = firstName;
                LastName = lastName;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhoneNumber, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
            }
            
            internal static ContactTag DeserializeTag(BinaryReader br)
            {
                var phoneNumber = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                return new ContactTag(phoneNumber, firstName, lastName);
            }
        }

        public sealed class UploadedDocumentTag : Record<UploadedDocumentTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd070f1e9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputFile File { get; }
            public string MimeType { get; }
            public Arr<T.DocumentAttribute> Attributes { get; }
            public string Caption { get; }
            public Option<Arr<T.InputDocument>> Stickers { get; }
            
            public UploadedDocumentTag(
                Some<T.InputFile> file,
                Some<string> mimeType,
                Some<Arr<T.DocumentAttribute>> attributes,
                Some<string> caption,
                Option<Arr<T.InputDocument>> stickers
            ) {
                File = file;
                MimeType = mimeType;
                Attributes = attributes;
                Caption = caption;
                Stickers = stickers;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Stickers), bw, WriteInt);
                Write(File, bw, WriteSerializable);
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
                Write(Caption, bw, WriteString);
                Write(Stickers, bw, WriteOption<Arr<T.InputDocument>>(WriteVector<T.InputDocument>(WriteSerializable)));
            }
            
            internal static UploadedDocumentTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var file = Read(br, T.InputFile.Deserialize);
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                var caption = Read(br, ReadString);
                var stickers = Read(br, ReadOption(flags, 0, ReadVector(T.InputDocument.Deserialize)));
                return new UploadedDocumentTag(file, mimeType, attributes, caption, stickers);
            }
        }

        public sealed class UploadedThumbDocumentTag : Record<UploadedThumbDocumentTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x50d88cae;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputFile File { get; }
            public T.InputFile Thumb { get; }
            public string MimeType { get; }
            public Arr<T.DocumentAttribute> Attributes { get; }
            public string Caption { get; }
            public Option<Arr<T.InputDocument>> Stickers { get; }
            
            public UploadedThumbDocumentTag(
                Some<T.InputFile> file,
                Some<T.InputFile> thumb,
                Some<string> mimeType,
                Some<Arr<T.DocumentAttribute>> attributes,
                Some<string> caption,
                Option<Arr<T.InputDocument>> stickers
            ) {
                File = file;
                Thumb = thumb;
                MimeType = mimeType;
                Attributes = attributes;
                Caption = caption;
                Stickers = stickers;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Stickers), bw, WriteInt);
                Write(File, bw, WriteSerializable);
                Write(Thumb, bw, WriteSerializable);
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
                Write(Caption, bw, WriteString);
                Write(Stickers, bw, WriteOption<Arr<T.InputDocument>>(WriteVector<T.InputDocument>(WriteSerializable)));
            }
            
            internal static UploadedThumbDocumentTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var file = Read(br, T.InputFile.Deserialize);
                var thumb = Read(br, T.InputFile.Deserialize);
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                var caption = Read(br, ReadString);
                var stickers = Read(br, ReadOption(flags, 0, ReadVector(T.InputDocument.Deserialize)));
                return new UploadedThumbDocumentTag(file, thumb, mimeType, attributes, caption, stickers);
            }
        }

        public sealed class DocumentTag : Record<DocumentTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x1a77f29c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputDocument Id { get; }
            public string Caption { get; }
            
            public DocumentTag(
                Some<T.InputDocument> id,
                Some<string> caption
            ) {
                Id = id;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteSerializable);
                Write(Caption, bw, WriteString);
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, T.InputDocument.Deserialize);
                var caption = Read(br, ReadString);
                return new DocumentTag(id, caption);
            }
        }

        public sealed class VenueTag : Record<VenueTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2827a81a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputGeoPoint GeoPoint { get; }
            public string Title { get; }
            public string Address { get; }
            public string Provider { get; }
            public string VenueId { get; }
            
            public VenueTag(
                Some<T.InputGeoPoint> geoPoint,
                Some<string> title,
                Some<string> address,
                Some<string> provider,
                Some<string> venueId
            ) {
                GeoPoint = geoPoint;
                Title = title;
                Address = address;
                Provider = provider;
                VenueId = venueId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(GeoPoint, bw, WriteSerializable);
                Write(Title, bw, WriteString);
                Write(Address, bw, WriteString);
                Write(Provider, bw, WriteString);
                Write(VenueId, bw, WriteString);
            }
            
            internal static VenueTag DeserializeTag(BinaryReader br)
            {
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                var title = Read(br, ReadString);
                var address = Read(br, ReadString);
                var provider = Read(br, ReadString);
                var venueId = Read(br, ReadString);
                return new VenueTag(geoPoint, title, address, provider, venueId);
            }
        }

        public sealed class GifExternalTag : Record<GifExternalTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x4843b0fd;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public string Q { get; }
            
            public GifExternalTag(
                Some<string> url,
                Some<string> q
            ) {
                Url = url;
                Q = q;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Q, bw, WriteString);
            }
            
            internal static GifExternalTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var q = Read(br, ReadString);
                return new GifExternalTag(url, q);
            }
        }

        public sealed class PhotoExternalTag : Record<PhotoExternalTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb55f4f18;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public string Caption { get; }
            
            public PhotoExternalTag(
                Some<string> url,
                Some<string> caption
            ) {
                Url = url;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Caption, bw, WriteString);
            }
            
            internal static PhotoExternalTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var caption = Read(br, ReadString);
                return new PhotoExternalTag(url, caption);
            }
        }

        public sealed class DocumentExternalTag : Record<DocumentExternalTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe5e9607c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public string Caption { get; }
            
            public DocumentExternalTag(
                Some<string> url,
                Some<string> caption
            ) {
                Url = url;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Caption, bw, WriteString);
            }
            
            internal static DocumentExternalTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var caption = Read(br, ReadString);
                return new DocumentExternalTag(url, caption);
            }
        }

        public sealed class GameTag : Record<GameTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd33f43f3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputGame Id { get; }
            
            public GameTag(
                Some<T.InputGame> id
            ) {
                Id = id;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteSerializable);
            }
            
            internal static GameTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, T.InputGame.Deserialize);
                return new GameTag(id);
            }
        }

        public sealed class InvoiceTag : Record<InvoiceTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x92153685;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Title { get; }
            public string Description { get; }
            public Option<T.InputWebDocument> Photo { get; }
            public T.Invoice Invoice { get; }
            public Arr<byte> Payload { get; }
            public string Provider { get; }
            public string StartParam { get; }
            
            public InvoiceTag(
                Some<string> title,
                Some<string> description,
                Option<T.InputWebDocument> photo,
                Some<T.Invoice> invoice,
                Some<Arr<byte>> payload,
                Some<string> provider,
                Some<string> startParam
            ) {
                Title = title;
                Description = description;
                Photo = photo;
                Invoice = invoice;
                Payload = payload;
                Provider = provider;
                StartParam = startParam;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Photo), bw, WriteInt);
                Write(Title, bw, WriteString);
                Write(Description, bw, WriteString);
                Write(Photo, bw, WriteOption<T.InputWebDocument>(WriteSerializable));
                Write(Invoice, bw, WriteSerializable);
                Write(Payload, bw, WriteBytes);
                Write(Provider, bw, WriteString);
                Write(StartParam, bw, WriteString);
            }
            
            internal static InvoiceTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var title = Read(br, ReadString);
                var description = Read(br, ReadString);
                var photo = Read(br, ReadOption(flags, 0, T.InputWebDocument.Deserialize));
                var invoice = Read(br, T.Invoice.Deserialize);
                var payload = Read(br, ReadBytes);
                var provider = Read(br, ReadString);
                var startParam = Read(br, ReadString);
                return new InvoiceTag(title, description, photo, invoice, payload, provider, startParam);
            }
        }

        readonly ITlTypeTag _tag;
        InputMedia(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputMedia(EmptyTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(UploadedPhotoTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(PhotoTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(GeoPointTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(ContactTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(UploadedDocumentTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(UploadedThumbDocumentTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(DocumentTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(VenueTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(GifExternalTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(PhotoExternalTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(DocumentExternalTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(GameTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(InvoiceTag tag) => new InputMedia(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputMedia Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (InputMedia) EmptyTag.DeserializeTag(br);
                case UploadedPhotoTag.TypeNumber: return (InputMedia) UploadedPhotoTag.DeserializeTag(br);
                case PhotoTag.TypeNumber: return (InputMedia) PhotoTag.DeserializeTag(br);
                case GeoPointTag.TypeNumber: return (InputMedia) GeoPointTag.DeserializeTag(br);
                case ContactTag.TypeNumber: return (InputMedia) ContactTag.DeserializeTag(br);
                case UploadedDocumentTag.TypeNumber: return (InputMedia) UploadedDocumentTag.DeserializeTag(br);
                case UploadedThumbDocumentTag.TypeNumber: return (InputMedia) UploadedThumbDocumentTag.DeserializeTag(br);
                case DocumentTag.TypeNumber: return (InputMedia) DocumentTag.DeserializeTag(br);
                case VenueTag.TypeNumber: return (InputMedia) VenueTag.DeserializeTag(br);
                case GifExternalTag.TypeNumber: return (InputMedia) GifExternalTag.DeserializeTag(br);
                case PhotoExternalTag.TypeNumber: return (InputMedia) PhotoExternalTag.DeserializeTag(br);
                case DocumentExternalTag.TypeNumber: return (InputMedia) DocumentExternalTag.DeserializeTag(br);
                case GameTag.TypeNumber: return (InputMedia) GameTag.DeserializeTag(br);
                case InvoiceTag.TypeNumber: return (InputMedia) InvoiceTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, UploadedPhotoTag.TypeNumber, PhotoTag.TypeNumber, GeoPointTag.TypeNumber, ContactTag.TypeNumber, UploadedDocumentTag.TypeNumber, UploadedThumbDocumentTag.TypeNumber, DocumentTag.TypeNumber, VenueTag.TypeNumber, GifExternalTag.TypeNumber, PhotoExternalTag.TypeNumber, DocumentExternalTag.TypeNumber, GameTag.TypeNumber, InvoiceTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<UploadedPhotoTag, T> uploadedPhotoTag = null,
            Func<PhotoTag, T> photoTag = null,
            Func<GeoPointTag, T> geoPointTag = null,
            Func<ContactTag, T> contactTag = null,
            Func<UploadedDocumentTag, T> uploadedDocumentTag = null,
            Func<UploadedThumbDocumentTag, T> uploadedThumbDocumentTag = null,
            Func<DocumentTag, T> documentTag = null,
            Func<VenueTag, T> venueTag = null,
            Func<GifExternalTag, T> gifExternalTag = null,
            Func<PhotoExternalTag, T> photoExternalTag = null,
            Func<DocumentExternalTag, T> documentExternalTag = null,
            Func<GameTag, T> gameTag = null,
            Func<InvoiceTag, T> invoiceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case UploadedPhotoTag x when uploadedPhotoTag != null: return uploadedPhotoTag(x);
                case PhotoTag x when photoTag != null: return photoTag(x);
                case GeoPointTag x when geoPointTag != null: return geoPointTag(x);
                case ContactTag x when contactTag != null: return contactTag(x);
                case UploadedDocumentTag x when uploadedDocumentTag != null: return uploadedDocumentTag(x);
                case UploadedThumbDocumentTag x when uploadedThumbDocumentTag != null: return uploadedThumbDocumentTag(x);
                case DocumentTag x when documentTag != null: return documentTag(x);
                case VenueTag x when venueTag != null: return venueTag(x);
                case GifExternalTag x when gifExternalTag != null: return gifExternalTag(x);
                case PhotoExternalTag x when photoExternalTag != null: return photoExternalTag(x);
                case DocumentExternalTag x when documentExternalTag != null: return documentExternalTag(x);
                case GameTag x when gameTag != null: return gameTag(x);
                case InvoiceTag x when invoiceTag != null: return invoiceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<UploadedPhotoTag, T> uploadedPhotoTag,
            Func<PhotoTag, T> photoTag,
            Func<GeoPointTag, T> geoPointTag,
            Func<ContactTag, T> contactTag,
            Func<UploadedDocumentTag, T> uploadedDocumentTag,
            Func<UploadedThumbDocumentTag, T> uploadedThumbDocumentTag,
            Func<DocumentTag, T> documentTag,
            Func<VenueTag, T> venueTag,
            Func<GifExternalTag, T> gifExternalTag,
            Func<PhotoExternalTag, T> photoExternalTag,
            Func<DocumentExternalTag, T> documentExternalTag,
            Func<GameTag, T> gameTag,
            Func<InvoiceTag, T> invoiceTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            uploadedPhotoTag ?? throw new ArgumentNullException(nameof(uploadedPhotoTag)),
            photoTag ?? throw new ArgumentNullException(nameof(photoTag)),
            geoPointTag ?? throw new ArgumentNullException(nameof(geoPointTag)),
            contactTag ?? throw new ArgumentNullException(nameof(contactTag)),
            uploadedDocumentTag ?? throw new ArgumentNullException(nameof(uploadedDocumentTag)),
            uploadedThumbDocumentTag ?? throw new ArgumentNullException(nameof(uploadedThumbDocumentTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag)),
            venueTag ?? throw new ArgumentNullException(nameof(venueTag)),
            gifExternalTag ?? throw new ArgumentNullException(nameof(gifExternalTag)),
            photoExternalTag ?? throw new ArgumentNullException(nameof(photoExternalTag)),
            documentExternalTag ?? throw new ArgumentNullException(nameof(documentExternalTag)),
            gameTag ?? throw new ArgumentNullException(nameof(gameTag)),
            invoiceTag ?? throw new ArgumentNullException(nameof(invoiceTag))
        );

        public bool Equals(InputMedia other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputMedia x && Equals(x);
        public static bool operator ==(InputMedia a, InputMedia b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputMedia a, InputMedia b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case UploadedPhotoTag _: return 1;
                case PhotoTag _: return 2;
                case GeoPointTag _: return 3;
                case ContactTag _: return 4;
                case UploadedDocumentTag _: return 5;
                case UploadedThumbDocumentTag _: return 6;
                case DocumentTag _: return 7;
                case VenueTag _: return 8;
                case GifExternalTag _: return 9;
                case PhotoExternalTag _: return 10;
                case DocumentExternalTag _: return 11;
                case GameTag _: return 12;
                case InvoiceTag _: return 13;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputMedia other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputMedia a, InputMedia b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputMedia a, InputMedia b) => a.CompareTo(b) < 0;
        public static bool operator >(InputMedia a, InputMedia b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputMedia a, InputMedia b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}