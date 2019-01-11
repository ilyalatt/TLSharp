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

        public sealed class UploadedPhotoTag : ITlTypeTag, IEquatable<UploadedPhotoTag>, IComparable<UploadedPhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0x1e287d04;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputFile File;
            public readonly Option<Arr<T.InputDocument>> Stickers;
            public readonly Option<int> TtlSeconds;
            
            public UploadedPhotoTag(
                Some<T.InputFile> file,
                Option<Arr<T.InputDocument>> stickers,
                Option<int> ttlSeconds
            ) {
                File = file;
                Stickers = stickers;
                TtlSeconds = ttlSeconds;
            }
            
            (T.InputFile, Option<Arr<T.InputDocument>>, Option<int>) CmpTuple =>
                (File, Stickers, TtlSeconds);

            public bool Equals(UploadedPhotoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UploadedPhotoTag x && Equals(x);
            public static bool operator ==(UploadedPhotoTag x, UploadedPhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedPhotoTag x, UploadedPhotoTag y) => !(x == y);

            public int CompareTo(UploadedPhotoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UploadedPhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedPhotoTag x, UploadedPhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(File: {File}, Stickers: {Stickers}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Stickers) | MaskBit(1, TtlSeconds), bw, WriteInt);
                Write(File, bw, WriteSerializable);
                Write(Stickers, bw, WriteOption<Arr<T.InputDocument>>(WriteVector<T.InputDocument>(WriteSerializable)));
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static UploadedPhotoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var file = Read(br, T.InputFile.Deserialize);
                var stickers = Read(br, ReadOption(flags, 0, ReadVector(T.InputDocument.Deserialize)));
                var ttlSeconds = Read(br, ReadOption(flags, 1, ReadInt));
                return new UploadedPhotoTag(file, stickers, ttlSeconds);
            }
        }

        public sealed class PhotoTag : ITlTypeTag, IEquatable<PhotoTag>, IComparable<PhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0xb3ba0635;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputPhoto Id;
            public readonly Option<int> TtlSeconds;
            
            public PhotoTag(
                Some<T.InputPhoto> id,
                Option<int> ttlSeconds
            ) {
                Id = id;
                TtlSeconds = ttlSeconds;
            }
            
            (T.InputPhoto, Option<int>) CmpTuple =>
                (Id, TtlSeconds);

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

            public override string ToString() => $"(Id: {Id}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, TtlSeconds), bw, WriteInt);
                Write(Id, bw, WriteSerializable);
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, T.InputPhoto.Deserialize);
                var ttlSeconds = Read(br, ReadOption(flags, 0, ReadInt));
                return new PhotoTag(id, ttlSeconds);
            }
        }

        public sealed class GeoPointTag : ITlTypeTag, IEquatable<GeoPointTag>, IComparable<GeoPointTag>, IComparable
        {
            internal const uint TypeNumber = 0xf9c44144;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGeoPoint GeoPoint;
            
            public GeoPointTag(
                Some<T.InputGeoPoint> geoPoint
            ) {
                GeoPoint = geoPoint;
            }
            
            T.InputGeoPoint CmpTuple =>
                GeoPoint;

            public bool Equals(GeoPointTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GeoPointTag x && Equals(x);
            public static bool operator ==(GeoPointTag x, GeoPointTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GeoPointTag x, GeoPointTag y) => !(x == y);

            public int CompareTo(GeoPointTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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
            internal const uint TypeNumber = 0xf8ab7dfb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PhoneNumber;
            public readonly string FirstName;
            public readonly string LastName;
            public readonly string Vcard;
            
            public ContactTag(
                Some<string> phoneNumber,
                Some<string> firstName,
                Some<string> lastName,
                Some<string> vcard
            ) {
                PhoneNumber = phoneNumber;
                FirstName = firstName;
                LastName = lastName;
                Vcard = vcard;
            }
            
            (string, string, string, string) CmpTuple =>
                (PhoneNumber, FirstName, LastName, Vcard);

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

            public override string ToString() => $"(PhoneNumber: {PhoneNumber}, FirstName: {FirstName}, LastName: {LastName}, Vcard: {Vcard})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhoneNumber, bw, WriteString);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
                Write(Vcard, bw, WriteString);
            }
            
            internal static ContactTag DeserializeTag(BinaryReader br)
            {
                var phoneNumber = Read(br, ReadString);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                var vcard = Read(br, ReadString);
                return new ContactTag(phoneNumber, firstName, lastName, vcard);
            }
        }

        public sealed class UploadedDocumentTag : ITlTypeTag, IEquatable<UploadedDocumentTag>, IComparable<UploadedDocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0x5b38c6c1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool NosoundVideo;
            public readonly T.InputFile File;
            public readonly Option<T.InputFile> Thumb;
            public readonly string MimeType;
            public readonly Arr<T.DocumentAttribute> Attributes;
            public readonly Option<Arr<T.InputDocument>> Stickers;
            public readonly Option<int> TtlSeconds;
            
            public UploadedDocumentTag(
                bool nosoundVideo,
                Some<T.InputFile> file,
                Option<T.InputFile> thumb,
                Some<string> mimeType,
                Some<Arr<T.DocumentAttribute>> attributes,
                Option<Arr<T.InputDocument>> stickers,
                Option<int> ttlSeconds
            ) {
                NosoundVideo = nosoundVideo;
                File = file;
                Thumb = thumb;
                MimeType = mimeType;
                Attributes = attributes;
                Stickers = stickers;
                TtlSeconds = ttlSeconds;
            }
            
            (bool, T.InputFile, Option<T.InputFile>, string, Arr<T.DocumentAttribute>, Option<Arr<T.InputDocument>>, Option<int>) CmpTuple =>
                (NosoundVideo, File, Thumb, MimeType, Attributes, Stickers, TtlSeconds);

            public bool Equals(UploadedDocumentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UploadedDocumentTag x && Equals(x);
            public static bool operator ==(UploadedDocumentTag x, UploadedDocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedDocumentTag x, UploadedDocumentTag y) => !(x == y);

            public int CompareTo(UploadedDocumentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UploadedDocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedDocumentTag x, UploadedDocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NosoundVideo: {NosoundVideo}, File: {File}, Thumb: {Thumb}, MimeType: {MimeType}, Attributes: {Attributes}, Stickers: {Stickers}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(3, NosoundVideo) | MaskBit(2, Thumb) | MaskBit(0, Stickers) | MaskBit(1, TtlSeconds), bw, WriteInt);
                Write(File, bw, WriteSerializable);
                Write(Thumb, bw, WriteOption<T.InputFile>(WriteSerializable));
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
                Write(Stickers, bw, WriteOption<Arr<T.InputDocument>>(WriteVector<T.InputDocument>(WriteSerializable)));
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static UploadedDocumentTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var nosoundVideo = Read(br, ReadOption(flags, 3));
                var file = Read(br, T.InputFile.Deserialize);
                var thumb = Read(br, ReadOption(flags, 2, T.InputFile.Deserialize));
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                var stickers = Read(br, ReadOption(flags, 0, ReadVector(T.InputDocument.Deserialize)));
                var ttlSeconds = Read(br, ReadOption(flags, 1, ReadInt));
                return new UploadedDocumentTag(nosoundVideo, file, thumb, mimeType, attributes, stickers, ttlSeconds);
            }
        }

        public sealed class DocumentTag : ITlTypeTag, IEquatable<DocumentTag>, IComparable<DocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0x23ab23d2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputDocument Id;
            public readonly Option<int> TtlSeconds;
            
            public DocumentTag(
                Some<T.InputDocument> id,
                Option<int> ttlSeconds
            ) {
                Id = id;
                TtlSeconds = ttlSeconds;
            }
            
            (T.InputDocument, Option<int>) CmpTuple =>
                (Id, TtlSeconds);

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

            public override string ToString() => $"(Id: {Id}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, TtlSeconds), bw, WriteInt);
                Write(Id, bw, WriteSerializable);
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, T.InputDocument.Deserialize);
                var ttlSeconds = Read(br, ReadOption(flags, 0, ReadInt));
                return new DocumentTag(id, ttlSeconds);
            }
        }

        public sealed class VenueTag : ITlTypeTag, IEquatable<VenueTag>, IComparable<VenueTag>, IComparable
        {
            internal const uint TypeNumber = 0xc13d1c11;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGeoPoint GeoPoint;
            public readonly string Title;
            public readonly string Address;
            public readonly string Provider;
            public readonly string VenueId;
            public readonly string VenueType;
            
            public VenueTag(
                Some<T.InputGeoPoint> geoPoint,
                Some<string> title,
                Some<string> address,
                Some<string> provider,
                Some<string> venueId,
                Some<string> venueType
            ) {
                GeoPoint = geoPoint;
                Title = title;
                Address = address;
                Provider = provider;
                VenueId = venueId;
                VenueType = venueType;
            }
            
            (T.InputGeoPoint, string, string, string, string, string) CmpTuple =>
                (GeoPoint, Title, Address, Provider, VenueId, VenueType);

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

            public override string ToString() => $"(GeoPoint: {GeoPoint}, Title: {Title}, Address: {Address}, Provider: {Provider}, VenueId: {VenueId}, VenueType: {VenueType})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(GeoPoint, bw, WriteSerializable);
                Write(Title, bw, WriteString);
                Write(Address, bw, WriteString);
                Write(Provider, bw, WriteString);
                Write(VenueId, bw, WriteString);
                Write(VenueType, bw, WriteString);
            }
            
            internal static VenueTag DeserializeTag(BinaryReader br)
            {
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                var title = Read(br, ReadString);
                var address = Read(br, ReadString);
                var provider = Read(br, ReadString);
                var venueId = Read(br, ReadString);
                var venueType = Read(br, ReadString);
                return new VenueTag(geoPoint, title, address, provider, venueId, venueType);
            }
        }

        public sealed class GifExternalTag : ITlTypeTag, IEquatable<GifExternalTag>, IComparable<GifExternalTag>, IComparable
        {
            internal const uint TypeNumber = 0x4843b0fd;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly string Q;
            
            public GifExternalTag(
                Some<string> url,
                Some<string> q
            ) {
                Url = url;
                Q = q;
            }
            
            (string, string) CmpTuple =>
                (Url, Q);

            public bool Equals(GifExternalTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GifExternalTag x && Equals(x);
            public static bool operator ==(GifExternalTag x, GifExternalTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GifExternalTag x, GifExternalTag y) => !(x == y);

            public int CompareTo(GifExternalTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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
            internal const uint TypeNumber = 0xe5bbfe1a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly Option<int> TtlSeconds;
            
            public PhotoExternalTag(
                Some<string> url,
                Option<int> ttlSeconds
            ) {
                Url = url;
                TtlSeconds = ttlSeconds;
            }
            
            (string, Option<int>) CmpTuple =>
                (Url, TtlSeconds);

            public bool Equals(PhotoExternalTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PhotoExternalTag x && Equals(x);
            public static bool operator ==(PhotoExternalTag x, PhotoExternalTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhotoExternalTag x, PhotoExternalTag y) => !(x == y);

            public int CompareTo(PhotoExternalTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PhotoExternalTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhotoExternalTag x, PhotoExternalTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, TtlSeconds), bw, WriteInt);
                Write(Url, bw, WriteString);
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static PhotoExternalTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var url = Read(br, ReadString);
                var ttlSeconds = Read(br, ReadOption(flags, 0, ReadInt));
                return new PhotoExternalTag(url, ttlSeconds);
            }
        }

        public sealed class DocumentExternalTag : ITlTypeTag, IEquatable<DocumentExternalTag>, IComparable<DocumentExternalTag>, IComparable
        {
            internal const uint TypeNumber = 0xfb52dc99;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly Option<int> TtlSeconds;
            
            public DocumentExternalTag(
                Some<string> url,
                Option<int> ttlSeconds
            ) {
                Url = url;
                TtlSeconds = ttlSeconds;
            }
            
            (string, Option<int>) CmpTuple =>
                (Url, TtlSeconds);

            public bool Equals(DocumentExternalTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DocumentExternalTag x && Equals(x);
            public static bool operator ==(DocumentExternalTag x, DocumentExternalTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentExternalTag x, DocumentExternalTag y) => !(x == y);

            public int CompareTo(DocumentExternalTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DocumentExternalTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DocumentExternalTag x, DocumentExternalTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, TtlSeconds: {TtlSeconds})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, TtlSeconds), bw, WriteInt);
                Write(Url, bw, WriteString);
                Write(TtlSeconds, bw, WriteOption<int>(WriteInt));
            }
            
            internal static DocumentExternalTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var url = Read(br, ReadString);
                var ttlSeconds = Read(br, ReadOption(flags, 0, ReadInt));
                return new DocumentExternalTag(url, ttlSeconds);
            }
        }

        public sealed class GameTag : ITlTypeTag, IEquatable<GameTag>, IComparable<GameTag>, IComparable
        {
            internal const uint TypeNumber = 0xd33f43f3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGame Id;
            
            public GameTag(
                Some<T.InputGame> id
            ) {
                Id = id;
            }
            
            T.InputGame CmpTuple =>
                Id;

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
            internal const uint TypeNumber = 0xf4e096c3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Title;
            public readonly string Description;
            public readonly Option<T.InputWebDocument> Photo;
            public readonly T.Invoice Invoice;
            public readonly Arr<byte> Payload;
            public readonly string Provider;
            public readonly T.DataJson ProviderData;
            public readonly string StartParam;
            
            public InvoiceTag(
                Some<string> title,
                Some<string> description,
                Option<T.InputWebDocument> photo,
                Some<T.Invoice> invoice,
                Some<Arr<byte>> payload,
                Some<string> provider,
                Some<T.DataJson> providerData,
                Some<string> startParam
            ) {
                Title = title;
                Description = description;
                Photo = photo;
                Invoice = invoice;
                Payload = payload;
                Provider = provider;
                ProviderData = providerData;
                StartParam = startParam;
            }
            
            (string, string, Option<T.InputWebDocument>, T.Invoice, Arr<byte>, string, T.DataJson, string) CmpTuple =>
                (Title, Description, Photo, Invoice, Payload, Provider, ProviderData, StartParam);

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

            public override string ToString() => $"(Title: {Title}, Description: {Description}, Photo: {Photo}, Invoice: {Invoice}, Payload: {Payload}, Provider: {Provider}, ProviderData: {ProviderData}, StartParam: {StartParam})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Photo), bw, WriteInt);
                Write(Title, bw, WriteString);
                Write(Description, bw, WriteString);
                Write(Photo, bw, WriteOption<T.InputWebDocument>(WriteSerializable));
                Write(Invoice, bw, WriteSerializable);
                Write(Payload, bw, WriteBytes);
                Write(Provider, bw, WriteString);
                Write(ProviderData, bw, WriteSerializable);
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
                var providerData = Read(br, T.DataJson.Deserialize);
                var startParam = Read(br, ReadString);
                return new InvoiceTag(title, description, photo, invoice, payload, provider, providerData, startParam);
            }
        }

        public sealed class GeoLiveTag : ITlTypeTag, IEquatable<GeoLiveTag>, IComparable<GeoLiveTag>, IComparable
        {
            internal const uint TypeNumber = 0x7b1a118f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputGeoPoint GeoPoint;
            public readonly int Period;
            
            public GeoLiveTag(
                Some<T.InputGeoPoint> geoPoint,
                int period
            ) {
                GeoPoint = geoPoint;
                Period = period;
            }
            
            (T.InputGeoPoint, int) CmpTuple =>
                (GeoPoint, Period);

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

            public override string ToString() => $"(GeoPoint: {GeoPoint}, Period: {Period})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(GeoPoint, bw, WriteSerializable);
                Write(Period, bw, WriteInt);
            }
            
            internal static GeoLiveTag DeserializeTag(BinaryReader br)
            {
                var geoPoint = Read(br, T.InputGeoPoint.Deserialize);
                var period = Read(br, ReadInt);
                return new GeoLiveTag(geoPoint, period);
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
        public static explicit operator InputMedia(DocumentTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(VenueTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(GifExternalTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(PhotoExternalTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(DocumentExternalTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(GameTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(InvoiceTag tag) => new InputMedia(tag);
        public static explicit operator InputMedia(GeoLiveTag tag) => new InputMedia(tag);

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
                case DocumentTag.TypeNumber: return (InputMedia) DocumentTag.DeserializeTag(br);
                case VenueTag.TypeNumber: return (InputMedia) VenueTag.DeserializeTag(br);
                case GifExternalTag.TypeNumber: return (InputMedia) GifExternalTag.DeserializeTag(br);
                case PhotoExternalTag.TypeNumber: return (InputMedia) PhotoExternalTag.DeserializeTag(br);
                case DocumentExternalTag.TypeNumber: return (InputMedia) DocumentExternalTag.DeserializeTag(br);
                case GameTag.TypeNumber: return (InputMedia) GameTag.DeserializeTag(br);
                case InvoiceTag.TypeNumber: return (InputMedia) InvoiceTag.DeserializeTag(br);
                case GeoLiveTag.TypeNumber: return (InputMedia) GeoLiveTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, UploadedPhotoTag.TypeNumber, PhotoTag.TypeNumber, GeoPointTag.TypeNumber, ContactTag.TypeNumber, UploadedDocumentTag.TypeNumber, DocumentTag.TypeNumber, VenueTag.TypeNumber, GifExternalTag.TypeNumber, PhotoExternalTag.TypeNumber, DocumentExternalTag.TypeNumber, GameTag.TypeNumber, InvoiceTag.TypeNumber, GeoLiveTag.TypeNumber });
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
            Func<DocumentTag, T> documentTag = null,
            Func<VenueTag, T> venueTag = null,
            Func<GifExternalTag, T> gifExternalTag = null,
            Func<PhotoExternalTag, T> photoExternalTag = null,
            Func<DocumentExternalTag, T> documentExternalTag = null,
            Func<GameTag, T> gameTag = null,
            Func<InvoiceTag, T> invoiceTag = null,
            Func<GeoLiveTag, T> geoLiveTag = null
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
                case DocumentTag x when documentTag != null: return documentTag(x);
                case VenueTag x when venueTag != null: return venueTag(x);
                case GifExternalTag x when gifExternalTag != null: return gifExternalTag(x);
                case PhotoExternalTag x when photoExternalTag != null: return photoExternalTag(x);
                case DocumentExternalTag x when documentExternalTag != null: return documentExternalTag(x);
                case GameTag x when gameTag != null: return gameTag(x);
                case InvoiceTag x when invoiceTag != null: return invoiceTag(x);
                case GeoLiveTag x when geoLiveTag != null: return geoLiveTag(x);
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
            Func<DocumentTag, T> documentTag,
            Func<VenueTag, T> venueTag,
            Func<GifExternalTag, T> gifExternalTag,
            Func<PhotoExternalTag, T> photoExternalTag,
            Func<DocumentExternalTag, T> documentExternalTag,
            Func<GameTag, T> gameTag,
            Func<InvoiceTag, T> invoiceTag,
            Func<GeoLiveTag, T> geoLiveTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            uploadedPhotoTag ?? throw new ArgumentNullException(nameof(uploadedPhotoTag)),
            photoTag ?? throw new ArgumentNullException(nameof(photoTag)),
            geoPointTag ?? throw new ArgumentNullException(nameof(geoPointTag)),
            contactTag ?? throw new ArgumentNullException(nameof(contactTag)),
            uploadedDocumentTag ?? throw new ArgumentNullException(nameof(uploadedDocumentTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag)),
            venueTag ?? throw new ArgumentNullException(nameof(venueTag)),
            gifExternalTag ?? throw new ArgumentNullException(nameof(gifExternalTag)),
            photoExternalTag ?? throw new ArgumentNullException(nameof(photoExternalTag)),
            documentExternalTag ?? throw new ArgumentNullException(nameof(documentExternalTag)),
            gameTag ?? throw new ArgumentNullException(nameof(gameTag)),
            invoiceTag ?? throw new ArgumentNullException(nameof(invoiceTag)),
            geoLiveTag ?? throw new ArgumentNullException(nameof(geoLiveTag))
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
                case DocumentTag _: return 6;
                case VenueTag _: return 7;
                case GifExternalTag _: return 8;
                case PhotoExternalTag _: return 9;
                case DocumentExternalTag _: return 10;
                case GameTag _: return 11;
                case InvoiceTag _: return 12;
                case GeoLiveTag _: return 13;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputMedia other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputMedia x && Equals(x);
        public static bool operator ==(InputMedia x, InputMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputMedia x, InputMedia y) => !(x == y);

        public int CompareTo(InputMedia other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputMedia x, InputMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputMedia x, InputMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(InputMedia x, InputMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputMedia x, InputMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputMedia.{_tag.GetType().Name}{_tag}";
    }
}