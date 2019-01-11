using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class LangPackString : ITlType, IEquatable<LangPackString>, IComparable<LangPackString>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xcad181f6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Key;
            public readonly string Value;
            
            public Tag(
                Some<string> key,
                Some<string> value
            ) {
                Key = key;
                Value = value;
            }
            
            (string, string) CmpTuple =>
                (Key, Value);

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

            public override string ToString() => $"(Key: {Key}, Value: {Value})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Key, bw, WriteString);
                Write(Value, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var key = Read(br, ReadString);
                var value = Read(br, ReadString);
                return new Tag(key, value);
            }
        }

        public sealed class PluralizedTag : ITlTypeTag, IEquatable<PluralizedTag>, IComparable<PluralizedTag>, IComparable
        {
            internal const uint TypeNumber = 0x6c47ac9f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Key;
            public readonly Option<string> ZeroValue;
            public readonly Option<string> OneValue;
            public readonly Option<string> TwoValue;
            public readonly Option<string> FewValue;
            public readonly Option<string> ManyValue;
            public readonly string OtherValue;
            
            public PluralizedTag(
                Some<string> key,
                Option<string> zeroValue,
                Option<string> oneValue,
                Option<string> twoValue,
                Option<string> fewValue,
                Option<string> manyValue,
                Some<string> otherValue
            ) {
                Key = key;
                ZeroValue = zeroValue;
                OneValue = oneValue;
                TwoValue = twoValue;
                FewValue = fewValue;
                ManyValue = manyValue;
                OtherValue = otherValue;
            }
            
            (string, Option<string>, Option<string>, Option<string>, Option<string>, Option<string>, string) CmpTuple =>
                (Key, ZeroValue, OneValue, TwoValue, FewValue, ManyValue, OtherValue);

            public bool Equals(PluralizedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PluralizedTag x && Equals(x);
            public static bool operator ==(PluralizedTag x, PluralizedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PluralizedTag x, PluralizedTag y) => !(x == y);

            public int CompareTo(PluralizedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PluralizedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PluralizedTag x, PluralizedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PluralizedTag x, PluralizedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PluralizedTag x, PluralizedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PluralizedTag x, PluralizedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Key: {Key}, ZeroValue: {ZeroValue}, OneValue: {OneValue}, TwoValue: {TwoValue}, FewValue: {FewValue}, ManyValue: {ManyValue}, OtherValue: {OtherValue})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, ZeroValue) | MaskBit(1, OneValue) | MaskBit(2, TwoValue) | MaskBit(3, FewValue) | MaskBit(4, ManyValue), bw, WriteInt);
                Write(Key, bw, WriteString);
                Write(ZeroValue, bw, WriteOption<string>(WriteString));
                Write(OneValue, bw, WriteOption<string>(WriteString));
                Write(TwoValue, bw, WriteOption<string>(WriteString));
                Write(FewValue, bw, WriteOption<string>(WriteString));
                Write(ManyValue, bw, WriteOption<string>(WriteString));
                Write(OtherValue, bw, WriteString);
            }
            
            internal static PluralizedTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var key = Read(br, ReadString);
                var zeroValue = Read(br, ReadOption(flags, 0, ReadString));
                var oneValue = Read(br, ReadOption(flags, 1, ReadString));
                var twoValue = Read(br, ReadOption(flags, 2, ReadString));
                var fewValue = Read(br, ReadOption(flags, 3, ReadString));
                var manyValue = Read(br, ReadOption(flags, 4, ReadString));
                var otherValue = Read(br, ReadString);
                return new PluralizedTag(key, zeroValue, oneValue, twoValue, fewValue, manyValue, otherValue);
            }
        }

        public sealed class DeletedTag : ITlTypeTag, IEquatable<DeletedTag>, IComparable<DeletedTag>, IComparable
        {
            internal const uint TypeNumber = 0x2979eeb2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Key;
            
            public DeletedTag(
                Some<string> key
            ) {
                Key = key;
            }
            
            string CmpTuple =>
                Key;

            public bool Equals(DeletedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DeletedTag x && Equals(x);
            public static bool operator ==(DeletedTag x, DeletedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DeletedTag x, DeletedTag y) => !(x == y);

            public int CompareTo(DeletedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DeletedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DeletedTag x, DeletedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DeletedTag x, DeletedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DeletedTag x, DeletedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DeletedTag x, DeletedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Key: {Key})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Key, bw, WriteString);
            }
            
            internal static DeletedTag DeserializeTag(BinaryReader br)
            {
                var key = Read(br, ReadString);
                return new DeletedTag(key);
            }
        }

        readonly ITlTypeTag _tag;
        LangPackString(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator LangPackString(Tag tag) => new LangPackString(tag);
        public static explicit operator LangPackString(PluralizedTag tag) => new LangPackString(tag);
        public static explicit operator LangPackString(DeletedTag tag) => new LangPackString(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static LangPackString Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (LangPackString) Tag.DeserializeTag(br);
                case PluralizedTag.TypeNumber: return (LangPackString) PluralizedTag.DeserializeTag(br);
                case DeletedTag.TypeNumber: return (LangPackString) DeletedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, PluralizedTag.TypeNumber, DeletedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<PluralizedTag, T> pluralizedTag = null,
            Func<DeletedTag, T> deletedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case PluralizedTag x when pluralizedTag != null: return pluralizedTag(x);
                case DeletedTag x when deletedTag != null: return deletedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<PluralizedTag, T> pluralizedTag,
            Func<DeletedTag, T> deletedTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            pluralizedTag ?? throw new ArgumentNullException(nameof(pluralizedTag)),
            deletedTag ?? throw new ArgumentNullException(nameof(deletedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case PluralizedTag _: return 1;
                case DeletedTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(LangPackString other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is LangPackString x && Equals(x);
        public static bool operator ==(LangPackString x, LangPackString y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(LangPackString x, LangPackString y) => !(x == y);

        public int CompareTo(LangPackString other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is LangPackString x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LangPackString x, LangPackString y) => x.CompareTo(y) <= 0;
        public static bool operator <(LangPackString x, LangPackString y) => x.CompareTo(y) < 0;
        public static bool operator >(LangPackString x, LangPackString y) => x.CompareTo(y) > 0;
        public static bool operator >=(LangPackString x, LangPackString y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"LangPackString.{_tag.GetType().Name}{_tag}";
    }
}