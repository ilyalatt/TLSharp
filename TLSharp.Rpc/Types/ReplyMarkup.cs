using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ReplyMarkup : ITlType, IEquatable<ReplyMarkup>, IComparable<ReplyMarkup>, IComparable
    {
        public sealed class KeyboardHideTag : Record<KeyboardHideTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa03e5b85;
            
            public bool Selective { get; }
            
            public KeyboardHideTag(
                bool selective
            ) {
                Selective = selective;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, Selective), bw, WriteInt);
            }
            
            internal static KeyboardHideTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var selective = Read(br, ReadOption(flags, 2));
                return new KeyboardHideTag(selective);
            }
        }

        public sealed class KeyboardForceReplyTag : Record<KeyboardForceReplyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf4108aa0;
            
            public bool SingleUse { get; }
            public bool Selective { get; }
            
            public KeyboardForceReplyTag(
                bool singleUse,
                bool selective
            ) {
                SingleUse = singleUse;
                Selective = selective;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, SingleUse) | MaskBit(2, Selective), bw, WriteInt);
            }
            
            internal static KeyboardForceReplyTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var singleUse = Read(br, ReadOption(flags, 1));
                var selective = Read(br, ReadOption(flags, 2));
                return new KeyboardForceReplyTag(singleUse, selective);
            }
        }

        public sealed class KeyboardTag : Record<KeyboardTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3502758c;
            
            public bool Resize { get; }
            public bool SingleUse { get; }
            public bool Selective { get; }
            public Arr<T.KeyboardButtonRow> Rows { get; }
            
            public KeyboardTag(
                bool resize,
                bool singleUse,
                bool selective,
                Some<Arr<T.KeyboardButtonRow>> rows
            ) {
                Resize = resize;
                SingleUse = singleUse;
                Selective = selective;
                Rows = rows;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Resize) | MaskBit(1, SingleUse) | MaskBit(2, Selective), bw, WriteInt);
                Write(Rows, bw, WriteVector<T.KeyboardButtonRow>(WriteSerializable));
            }
            
            internal static KeyboardTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var resize = Read(br, ReadOption(flags, 0));
                var singleUse = Read(br, ReadOption(flags, 1));
                var selective = Read(br, ReadOption(flags, 2));
                var rows = Read(br, ReadVector(T.KeyboardButtonRow.Deserialize));
                return new KeyboardTag(resize, singleUse, selective, rows);
            }
        }

        public sealed class InlineTag : Record<InlineTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x48a30254;
            
            public Arr<T.KeyboardButtonRow> Rows { get; }
            
            public InlineTag(
                Some<Arr<T.KeyboardButtonRow>> rows
            ) {
                Rows = rows;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Rows, bw, WriteVector<T.KeyboardButtonRow>(WriteSerializable));
            }
            
            internal static InlineTag DeserializeTag(BinaryReader br)
            {
                var rows = Read(br, ReadVector(T.KeyboardButtonRow.Deserialize));
                return new InlineTag(rows);
            }
        }

        readonly ITlTypeTag _tag;
        ReplyMarkup(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ReplyMarkup(KeyboardHideTag tag) => new ReplyMarkup(tag);
        public static explicit operator ReplyMarkup(KeyboardForceReplyTag tag) => new ReplyMarkup(tag);
        public static explicit operator ReplyMarkup(KeyboardTag tag) => new ReplyMarkup(tag);
        public static explicit operator ReplyMarkup(InlineTag tag) => new ReplyMarkup(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ReplyMarkup Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xa03e5b85: return (ReplyMarkup) KeyboardHideTag.DeserializeTag(br);
                case 0xf4108aa0: return (ReplyMarkup) KeyboardForceReplyTag.DeserializeTag(br);
                case 0x3502758c: return (ReplyMarkup) KeyboardTag.DeserializeTag(br);
                case 0x48a30254: return (ReplyMarkup) InlineTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xa03e5b85, 0xf4108aa0, 0x3502758c, 0x48a30254 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<KeyboardHideTag, T> keyboardHideTag = null,
            Func<KeyboardForceReplyTag, T> keyboardForceReplyTag = null,
            Func<KeyboardTag, T> keyboardTag = null,
            Func<InlineTag, T> inlineTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case KeyboardHideTag x when keyboardHideTag != null: return keyboardHideTag(x);
                case KeyboardForceReplyTag x when keyboardForceReplyTag != null: return keyboardForceReplyTag(x);
                case KeyboardTag x when keyboardTag != null: return keyboardTag(x);
                case InlineTag x when inlineTag != null: return inlineTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<KeyboardHideTag, T> keyboardHideTag,
            Func<KeyboardForceReplyTag, T> keyboardForceReplyTag,
            Func<KeyboardTag, T> keyboardTag,
            Func<InlineTag, T> inlineTag
        ) => Match(
            () => throw new Exception("WTF"),
            keyboardHideTag ?? throw new ArgumentNullException(nameof(keyboardHideTag)),
            keyboardForceReplyTag ?? throw new ArgumentNullException(nameof(keyboardForceReplyTag)),
            keyboardTag ?? throw new ArgumentNullException(nameof(keyboardTag)),
            inlineTag ?? throw new ArgumentNullException(nameof(inlineTag))
        );

        public bool Equals(ReplyMarkup other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ReplyMarkup x && Equals(x);
        public static bool operator ==(ReplyMarkup a, ReplyMarkup b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ReplyMarkup a, ReplyMarkup b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case KeyboardHideTag _: return 0;
                case KeyboardForceReplyTag _: return 1;
                case KeyboardTag _: return 2;
                case InlineTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ReplyMarkup other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReplyMarkup x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReplyMarkup a, ReplyMarkup b) => a.CompareTo(b) <= 0;
        public static bool operator <(ReplyMarkup a, ReplyMarkup b) => a.CompareTo(b) < 0;
        public static bool operator >(ReplyMarkup a, ReplyMarkup b) => a.CompareTo(b) > 0;
        public static bool operator >=(ReplyMarkup a, ReplyMarkup b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}