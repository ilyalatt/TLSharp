using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecureCredentialsEncrypted : ITlType, IEquatable<SecureCredentialsEncrypted>, IComparable<SecureCredentialsEncrypted>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x33f0ea47;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<byte> Data;
            public readonly Arr<byte> Hash;
            public readonly Arr<byte> Secret;
            
            public Tag(
                Some<Arr<byte>> data,
                Some<Arr<byte>> hash,
                Some<Arr<byte>> secret
            ) {
                Data = data;
                Hash = hash;
                Secret = secret;
            }
            
            (Arr<byte>, Arr<byte>, Arr<byte>) CmpTuple =>
                (Data, Hash, Secret);

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

            public override string ToString() => $"(Data: {Data}, Hash: {Hash}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Data, bw, WriteBytes);
                Write(Hash, bw, WriteBytes);
                Write(Secret, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var data = Read(br, ReadBytes);
                var hash = Read(br, ReadBytes);
                var secret = Read(br, ReadBytes);
                return new Tag(data, hash, secret);
            }
        }

        readonly ITlTypeTag _tag;
        SecureCredentialsEncrypted(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecureCredentialsEncrypted(Tag tag) => new SecureCredentialsEncrypted(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecureCredentialsEncrypted Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (SecureCredentialsEncrypted) Tag.DeserializeTag(br);
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

        public bool Equals(SecureCredentialsEncrypted other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecureCredentialsEncrypted x && Equals(x);
        public static bool operator ==(SecureCredentialsEncrypted x, SecureCredentialsEncrypted y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecureCredentialsEncrypted x, SecureCredentialsEncrypted y) => !(x == y);

        public int CompareTo(SecureCredentialsEncrypted other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecureCredentialsEncrypted x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecureCredentialsEncrypted x, SecureCredentialsEncrypted y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecureCredentialsEncrypted x, SecureCredentialsEncrypted y) => x.CompareTo(y) < 0;
        public static bool operator >(SecureCredentialsEncrypted x, SecureCredentialsEncrypted y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecureCredentialsEncrypted x, SecureCredentialsEncrypted y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecureCredentialsEncrypted.{_tag.GetType().Name}{_tag}";
    }
}