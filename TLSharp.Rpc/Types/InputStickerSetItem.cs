using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputStickerSetItem : ITlType, IEquatable<InputStickerSetItem>, IComparable<InputStickerSetItem>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xffa0a496;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputDocument Document;
            public readonly string Emoji;
            public readonly Option<T.MaskCoords> MaskCoords;
            
            public Tag(
                Some<T.InputDocument> document,
                Some<string> emoji,
                Option<T.MaskCoords> maskCoords
            ) {
                Document = document;
                Emoji = emoji;
                MaskCoords = maskCoords;
            }
            
            (T.InputDocument, string, Option<T.MaskCoords>) CmpTuple =>
                (Document, Emoji, MaskCoords);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Document: {Document}, Emoji: {Emoji}, MaskCoords: {MaskCoords})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, MaskCoords), bw, WriteInt);
                Write(Document, bw, WriteSerializable);
                Write(Emoji, bw, WriteString);
                Write(MaskCoords, bw, WriteOption<T.MaskCoords>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var document = Read(br, T.InputDocument.Deserialize);
                var emoji = Read(br, ReadString);
                var maskCoords = Read(br, ReadOption(flags, 0, T.MaskCoords.Deserialize));
                return new Tag(document, emoji, maskCoords);
            }
        }

        readonly ITlTypeTag _tag;
        InputStickerSetItem(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputStickerSetItem(Tag tag) => new InputStickerSetItem(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputStickerSetItem Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputStickerSetItem) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputStickerSetItem other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputStickerSetItem x && Equals(x);
        public static bool operator ==(InputStickerSetItem x, InputStickerSetItem y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputStickerSetItem x, InputStickerSetItem y) => !(x == y);

        public int CompareTo(InputStickerSetItem other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputStickerSetItem x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputStickerSetItem x, InputStickerSetItem y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputStickerSetItem x, InputStickerSetItem y) => x.CompareTo(y) < 0;
        public static bool operator >(InputStickerSetItem x, InputStickerSetItem y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputStickerSetItem x, InputStickerSetItem y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputStickerSetItem.{_tag.GetType().Name}{_tag}";
    }
}