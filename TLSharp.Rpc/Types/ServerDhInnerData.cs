using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ServerDhInnerData : ITlType, IEquatable<ServerDhInnerData>, IComparable<ServerDhInnerData>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xb5890dba;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public int G { get; }
            public Arr<byte> DhPrime { get; }
            public Arr<byte> Ga { get; }
            public int ServerTime { get; }
            
            public Tag(
                Int128 nonce,
                Int128 serverNonce,
                int g,
                Some<Arr<byte>> dhPrime,
                Some<Arr<byte>> ga,
                int serverTime
            ) {
                Nonce = nonce;
                ServerNonce = serverNonce;
                G = g;
                DhPrime = dhPrime;
                Ga = ga;
                ServerTime = serverTime;
            }
            
            (Int128, Int128, int, Arr<byte>, Arr<byte>, int) CmpTuple =>
                (Nonce, ServerNonce, G, DhPrime, Ga, ServerTime);

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

            public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, G: {G}, DhPrime: {DhPrime}, Ga: {Ga}, ServerTime: {ServerTime})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(G, bw, WriteInt);
                Write(DhPrime, bw, WriteBytes);
                Write(Ga, bw, WriteBytes);
                Write(ServerTime, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var g = Read(br, ReadInt);
                var dhPrime = Read(br, ReadBytes);
                var ga = Read(br, ReadBytes);
                var serverTime = Read(br, ReadInt);
                return new Tag(nonce, serverNonce, g, dhPrime, ga, serverTime);
            }
        }

        readonly ITlTypeTag _tag;
        ServerDhInnerData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ServerDhInnerData(Tag tag) => new ServerDhInnerData(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ServerDhInnerData Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ServerDhInnerData) Tag.DeserializeTag(br);
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

        public bool Equals(ServerDhInnerData other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ServerDhInnerData x && Equals(x);
        public static bool operator ==(ServerDhInnerData x, ServerDhInnerData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ServerDhInnerData x, ServerDhInnerData y) => !(x == y);

        public int CompareTo(ServerDhInnerData other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ServerDhInnerData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ServerDhInnerData x, ServerDhInnerData y) => x.CompareTo(y) <= 0;
        public static bool operator <(ServerDhInnerData x, ServerDhInnerData y) => x.CompareTo(y) < 0;
        public static bool operator >(ServerDhInnerData x, ServerDhInnerData y) => x.CompareTo(y) > 0;
        public static bool operator >=(ServerDhInnerData x, ServerDhInnerData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ServerDhInnerData.{_tag.GetType().Name}{_tag}";
    }
}