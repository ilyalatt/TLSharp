using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class LangPackDifference : ITlType, IEquatable<LangPackDifference>, IComparable<LangPackDifference>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xf385c1f6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string LangCode;
            public readonly int FromVersion;
            public readonly int Version;
            public readonly Arr<T.LangPackString> Strings;
            
            public Tag(
                Some<string> langCode,
                int fromVersion,
                int version,
                Some<Arr<T.LangPackString>> strings
            ) {
                LangCode = langCode;
                FromVersion = fromVersion;
                Version = version;
                Strings = strings;
            }
            
            (string, int, int, Arr<T.LangPackString>) CmpTuple =>
                (LangCode, FromVersion, Version, Strings);

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

            public override string ToString() => $"(LangCode: {LangCode}, FromVersion: {FromVersion}, Version: {Version}, Strings: {Strings})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(LangCode, bw, WriteString);
                Write(FromVersion, bw, WriteInt);
                Write(Version, bw, WriteInt);
                Write(Strings, bw, WriteVector<T.LangPackString>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var langCode = Read(br, ReadString);
                var fromVersion = Read(br, ReadInt);
                var version = Read(br, ReadInt);
                var strings = Read(br, ReadVector(T.LangPackString.Deserialize));
                return new Tag(langCode, fromVersion, version, strings);
            }
        }

        readonly ITlTypeTag _tag;
        LangPackDifference(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator LangPackDifference(Tag tag) => new LangPackDifference(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static LangPackDifference Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (LangPackDifference) Tag.DeserializeTag(br);
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

        public bool Equals(LangPackDifference other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is LangPackDifference x && Equals(x);
        public static bool operator ==(LangPackDifference x, LangPackDifference y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(LangPackDifference x, LangPackDifference y) => !(x == y);

        public int CompareTo(LangPackDifference other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is LangPackDifference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LangPackDifference x, LangPackDifference y) => x.CompareTo(y) <= 0;
        public static bool operator <(LangPackDifference x, LangPackDifference y) => x.CompareTo(y) < 0;
        public static bool operator >(LangPackDifference x, LangPackDifference y) => x.CompareTo(y) > 0;
        public static bool operator >=(LangPackDifference x, LangPackDifference y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"LangPackDifference.{_tag.GetType().Name}{_tag}";
    }
}