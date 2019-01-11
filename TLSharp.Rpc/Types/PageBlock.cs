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
        public sealed class UnsupportedTag : ITlTypeTag, IEquatable<UnsupportedTag>, IComparable<UnsupportedTag>, IComparable
        {
            internal const uint TypeNumber = 0x13567e8a;
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

        public sealed class TitleTag : ITlTypeTag, IEquatable<TitleTag>, IComparable<TitleTag>, IComparable
        {
            internal const uint TypeNumber = 0x70abc3fd;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            
            public TitleTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            T.RichText CmpTuple =>
                Text;

            public bool Equals(TitleTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TitleTag x && Equals(x);
            public static bool operator ==(TitleTag x, TitleTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TitleTag x, TitleTag y) => !(x == y);

            public int CompareTo(TitleTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TitleTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TitleTag x, TitleTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TitleTag x, TitleTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TitleTag x, TitleTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TitleTag x, TitleTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
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

        public sealed class SubtitleTag : ITlTypeTag, IEquatable<SubtitleTag>, IComparable<SubtitleTag>, IComparable
        {
            internal const uint TypeNumber = 0x8ffa9a1f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            
            public SubtitleTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            T.RichText CmpTuple =>
                Text;

            public bool Equals(SubtitleTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SubtitleTag x && Equals(x);
            public static bool operator ==(SubtitleTag x, SubtitleTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SubtitleTag x, SubtitleTag y) => !(x == y);

            public int CompareTo(SubtitleTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SubtitleTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SubtitleTag x, SubtitleTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SubtitleTag x, SubtitleTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SubtitleTag x, SubtitleTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SubtitleTag x, SubtitleTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
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

        public sealed class AuthorDateTag : ITlTypeTag, IEquatable<AuthorDateTag>, IComparable<AuthorDateTag>, IComparable
        {
            internal const uint TypeNumber = 0xbaafe5e0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Author;
            public readonly int PublishedDate;
            
            public AuthorDateTag(
                Some<T.RichText> author,
                int publishedDate
            ) {
                Author = author;
                PublishedDate = publishedDate;
            }
            
            (T.RichText, int) CmpTuple =>
                (Author, PublishedDate);

            public bool Equals(AuthorDateTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AuthorDateTag x && Equals(x);
            public static bool operator ==(AuthorDateTag x, AuthorDateTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AuthorDateTag x, AuthorDateTag y) => !(x == y);

            public int CompareTo(AuthorDateTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AuthorDateTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AuthorDateTag x, AuthorDateTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AuthorDateTag x, AuthorDateTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AuthorDateTag x, AuthorDateTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AuthorDateTag x, AuthorDateTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Author: {Author}, PublishedDate: {PublishedDate})";
            
            
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

        public sealed class HeaderTag : ITlTypeTag, IEquatable<HeaderTag>, IComparable<HeaderTag>, IComparable
        {
            internal const uint TypeNumber = 0xbfd064ec;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            
            public HeaderTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            T.RichText CmpTuple =>
                Text;

            public bool Equals(HeaderTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is HeaderTag x && Equals(x);
            public static bool operator ==(HeaderTag x, HeaderTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(HeaderTag x, HeaderTag y) => !(x == y);

            public int CompareTo(HeaderTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is HeaderTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(HeaderTag x, HeaderTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(HeaderTag x, HeaderTag y) => x.CompareTo(y) < 0;
            public static bool operator >(HeaderTag x, HeaderTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(HeaderTag x, HeaderTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
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

        public sealed class SubheaderTag : ITlTypeTag, IEquatable<SubheaderTag>, IComparable<SubheaderTag>, IComparable
        {
            internal const uint TypeNumber = 0xf12bb6e1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            
            public SubheaderTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            T.RichText CmpTuple =>
                Text;

            public bool Equals(SubheaderTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SubheaderTag x && Equals(x);
            public static bool operator ==(SubheaderTag x, SubheaderTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SubheaderTag x, SubheaderTag y) => !(x == y);

            public int CompareTo(SubheaderTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SubheaderTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SubheaderTag x, SubheaderTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SubheaderTag x, SubheaderTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SubheaderTag x, SubheaderTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SubheaderTag x, SubheaderTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
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

        public sealed class ParagraphTag : ITlTypeTag, IEquatable<ParagraphTag>, IComparable<ParagraphTag>, IComparable
        {
            internal const uint TypeNumber = 0x467a0766;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            
            public ParagraphTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            T.RichText CmpTuple =>
                Text;

            public bool Equals(ParagraphTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ParagraphTag x && Equals(x);
            public static bool operator ==(ParagraphTag x, ParagraphTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ParagraphTag x, ParagraphTag y) => !(x == y);

            public int CompareTo(ParagraphTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ParagraphTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ParagraphTag x, ParagraphTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ParagraphTag x, ParagraphTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ParagraphTag x, ParagraphTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ParagraphTag x, ParagraphTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
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

        public sealed class PreformattedTag : ITlTypeTag, IEquatable<PreformattedTag>, IComparable<PreformattedTag>, IComparable
        {
            internal const uint TypeNumber = 0xc070d93e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            public readonly string Language;
            
            public PreformattedTag(
                Some<T.RichText> text,
                Some<string> language
            ) {
                Text = text;
                Language = language;
            }
            
            (T.RichText, string) CmpTuple =>
                (Text, Language);

            public bool Equals(PreformattedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PreformattedTag x && Equals(x);
            public static bool operator ==(PreformattedTag x, PreformattedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PreformattedTag x, PreformattedTag y) => !(x == y);

            public int CompareTo(PreformattedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PreformattedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PreformattedTag x, PreformattedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PreformattedTag x, PreformattedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PreformattedTag x, PreformattedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PreformattedTag x, PreformattedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text}, Language: {Language})";
            
            
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

        public sealed class FooterTag : ITlTypeTag, IEquatable<FooterTag>, IComparable<FooterTag>, IComparable
        {
            internal const uint TypeNumber = 0x48870999;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            
            public FooterTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            T.RichText CmpTuple =>
                Text;

            public bool Equals(FooterTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FooterTag x && Equals(x);
            public static bool operator ==(FooterTag x, FooterTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FooterTag x, FooterTag y) => !(x == y);

            public int CompareTo(FooterTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FooterTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FooterTag x, FooterTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FooterTag x, FooterTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FooterTag x, FooterTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FooterTag x, FooterTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text})";
            
            
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

        public sealed class DividerTag : ITlTypeTag, IEquatable<DividerTag>, IComparable<DividerTag>, IComparable
        {
            internal const uint TypeNumber = 0xdb20b188;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public DividerTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(DividerTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DividerTag x && Equals(x);
            public static bool operator ==(DividerTag x, DividerTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DividerTag x, DividerTag y) => !(x == y);

            public int CompareTo(DividerTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DividerTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DividerTag x, DividerTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DividerTag x, DividerTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DividerTag x, DividerTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DividerTag x, DividerTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static DividerTag DeserializeTag(BinaryReader br)
            {

                return new DividerTag();
            }
        }

        public sealed class AnchorTag : ITlTypeTag, IEquatable<AnchorTag>, IComparable<AnchorTag>, IComparable
        {
            internal const uint TypeNumber = 0xce0d37b0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Name;
            
            public AnchorTag(
                Some<string> name
            ) {
                Name = name;
            }
            
            string CmpTuple =>
                Name;

            public bool Equals(AnchorTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AnchorTag x && Equals(x);
            public static bool operator ==(AnchorTag x, AnchorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AnchorTag x, AnchorTag y) => !(x == y);

            public int CompareTo(AnchorTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AnchorTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AnchorTag x, AnchorTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AnchorTag x, AnchorTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AnchorTag x, AnchorTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AnchorTag x, AnchorTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Name: {Name})";
            
            
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

        public sealed class ListTag : ITlTypeTag, IEquatable<ListTag>, IComparable<ListTag>, IComparable
        {
            internal const uint TypeNumber = 0x3a58c7f4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Ordered;
            public readonly Arr<T.RichText> Items;
            
            public ListTag(
                bool ordered,
                Some<Arr<T.RichText>> items
            ) {
                Ordered = ordered;
                Items = items;
            }
            
            (bool, Arr<T.RichText>) CmpTuple =>
                (Ordered, Items);

            public bool Equals(ListTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ListTag x && Equals(x);
            public static bool operator ==(ListTag x, ListTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ListTag x, ListTag y) => !(x == y);

            public int CompareTo(ListTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ListTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ListTag x, ListTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ListTag x, ListTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ListTag x, ListTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ListTag x, ListTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Ordered: {Ordered}, Items: {Items})";
            
            
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

        public sealed class BlockquoteTag : ITlTypeTag, IEquatable<BlockquoteTag>, IComparable<BlockquoteTag>, IComparable
        {
            internal const uint TypeNumber = 0x263d7c26;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            public readonly T.RichText Caption;
            
            public BlockquoteTag(
                Some<T.RichText> text,
                Some<T.RichText> caption
            ) {
                Text = text;
                Caption = caption;
            }
            
            (T.RichText, T.RichText) CmpTuple =>
                (Text, Caption);

            public bool Equals(BlockquoteTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BlockquoteTag x && Equals(x);
            public static bool operator ==(BlockquoteTag x, BlockquoteTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BlockquoteTag x, BlockquoteTag y) => !(x == y);

            public int CompareTo(BlockquoteTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BlockquoteTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BlockquoteTag x, BlockquoteTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BlockquoteTag x, BlockquoteTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BlockquoteTag x, BlockquoteTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BlockquoteTag x, BlockquoteTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text}, Caption: {Caption})";
            
            
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

        public sealed class PullquoteTag : ITlTypeTag, IEquatable<PullquoteTag>, IComparable<PullquoteTag>, IComparable
        {
            internal const uint TypeNumber = 0x4f4456d3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.RichText Text;
            public readonly T.RichText Caption;
            
            public PullquoteTag(
                Some<T.RichText> text,
                Some<T.RichText> caption
            ) {
                Text = text;
                Caption = caption;
            }
            
            (T.RichText, T.RichText) CmpTuple =>
                (Text, Caption);

            public bool Equals(PullquoteTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PullquoteTag x && Equals(x);
            public static bool operator ==(PullquoteTag x, PullquoteTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PullquoteTag x, PullquoteTag y) => !(x == y);

            public int CompareTo(PullquoteTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PullquoteTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PullquoteTag x, PullquoteTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PullquoteTag x, PullquoteTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PullquoteTag x, PullquoteTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PullquoteTag x, PullquoteTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Text: {Text}, Caption: {Caption})";
            
            
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

        public sealed class PhotoTag : ITlTypeTag, IEquatable<PhotoTag>, IComparable<PhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0xe9c69982;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long PhotoId;
            public readonly T.RichText Caption;
            
            public PhotoTag(
                long photoId,
                Some<T.RichText> caption
            ) {
                PhotoId = photoId;
                Caption = caption;
            }
            
            (long, T.RichText) CmpTuple =>
                (PhotoId, Caption);

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

            public override string ToString() => $"(PhotoId: {PhotoId}, Caption: {Caption})";
            
            
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

        public sealed class VideoTag : ITlTypeTag, IEquatable<VideoTag>, IComparable<VideoTag>, IComparable
        {
            internal const uint TypeNumber = 0xd9d71866;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Autoplay;
            public readonly bool Loop;
            public readonly long VideoId;
            public readonly T.RichText Caption;
            
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
            
            (bool, bool, long, T.RichText) CmpTuple =>
                (Autoplay, Loop, VideoId, Caption);

            public bool Equals(VideoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is VideoTag x && Equals(x);
            public static bool operator ==(VideoTag x, VideoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(VideoTag x, VideoTag y) => !(x == y);

            public int CompareTo(VideoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is VideoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(VideoTag x, VideoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(VideoTag x, VideoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(VideoTag x, VideoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(VideoTag x, VideoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Autoplay: {Autoplay}, Loop: {Loop}, VideoId: {VideoId}, Caption: {Caption})";
            
            
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

        public sealed class CoverTag : ITlTypeTag, IEquatable<CoverTag>, IComparable<CoverTag>, IComparable
        {
            internal const uint TypeNumber = 0x39f23300;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.PageBlock Cover;
            
            public CoverTag(
                Some<T.PageBlock> cover
            ) {
                Cover = cover;
            }
            
            T.PageBlock CmpTuple =>
                Cover;

            public bool Equals(CoverTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CoverTag x && Equals(x);
            public static bool operator ==(CoverTag x, CoverTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CoverTag x, CoverTag y) => !(x == y);

            public int CompareTo(CoverTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CoverTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CoverTag x, CoverTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CoverTag x, CoverTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CoverTag x, CoverTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CoverTag x, CoverTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Cover: {Cover})";
            
            
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

        public sealed class EmbedTag : ITlTypeTag, IEquatable<EmbedTag>, IComparable<EmbedTag>, IComparable
        {
            internal const uint TypeNumber = 0xcde200d1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool FullWidth;
            public readonly bool AllowScrolling;
            public readonly Option<string> Url;
            public readonly Option<string> Html;
            public readonly Option<long> PosterPhotoId;
            public readonly int W;
            public readonly int H;
            public readonly T.RichText Caption;
            
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
            
            (bool, bool, Option<string>, Option<string>, Option<long>, int, int, T.RichText) CmpTuple =>
                (FullWidth, AllowScrolling, Url, Html, PosterPhotoId, W, H, Caption);

            public bool Equals(EmbedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmbedTag x && Equals(x);
            public static bool operator ==(EmbedTag x, EmbedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmbedTag x, EmbedTag y) => !(x == y);

            public int CompareTo(EmbedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmbedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmbedTag x, EmbedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmbedTag x, EmbedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmbedTag x, EmbedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmbedTag x, EmbedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(FullWidth: {FullWidth}, AllowScrolling: {AllowScrolling}, Url: {Url}, Html: {Html}, PosterPhotoId: {PosterPhotoId}, W: {W}, H: {H}, Caption: {Caption})";
            
            
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

        public sealed class EmbedPostTag : ITlTypeTag, IEquatable<EmbedPostTag>, IComparable<EmbedPostTag>, IComparable
        {
            internal const uint TypeNumber = 0x292c7be9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly long WebpageId;
            public readonly long AuthorPhotoId;
            public readonly string Author;
            public readonly int Date;
            public readonly Arr<T.PageBlock> Blocks;
            public readonly T.RichText Caption;
            
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
            
            (string, long, long, string, int, Arr<T.PageBlock>, T.RichText) CmpTuple =>
                (Url, WebpageId, AuthorPhotoId, Author, Date, Blocks, Caption);

            public bool Equals(EmbedPostTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmbedPostTag x && Equals(x);
            public static bool operator ==(EmbedPostTag x, EmbedPostTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmbedPostTag x, EmbedPostTag y) => !(x == y);

            public int CompareTo(EmbedPostTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmbedPostTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmbedPostTag x, EmbedPostTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmbedPostTag x, EmbedPostTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmbedPostTag x, EmbedPostTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmbedPostTag x, EmbedPostTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, WebpageId: {WebpageId}, AuthorPhotoId: {AuthorPhotoId}, Author: {Author}, Date: {Date}, Blocks: {Blocks}, Caption: {Caption})";
            
            
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

        public sealed class CollageTag : ITlTypeTag, IEquatable<CollageTag>, IComparable<CollageTag>, IComparable
        {
            internal const uint TypeNumber = 0x08b31c4f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.PageBlock> Items;
            public readonly T.RichText Caption;
            
            public CollageTag(
                Some<Arr<T.PageBlock>> items,
                Some<T.RichText> caption
            ) {
                Items = items;
                Caption = caption;
            }
            
            (Arr<T.PageBlock>, T.RichText) CmpTuple =>
                (Items, Caption);

            public bool Equals(CollageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CollageTag x && Equals(x);
            public static bool operator ==(CollageTag x, CollageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CollageTag x, CollageTag y) => !(x == y);

            public int CompareTo(CollageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CollageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CollageTag x, CollageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CollageTag x, CollageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CollageTag x, CollageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CollageTag x, CollageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Items: {Items}, Caption: {Caption})";
            
            
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

        public sealed class SlideshowTag : ITlTypeTag, IEquatable<SlideshowTag>, IComparable<SlideshowTag>, IComparable
        {
            internal const uint TypeNumber = 0x130c8963;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.PageBlock> Items;
            public readonly T.RichText Caption;
            
            public SlideshowTag(
                Some<Arr<T.PageBlock>> items,
                Some<T.RichText> caption
            ) {
                Items = items;
                Caption = caption;
            }
            
            (Arr<T.PageBlock>, T.RichText) CmpTuple =>
                (Items, Caption);

            public bool Equals(SlideshowTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SlideshowTag x && Equals(x);
            public static bool operator ==(SlideshowTag x, SlideshowTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SlideshowTag x, SlideshowTag y) => !(x == y);

            public int CompareTo(SlideshowTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SlideshowTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SlideshowTag x, SlideshowTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SlideshowTag x, SlideshowTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SlideshowTag x, SlideshowTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SlideshowTag x, SlideshowTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Items: {Items}, Caption: {Caption})";
            
            
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

        public sealed class ChannelTag : ITlTypeTag, IEquatable<ChannelTag>, IComparable<ChannelTag>, IComparable
        {
            internal const uint TypeNumber = 0xef1751b5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Chat Channel;
            
            public ChannelTag(
                Some<T.Chat> channel
            ) {
                Channel = channel;
            }
            
            T.Chat CmpTuple =>
                Channel;

            public bool Equals(ChannelTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChannelTag x && Equals(x);
            public static bool operator ==(ChannelTag x, ChannelTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelTag x, ChannelTag y) => !(x == y);

            public int CompareTo(ChannelTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChannelTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelTag x, ChannelTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelTag x, ChannelTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelTag x, ChannelTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelTag x, ChannelTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Channel: {Channel})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Channel, bw, WriteSerializable);
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var channel = Read(br, T.Chat.Deserialize);
                return new ChannelTag(channel);
            }
        }

        public sealed class AudioTag : ITlTypeTag, IEquatable<AudioTag>, IComparable<AudioTag>, IComparable
        {
            internal const uint TypeNumber = 0x31b81a7f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long AudioId;
            public readonly T.RichText Caption;
            
            public AudioTag(
                long audioId,
                Some<T.RichText> caption
            ) {
                AudioId = audioId;
                Caption = caption;
            }
            
            (long, T.RichText) CmpTuple =>
                (AudioId, Caption);

            public bool Equals(AudioTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AudioTag x && Equals(x);
            public static bool operator ==(AudioTag x, AudioTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AudioTag x, AudioTag y) => !(x == y);

            public int CompareTo(AudioTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AudioTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AudioTag x, AudioTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AudioTag x, AudioTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AudioTag x, AudioTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AudioTag x, AudioTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(AudioId: {AudioId}, Caption: {Caption})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(AudioId, bw, WriteLong);
                Write(Caption, bw, WriteSerializable);
            }
            
            internal static AudioTag DeserializeTag(BinaryReader br)
            {
                var audioId = Read(br, ReadLong);
                var caption = Read(br, T.RichText.Deserialize);
                return new AudioTag(audioId, caption);
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
        public static explicit operator PageBlock(ChannelTag tag) => new PageBlock(tag);
        public static explicit operator PageBlock(AudioTag tag) => new PageBlock(tag);

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
                case UnsupportedTag.TypeNumber: return (PageBlock) UnsupportedTag.DeserializeTag(br);
                case TitleTag.TypeNumber: return (PageBlock) TitleTag.DeserializeTag(br);
                case SubtitleTag.TypeNumber: return (PageBlock) SubtitleTag.DeserializeTag(br);
                case AuthorDateTag.TypeNumber: return (PageBlock) AuthorDateTag.DeserializeTag(br);
                case HeaderTag.TypeNumber: return (PageBlock) HeaderTag.DeserializeTag(br);
                case SubheaderTag.TypeNumber: return (PageBlock) SubheaderTag.DeserializeTag(br);
                case ParagraphTag.TypeNumber: return (PageBlock) ParagraphTag.DeserializeTag(br);
                case PreformattedTag.TypeNumber: return (PageBlock) PreformattedTag.DeserializeTag(br);
                case FooterTag.TypeNumber: return (PageBlock) FooterTag.DeserializeTag(br);
                case DividerTag.TypeNumber: return (PageBlock) DividerTag.DeserializeTag(br);
                case AnchorTag.TypeNumber: return (PageBlock) AnchorTag.DeserializeTag(br);
                case ListTag.TypeNumber: return (PageBlock) ListTag.DeserializeTag(br);
                case BlockquoteTag.TypeNumber: return (PageBlock) BlockquoteTag.DeserializeTag(br);
                case PullquoteTag.TypeNumber: return (PageBlock) PullquoteTag.DeserializeTag(br);
                case PhotoTag.TypeNumber: return (PageBlock) PhotoTag.DeserializeTag(br);
                case VideoTag.TypeNumber: return (PageBlock) VideoTag.DeserializeTag(br);
                case CoverTag.TypeNumber: return (PageBlock) CoverTag.DeserializeTag(br);
                case EmbedTag.TypeNumber: return (PageBlock) EmbedTag.DeserializeTag(br);
                case EmbedPostTag.TypeNumber: return (PageBlock) EmbedPostTag.DeserializeTag(br);
                case CollageTag.TypeNumber: return (PageBlock) CollageTag.DeserializeTag(br);
                case SlideshowTag.TypeNumber: return (PageBlock) SlideshowTag.DeserializeTag(br);
                case ChannelTag.TypeNumber: return (PageBlock) ChannelTag.DeserializeTag(br);
                case AudioTag.TypeNumber: return (PageBlock) AudioTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UnsupportedTag.TypeNumber, TitleTag.TypeNumber, SubtitleTag.TypeNumber, AuthorDateTag.TypeNumber, HeaderTag.TypeNumber, SubheaderTag.TypeNumber, ParagraphTag.TypeNumber, PreformattedTag.TypeNumber, FooterTag.TypeNumber, DividerTag.TypeNumber, AnchorTag.TypeNumber, ListTag.TypeNumber, BlockquoteTag.TypeNumber, PullquoteTag.TypeNumber, PhotoTag.TypeNumber, VideoTag.TypeNumber, CoverTag.TypeNumber, EmbedTag.TypeNumber, EmbedPostTag.TypeNumber, CollageTag.TypeNumber, SlideshowTag.TypeNumber, ChannelTag.TypeNumber, AudioTag.TypeNumber });
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
            Func<SlideshowTag, T> slideshowTag = null,
            Func<ChannelTag, T> channelTag = null,
            Func<AudioTag, T> audioTag = null
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
                case ChannelTag x when channelTag != null: return channelTag(x);
                case AudioTag x when audioTag != null: return audioTag(x);
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
            Func<SlideshowTag, T> slideshowTag,
            Func<ChannelTag, T> channelTag,
            Func<AudioTag, T> audioTag
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
            slideshowTag ?? throw new ArgumentNullException(nameof(slideshowTag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag)),
            audioTag ?? throw new ArgumentNullException(nameof(audioTag))
        );

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
                case ChannelTag _: return 21;
                case AudioTag _: return 22;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(PageBlock other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PageBlock x && Equals(x);
        public static bool operator ==(PageBlock x, PageBlock y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PageBlock x, PageBlock y) => !(x == y);

        public int CompareTo(PageBlock other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PageBlock x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PageBlock x, PageBlock y) => x.CompareTo(y) <= 0;
        public static bool operator <(PageBlock x, PageBlock y) => x.CompareTo(y) < 0;
        public static bool operator >(PageBlock x, PageBlock y) => x.CompareTo(y) > 0;
        public static bool operator >=(PageBlock x, PageBlock y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PageBlock.{_tag.GetType().Name}{_tag}";
    }
}