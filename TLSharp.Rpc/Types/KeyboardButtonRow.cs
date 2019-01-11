using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class KeyboardButtonRow : ITlType, IEquatable<KeyboardButtonRow>, IComparable<KeyboardButtonRow>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x77608b83;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.KeyboardButton> Buttons;
            
            public Tag(
                Some<Arr<T.KeyboardButton>> buttons
            ) {
                Buttons = buttons;
            }
            
            Arr<T.KeyboardButton> CmpTuple =>
                Buttons;

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

            public override string ToString() => $"(Buttons: {Buttons})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Buttons, bw, WriteVector<T.KeyboardButton>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var buttons = Read(br, ReadVector(T.KeyboardButton.Deserialize));
                return new Tag(buttons);
            }
        }

        readonly ITlTypeTag _tag;
        KeyboardButtonRow(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator KeyboardButtonRow(Tag tag) => new KeyboardButtonRow(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static KeyboardButtonRow Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (KeyboardButtonRow) Tag.DeserializeTag(br);
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

        public bool Equals(KeyboardButtonRow other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is KeyboardButtonRow x && Equals(x);
        public static bool operator ==(KeyboardButtonRow x, KeyboardButtonRow y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(KeyboardButtonRow x, KeyboardButtonRow y) => !(x == y);

        public int CompareTo(KeyboardButtonRow other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is KeyboardButtonRow x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(KeyboardButtonRow x, KeyboardButtonRow y) => x.CompareTo(y) <= 0;
        public static bool operator <(KeyboardButtonRow x, KeyboardButtonRow y) => x.CompareTo(y) < 0;
        public static bool operator >(KeyboardButtonRow x, KeyboardButtonRow y) => x.CompareTo(y) > 0;
        public static bool operator >=(KeyboardButtonRow x, KeyboardButtonRow y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"KeyboardButtonRow.{_tag.GetType().Name}{_tag}";
    }
}