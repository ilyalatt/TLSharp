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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa2bb35cb;
            
            public bool UdpP2p { get; }
            public bool UdpReflector { get; }
            public int MinLayer { get; }
            public int MaxLayer { get; }
            
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
                case 0xa2bb35cb: return (PhoneCallProtocol) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xa2bb35cb });
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

        public bool Equals(PhoneCallProtocol other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PhoneCallProtocol x && Equals(x);
        public static bool operator ==(PhoneCallProtocol a, PhoneCallProtocol b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PhoneCallProtocol a, PhoneCallProtocol b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PhoneCallProtocol other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhoneCallProtocol x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneCallProtocol a, PhoneCallProtocol b) => a.CompareTo(b) <= 0;
        public static bool operator <(PhoneCallProtocol a, PhoneCallProtocol b) => a.CompareTo(b) < 0;
        public static bool operator >(PhoneCallProtocol a, PhoneCallProtocol b) => a.CompareTo(b) > 0;
        public static bool operator >=(PhoneCallProtocol a, PhoneCallProtocol b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}