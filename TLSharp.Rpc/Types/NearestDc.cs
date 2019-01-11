using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class NearestDc : ITlType, IEquatable<NearestDc>, IComparable<NearestDc>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x8e1a1775;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Country;
            public readonly int ThisDc;
            public readonly int NearestDc;
            
            public Tag(
                Some<string> country,
                int thisDc,
                int nearestDc
            ) {
                Country = country;
                ThisDc = thisDc;
                NearestDc = nearestDc;
            }
            
            (string, int, int) CmpTuple =>
                (Country, ThisDc, NearestDc);

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

            public override string ToString() => $"(Country: {Country}, ThisDc: {ThisDc}, NearestDc: {NearestDc})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Country, bw, WriteString);
                Write(ThisDc, bw, WriteInt);
                Write(NearestDc, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var country = Read(br, ReadString);
                var thisDc = Read(br, ReadInt);
                var nearestDc = Read(br, ReadInt);
                return new Tag(country, thisDc, nearestDc);
            }
        }

        readonly ITlTypeTag _tag;
        NearestDc(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator NearestDc(Tag tag) => new NearestDc(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static NearestDc Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (NearestDc) Tag.DeserializeTag(br);
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

        public bool Equals(NearestDc other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is NearestDc x && Equals(x);
        public static bool operator ==(NearestDc x, NearestDc y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(NearestDc x, NearestDc y) => !(x == y);

        public int CompareTo(NearestDc other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is NearestDc x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(NearestDc x, NearestDc y) => x.CompareTo(y) <= 0;
        public static bool operator <(NearestDc x, NearestDc y) => x.CompareTo(y) < 0;
        public static bool operator >(NearestDc x, NearestDc y) => x.CompareTo(y) > 0;
        public static bool operator >=(NearestDc x, NearestDc y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"NearestDc.{_tag.GetType().Name}{_tag}";
    }
}