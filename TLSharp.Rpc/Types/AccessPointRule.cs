using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class AccessPointRule : ITlType, IEquatable<AccessPointRule>, IComparable<AccessPointRule>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x4679b65f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string PhonePrefixRules;
            public readonly int DcId;
            public readonly Arr<T.IpPort> Ips;
            
            public Tag(
                Some<string> phonePrefixRules,
                int dcId,
                Some<Arr<T.IpPort>> ips
            ) {
                PhonePrefixRules = phonePrefixRules;
                DcId = dcId;
                Ips = ips;
            }
            
            (string, int, Arr<T.IpPort>) CmpTuple =>
                (PhonePrefixRules, DcId, Ips);

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

            public override string ToString() => $"(PhonePrefixRules: {PhonePrefixRules}, DcId: {DcId}, Ips: {Ips})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhonePrefixRules, bw, WriteString);
                Write(DcId, bw, WriteInt);
                Write(Ips, bw, WriteVector<T.IpPort>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var phonePrefixRules = Read(br, ReadString);
                var dcId = Read(br, ReadInt);
                var ips = Read(br, ReadVector(T.IpPort.Deserialize));
                return new Tag(phonePrefixRules, dcId, ips);
            }
        }

        readonly ITlTypeTag _tag;
        AccessPointRule(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator AccessPointRule(Tag tag) => new AccessPointRule(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static AccessPointRule Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (AccessPointRule) Tag.DeserializeTag(br);
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

        public bool Equals(AccessPointRule other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is AccessPointRule x && Equals(x);
        public static bool operator ==(AccessPointRule x, AccessPointRule y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AccessPointRule x, AccessPointRule y) => !(x == y);

        public int CompareTo(AccessPointRule other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is AccessPointRule x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AccessPointRule x, AccessPointRule y) => x.CompareTo(y) <= 0;
        public static bool operator <(AccessPointRule x, AccessPointRule y) => x.CompareTo(y) < 0;
        public static bool operator >(AccessPointRule x, AccessPointRule y) => x.CompareTo(y) > 0;
        public static bool operator >=(AccessPointRule x, AccessPointRule y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"AccessPointRule.{_tag.GetType().Name}{_tag}";
    }
}