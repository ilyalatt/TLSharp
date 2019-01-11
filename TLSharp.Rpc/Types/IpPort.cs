using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class IpPort : ITlType, IEquatable<IpPort>, IComparable<IpPort>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xd433ad73;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Ipv4;
            public readonly int Port;
            
            public Tag(
                int ipv4,
                int port
            ) {
                Ipv4 = ipv4;
                Port = port;
            }
            
            (int, int) CmpTuple =>
                (Ipv4, Port);

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

            public override string ToString() => $"(Ipv4: {Ipv4}, Port: {Port})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Ipv4, bw, WriteInt);
                Write(Port, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var ipv4 = Read(br, ReadInt);
                var port = Read(br, ReadInt);
                return new Tag(ipv4, port);
            }
        }

        public sealed class SecretTag : ITlTypeTag, IEquatable<SecretTag>, IComparable<SecretTag>, IComparable
        {
            internal const uint TypeNumber = 0x37982646;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Ipv4;
            public readonly int Port;
            public readonly Arr<byte> Secret;
            
            public SecretTag(
                int ipv4,
                int port,
                Some<Arr<byte>> secret
            ) {
                Ipv4 = ipv4;
                Port = port;
                Secret = secret;
            }
            
            (int, int, Arr<byte>) CmpTuple =>
                (Ipv4, Port, Secret);

            public bool Equals(SecretTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SecretTag x && Equals(x);
            public static bool operator ==(SecretTag x, SecretTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SecretTag x, SecretTag y) => !(x == y);

            public int CompareTo(SecretTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SecretTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SecretTag x, SecretTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SecretTag x, SecretTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SecretTag x, SecretTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SecretTag x, SecretTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Ipv4: {Ipv4}, Port: {Port}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Ipv4, bw, WriteInt);
                Write(Port, bw, WriteInt);
                Write(Secret, bw, WriteBytes);
            }
            
            internal static SecretTag DeserializeTag(BinaryReader br)
            {
                var ipv4 = Read(br, ReadInt);
                var port = Read(br, ReadInt);
                var secret = Read(br, ReadBytes);
                return new SecretTag(ipv4, port, secret);
            }
        }

        readonly ITlTypeTag _tag;
        IpPort(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator IpPort(Tag tag) => new IpPort(tag);
        public static explicit operator IpPort(SecretTag tag) => new IpPort(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static IpPort Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (IpPort) Tag.DeserializeTag(br);
                case SecretTag.TypeNumber: return (IpPort) SecretTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, SecretTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SecretTag, T> secretTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SecretTag x when secretTag != null: return secretTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SecretTag, T> secretTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            secretTag ?? throw new ArgumentNullException(nameof(secretTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SecretTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(IpPort other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is IpPort x && Equals(x);
        public static bool operator ==(IpPort x, IpPort y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(IpPort x, IpPort y) => !(x == y);

        public int CompareTo(IpPort other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is IpPort x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(IpPort x, IpPort y) => x.CompareTo(y) <= 0;
        public static bool operator <(IpPort x, IpPort y) => x.CompareTo(y) < 0;
        public static bool operator >(IpPort x, IpPort y) => x.CompareTo(y) > 0;
        public static bool operator >=(IpPort x, IpPort y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"IpPort.{_tag.GetType().Name}{_tag}";
    }
}