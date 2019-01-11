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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
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
            
            (Int128, Int128, long, Arr<byte>) CmpTuple =>
                (Nonce, ServerNonce, RetryId, Gb);

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

            public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, RetryId: {RetryId}, Gb: {Gb})";
            
            
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ClientDhInnerData other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ClientDhInnerData x && Equals(x);
        public static bool operator ==(ClientDhInnerData x, ClientDhInnerData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ClientDhInnerData x, ClientDhInnerData y) => !(x == y);

        public int CompareTo(ClientDhInnerData other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ClientDhInnerData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ClientDhInnerData x, ClientDhInnerData y) => x.CompareTo(y) <= 0;
        public static bool operator <(ClientDhInnerData x, ClientDhInnerData y) => x.CompareTo(y) < 0;
        public static bool operator >(ClientDhInnerData x, ClientDhInnerData y) => x.CompareTo(y) > 0;
        public static bool operator >=(ClientDhInnerData x, ClientDhInnerData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ClientDhInnerData.{_tag.GetType().Name}{_tag}";
    }
}