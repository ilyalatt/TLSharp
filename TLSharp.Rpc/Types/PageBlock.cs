using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PageBlock : ITlType, IEquatable<PageBlock>, IComparable<PageBlock>, IComparable
    {
        public sealed class UnsupportedTag : Record<UnsupportedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x13567e8a;
            

            
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

        public sealed class TitleTag : Record<TitleTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x70abc3fd;
            
            public T.RichText Text { get; }
            
            public TitleTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static TitleTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new TitleTag(text);
            }
        }

        public sealed class SubtitleTag : Record<SubtitleTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8ffa9a1f;
            
            public T.RichText Text { get; }
            
            public SubtitleTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static SubtitleTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new SubtitleTag(text);
            }
        }

        public sealed class AuthorDateTag : Record<AuthorDateTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbaafe5e0;
            
            public T.RichText Author { get; }
            public int PublishedDate { get; }
            
            public AuthorDateTag(
                Some<T.RichText> author,
                int publishedDate
            ) {
                Author = author;
                PublishedDate = publishedDate;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Author, bw, WriteSerializable);
                Write(PublishedDate, bw, WriteInt);
            }
            
            internal static AuthorDateTag DeserializeTag(BinaryReader br)
            {
                var author = Read(br, T.RichText.Deserialize);
                var publishedDate = Read(br, ReadInt);
                return new AuthorDateTag(author, publishedDate);
            }
        }

        public sealed class HeaderTag : Record<HeaderTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbfd064ec;
            
            public T.RichText Text { get; }
            
            public HeaderTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static HeaderTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new HeaderTag(text);
            }
        }

        public sealed class SubheaderTag : Record<SubheaderTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf12bb6e1;
            
            public T.RichText Text { get; }
            
            public SubheaderTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static SubheaderTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new SubheaderTag(text);
            }
        }

        public sealed class ParagraphTag : Record<ParagraphTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x467a0766;
            
            public T.RichText Text { get; }
            
            public ParagraphTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static ParagraphTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new ParagraphTag(text);
            }
        }

        public sealed class PreformattedTag : Record<PreformattedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc070d93e;
            
            public T.RichText Text { get; }
            public string Language { get; }
            
            public PreformattedTag(
                Some<T.RichText> text,
                Some<string> language
            ) {
                Text = text;
                Language = language;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
                Write(Language, bw, WriteString);
            }
            
            internal static PreformattedTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                var language = Read(br, ReadString);
                return new PreformattedTag(text, language);
            }
        }

        public sealed class FooterTag : Record<FooterTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x48870999;
            
            public T.RichText Text { get; }
            
            public FooterTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static FooterTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new FooterTag(text);
            }
        }

        public sealed class DividerTag : Record<DividerTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xdb20b188;
            

            
            public DividerTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static DividerTag DeserializeTag(BinaryReader br)
            {

                return new DividerTag();
            }
        }

        public sealed class AnchorTag : Record<AnchorTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xce0d37b0;
            
            public string Name { get; }
            
            public AnchorTag(
                Some<string> name
            ) {
                Name = name;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Name, bw, WriteString);
            }
            
            internal static AnchorTag DeserializeTag(BinaryReader br)
            {
                var name = Read(br, ReadString);
                return new AnchorTag(name);
            }
        }

        public sealed class ListTag : Record<ListTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3a58c7f4;
            
            public bool Ordered { get; }
            public Arr<T.RichText> Items { get; }
            
            public ListTag(
                bool ordered,
                Some<Arr<T.RichText>> items
            ) {
                Ordered = ordered;
                Items = items;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Ordered, bw, WriteBool);
                Write(Items, bw, WriteVector<T.RichText>(WriteSerializable));
            }
            
            internal static ListTag DeserializeTag(BinaryReader br)
            {
                var ordered = Read(br, ReadBool);
                var items = Read(br, ReadVector(T.RichText.Deserialize));
                return new ListTag(ordered, items);
            }
        }

        public sealed class BlockquoteTag : Record<BlockquoteTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x263d7c26;
            
            public T.RichText Text { get; }
            public T.RichText Caption { get; }
            
            public BlockquoteTag(
                Some<T.RichText> text,
                Some<T.RichText> caption
            ) {
                Text = text;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static BlockquoteTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                var caption = Read(br, T.RichText.Deserialize);
                return new BlockquoteTag(text, caption);
            }
        }

        public sealed class PullquoteTag : Record<PullquoteTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x4f4456d3;
            
            public T.RichText Text { get; }
            public T.RichText Caption { get; }
            
            public PullquoteTag(
                Some<T.RichText> text,
                Some<T.RichText> caption
            ) {
                Text = text;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static PullquoteTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                var caption = Read(br, T.RichText.Deserialize);
                return new PullquoteTag(text, caption);
            }
        }

        public sealed class PhotoTag : Record<PhotoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe9c69982;
            
            public long PhotoId { get; }
            public T.RichText Caption { get; }
            
            public PhotoTag(
                long photoId,
                Some<T.RichText> caption
            ) {
                PhotoId = photoId;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhotoId, bw, WriteLong);
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var photoId = Read(br, ReadLong);
                var caption = Read(br, T.RichText.Deserialize);
                return new PhotoTag(photoId, caption);
            }
        }

        public sealed class VideoTag : Record<VideoTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xd9d71866;
            
            public bool Autoplay { get; }
            public bool Loop { get; }
            public long VideoId { get; }
            public T.RichText Caption { get; }
            
            public VideoTag(
                bool autoplay,
                bool loop,
                long videoId,
                Some<T.RichText> caption
            ) {
                Autoplay = autoplay;
                Loop = loop;
                VideoId = videoId;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Autoplay) | MaskBit(1, Loop), bw, WriteInt);
                Write(VideoId, bw, WriteLong);
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static VideoTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var autoplay = Read(br, ReadOption(flags, 0));
                var loop = Read(br, ReadOption(flags, 1));
                var videoId = Read(br, ReadLong);
                var caption = Read(br, T.RichText.Deserialize);
                return new VideoTag(autoplay, loop, videoId, caption);
            }
        }

        public sealed class CoverTag : Record<CoverTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x39f23300;
            
            public T.PageBlock Cover { get; }
            
            public CoverTag(
                Some<T.PageBlock> cover
            ) {
                Cover = cover;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Cover, bw, WriteSerializable);
            }
            
            internal static CoverTag DeserializeTag(BinaryReader br)
            {
                var cover = Read(br, T.PageBlock.Deserialize);
                return new CoverTag(cover);
            }
        }

        public sealed class EmbedTag : Record<EmbedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xcde200d1;
            
            public bool FullWidth { get; }
            public bool AllowScrolling { get; }
            public Option<string> Url { get; }
            public Option<string> Html { get; }
            public Option<long> PosterPhotoId { get; }
            public int W { get; }
            public int H { get; }
            public T.RichText Caption { get; }
            
            public EmbedTag(
                bool fullWidth,
                bool allowScrolling,
                Option<string> url,
                Option<string> html,
                Option<long> posterPhotoId,
                int w,
                int h,
                Some<T.RichText> caption
            ) {
                FullWidth = fullWidth;
                AllowScrolling = allowScrolling;
                Url = url;
                Html = html;
                PosterPhotoId = posterPhotoId;
                W = w;
                H = h;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, FullWidth) | MaskBit(3, AllowScrolling) | MaskBit(1, Url) | MaskBit(2, Html) | MaskBit(4, PosterPhotoId), bw, WriteInt);
                Write(Url, bw, WriteOption<string>(WriteString));
                Write(Html, bw, WriteOption<string>(WriteString));
                Write(PosterPhotoId, bw, WriteOption<long>(WriteLong));
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static EmbedTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var fullWidth = Read(br, ReadOption(flags, 0));
                var allowScrolling = Read(br, ReadOption(flags, 3));
                var url = Read(br, ReadOption(flags, 1, ReadString));
                var html = Read(br, ReadOption(flags, 2, ReadString));
                var posterPhotoId = Read(br, ReadOption(flags, 4, ReadLong));
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                var caption = Read(br, T.RichText.Deserialize);
                return new EmbedTag(fullWidth, allowScrolling, url, html, posterPhotoId, w, h, caption);
            }
        }

        public sealed class EmbedPostTag : Record<EmbedPostTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x292c7be9;
            
            public string Url { get; }
            public long WebpageId { get; }
            public long AuthorPhotoId { get; }
            public string Author { get; }
            public int Date { get; }
            public Arr<T.PageBlock> Blocks { get; }
            public T.RichText Caption { get; }
            
            public EmbedPostTag(
                Some<string> url,
                long webpageId,
                long authorPhotoId,
                Some<string> author,
                int date,
                Some<Arr<T.PageBlock>> blocks,
                Some<T.RichText> caption
            ) {
                Url = url;
                WebpageId = webpageId;
                AuthorPhotoId = authorPhotoId;
                Author = author;
                Date = date;
                Blocks = blocks;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(WebpageId, bw, WriteLong);
                Write(AuthorPhotoId, bw, WriteLong);
                Write(Author, bw, WriteString);
                Write(Date, bw, WriteInt);
                Write(Blocks, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static EmbedPostTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var webpageId = Read(br, ReadLong);
                var authorPhotoId = Read(br, ReadLong);
                var author = Read(br, ReadString);
                var date = Read(br, ReadInt);
                var blocks = Read(br, ReadVector(T.PageBlock.Deserialize));
                var caption = Read(br, T.RichText.Deserialize);
                return new EmbedPostTag(url, webpageId, authorPhotoId, author, date, blocks, caption);
            }
        }

        public sealed class CollageTag : Record<CollageTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x08b31c4f;
            
            public Arr<T.PageBlock> Items { get; }
            public T.RichText Caption { get; }
            
            public CollageTag(
                Some<Arr<T.PageBlock>> items,
                Some<T.RichText> caption
            ) {
                Items = items;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Items, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static CollageTag DeserializeTag(BinaryReader br)
            {
                var items = Read(br, ReadVector(T.PageBlock.Deserialize));
                var caption = Read(br, T.RichText.Deserialize);
                return new CollageTag(items, caption);
            }
        }

        public sealed class SlideshowTag : Record<SlideshowTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x130c8963;
            
            public Arr<T.PageBlock> Items { get; }
            public T.RichText Caption { get; }
            
            public SlideshowTag(
                Some<Arr<T.PageBlock>> items,
                Some<T.RichText> caption
            ) {
                Items = items;
                Caption = caption;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Items, bw, WriteVector<T.PageBlock>(WriteSerializable));
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static SlideshowTag DeserializeTag(BinaryReader br)
            {
                var items = Read(br, ReadVector(T.PageBlock.Deserialize));
                var caption = Read(br, T.RichText.Deserialize);
                return new SlideshowTag(items, caption);
            }
        }

        readonly ITlTypeTag _tag;
        PageBlock(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PageBlock(UnsupportedTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(TitleTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(SubtitleTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(AuthorDateTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(HeaderTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(SubheaderTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(ParagraphTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(PreformattedTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(FooterTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(DividerTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(AnchorTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(ListTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(BlockquoteTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(PullquoteTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(PhotoTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(VideoTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(CoverTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(EmbedTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(EmbedPostTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(CollageTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(SlideshowTag tag) => new PageBlock(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PageBlock Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x13567e8a: return (PageBlock) UnsupportedTag.DeserializeTag(br);
                case 0x70abc3fd: return (PageBlock) TitleTag.DeserializeTag(br);
                case 0x8ffa9a1f: return (PageBlock) SubtitleTag.DeserializeTag(br);
                case 0xbaafe5e0: return (PageBlock) AuthorDateTag.DeserializeTag(br);
                case 0xbfd064ec: return (PageBlock) HeaderTag.DeserializeTag(br);
                case 0xf12bb6e1: return (PageBlock) SubheaderTag.DeserializeTag(br);
                case 0x467a0766: return (PageBlock) ParagraphTag.DeserializeTag(br);
                case 0xc070d93e: return (PageBlock) PreformattedTag.DeserializeTag(br);
                case 0x48870999: return (PageBlock) FooterTag.DeserializeTag(br);
                case 0xdb20b188: return (PageBlock) DividerTag.DeserializeTag(br);
                case 0xce0d37b0: return (PageBlock) AnchorTag.DeserializeTag(br);
                case 0x3a58c7f4: return (PageBlock) ListTag.DeserializeTag(br);
                case 0x263d7c26: return (PageBlock) BlockquoteTag.DeserializeTag(br);
                case 0x4f4456d3: return (PageBlock) PullquoteTag.DeserializeTag(br);
                case 0xe9c69982: return (PageBlock) PhotoTag.DeserializeTag(br);
                case 0xd9d71866: return (PageBlock) VideoTag.DeserializeTag(br);
                case 0x39f23300: return (PageBlock) CoverTag.DeserializeTag(br);
                case 0xcde200d1: return (PageBlock) EmbedTag.DeserializeTag(br);
                case 0x292c7be9: return (PageBlock) EmbedPostTag.DeserializeTag(br);
                case 0x08b31c4f: return (PageBlock) CollageTag.DeserializeTag(br);
                case 0x130c8963: return (PageBlock) SlideshowTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x13567e8a, 0x70abc3fd, 0x8ffa9a1f, 0xbaafe5e0, 0xbfd064ec, 0xf12bb6e1, 0x467a0766, 0xc070d93e, 0x48870999, 0xdb20b188, 0xce0d37b0, 0x3a58c7f4, 0x263d7c26, 0x4f4456d3, 0xe9c69982, 0xd9d71866, 0x39f23300, 0xcde200d1, 0x292c7be9, 0x08b31c4f, 0x130c8963 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UnsupportedTag, T> unsupportedTag = null,
            Func<TitleTag, T> titleTag = null,
            Func<SubtitleTag, T> subtitleTag = null,
            Func<AuthorDateTag, T> authorDateTag = null,
            Func<HeaderTag, T> headerTag = null,
            Func<SubheaderTag, T> subheaderTag = null,
            Func<ParagraphTag, T> paragraphTag = null,
            Func<PreformattedTag, T> preformattedTag = null,
            Func<FooterTag, T> footerTag = null,
            Func<DividerTag, T> dividerTag = null,
            Func<AnchorTag, T> anchorTag = null,
            Func<ListTag, T> listTag = null,
            Func<BlockquoteTag, T> blockquoteTag = null,
            Func<PullquoteTag, T> pullquoteTag = null,
            Func<PhotoTag, T> photoTag = null,
            Func<VideoTag, T> videoTag = null,
            Func<CoverTag, T> coverTag = null,
            Func<EmbedTag, T> embedTag = null,
            Func<EmbedPostTag, T> embedPostTag = null,
            Func<CollageTag, T> collageTag = null,
            Func<SlideshowTag, T> slideshowTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UnsupportedTag x when unsupportedTag != null: return unsupportedTag(x);
                case TitleTag x when titleTag != null: return titleTag(x);
                case SubtitleTag x when subtitleTag != null: return subtitleTag(x);
                case AuthorDateTag x when authorDateTag != null: return authorDateTag(x);
                case HeaderTag x when headerTag != null: return headerTag(x);
                case SubheaderTag x when subheaderTag != null: return subheaderTag(x);
                case ParagraphTag x when paragraphTag != null: return paragraphTag(x);
                case PreformattedTag x when preformattedTag != null: return preformattedTag(x);
                case FooterTag x when footerTag != null: return footerTag(x);
                case DividerTag x when dividerTag != null: return dividerTag(x);
                case AnchorTag x when anchorTag != null: return anchorTag(x);
                case ListTag x when listTag != null: return listTag(x);
                case BlockquoteTag x when blockquoteTag != null: return blockquoteTag(x);
                case PullquoteTag x when pullquoteTag != null: return pullquoteTag(x);
                case PhotoTag x when photoTag != null: return photoTag(x);
                case VideoTag x when videoTag != null: return videoTag(x);
                case CoverTag x when coverTag != null: return coverTag(x);
                case EmbedTag x when embedTag != null: return embedTag(x);
                case EmbedPostTag x when embedPostTag != null: return embedPostTag(x);
                case CollageTag x when collageTag != null: return collageTag(x);
                case SlideshowTag x when slideshowTag != null: return slideshowTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UnsupportedTag, T> unsupportedTag,
            Func<TitleTag, T> titleTag,
            Func<SubtitleTag, T> subtitleTag,
            Func<AuthorDateTag, T> authorDateTag,
            Func<HeaderTag, T> headerTag,
            Func<SubheaderTag, T> subheaderTag,
            Func<ParagraphTag, T> paragraphTag,
            Func<PreformattedTag, T> preformattedTag,
            Func<FooterTag, T> footerTag,
            Func<DividerTag, T> dividerTag,
            Func<AnchorTag, T> anchorTag,
            Func<ListTag, T> listTag,
            Func<BlockquoteTag, T> blockquoteTag,
            Func<PullquoteTag, T> pullquoteTag,
            Func<PhotoTag, T> photoTag,
            Func<VideoTag, T> videoTag,
            Func<CoverTag, T> coverTag,
            Func<EmbedTag, T> embedTag,
            Func<EmbedPostTag, T> embedPostTag,
            Func<CollageTag, T> collageTag,
            Func<SlideshowTag, T> slideshowTag
        ) => Match(
            () => throw new Exception("WTF"),
            unsupportedTag ?? throw new ArgumentNullException(nameof(unsupportedTag)),
            titleTag ?? throw new ArgumentNullException(nameof(titleTag)),
            subtitleTag ?? throw new ArgumentNullException(nameof(subtitleTag)),
            authorDateTag ?? throw new ArgumentNullException(nameof(authorDateTag)),
            headerTag ?? throw new ArgumentNullException(nameof(headerTag)),
            subheaderTag ?? throw new ArgumentNullException(nameof(subheaderTag)),
            paragraphTag ?? throw new ArgumentNullException(nameof(paragraphTag)),
            preformattedTag ?? throw new ArgumentNullException(nameof(preformattedTag)),
            footerTag ?? throw new ArgumentNullException(nameof(footerTag)),
            dividerTag ?? throw new ArgumentNullException(nameof(dividerTag)),
            anchorTag ?? throw new ArgumentNullException(nameof(anchorTag)),
            listTag ?? throw new ArgumentNullException(nameof(listTag)),
            blockquoteTag ?? throw new ArgumentNullException(nameof(blockquoteTag)),
            pullquoteTag ?? throw new ArgumentNullException(nameof(pullquoteTag)),
            photoTag ?? throw new ArgumentNullException(nameof(photoTag)),
            videoTag ?? throw new ArgumentNullException(nameof(videoTag)),
            coverTag ?? throw new ArgumentNullException(nameof(coverTag)),
            embedTag ?? throw new ArgumentNullException(nameof(embedTag)),
            embedPostTag ?? throw new ArgumentNullException(nameof(embedPostTag)),
            collageTag ?? throw new ArgumentNullException(nameof(collageTag)),
            slideshowTag ?? throw new ArgumentNullException(nameof(slideshowTag))
        );

        public bool Equals(PageBlock other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PageBlock x && Equals(x);
        public static bool operator ==(PageBlock a, PageBlock b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PageBlock a, PageBlock b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UnsupportedTag _: return 0;
                case TitleTag _: return 1;
                case SubtitleTag _: return 2;
                case AuthorDateTag _: return 3;
                case HeaderTag _: return 4;
                case SubheaderTag _: return 5;
                case ParagraphTag _: return 6;
                case PreformattedTag _: return 7;
                case FooterTag _: return 8;
                case DividerTag _: return 9;
                case AnchorTag _: return 10;
                case ListTag _: return 11;
                case BlockquoteTag _: return 12;
                case PullquoteTag _: return 13;
                case PhotoTag _: return 14;
                case VideoTag _: return 15;
                case CoverTag _: return 16;
                case EmbedTag _: return 17;
                case EmbedPostTag _: return 18;
                case CollageTag _: return 19;
                case SlideshowTag _: return 20;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PageBlock other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PageBlock x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PageBlock a, PageBlock b) => a.CompareTo(b) <= 0;
        public static bool operator <(PageBlock a, PageBlock b) => a.CompareTo(b) < 0;
        public static bool operator >(PageBlock a, PageBlock b) => a.CompareTo(b) > 0;
        public static bool operator >=(PageBlock a, PageBlock b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}