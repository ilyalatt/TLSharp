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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8e1a1775;
            
            public string Country { get; }
            public int ThisDc { get; }
            public int NearestDc { get; }
            
            public Tag(
                Some<string> country,
                int thisDc,
                int nearestDc
            ) {
                Country = country;
                ThisDc = thisDc;
                NearestDc = nearestDc;
            }
            
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
                case 0x8e1a1775: return (NearestDc) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x8e1a1775 });
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

        public bool Equals(NearestDc other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is NearestDc x && Equals(x);
        public static bool operator ==(NearestDc a, NearestDc b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(NearestDc a, NearestDc b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(NearestDc other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is NearestDc x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(NearestDc a, NearestDc b) => a.CompareTo(b) <= 0;
        public static bool operator <(NearestDc a, NearestDc b) => a.CompareTo(b) < 0;
        public static bool operator >(NearestDc a, NearestDc b) => a.CompareTo(b) > 0;
        public static bool operator >=(NearestDc a, NearestDc b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}