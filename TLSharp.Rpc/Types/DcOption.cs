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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x05d8c6cc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Ipv6;
            public readonly bool MediaOnly;
            public readonly bool TcpoOnly;
            public readonly bool Cdn;
            public readonly int Id;
            public readonly string IpAddress;
            public readonly int Port;
            
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
            
            (bool, bool, bool, bool, int, string, int) CmpTuple =>
                (Ipv6, MediaOnly, TcpoOnly, Cdn, Id, IpAddress, Port);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Ipv6: {Ipv6}, MediaOnly: {MediaOnly}, TcpoOnly: {TcpoOnly}, Cdn: {Cdn}, Id: {Id}, IpAddress: {IpAddress}, Port: {Port})";
            
            
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
                case Tag.TypeNumber: return (DcOption) Tag.DeserializeTag(br);
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

        public bool Equals(DcOption other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is DcOption x && Equals(x);
        public static bool operator ==(DcOption x, DcOption y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DcOption x, DcOption y) => !(x == y);

        public int CompareTo(DcOption other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is DcOption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DcOption x, DcOption y) => x.CompareTo(y) <= 0;
        public static bool operator <(DcOption x, DcOption y) => x.CompareTo(y) < 0;
        public static bool operator >(DcOption x, DcOption y) => x.CompareTo(y) > 0;
        public static bool operator >=(DcOption x, DcOption y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"DcOption.{_tag.GetType().Name}{_tag}";
    }
}