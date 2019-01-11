using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PhoneCallProtocol : ITlType, IEquatable<PhoneCallProtocol>, IComparable<PhoneCallProtocol>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xa2bb35cb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool UdpP2p;
            public readonly bool UdpReflector;
            public readonly int MinLayer;
            public readonly int MaxLayer;
            
            public Tag(
                bool udpP2p,
                bool udpReflector,
                int minLayer,
                int maxLayer
            ) {
                UdpP2p = udpP2p;
                UdpReflector = udpReflector;
                MinLayer = minLayer;
                MaxLayer = maxLayer;
            }
            
            (bool, bool, int, int) CmpTuple =>
                (UdpP2p, UdpReflector, MinLayer, MaxLayer);

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

            public override string ToString() => $"(UdpP2p: {UdpP2p}, UdpReflector: {UdpReflector}, MinLayer: {MinLayer}, MaxLayer: {MaxLayer})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, UdpP2p) | MaskBit(1, UdpReflector), bw, WriteInt);
                Write(MinLayer, bw, WriteInt);
                Write(MaxLayer, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var udpP2p = Read(br, ReadOption(flags, 0));
                var udpReflector = Read(br, ReadOption(flags, 1));
                var minLayer = Read(br, ReadInt);
                var maxLayer = Read(br, ReadInt);
                return new Tag(udpP2p, udpReflector, minLayer, maxLayer);
            }
        }

        readonly ITlTypeTag _tag;
        PhoneCallProtocol(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PhoneCallProtocol(Tag tag) => new PhoneCallProtocol(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PhoneCallProtocol Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PhoneCallProtocol) Tag.DeserializeTag(br);
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

        public bool Equals(PhoneCallProtocol other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PhoneCallProtocol x && Equals(x);
        public static bool operator ==(PhoneCallProtocol x, PhoneCallProtocol y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PhoneCallProtocol x, PhoneCallProtocol y) => !(x == y);

        public int CompareTo(PhoneCallProtocol other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PhoneCallProtocol x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneCallProtocol x, PhoneCallProtocol y) => x.CompareTo(y) <= 0;
        public static bool operator <(PhoneCallProtocol x, PhoneCallProtocol y) => x.CompareTo(y) < 0;
        public static bool operator >(PhoneCallProtocol x, PhoneCallProtocol y) => x.CompareTo(y) > 0;
        public static bool operator >=(PhoneCallProtocol x, PhoneCallProtocol y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PhoneCallProtocol.{_tag.GetType().Name}{_tag}";
    }
}