using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class DcOption : ITlType, IEquatable<DcOption>, IComparable<DcOption>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x05d8c6cc;
            
            public bool Ipv6 { get; }
            public bool MediaOnly { get; }
            public bool TcpoOnly { get; }
            public bool Cdn { get; }
            public int Id { get; }
            public string IpAddress { get; }
            public int Port { get; }
            
            public Tag(
                bool ipv6,
                bool mediaOnly,
                bool tcpoOnly,
                bool cdn,
                int id,
                Some<string> ipAddress,
                int port
            ) {
                Ipv6 = ipv6;
                MediaOnly = mediaOnly;
                TcpoOnly = tcpoOnly;
                Cdn = cdn;
                Id = id;
                IpAddress = ipAddress;
                Port = port;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Ipv6) | MaskBit(1, MediaOnly) | MaskBit(2, TcpoOnly) | MaskBit(3, Cdn), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(IpAddress, bw, WriteString);
                Write(Port, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var ipv6 = Read(br, ReadOption(flags, 0));
                var mediaOnly = Read(br, ReadOption(flags, 1));
                var tcpoOnly = Read(br, ReadOption(flags, 2));
                var cdn = Read(br, ReadOption(flags, 3));
                var id = Read(br, ReadInt);
                var ipAddress = Read(br, ReadString);
                var port = Read(br, ReadInt);
                return new Tag(ipv6, mediaOnly, tcpoOnly, cdn, id, ipAddress, port);
            }
        }

        readonly ITlTypeTag _tag;
        DcOption(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DcOption(Tag tag) => new DcOption(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DcOption Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x05d8c6cc: return (DcOption) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x05d8c6cc });
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

        public bool Equals(DcOption other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is DcOption x && Equals(x);
        public static bool operator ==(DcOption a, DcOption b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(DcOption a, DcOption b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(DcOption other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DcOption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DcOption a, DcOption b) => a.CompareTo(b) <= 0;
        public static bool operator <(DcOption a, DcOption b) => a.CompareTo(b) < 0;
        public static bool operator >(DcOption a, DcOption b) => a.CompareTo(b) > 0;
        public static bool operator >=(DcOption a, DcOption b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}