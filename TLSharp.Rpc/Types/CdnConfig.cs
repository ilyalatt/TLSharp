using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class CdnConfig : ITlType, IEquatable<CdnConfig>, IComparable<CdnConfig>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x5725e40a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.CdnPublicKey> PublicKeys { get; }
            
            public Tag(
                Some<Arr<T.CdnPublicKey>> publicKeys
            ) {
                PublicKeys = publicKeys;
            }
            
            Arr<T.CdnPublicKey> CmpTuple =>
                PublicKeys;

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

            public override string ToString() => $"(PublicKeys: {PublicKeys})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PublicKeys, bw, WriteVector<T.CdnPublicKey>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var publicKeys = Read(br, ReadVector(T.CdnPublicKey.Deserialize));
                return new Tag(publicKeys);
            }
        }

        readonly ITlTypeTag _tag;
        CdnConfig(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator CdnConfig(Tag tag) => new CdnConfig(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static CdnConfig Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (CdnConfig) Tag.DeserializeTag(br);
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

        public bool Equals(CdnConfig other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is CdnConfig x && Equals(x);
        public static bool operator ==(CdnConfig x, CdnConfig y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CdnConfig x, CdnConfig y) => !(x == y);

        public int CompareTo(CdnConfig other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CdnConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CdnConfig x, CdnConfig y) => x.CompareTo(y) <= 0;
        public static bool operator <(CdnConfig x, CdnConfig y) => x.CompareTo(y) < 0;
        public static bool operator >(CdnConfig x, CdnConfig y) => x.CompareTo(y) > 0;
        public static bool operator >=(CdnConfig x, CdnConfig y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"CdnConfig.{_tag.GetType().Name}{_tag}";
    }
}