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
        public sealed class KeyboardHideTag : ITlTypeTag, IEquatable<KeyboardHideTag>, IComparable<KeyboardHideTag>, IComparable
        {
            internal const uint TypeNumber = 0xa03e5b85;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Selective { get; }
            
            public KeyboardHideTag(
                bool selective
            ) {
                Selective = selective;
            }
            
            bool CmpTuple =>
                Selective;

            public bool Equals(KeyboardHideTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is KeyboardHideTag x && Equals(x);
            public static bool operator ==(KeyboardHideTag x, KeyboardHideTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(KeyboardHideTag x, KeyboardHideTag y) => !(x == y);

            public int CompareTo(KeyboardHideTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is KeyboardHideTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(KeyboardHideTag x, KeyboardHideTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(KeyboardHideTag x, KeyboardHideTag y) => x.CompareTo(y) < 0;
            public static bool operator >(KeyboardHideTag x, KeyboardHideTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(KeyboardHideTag x, KeyboardHideTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Selective: {Selective})";
            
            
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

        public sealed class KeyboardForceReplyTag : ITlTypeTag, IEquatable<KeyboardForceReplyTag>, IComparable<KeyboardForceReplyTag>, IComparable
        {
            internal const uint TypeNumber = 0xf4108aa0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool SingleUse { get; }
            public bool Selective { get; }
            
            public KeyboardForceReplyTag(
                bool singleUse,
                bool selective
            ) {
                SingleUse = singleUse;
                Selective = selective;
            }
            
            (bool, bool) CmpTuple =>
                (SingleUse, Selective);

            public bool Equals(KeyboardForceReplyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is KeyboardForceReplyTag x && Equals(x);
            public static bool operator ==(KeyboardForceReplyTag x, KeyboardForceReplyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(KeyboardForceReplyTag x, KeyboardForceReplyTag y) => !(x == y);

            public int CompareTo(KeyboardForceReplyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is KeyboardForceReplyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(KeyboardForceReplyTag x, KeyboardForceReplyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(KeyboardForceReplyTag x, KeyboardForceReplyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(KeyboardForceReplyTag x, KeyboardForceReplyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(KeyboardForceReplyTag x, KeyboardForceReplyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(SingleUse: {SingleUse}, Selective: {Selective})";
            
            
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

        public sealed class KeyboardTag : ITlTypeTag, IEquatable<KeyboardTag>, IComparable<KeyboardTag>, IComparable
        {
            internal const uint TypeNumber = 0x3502758c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (bool, bool, bool, Arr<T.KeyboardButtonRow>) CmpTuple =>
                (Resize, SingleUse, Selective, Rows);

            public bool Equals(KeyboardTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is KeyboardTag x && Equals(x);
            public static bool operator ==(KeyboardTag x, KeyboardTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(KeyboardTag x, KeyboardTag y) => !(x == y);

            public int CompareTo(KeyboardTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is KeyboardTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(KeyboardTag x, KeyboardTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(KeyboardTag x, KeyboardTag y) => x.CompareTo(y) < 0;
            public static bool operator >(KeyboardTag x, KeyboardTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(KeyboardTag x, KeyboardTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Resize: {Resize}, SingleUse: {SingleUse}, Selective: {Selective}, Rows: {Rows})";
            
            
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

        public sealed class InlineTag : ITlTypeTag, IEquatable<InlineTag>, IComparable<InlineTag>, IComparable
        {
            internal const uint TypeNumber = 0x48a30254;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.KeyboardButtonRow> Rows { get; }
            
            public InlineTag(
                Some<Arr<T.KeyboardButtonRow>> rows
            ) {
                Rows = rows;
            }
            
            Arr<T.KeyboardButtonRow> CmpTuple =>
                Rows;

            public bool Equals(InlineTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is InlineTag x && Equals(x);
            public static bool operator ==(InlineTag x, InlineTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InlineTag x, InlineTag y) => !(x == y);

            public int CompareTo(InlineTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is InlineTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InlineTag x, InlineTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InlineTag x, InlineTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InlineTag x, InlineTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InlineTag x, InlineTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Rows: {Rows})";
            
            
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
                case KeyboardHideTag.TypeNumber: return (ReplyMarkup) KeyboardHideTag.DeserializeTag(br);
                case KeyboardForceReplyTag.TypeNumber: return (ReplyMarkup) KeyboardForceReplyTag.DeserializeTag(br);
                case KeyboardTag.TypeNumber: return (ReplyMarkup) KeyboardTag.DeserializeTag(br);
                case InlineTag.TypeNumber: return (ReplyMarkup) InlineTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { KeyboardHideTag.TypeNumber, KeyboardForceReplyTag.TypeNumber, KeyboardTag.TypeNumber, InlineTag.TypeNumber });
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

        public bool Equals(ReplyMarkup other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ReplyMarkup x && Equals(x);
        public static bool operator ==(ReplyMarkup x, ReplyMarkup y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReplyMarkup x, ReplyMarkup y) => !(x == y);

        public int CompareTo(ReplyMarkup other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReplyMarkup x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReplyMarkup x, ReplyMarkup y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReplyMarkup x, ReplyMarkup y) => x.CompareTo(y) < 0;
        public static bool operator >(ReplyMarkup x, ReplyMarkup y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReplyMarkup x, ReplyMarkup y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ReplyMarkup.{_tag.GetType().Name}{_tag}";
    }
}