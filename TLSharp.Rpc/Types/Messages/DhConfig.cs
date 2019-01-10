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
        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc0e24635;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<byte> Random { get; }
            
            public NotModifiedTag(
                Some<Arr<byte>> random
            ) {
                Random = random;
            }
            
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

        public sealed class Tag : Record<Tag>, ITlTypeTag
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

        public bool Equals(DhConfig other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is DhConfig x && Equals(x);
        public static bool operator ==(DhConfig a, DhConfig b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(DhConfig a, DhConfig b) => !(a == b);

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

        public int CompareTo(DhConfig other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DhConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DhConfig a, DhConfig b) => a.CompareTo(b) <= 0;
        public static bool operator <(DhConfig a, DhConfig b) => a.CompareTo(b) < 0;
        public static bool operator >(DhConfig a, DhConfig b) => a.CompareTo(b) > 0;
        public static bool operator >=(DhConfig a, DhConfig b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}