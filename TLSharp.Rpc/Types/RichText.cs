using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class RichText : ITlType, IEquatable<RichText>, IComparable<RichText>, IComparable
    {
        public sealed class TextEmptyTag : Record<TextEmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xdc3d824f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public TextEmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static TextEmptyTag DeserializeTag(BinaryReader br)
            {

                return new TextEmptyTag();
            }
        }

        public sealed class TextPlainTag : Record<TextPlainTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x744694e0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Text { get; }
            
            public TextPlainTag(
                Some<string> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteString);
            }
            
            internal static TextPlainTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, ReadString);
                return new TextPlainTag(text);
            }
        }

        public sealed class TextBoldTag : Record<TextBoldTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x6724abc4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            
            public TextBoldTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static TextBoldTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new TextBoldTag(text);
            }
        }

        public sealed class TextItalicTag : Record<TextItalicTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd912a59c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            
            public TextItalicTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static TextItalicTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new TextItalicTag(text);
            }
        }

        public sealed class TextUnderlineTag : Record<TextUnderlineTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc12622c4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            
            public TextUnderlineTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static TextUnderlineTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new TextUnderlineTag(text);
            }
        }

        public sealed class TextStrikeTag : Record<TextStrikeTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9bf8bb95;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            
            public TextStrikeTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static TextStrikeTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new TextStrikeTag(text);
            }
        }

        public sealed class TextFixedTag : Record<TextFixedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x6c3f19b9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            
            public TextFixedTag(
                Some<T.RichText> text
            ) {
                Text = text;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
            }
            
            internal static TextFixedTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                return new TextFixedTag(text);
            }
        }

        public sealed class TextUrlTag : Record<TextUrlTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x3c2884c1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            public string Url { get; }
            public long WebpageId { get; }
            
            public TextUrlTag(
                Some<T.RichText> text,
                Some<string> url,
                long webpageId
            ) {
                Text = text;
                Url = url;
                WebpageId = webpageId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
                Write(Url, bw, WriteString);
                Write(WebpageId, bw, WriteLong);
            }
            
            internal static TextUrlTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                var url = Read(br, ReadString);
                var webpageId = Read(br, ReadLong);
                return new TextUrlTag(text, url, webpageId);
            }
        }

        public sealed class TextEmailTag : Record<TextEmailTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xde5a0dd6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.RichText Text { get; }
            public string Email { get; }
            
            public TextEmailTag(
                Some<T.RichText> text,
                Some<string> email
            ) {
                Text = text;
                Email = email;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Text, bw, WriteSerializable);
                Write(Email, bw, WriteString);
            }
            
            internal static TextEmailTag DeserializeTag(BinaryReader br)
            {
                var text = Read(br, T.RichText.Deserialize);
                var email = Read(br, ReadString);
                return new TextEmailTag(text, email);
            }
        }

        public sealed class TextConcatTag : Record<TextConcatTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x7e6260d7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.RichText> Texts { get; }
            
            public TextConcatTag(
                Some<Arr<T.RichText>> texts
            ) {
                Texts = texts;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Texts, bw, WriteVector<T.RichText>(WriteSerializable));
            }
            
            internal static TextConcatTag DeserializeTag(BinaryReader br)
            {
                var texts = Read(br, ReadVector(T.RichText.Deserialize));
                return new TextConcatTag(texts);
            }
        }

        readonly ITlTypeTag _tag;
        RichText(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator RichText(TextEmptyTag tag) => new RichText(tag);
        public static explicit operator RichText(TextPlainTag tag) => new RichText(tag);
        public static explicit operator RichText(TextBoldTag tag) => new RichText(tag);
        public static explicit operator RichText(TextItalicTag tag) => new RichText(tag);
        public static explicit operator RichText(TextUnderlineTag tag) => new RichText(tag);
        public static explicit operator RichText(TextStrikeTag tag) => new RichText(tag);
        public static explicit operator RichText(TextFixedTag tag) => new RichText(tag);
        public static explicit operator RichText(TextUrlTag tag) => new RichText(tag);
        public static explicit operator RichText(TextEmailTag tag) => new RichText(tag);
        public static explicit operator RichText(TextConcatTag tag) => new RichText(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static RichText Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case TextEmptyTag.TypeNumber: return (RichText) TextEmptyTag.DeserializeTag(br);
                case TextPlainTag.TypeNumber: return (RichText) TextPlainTag.DeserializeTag(br);
                case TextBoldTag.TypeNumber: return (RichText) TextBoldTag.DeserializeTag(br);
                case TextItalicTag.TypeNumber: return (RichText) TextItalicTag.DeserializeTag(br);
                case TextUnderlineTag.TypeNumber: return (RichText) TextUnderlineTag.DeserializeTag(br);
                case TextStrikeTag.TypeNumber: return (RichText) TextStrikeTag.DeserializeTag(br);
                case TextFixedTag.TypeNumber: return (RichText) TextFixedTag.DeserializeTag(br);
                case TextUrlTag.TypeNumber: return (RichText) TextUrlTag.DeserializeTag(br);
                case TextEmailTag.TypeNumber: return (RichText) TextEmailTag.DeserializeTag(br);
                case TextConcatTag.TypeNumber: return (RichText) TextConcatTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { TextEmptyTag.TypeNumber, TextPlainTag.TypeNumber, TextBoldTag.TypeNumber, TextItalicTag.TypeNumber, TextUnderlineTag.TypeNumber, TextStrikeTag.TypeNumber, TextFixedTag.TypeNumber, TextUrlTag.TypeNumber, TextEmailTag.TypeNumber, TextConcatTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<TextEmptyTag, T> textEmptyTag = null,
            Func<TextPlainTag, T> textPlainTag = null,
            Func<TextBoldTag, T> textBoldTag = null,
            Func<TextItalicTag, T> textItalicTag = null,
            Func<TextUnderlineTag, T> textUnderlineTag = null,
            Func<TextStrikeTag, T> textStrikeTag = null,
            Func<TextFixedTag, T> textFixedTag = null,
            Func<TextUrlTag, T> textUrlTag = null,
            Func<TextEmailTag, T> textEmailTag = null,
            Func<TextConcatTag, T> textConcatTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case TextEmptyTag x when textEmptyTag != null: return textEmptyTag(x);
                case TextPlainTag x when textPlainTag != null: return textPlainTag(x);
                case TextBoldTag x when textBoldTag != null: return textBoldTag(x);
                case TextItalicTag x when textItalicTag != null: return textItalicTag(x);
                case TextUnderlineTag x when textUnderlineTag != null: return textUnderlineTag(x);
                case TextStrikeTag x when textStrikeTag != null: return textStrikeTag(x);
                case TextFixedTag x when textFixedTag != null: return textFixedTag(x);
                case TextUrlTag x when textUrlTag != null: return textUrlTag(x);
                case TextEmailTag x when textEmailTag != null: return textEmailTag(x);
                case TextConcatTag x when textConcatTag != null: return textConcatTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<TextEmptyTag, T> textEmptyTag,
            Func<TextPlainTag, T> textPlainTag,
            Func<TextBoldTag, T> textBoldTag,
            Func<TextItalicTag, T> textItalicTag,
            Func<TextUnderlineTag, T> textUnderlineTag,
            Func<TextStrikeTag, T> textStrikeTag,
            Func<TextFixedTag, T> textFixedTag,
            Func<TextUrlTag, T> textUrlTag,
            Func<TextEmailTag, T> textEmailTag,
            Func<TextConcatTag, T> textConcatTag
        ) => Match(
            () => throw new Exception("WTF"),
            textEmptyTag ?? throw new ArgumentNullException(nameof(textEmptyTag)),
            textPlainTag ?? throw new ArgumentNullException(nameof(textPlainTag)),
            textBoldTag ?? throw new ArgumentNullException(nameof(textBoldTag)),
            textItalicTag ?? throw new ArgumentNullException(nameof(textItalicTag)),
            textUnderlineTag ?? throw new ArgumentNullException(nameof(textUnderlineTag)),
            textStrikeTag ?? throw new ArgumentNullException(nameof(textStrikeTag)),
            textFixedTag ?? throw new ArgumentNullException(nameof(textFixedTag)),
            textUrlTag ?? throw new ArgumentNullException(nameof(textUrlTag)),
            textEmailTag ?? throw new ArgumentNullException(nameof(textEmailTag)),
            textConcatTag ?? throw new ArgumentNullException(nameof(textConcatTag))
        );

        public bool Equals(RichText other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is RichText x && Equals(x);
        public static bool operator ==(RichText a, RichText b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(RichText a, RichText b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case TextEmptyTag _: return 0;
                case TextPlainTag _: return 1;
                case TextBoldTag _: return 2;
                case TextItalicTag _: return 3;
                case TextUnderlineTag _: return 4;
                case TextStrikeTag _: return 5;
                case TextFixedTag _: return 6;
                case TextUrlTag _: return 7;
                case TextEmailTag _: return 8;
                case TextConcatTag _: return 9;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(RichText other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is RichText x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RichText a, RichText b) => a.CompareTo(b) <= 0;
        public static bool operator <(RichText a, RichText b) => a.CompareTo(b) < 0;
        public static bool operator >(RichText a, RichText b) => a.CompareTo(b) > 0;
        public static bool operator >=(RichText a, RichText b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}