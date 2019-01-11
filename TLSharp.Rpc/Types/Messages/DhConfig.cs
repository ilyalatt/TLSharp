using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class DhConfig : ITlType, IEquatable<DhConfig>, IComparable<DhConfig>, IComparable
    {
        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0xc0e24635;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<byte> Random { get; }
            
            public NotModifiedTag(
                Some<Arr<byte>> random
            ) {
                Random = random;
            }
            
            Arr<byte> CmpTuple =>
                Random;

            public bool Equals(NotModifiedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NotModifiedTag x && Equals(x);
            public static bool operator ==(NotModifiedTag x, NotModifiedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NotModifiedTag x, NotModifiedTag y) => !(x == y);

            public int CompareTo(NotModifiedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NotModifiedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Random: {Random})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Random, bw, WriteBytes);
            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {
                var random = Read(br, ReadBytes);
                return new NotModifiedTag(random);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x2c221edd;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int G { get; }
            public Arr<byte> P { get; }
            public int Version { get; }
            public Arr<byte> Random { get; }
            
            public Tag(
                int g,
                Some<Arr<byte>> p,
                int version,
                Some<Arr<byte>> random
            ) {
                G = g;
                P = p;
                Version = version;
                Random = random;
            }
            
            (int, Arr<byte>, int, Arr<byte>) CmpTuple =>
                (G, P, Version, Random);

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

            public override string ToString() => $"(G: {G}, P: {P}, Version: {Version}, Random: {Random})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(G, bw, WriteInt);
                Write(P, bw, WriteBytes);
                Write(Version, bw, WriteInt);
                Write(Random, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var g = Read(br, ReadInt);
                var p = Read(br, ReadBytes);
                var version = Read(br, ReadInt);
                var random = Read(br, ReadBytes);
                return new Tag(g, p, version, random);
            }
        }

        readonly ITlTypeTag _tag;
        DhConfig(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DhConfig(NotModifiedTag tag) => new DhConfig(tag);
        public static explicit operator DhConfig(Tag tag) => new DhConfig(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DhConfig Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NotModifiedTag.TypeNumber: return (DhConfig) NotModifiedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (DhConfig) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NotModifiedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NotModifiedTag, T> notModifiedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NotModifiedTag, T> notModifiedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NotModifiedTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(DhConfig other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is DhConfig x && Equals(x);
        public static bool operator ==(DhConfig x, DhConfig y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DhConfig x, DhConfig y) => !(x == y);

        public int CompareTo(DhConfig other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DhConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DhConfig x, DhConfig y) => x.CompareTo(y) <= 0;
        public static bool operator <(DhConfig x, DhConfig y) => x.CompareTo(y) < 0;
        public static bool operator >(DhConfig x, DhConfig y) => x.CompareTo(y) > 0;
        public static bool operator >=(DhConfig x, DhConfig y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"DhConfig.{_tag.GetType().Name}{_tag}";
    }
}