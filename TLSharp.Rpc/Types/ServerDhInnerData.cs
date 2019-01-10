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
        public sealed class Tag : Record<Tag>, ITlTypeTag
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

        public bool Equals(ServerDhInnerData other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ServerDhInnerData x && Equals(x);
        public static bool operator ==(ServerDhInnerData a, ServerDhInnerData b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ServerDhInnerData a, ServerDhInnerData b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ServerDhInnerData other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ServerDhInnerData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ServerDhInnerData a, ServerDhInnerData b) => a.CompareTo(b) <= 0;
        public static bool operator <(ServerDhInnerData a, ServerDhInnerData b) => a.CompareTo(b) < 0;
        public static bool operator >(ServerDhInnerData a, ServerDhInnerData b) => a.CompareTo(b) > 0;
        public static bool operator >=(ServerDhInnerData a, ServerDhInnerData b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}