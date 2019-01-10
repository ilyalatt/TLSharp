using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ClientDhInnerData : ITlType, IEquatable<ClientDhInnerData>, IComparable<ClientDhInnerData>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x6643b654;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public long RetryId { get; }
            public Arr<byte> Gb { get; }
            
            public Tag(
                Int128 nonce,
                Int128 serverNonce,
                long retryId,
                Some<Arr<byte>> gb
            ) {
                Nonce = nonce;
                ServerNonce = serverNonce;
                RetryId = retryId;
                Gb = gb;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(RetryId, bw, WriteLong);
                Write(Gb, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var retryId = Read(br, ReadLong);
                var gb = Read(br, ReadBytes);
                return new Tag(nonce, serverNonce, retryId, gb);
            }
        }

        readonly ITlTypeTag _tag;
        ClientDhInnerData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ClientDhInnerData(Tag tag) => new ClientDhInnerData(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ClientDhInnerData Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ClientDhInnerData) Tag.DeserializeTag(br);
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

        public bool Equals(ClientDhInnerData other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ClientDhInnerData x && Equals(x);
        public static bool operator ==(ClientDhInnerData a, ClientDhInnerData b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ClientDhInnerData a, ClientDhInnerData b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ClientDhInnerData other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ClientDhInnerData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ClientDhInnerData a, ClientDhInnerData b) => a.CompareTo(b) <= 0;
        public static bool operator <(ClientDhInnerData a, ClientDhInnerData b) => a.CompareTo(b) < 0;
        public static bool operator >(ClientDhInnerData a, ClientDhInnerData b) => a.CompareTo(b) > 0;
        public static bool operator >=(ClientDhInnerData a, ClientDhInnerData b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}