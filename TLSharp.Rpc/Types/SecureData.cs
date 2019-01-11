using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecureData : ITlType, IEquatable<SecureData>, IComparable<SecureData>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x8aeabec3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<byte> Data;
            public readonly Arr<byte> DataHash;
            public readonly Arr<byte> Secret;
            
            public Tag(
                Some<Arr<byte>> data,
                Some<Arr<byte>> dataHash,
                Some<Arr<byte>> secret
            ) {
                Data = data;
                DataHash = dataHash;
                Secret = secret;
            }
            
            (Arr<byte>, Arr<byte>, Arr<byte>) CmpTuple =>
                (Data, DataHash, Secret);

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

            public override string ToString() => $"(Data: {Data}, DataHash: {DataHash}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Data, bw, WriteBytes);
                Write(DataHash, bw, WriteBytes);
                Write(Secret, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var data = Read(br, ReadBytes);
                var dataHash = Read(br, ReadBytes);
                var secret = Read(br, ReadBytes);
                return new Tag(data, dataHash, secret);
            }
        }

        readonly ITlTypeTag _tag;
        SecureData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecureData(Tag tag) => new SecureData(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecureData Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (SecureData) Tag.DeserializeTag(br);
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

        public bool Equals(SecureData other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecureData x && Equals(x);
        public static bool operator ==(SecureData x, SecureData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecureData x, SecureData y) => !(x == y);

        public int CompareTo(SecureData other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecureData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecureData x, SecureData y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecureData x, SecureData y) => x.CompareTo(y) < 0;
        public static bool operator >(SecureData x, SecureData y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecureData x, SecureData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecureData.{_tag.GetType().Name}{_tag}";
    }
}