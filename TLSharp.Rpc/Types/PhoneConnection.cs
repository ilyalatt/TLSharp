using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PhoneConnection : ITlType, IEquatable<PhoneConnection>, IComparable<PhoneConnection>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9d4c17c0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public string Ip { get; }
            public string Ipv6 { get; }
            public int Port { get; }
            public Arr<byte> PeerTag { get; }
            
            public Tag(
                long id,
                Some<string> ip,
                Some<string> ipv6,
                int port,
                Some<Arr<byte>> peerTag
            ) {
                Id = id;
                Ip = ip;
                Ipv6 = ipv6;
                Port = port;
                PeerTag = peerTag;
            }
            
            (long, string, string, int, Arr<byte>) CmpTuple =>
                (Id, Ip, Ipv6, Port, PeerTag);

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

            public override string ToString() => $"(Id: {Id}, Ip: {Ip}, Ipv6: {Ipv6}, Port: {Port}, PeerTag: {PeerTag})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Ip, bw, WriteString);
                Write(Ipv6, bw, WriteString);
                Write(Port, bw, WriteInt);
                Write(PeerTag, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var ip = Read(br, ReadString);
                var ipv6 = Read(br, ReadString);
                var port = Read(br, ReadInt);
                var peerTag = Read(br, ReadBytes);
                return new Tag(id, ip, ipv6, port, peerTag);
            }
        }

        readonly ITlTypeTag _tag;
        PhoneConnection(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PhoneConnection(Tag tag) => new PhoneConnection(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PhoneConnection Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PhoneConnection) Tag.DeserializeTag(br);
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

        public bool Equals(PhoneConnection other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PhoneConnection x && Equals(x);
        public static bool operator ==(PhoneConnection x, PhoneConnection y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PhoneConnection x, PhoneConnection y) => !(x == y);

        public int CompareTo(PhoneConnection other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhoneConnection x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneConnection x, PhoneConnection y) => x.CompareTo(y) <= 0;
        public static bool operator <(PhoneConnection x, PhoneConnection y) => x.CompareTo(y) < 0;
        public static bool operator >(PhoneConnection x, PhoneConnection y) => x.CompareTo(y) > 0;
        public static bool operator >=(PhoneConnection x, PhoneConnection y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PhoneConnection.{_tag.GetType().Name}{_tag}";
    }
}