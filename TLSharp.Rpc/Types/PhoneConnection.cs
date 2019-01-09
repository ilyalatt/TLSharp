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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9d4c17c0;
            
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
                case 0x9d4c17c0: return (PhoneConnection) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x9d4c17c0 });
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

        public bool Equals(PhoneConnection other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PhoneConnection x && Equals(x);
        public static bool operator ==(PhoneConnection a, PhoneConnection b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PhoneConnection a, PhoneConnection b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PhoneConnection other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhoneConnection x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneConnection a, PhoneConnection b) => a.CompareTo(b) <= 0;
        public static bool operator <(PhoneConnection a, PhoneConnection b) => a.CompareTo(b) < 0;
        public static bool operator >(PhoneConnection a, PhoneConnection b) => a.CompareTo(b) > 0;
        public static bool operator >=(PhoneConnection a, PhoneConnection b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}