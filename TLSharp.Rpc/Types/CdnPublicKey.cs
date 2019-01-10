using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class CdnPublicKey : ITlType, IEquatable<CdnPublicKey>, IComparable<CdnPublicKey>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc982eaba;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int DcId { get; }
            public string PublicKey { get; }
            
            public Tag(
                int dcId,
                Some<string> publicKey
            ) {
                DcId = dcId;
                PublicKey = publicKey;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(DcId, bw, WriteInt);
                Write(PublicKey, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var dcId = Read(br, ReadInt);
                var publicKey = Read(br, ReadString);
                return new Tag(dcId, publicKey);
            }
        }

        readonly ITlTypeTag _tag;
        CdnPublicKey(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator CdnPublicKey(Tag tag) => new CdnPublicKey(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static CdnPublicKey Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (CdnPublicKey) Tag.DeserializeTag(br);
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

        public bool Equals(CdnPublicKey other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is CdnPublicKey x && Equals(x);
        public static bool operator ==(CdnPublicKey a, CdnPublicKey b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(CdnPublicKey a, CdnPublicKey b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(CdnPublicKey other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CdnPublicKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CdnPublicKey a, CdnPublicKey b) => a.CompareTo(b) <= 0;
        public static bool operator <(CdnPublicKey a, CdnPublicKey b) => a.CompareTo(b) < 0;
        public static bool operator >(CdnPublicKey a, CdnPublicKey b) => a.CompareTo(b) > 0;
        public static bool operator >=(CdnPublicKey a, CdnPublicKey b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}