using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class LangPackLanguage : ITlType, IEquatable<LangPackLanguage>, IComparable<LangPackLanguage>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x117698f1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Name;
            public readonly string NativeName;
            public readonly string LangCode;
            
            public Tag(
                Some<string> name,
                Some<string> nativeName,
                Some<string> langCode
            ) {
                Name = name;
                NativeName = nativeName;
                LangCode = langCode;
            }
            
            (string, string, string) CmpTuple =>
                (Name, NativeName, LangCode);

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

            public override string ToString() => $"(Name: {Name}, NativeName: {NativeName}, LangCode: {LangCode})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Name, bw, WriteString);
                Write(NativeName, bw, WriteString);
                Write(LangCode, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var name = Read(br, ReadString);
                var nativeName = Read(br, ReadString);
                var langCode = Read(br, ReadString);
                return new Tag(name, nativeName, langCode);
            }
        }

        readonly ITlTypeTag _tag;
        LangPackLanguage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator LangPackLanguage(Tag tag) => new LangPackLanguage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static LangPackLanguage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (LangPackLanguage) Tag.DeserializeTag(br);
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

        public bool Equals(LangPackLanguage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is LangPackLanguage x && Equals(x);
        public static bool operator ==(LangPackLanguage x, LangPackLanguage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(LangPackLanguage x, LangPackLanguage y) => !(x == y);

        public int CompareTo(LangPackLanguage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is LangPackLanguage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LangPackLanguage x, LangPackLanguage y) => x.CompareTo(y) <= 0;
        public static bool operator <(LangPackLanguage x, LangPackLanguage y) => x.CompareTo(y) < 0;
        public static bool operator >(LangPackLanguage x, LangPackLanguage y) => x.CompareTo(y) > 0;
        public static bool operator >=(LangPackLanguage x, LangPackLanguage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"LangPackLanguage.{_tag.GetType().Name}{_tag}";
    }
}