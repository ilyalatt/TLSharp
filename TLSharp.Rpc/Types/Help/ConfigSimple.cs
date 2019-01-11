using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class ConfigSimple : ITlType, IEquatable<ConfigSimple>, IComparable<ConfigSimple>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x5a592a6c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Date;
            public readonly int Expires;
            public readonly Arr<T.AccessPointRule> Rules;
            
            public Tag(
                int date,
                int expires,
                Some<Arr<T.AccessPointRule>> rules
            ) {
                Date = date;
                Expires = expires;
                Rules = rules;
            }
            
            (int, int, Arr<T.AccessPointRule>) CmpTuple =>
                (Date, Expires, Rules);

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

            public override string ToString() => $"(Date: {Date}, Expires: {Expires}, Rules: {Rules})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Date, bw, WriteInt);
                Write(Expires, bw, WriteInt);
                Write(Rules, bw, WriteVector<T.AccessPointRule>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var date = Read(br, ReadInt);
                var expires = Read(br, ReadInt);
                var rules = Read(br, ReadVector(T.AccessPointRule.Deserialize));
                return new Tag(date, expires, rules);
            }
        }

        readonly ITlTypeTag _tag;
        ConfigSimple(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ConfigSimple(Tag tag) => new ConfigSimple(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ConfigSimple Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ConfigSimple) Tag.DeserializeTag(br);
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

        public bool Equals(ConfigSimple other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ConfigSimple x && Equals(x);
        public static bool operator ==(ConfigSimple x, ConfigSimple y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ConfigSimple x, ConfigSimple y) => !(x == y);

        public int CompareTo(ConfigSimple other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ConfigSimple x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ConfigSimple x, ConfigSimple y) => x.CompareTo(y) <= 0;
        public static bool operator <(ConfigSimple x, ConfigSimple y) => x.CompareTo(y) < 0;
        public static bool operator >(ConfigSimple x, ConfigSimple y) => x.CompareTo(y) > 0;
        public static bool operator >=(ConfigSimple x, ConfigSimple y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ConfigSimple.{_tag.GetType().Name}{_tag}";
    }
}