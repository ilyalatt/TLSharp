using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class DocumentAttribute : ITlType, IEquatable<DocumentAttribute>, IComparable<DocumentAttribute>, IComparable
    {
        public sealed class ImageSizeTag : ITlTypeTag, IEquatable<ImageSizeTag>, IComparable<ImageSizeTag>, IComparable
        {
            internal const uint TypeNumber = 0x6c37c15c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int W { get; }
            public int H { get; }
            
            public ImageSizeTag(
                int w,
                int h
            ) {
                W = w;
                H = h;
            }
            
            (int, int) CmpTuple =>
                (W, H);

            public bool Equals(ImageSizeTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ImageSizeTag x && Equals(x);
            public static bool operator ==(ImageSizeTag x, ImageSizeTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ImageSizeTag x, ImageSizeTag y) => !(x == y);

            public int CompareTo(ImageSizeTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ImageSizeTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ImageSizeTag x, ImageSizeTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ImageSizeTag x, ImageSizeTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ImageSizeTag x, ImageSizeTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ImageSizeTag x, ImageSizeTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(W: {W}, H: {H})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
            }
            
            internal static ImageSizeTag DeserializeTag(BinaryReader br)
            {
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                return new ImageSizeTag(w, h);
            }
        }

        public sealed class AnimatedTag : ITlTypeTag, IEquatable<AnimatedTag>, IComparable<AnimatedTag>, IComparable
        {
            internal const uint TypeNumber = 0x11b58939;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AnimatedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AnimatedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is AnimatedTag x && Equals(x);
            public static bool operator ==(AnimatedTag x, AnimatedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AnimatedTag x, AnimatedTag y) => !(x == y);

            public int CompareTo(AnimatedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is AnimatedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AnimatedTag x, AnimatedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AnimatedTag x, AnimatedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AnimatedTag x, AnimatedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AnimatedTag x, AnimatedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AnimatedTag DeserializeTag(BinaryReader br)
            {

                return new AnimatedTag();
            }
        }

        public sealed class StickerTag : ITlTypeTag, IEquatable<StickerTag>, IComparable<StickerTag>, IComparable
        {
            internal const uint TypeNumber = 0x6319d612;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Mask { get; }
            public string Alt { get; }
            public T.InputStickerSet Stickerset { get; }
            public Option<T.MaskCoords> MaskCoords { get; }
            
            public StickerTag(
                bool mask,
                Some<string> alt,
                Some<T.InputStickerSet> stickerset,
                Option<T.MaskCoords> maskCoords
            ) {
                Mask = mask;
                Alt = alt;
                Stickerset = stickerset;
                MaskCoords = maskCoords;
            }
            
            (bool, string, T.InputStickerSet, Option<T.MaskCoords>) CmpTuple =>
                (Mask, Alt, Stickerset, MaskCoords);

            public bool Equals(StickerTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is StickerTag x && Equals(x);
            public static bool operator ==(StickerTag x, StickerTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(StickerTag x, StickerTag y) => !(x == y);

            public int CompareTo(StickerTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is StickerTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(StickerTag x, StickerTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(StickerTag x, StickerTag y) => x.CompareTo(y) < 0;
            public static bool operator >(StickerTag x, StickerTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(StickerTag x, StickerTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Mask: {Mask}, Alt: {Alt}, Stickerset: {Stickerset}, MaskCoords: {MaskCoords})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Mask) | MaskBit(0, MaskCoords), bw, WriteInt);
                Write(Alt, bw, WriteString);
                Write(Stickerset, bw, WriteSerializable);
                Write(MaskCoords, bw, WriteOption<T.MaskCoords>(WriteSerializable));
            }
            
            internal static StickerTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var mask = Read(br, ReadOption(flags, 1));
                var alt = Read(br, ReadString);
                var stickerset = Read(br, T.InputStickerSet.Deserialize);
                var maskCoords = Read(br, ReadOption(flags, 0, T.MaskCoords.Deserialize));
                return new StickerTag(mask, alt, stickerset, maskCoords);
            }
        }

        public sealed class VideoTag : ITlTypeTag, IEquatable<VideoTag>, IComparable<VideoTag>, IComparable
        {
            internal const uint TypeNumber = 0x0ef02ce6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool RoundMessage { get; }
            public int Duration { get; }
            public int W { get; }
            public int H { get; }
            
            public VideoTag(
                bool roundMessage,
                int duration,
                int w,
                int h
            ) {
                RoundMessage = roundMessage;
                Duration = duration;
                W = w;
                H = h;
            }
            
            (bool, int, int, int) CmpTuple =>
                (RoundMessage, Duration, W, H);

            public bool Equals(VideoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is VideoTag x && Equals(x);
            public static bool operator ==(VideoTag x, VideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(VideoTag x, VideoTag y) => !(x == y);

            public int CompareTo(VideoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is VideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(VideoTag x, VideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(VideoTag x, VideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(VideoTag x, VideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(VideoTag x, VideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(RoundMessage: {RoundMessage}, Duration: {Duration}, W: {W}, H: {H})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, RoundMessage), bw, WriteInt);
                Write(Duration, bw, WriteInt);
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
            }
            
            internal static VideoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var roundMessage = Read(br, ReadOption(flags, 0));
                var duration = Read(br, ReadInt);
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                return new VideoTag(roundMessage, duration, w, h);
            }
        }

        public sealed class AudioTag : ITlTypeTag, IEquatable<AudioTag>, IComparable<AudioTag>, IComparable
        {
            internal const uint TypeNumber = 0x9852f9c6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Voice { get; }
            public int Duration { get; }
            public Option<string> Title { get; }
            public Option<string> Performer { get; }
            public Option<Arr<byte>> Waveform { get; }
            
            public AudioTag(
                bool voice,
                int duration,
                Option<string> title,
                Option<string> performer,
                Option<Arr<byte>> waveform
            ) {
                Voice = voice;
                Duration = duration;
                Title = title;
                Performer = performer;
                Waveform = waveform;
            }
            
            (bool, int, Option<string>, Option<string>, Option<Arr<byte>>) CmpTuple =>
                (Voice, Duration, Title, Performer, Waveform);

            public bool Equals(AudioTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is AudioTag x && Equals(x);
            public static bool operator ==(AudioTag x, AudioTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AudioTag x, AudioTag y) => !(x == y);

            public int CompareTo(AudioTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is AudioTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AudioTag x, AudioTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AudioTag x, AudioTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AudioTag x, AudioTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AudioTag x, AudioTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Voice: {Voice}, Duration: {Duration}, Title: {Title}, Performer: {Performer}, Waveform: {Waveform})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(10, Voice) | MaskBit(0, Title) | MaskBit(1, Performer) | MaskBit(2, Waveform), bw, WriteInt);
                Write(Duration, bw, WriteInt);
                Write(Title, bw, WriteOption<string>(WriteString));
                Write(Performer, bw, WriteOption<string>(WriteString));
                Write(Waveform, bw, WriteOption<Arr<byte>>(WriteBytes));
            }
            
            internal static AudioTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var voice = Read(br, ReadOption(flags, 10));
                var duration = Read(br, ReadInt);
                var title = Read(br, ReadOption(flags, 0, ReadString));
                var performer = Read(br, ReadOption(flags, 1, ReadString));
                var waveform = Read(br, ReadOption(flags, 2, ReadBytes));
                return new AudioTag(voice, duration, title, performer, waveform);
            }
        }

        public sealed class FilenameTag : ITlTypeTag, IEquatable<FilenameTag>, IComparable<FilenameTag>, IComparable
        {
            internal const uint TypeNumber = 0x15590068;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string FileName { get; }
            
            public FilenameTag(
                Some<string> fileName
            ) {
                FileName = fileName;
            }
            
            string CmpTuple =>
                FileName;

            public bool Equals(FilenameTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is FilenameTag x && Equals(x);
            public static bool operator ==(FilenameTag x, FilenameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FilenameTag x, FilenameTag y) => !(x == y);

            public int CompareTo(FilenameTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is FilenameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FilenameTag x, FilenameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FilenameTag x, FilenameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FilenameTag x, FilenameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FilenameTag x, FilenameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(FileName: {FileName})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(FileName, bw, WriteString);
            }
            
            internal static FilenameTag DeserializeTag(BinaryReader br)
            {
                var fileName = Read(br, ReadString);
                return new FilenameTag(fileName);
            }
        }

        public sealed class HasStickersTag : ITlTypeTag, IEquatable<HasStickersTag>, IComparable<HasStickersTag>, IComparable
        {
            internal const uint TypeNumber = 0x9801d2f7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public HasStickersTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(HasStickersTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is HasStickersTag x && Equals(x);
            public static bool operator ==(HasStickersTag x, HasStickersTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(HasStickersTag x, HasStickersTag y) => !(x == y);

            public int CompareTo(HasStickersTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is HasStickersTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(HasStickersTag x, HasStickersTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(HasStickersTag x, HasStickersTag y) => x.CompareTo(y) < 0;
            public static bool operator >(HasStickersTag x, HasStickersTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(HasStickersTag x, HasStickersTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HasStickersTag DeserializeTag(BinaryReader br)
            {

                return new HasStickersTag();
            }
        }

        readonly ITlTypeTag _tag;
        DocumentAttribute(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DocumentAttribute(ImageSizeTag tag) => new DocumentAttribute(tag);
        public static explicit operator DocumentAttribute(AnimatedTag tag) => new DocumentAttribute(tag);
        public static explicit operator DocumentAttribute(StickerTag tag) => new DocumentAttribute(tag);
        public static explicit operator DocumentAttribute(VideoTag tag) => new DocumentAttribute(tag);
        public static explicit operator DocumentAttribute(AudioTag tag) => new DocumentAttribute(tag);
        public static explicit operator DocumentAttribute(FilenameTag tag) => new DocumentAttribute(tag);
        public static explicit operator DocumentAttribute(HasStickersTag tag) => new DocumentAttribute(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DocumentAttribute Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case ImageSizeTag.TypeNumber: return (DocumentAttribute) ImageSizeTag.DeserializeTag(br);
                case AnimatedTag.TypeNumber: return (DocumentAttribute) AnimatedTag.DeserializeTag(br);
                case StickerTag.TypeNumber: return (DocumentAttribute) StickerTag.DeserializeTag(br);
                case VideoTag.TypeNumber: return (DocumentAttribute) VideoTag.DeserializeTag(br);
                case AudioTag.TypeNumber: return (DocumentAttribute) AudioTag.DeserializeTag(br);
                case FilenameTag.TypeNumber: return (DocumentAttribute) FilenameTag.DeserializeTag(br);
                case HasStickersTag.TypeNumber: return (DocumentAttribute) HasStickersTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ImageSizeTag.TypeNumber, AnimatedTag.TypeNumber, StickerTag.TypeNumber, VideoTag.TypeNumber, AudioTag.TypeNumber, FilenameTag.TypeNumber, HasStickersTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<ImageSizeTag, T> imageSizeTag = null,
            Func<AnimatedTag, T> animatedTag = null,
            Func<StickerTag, T> stickerTag = null,
            Func<VideoTag, T> videoTag = null,
            Func<AudioTag, T> audioTag = null,
            Func<FilenameTag, T> filenameTag = null,
            Func<HasStickersTag, T> hasStickersTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case ImageSizeTag x when imageSizeTag != null: return imageSizeTag(x);
                case AnimatedTag x when animatedTag != null: return animatedTag(x);
                case StickerTag x when stickerTag != null: return stickerTag(x);
                case VideoTag x when videoTag != null: return videoTag(x);
                case AudioTag x when audioTag != null: return audioTag(x);
                case FilenameTag x when filenameTag != null: return filenameTag(x);
                case HasStickersTag x when hasStickersTag != null: return hasStickersTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<ImageSizeTag, T> imageSizeTag,
            Func<AnimatedTag, T> animatedTag,
            Func<StickerTag, T> stickerTag,
            Func<VideoTag, T> videoTag,
            Func<AudioTag, T> audioTag,
            Func<FilenameTag, T> filenameTag,
            Func<HasStickersTag, T> hasStickersTag
        ) => Match(
            () => throw new Exception("WTF"),
            imageSizeTag ?? throw new ArgumentNullException(nameof(imageSizeTag)),
            animatedTag ?? throw new ArgumentNullException(nameof(animatedTag)),
            stickerTag ?? throw new ArgumentNullException(nameof(stickerTag)),
            videoTag ?? throw new ArgumentNullException(nameof(videoTag)),
            audioTag ?? throw new ArgumentNullException(nameof(audioTag)),
            filenameTag ?? throw new ArgumentNullException(nameof(filenameTag)),
            hasStickersTag ?? throw new ArgumentNullException(nameof(hasStickersTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case ImageSizeTag _: return 0;
                case AnimatedTag _: return 1;
                case StickerTag _: return 2;
                case VideoTag _: return 3;
                case AudioTag _: return 4;
                case FilenameTag _: return 5;
                case HasStickersTag _: return 6;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(DocumentAttribute other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is DocumentAttribute x && Equals(x);
        public static bool operator ==(DocumentAttribute x, DocumentAttribute y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DocumentAttribute x, DocumentAttribute y) => !(x == y);

        public int CompareTo(DocumentAttribute other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DocumentAttribute x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DocumentAttribute x, DocumentAttribute y) => x.CompareTo(y) <= 0;
        public static bool operator <(DocumentAttribute x, DocumentAttribute y) => x.CompareTo(y) < 0;
        public static bool operator >(DocumentAttribute x, DocumentAttribute y) => x.CompareTo(y) > 0;
        public static bool operator >=(DocumentAttribute x, DocumentAttribute y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"DocumentAttribute.{_tag.GetType().Name}{_tag}";
    }
}