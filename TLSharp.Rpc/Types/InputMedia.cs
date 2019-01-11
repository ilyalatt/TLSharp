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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x9664f57f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
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

        public sealed class UploadedPhotoTag : ITlTypeTag, IEquatable<UploadedPhotoTag>, IComparable<UploadedPhotoTag>, IComparable
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
            
            (T.InputFile, string, Option<Arr<T.InputDocument>>) CmpTuple =>
                (File, Caption, Stickers);

            public bool Equals(UploadedPhotoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadedPhotoTag x && Equals(x);
            public static bool operator ==(UploadedPhotoTag x, UploadedPhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedPhotoTag x, UploadedPhotoTag y) => !(x == y);

            public int CompareTo(UploadedPhotoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadedPhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(File: {File}, Caption: {Caption}, Stickers: {Stickers})";
            
            
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

        public sealed class PhotoTag : ITlTypeTag, IEquatable<PhotoTag>, IComparable<PhotoTag>, IComparable
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
            
            (T.InputPhoto, string) CmpTuple =>
                (Id, Caption);

            public bool Equals(PhotoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PhotoTag x && Equals(x);
            public static bool operator ==(PhotoTag x, PhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhotoTag x, PhotoTag y) => !(x == y);

            public int CompareTo(PhotoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhotoTag x, PhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhotoTag x, PhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhotoTag x, PhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhotoTag x, PhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Caption: {Caption})";
            
            
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

        public sealed class GeoPointTag : ITlTypeTag, IEquatable<GeoPointTag>, IComparable<GeoPointTag>, IComparable
        {
            internal const uint TypeNumber = 0xf9c44144;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputGeoPoint GeoPoint { get; }
            
            public GeoPointTag(
                Some<T.InputGeoPoint> geoPoint
            ) {
                GeoPoint = geoPoint;
            }
            
            T.InputGeoPoint CmpTuple =>
                GeoPoint;

            public bool Equals(GeoPointTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GeoPointTag x && Equals(x);
            public static bool operator ==(GeoPointTag x, GeoPointTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GeoPointTag x, GeoPointTag y) => !(x == y);

            public int CompareTo(GeoPointTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GeoPointTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GeoPointTag x, GeoPointTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(GeoPoint: {GeoPoint})";
            
            
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

        public sealed class ContactTag : ITlTypeTag, IEquatable<ContactTag>, IComparable<ContactTag>, IComparable
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
            
            (string, string, string) CmpTuple =>
                (PhoneNumber, FirstName, LastName);

            public bool Equals(ContactTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ContactTag x && Equals(x);
            public static bool operator ==(ContactTag x, ContactTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ContactTag x, ContactTag y) => !(x == y);

            public int CompareTo(ContactTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ContactTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ContactTag x, ContactTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ContactTag x, ContactTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ContactTag x, ContactTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ContactTag x, ContactTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PhoneNumber: {PhoneNumber}, FirstName: {FirstName}, LastName: {LastName})";
            
            
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

        public sealed class UploadedDocumentTag : ITlTypeTag, IEquatable<UploadedDocumentTag>, IComparable<UploadedDocumentTag>, IComparable
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
            
            (T.InputFile, string, Arr<T.DocumentAttribute>, string, Option<Arr<T.InputDocument>>) CmpTuple =>
                (File, MimeType, Attributes, Caption, Stickers);

            public bool Equals(UploadedDocumentTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadedDocumentTag x && Equals(x);
            public static bool operator ==(UploadedDocumentTag x, UploadedDocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedDocumentTag x, UploadedDocumentTag y) => !(x == y);

            public int CompareTo(UploadedDocumentTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadedDocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(File: {File}, MimeType: {MimeType}, Attributes: {Attributes}, Caption: {Caption}, Stickers: {Stickers})";
            
            
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

        public sealed class UploadedThumbDocumentTag : ITlTypeTag, IEquatable<UploadedThumbDocumentTag>, IComparable<UploadedThumbDocumentTag>, IComparable
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
            
            (T.InputFile, T.InputFile, string, Arr<T.DocumentAttribute>, string, Option<Arr<T.InputDocument>>) CmpTuple =>
                (File, Thumb, MimeType, Attributes, Caption, Stickers);

            public bool Equals(UploadedThumbDocumentTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UploadedThumbDocumentTag x && Equals(x);
            public static bool operator ==(UploadedThumbDocumentTag x, UploadedThumbDocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedThumbDocumentTag x, UploadedThumbDocumentTag y) => !(x == y);

            public int CompareTo(UploadedThumbDocumentTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UploadedThumbDocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedThumbDocumentTag x, UploadedThumbDocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedThumbDocumentTag x, UploadedThumbDocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedThumbDocumentTag x, UploadedThumbDocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedThumbDocumentTag x, UploadedThumbDocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(File: {File}, Thumb: {Thumb}, MimeType: {MimeType}, Attributes: {Attributes}, Caption: {Caption}, Stickers: {Stickers})";
            
            
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

        public sealed class DocumentTag : ITlTypeTag, IEquatable<DocumentTag>, IComparable<DocumentTag>, IComparable
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
            
            (T.InputDocument, string) CmpTuple =>
                (Id, Caption);

            public bool Equals(DocumentTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DocumentTag x && Equals(x);
            public static bool operator ==(DocumentTag x, DocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentTag x, DocumentTag y) => !(x == y);

            public int CompareTo(DocumentTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DocumentTag x, DocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DocumentTag x, DocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DocumentTag x, DocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DocumentTag x, DocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Caption: {Caption})";
            
            
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

        public sealed class VenueTag : ITlTypeTag, IEquatable<VenueTag>, IComparable<VenueTag>, IComparable
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
            
            (T.InputGeoPoint, string, string, string, string) CmpTuple =>
                (GeoPoint, Title, Address, Provider, VenueId);

            public bool Equals(VenueTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is VenueTag x && Equals(x);
            public static bool operator ==(VenueTag x, VenueTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(VenueTag x, VenueTag y) => !(x == y);

            public int CompareTo(VenueTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is VenueTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(VenueTag x, VenueTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(VenueTag x, VenueTag y) => x.CompareTo(y) < 0;
            public static bool operator >(VenueTag x, VenueTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(VenueTag x, VenueTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(GeoPoint: {GeoPoint}, Title: {Title}, Address: {Address}, Provider: {Provider}, VenueId: {VenueId})";
            
            
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

        public sealed class GifExternalTag : ITlTypeTag, IEquatable<GifExternalTag>, IComparable<GifExternalTag>, IComparable
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
            
            (string, string) CmpTuple =>
                (Url, Q);

            public bool Equals(GifExternalTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GifExternalTag x && Equals(x);
            public static bool operator ==(GifExternalTag x, GifExternalTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GifExternalTag x, GifExternalTag y) => !(x == y);

            public int CompareTo(GifExternalTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GifExternalTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GifExternalTag x, GifExternalTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GifExternalTag x, GifExternalTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GifExternalTag x, GifExternalTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GifExternalTag x, GifExternalTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, Q: {Q})";
            
            
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

        public sealed class PhotoExternalTag : ITlTypeTag, IEquatable<PhotoExternalTag>, IComparable<PhotoExternalTag>, IComparable
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
            
            (string, string) CmpTuple =>
                (Url, Caption);

            public bool Equals(PhotoExternalTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PhotoExternalTag x && Equals(x);
            public static bool operator ==(PhotoExternalTag x, PhotoExternalTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhotoExternalTag x, PhotoExternalTag y) => !(x == y);

            public int CompareTo(PhotoExternalTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PhotoExternalTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, Caption: {Caption})";
            
            
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

        public sealed class DocumentExternalTag : ITlTypeTag, IEquatable<DocumentExternalTag>, IComparable<DocumentExternalTag>, IComparable
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
            
            (string, string) CmpTuple =>
                (Url, Caption);

            public bool Equals(DocumentExternalTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DocumentExternalTag x && Equals(x);
            public static bool operator ==(DocumentExternalTag x, DocumentExternalTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentExternalTag x, DocumentExternalTag y) => !(x == y);

            public int CompareTo(DocumentExternalTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DocumentExternalTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, Caption: {Caption})";
            
            
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

        public sealed class GameTag : ITlTypeTag, IEquatable<GameTag>, IComparable<GameTag>, IComparable
        {
            internal const uint TypeNumber = 0xd33f43f3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.InputGame Id { get; }
            
            public GameTag(
                Some<T.InputGame> id
            ) {
                Id = id;
            }
            
            T.InputGame CmpTuple =>
                Id;

            public bool Equals(GameTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GameTag x && Equals(x);
            public static bool operator ==(GameTag x, GameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GameTag x, GameTag y) => !(x == y);

            public int CompareTo(GameTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GameTag x, GameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GameTag x, GameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GameTag x, GameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GameTag x, GameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
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

        public sealed class InvoiceTag : ITlTypeTag, IEquatable<InvoiceTag>, IComparable<InvoiceTag>, IComparable
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
            
            (string, string, Option<T.InputWebDocument>, T.Invoice, Arr<byte>, string, string) CmpTuple =>
                (Title, Description, Photo, Invoice, Payload, Provider, StartParam);

            public bool Equals(InvoiceTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is InvoiceTag x && Equals(x);
            public static bool operator ==(InvoiceTag x, InvoiceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InvoiceTag x, InvoiceTag y) => !(x == y);

            public int CompareTo(InvoiceTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is InvoiceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InvoiceTag x, InvoiceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Title: {Title}, Description: {Description}, Photo: {Photo}, Invoice: {Invoice}, Payload: {Payload}, Provider: {Provider}, StartParam: {StartParam})";
            
            
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

        public bool Equals(InputMedia other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputMedia x && Equals(x);
        public static bool operator ==(InputMedia x, InputMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputMedia x, InputMedia y) => !(x == y);

        public int CompareTo(InputMedia other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputMedia x, InputMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputMedia x, InputMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(InputMedia x, InputMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputMedia x, InputMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputMedia.{_tag.GetType().Name}{_tag}";
    }
}