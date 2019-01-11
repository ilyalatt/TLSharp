using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class PasswordSettings : ITlType, IEquatable<PasswordSettings>, IComparable<PasswordSettings>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x7bd9c3f1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Email;
            public readonly Arr<byte> SecureSalt;
            public readonly Arr<byte> SecureSecret;
            public readonly long SecureSecretId;
            
            public Tag(
                Some<string> email,
                Some<Arr<byte>> secureSalt,
                Some<Arr<byte>> secureSecret,
                long secureSecretId
            ) {
                Email = email;
                SecureSalt = secureSalt;
                SecureSecret = secureSecret;
                SecureSecretId = secureSecretId;
            }
            
            (string, Arr<byte>, Arr<byte>, long) CmpTuple =>
                (Email, SecureSalt, SecureSecret, SecureSecretId);

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

            public override string ToString() => $"(Email: {Email}, SecureSalt: {SecureSalt}, SecureSecret: {SecureSecret}, SecureSecretId: {SecureSecretId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Email, bw, WriteString);
                Write(SecureSalt, bw, WriteBytes);
                Write(SecureSecret, bw, WriteBytes);
                Write(SecureSecretId, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var email = Read(br, ReadString);
                var secureSalt = Read(br, ReadBytes);
                var secureSecret = Read(br, ReadBytes);
                var secureSecretId = Read(br, ReadLong);
                return new Tag(email, secureSalt, secureSecret, secureSecretId);
            }
        }

        readonly ITlTypeTag _tag;
        PasswordSettings(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PasswordSettings(Tag tag) => new PasswordSettings(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PasswordSettings Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PasswordSettings) Tag.DeserializeTag(br);
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

        public bool Equals(PasswordSettings other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PasswordSettings x && Equals(x);
        public static bool operator ==(PasswordSettings x, PasswordSettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PasswordSettings x, PasswordSettings y) => !(x == y);

        public int CompareTo(PasswordSettings other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PasswordSettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PasswordSettings x, PasswordSettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(PasswordSettings x, PasswordSettings y) => x.CompareTo(y) < 0;
        public static bool operator >(PasswordSettings x, PasswordSettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(PasswordSettings x, PasswordSettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PasswordSettings.{_tag.GetType().Name}{_tag}";
    }
}