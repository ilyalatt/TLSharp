using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class DisabledFeature : ITlType, IEquatable<DisabledFeature>, IComparable<DisabledFeature>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xae636f24;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Feature { get; }
            public string Description { get; }
            
            public Tag(
                Some<string> feature,
                Some<string> description
            ) {
                Feature = feature;
                Description = description;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Feature, bw, WriteString);
                Write(Description, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var feature = Read(br, ReadString);
                var description = Read(br, ReadString);
                return new Tag(feature, description);
            }
        }

        readonly ITlTypeTag _tag;
        DisabledFeature(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DisabledFeature(Tag tag) => new DisabledFeature(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DisabledFeature Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (DisabledFeature) Tag.DeserializeTag(br);
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

        public bool Equals(DisabledFeature other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is DisabledFeature x && Equals(x);
        public static bool operator ==(DisabledFeature a, DisabledFeature b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(DisabledFeature a, DisabledFeature b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(DisabledFeature other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DisabledFeature x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DisabledFeature a, DisabledFeature b) => a.CompareTo(b) <= 0;
        public static bool operator <(DisabledFeature a, DisabledFeature b) => a.CompareTo(b) < 0;
        public static bool operator >(DisabledFeature a, DisabledFeature b) => a.CompareTo(b) > 0;
        public static bool operator >=(DisabledFeature a, DisabledFeature b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}