using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PostAddress : ITlType, IEquatable<PostAddress>, IComparable<PostAddress>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x1e8caaeb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string StreetLine1 { get; }
            public string StreetLine2 { get; }
            public string City { get; }
            public string State { get; }
            public string CountryIso2 { get; }
            public string PostCode { get; }
            
            public Tag(
                Some<string> streetLine1,
                Some<string> streetLine2,
                Some<string> city,
                Some<string> state,
                Some<string> countryIso2,
                Some<string> postCode
            ) {
                StreetLine1 = streetLine1;
                StreetLine2 = streetLine2;
                City = city;
                State = state;
                CountryIso2 = countryIso2;
                PostCode = postCode;
            }
            
            (string, string, string, string, string, string) CmpTuple =>
                (StreetLine1, StreetLine2, City, State, CountryIso2, PostCode);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(StreetLine1: {StreetLine1}, StreetLine2: {StreetLine2}, City: {City}, State: {State}, CountryIso2: {CountryIso2}, PostCode: {PostCode})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(StreetLine1, bw, WriteString);
                Write(StreetLine2, bw, WriteString);
                Write(City, bw, WriteString);
                Write(State, bw, WriteString);
                Write(CountryIso2, bw, WriteString);
                Write(PostCode, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var streetLine1 = Read(br, ReadString);
                var streetLine2 = Read(br, ReadString);
                var city = Read(br, ReadString);
                var state = Read(br, ReadString);
                var countryIso2 = Read(br, ReadString);
                var postCode = Read(br, ReadString);
                return new Tag(streetLine1, streetLine2, city, state, countryIso2, postCode);
            }
        }

        readonly ITlTypeTag _tag;
        PostAddress(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PostAddress(Tag tag) => new PostAddress(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PostAddress Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PostAddress) Tag.DeserializeTag(br);
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

        public bool Equals(PostAddress other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PostAddress x && Equals(x);
        public static bool operator ==(PostAddress x, PostAddress y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PostAddress x, PostAddress y) => !(x == y);

        public int CompareTo(PostAddress other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PostAddress x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PostAddress x, PostAddress y) => x.CompareTo(y) <= 0;
        public static bool operator <(PostAddress x, PostAddress y) => x.CompareTo(y) < 0;
        public static bool operator >(PostAddress x, PostAddress y) => x.CompareTo(y) > 0;
        public static bool operator >=(PostAddress x, PostAddress y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PostAddress.{_tag.GetType().Name}{_tag}";
    }
}