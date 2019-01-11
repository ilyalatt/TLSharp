using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Storage
{
    public sealed class FileType : ITlType, IEquatable<FileType>, IComparable<FileType>, IComparable
    {
        public sealed class UnknownTag : ITlTypeTag, IEquatable<UnknownTag>, IComparable<UnknownTag>, IComparable
        {
            internal const uint TypeNumber = 0xaa963b05;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public UnknownTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(UnknownTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UnknownTag x && Equals(x);
            public static bool operator ==(UnknownTag x, UnknownTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UnknownTag x, UnknownTag y) => !(x == y);

            public int CompareTo(UnknownTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UnknownTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UnknownTag x, UnknownTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UnknownTag x, UnknownTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UnknownTag x, UnknownTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UnknownTag x, UnknownTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UnknownTag DeserializeTag(BinaryReader br)
            {

                return new UnknownTag();
            }
        }

        public sealed class PartialTag : ITlTypeTag, IEquatable<PartialTag>, IComparable<PartialTag>, IComparable
        {
            internal const uint TypeNumber = 0x40bc6f52;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PartialTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PartialTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PartialTag x && Equals(x);
            public static bool operator ==(PartialTag x, PartialTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PartialTag x, PartialTag y) => !(x == y);

            public int CompareTo(PartialTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PartialTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PartialTag x, PartialTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PartialTag x, PartialTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PartialTag x, PartialTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PartialTag x, PartialTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PartialTag DeserializeTag(BinaryReader br)
            {

                return new PartialTag();
            }
        }

        public sealed class JpegTag : ITlTypeTag, IEquatable<JpegTag>, IComparable<JpegTag>, IComparable
        {
            internal const uint TypeNumber = 0x007efe0e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public JpegTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(JpegTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is JpegTag x && Equals(x);
            public static bool operator ==(JpegTag x, JpegTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(JpegTag x, JpegTag y) => !(x == y);

            public int CompareTo(JpegTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is JpegTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(JpegTag x, JpegTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(JpegTag x, JpegTag y) => x.CompareTo(y) < 0;
            public static bool operator >(JpegTag x, JpegTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(JpegTag x, JpegTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static JpegTag DeserializeTag(BinaryReader br)
            {

                return new JpegTag();
            }
        }

        public sealed class GifTag : ITlTypeTag, IEquatable<GifTag>, IComparable<GifTag>, IComparable
        {
            internal const uint TypeNumber = 0xcae1aadf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public GifTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(GifTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is GifTag x && Equals(x);
            public static bool operator ==(GifTag x, GifTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GifTag x, GifTag y) => !(x == y);

            public int CompareTo(GifTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is GifTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GifTag x, GifTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GifTag x, GifTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GifTag x, GifTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GifTag x, GifTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static GifTag DeserializeTag(BinaryReader br)
            {

                return new GifTag();
            }
        }

        public sealed class PngTag : ITlTypeTag, IEquatable<PngTag>, IComparable<PngTag>, IComparable
        {
            internal const uint TypeNumber = 0x0a4f63c0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PngTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PngTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PngTag x && Equals(x);
            public static bool operator ==(PngTag x, PngTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PngTag x, PngTag y) => !(x == y);

            public int CompareTo(PngTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PngTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PngTag x, PngTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PngTag x, PngTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PngTag x, PngTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PngTag x, PngTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PngTag DeserializeTag(BinaryReader br)
            {

                return new PngTag();
            }
        }

        public sealed class PdfTag : ITlTypeTag, IEquatable<PdfTag>, IComparable<PdfTag>, IComparable
        {
            internal const uint TypeNumber = 0xae1e508d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PdfTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PdfTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PdfTag x && Equals(x);
            public static bool operator ==(PdfTag x, PdfTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PdfTag x, PdfTag y) => !(x == y);

            public int CompareTo(PdfTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PdfTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PdfTag x, PdfTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PdfTag x, PdfTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PdfTag x, PdfTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PdfTag x, PdfTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PdfTag DeserializeTag(BinaryReader br)
            {

                return new PdfTag();
            }
        }

        public sealed class Mp3Tag : ITlTypeTag, IEquatable<Mp3Tag>, IComparable<Mp3Tag>, IComparable
        {
            internal const uint TypeNumber = 0x528a0677;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public Mp3Tag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(Mp3Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Mp3Tag x && Equals(x);
            public static bool operator ==(Mp3Tag x, Mp3Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Mp3Tag x, Mp3Tag y) => !(x == y);

            public int CompareTo(Mp3Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Mp3Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Mp3Tag x, Mp3Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Mp3Tag x, Mp3Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Mp3Tag x, Mp3Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Mp3Tag x, Mp3Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static Mp3Tag DeserializeTag(BinaryReader br)
            {

                return new Mp3Tag();
            }
        }

        public sealed class MovTag : ITlTypeTag, IEquatable<MovTag>, IComparable<MovTag>, IComparable
        {
            internal const uint TypeNumber = 0x4b09ebbc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public MovTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(MovTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MovTag x && Equals(x);
            public static bool operator ==(MovTag x, MovTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MovTag x, MovTag y) => !(x == y);

            public int CompareTo(MovTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is MovTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MovTag x, MovTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MovTag x, MovTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MovTag x, MovTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MovTag x, MovTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static MovTag DeserializeTag(BinaryReader br)
            {

                return new MovTag();
            }
        }

        public sealed class Mp4Tag : ITlTypeTag, IEquatable<Mp4Tag>, IComparable<Mp4Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb3cea0e4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public Mp4Tag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(Mp4Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Mp4Tag x && Equals(x);
            public static bool operator ==(Mp4Tag x, Mp4Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Mp4Tag x, Mp4Tag y) => !(x == y);

            public int CompareTo(Mp4Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Mp4Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Mp4Tag x, Mp4Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Mp4Tag x, Mp4Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Mp4Tag x, Mp4Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Mp4Tag x, Mp4Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static Mp4Tag DeserializeTag(BinaryReader br)
            {

                return new Mp4Tag();
            }
        }

        public sealed class WebpTag : ITlTypeTag, IEquatable<WebpTag>, IComparable<WebpTag>, IComparable
        {
            internal const uint TypeNumber = 0x1081464c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public WebpTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(WebpTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is WebpTag x && Equals(x);
            public static bool operator ==(WebpTag x, WebpTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(WebpTag x, WebpTag y) => !(x == y);

            public int CompareTo(WebpTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is WebpTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(WebpTag x, WebpTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(WebpTag x, WebpTag y) => x.CompareTo(y) < 0;
            public static bool operator >(WebpTag x, WebpTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(WebpTag x, WebpTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static WebpTag DeserializeTag(BinaryReader br)
            {

                return new WebpTag();
            }
        }

        readonly ITlTypeTag _tag;
        FileType(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FileType(UnknownTag tag) => new FileType(tag);
        public static explicit operator FileType(PartialTag tag) => new FileType(tag);
        public static explicit operator FileType(JpegTag tag) => new FileType(tag);
        public static explicit operator FileType(GifTag tag) => new FileType(tag);
        public static explicit operator FileType(PngTag tag) => new FileType(tag);
        public static explicit operator FileType(PdfTag tag) => new FileType(tag);
        public static explicit operator FileType(Mp3Tag tag) => new FileType(tag);
        public static explicit operator FileType(MovTag tag) => new FileType(tag);
        public static explicit operator FileType(Mp4Tag tag) => new FileType(tag);
        public static explicit operator FileType(WebpTag tag) => new FileType(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FileType Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case UnknownTag.TypeNumber: return (FileType) UnknownTag.DeserializeTag(br);
                case PartialTag.TypeNumber: return (FileType) PartialTag.DeserializeTag(br);
                case JpegTag.TypeNumber: return (FileType) JpegTag.DeserializeTag(br);
                case GifTag.TypeNumber: return (FileType) GifTag.DeserializeTag(br);
                case PngTag.TypeNumber: return (FileType) PngTag.DeserializeTag(br);
                case PdfTag.TypeNumber: return (FileType) PdfTag.DeserializeTag(br);
                case Mp3Tag.TypeNumber: return (FileType) Mp3Tag.DeserializeTag(br);
                case MovTag.TypeNumber: return (FileType) MovTag.DeserializeTag(br);
                case Mp4Tag.TypeNumber: return (FileType) Mp4Tag.DeserializeTag(br);
                case WebpTag.TypeNumber: return (FileType) WebpTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UnknownTag.TypeNumber, PartialTag.TypeNumber, JpegTag.TypeNumber, GifTag.TypeNumber, PngTag.TypeNumber, PdfTag.TypeNumber, Mp3Tag.TypeNumber, MovTag.TypeNumber, Mp4Tag.TypeNumber, WebpTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UnknownTag, T> unknownTag = null,
            Func<PartialTag, T> partialTag = null,
            Func<JpegTag, T> jpegTag = null,
            Func<GifTag, T> gifTag = null,
            Func<PngTag, T> pngTag = null,
            Func<PdfTag, T> pdfTag = null,
            Func<Mp3Tag, T> mp3Tag = null,
            Func<MovTag, T> movTag = null,
            Func<Mp4Tag, T> mp4Tag = null,
            Func<WebpTag, T> webpTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UnknownTag x when unknownTag != null: return unknownTag(x);
                case PartialTag x when partialTag != null: return partialTag(x);
                case JpegTag x when jpegTag != null: return jpegTag(x);
                case GifTag x when gifTag != null: return gifTag(x);
                case PngTag x when pngTag != null: return pngTag(x);
                case PdfTag x when pdfTag != null: return pdfTag(x);
                case Mp3Tag x when mp3Tag != null: return mp3Tag(x);
                case MovTag x when movTag != null: return movTag(x);
                case Mp4Tag x when mp4Tag != null: return mp4Tag(x);
                case WebpTag x when webpTag != null: return webpTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UnknownTag, T> unknownTag,
            Func<PartialTag, T> partialTag,
            Func<JpegTag, T> jpegTag,
            Func<GifTag, T> gifTag,
            Func<PngTag, T> pngTag,
            Func<PdfTag, T> pdfTag,
            Func<Mp3Tag, T> mp3Tag,
            Func<MovTag, T> movTag,
            Func<Mp4Tag, T> mp4Tag,
            Func<WebpTag, T> webpTag
        ) => Match(
            () => throw new Exception("WTF"),
            unknownTag ?? throw new ArgumentNullException(nameof(unknownTag)),
            partialTag ?? throw new ArgumentNullException(nameof(partialTag)),
            jpegTag ?? throw new ArgumentNullException(nameof(jpegTag)),
            gifTag ?? throw new ArgumentNullException(nameof(gifTag)),
            pngTag ?? throw new ArgumentNullException(nameof(pngTag)),
            pdfTag ?? throw new ArgumentNullException(nameof(pdfTag)),
            mp3Tag ?? throw new ArgumentNullException(nameof(mp3Tag)),
            movTag ?? throw new ArgumentNullException(nameof(movTag)),
            mp4Tag ?? throw new ArgumentNullException(nameof(mp4Tag)),
            webpTag ?? throw new ArgumentNullException(nameof(webpTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UnknownTag _: return 0;
                case PartialTag _: return 1;
                case JpegTag _: return 2;
                case GifTag _: return 3;
                case PngTag _: return 4;
                case PdfTag _: return 5;
                case Mp3Tag _: return 6;
                case MovTag _: return 7;
                case Mp4Tag _: return 8;
                case WebpTag _: return 9;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(FileType other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is FileType x && Equals(x);
        public static bool operator ==(FileType x, FileType y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FileType x, FileType y) => !(x == y);

        public int CompareTo(FileType other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FileType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FileType x, FileType y) => x.CompareTo(y) <= 0;
        public static bool operator <(FileType x, FileType y) => x.CompareTo(y) < 0;
        public static bool operator >(FileType x, FileType y) => x.CompareTo(y) > 0;
        public static bool operator >=(FileType x, FileType y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FileType.{_tag.GetType().Name}{_tag}";
    }
}