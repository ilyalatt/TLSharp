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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb7b72ab3;
            
            public string Email { get; }
            
            public Tag(
                Some<string> email
            ) {
                Email = email;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Email, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var email = Read(br, ReadString);
                return new Tag(email);
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
                case 0xb7b72ab3: return (PasswordSettings) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xb7b72ab3 });
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

        public bool Equals(PasswordSettings other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PasswordSettings x && Equals(x);
        public static bool operator ==(PasswordSettings a, PasswordSettings b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PasswordSettings a, PasswordSettings b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PasswordSettings other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PasswordSettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PasswordSettings a, PasswordSettings b) => a.CompareTo(b) <= 0;
        public static bool operator <(PasswordSettings a, PasswordSettings b) => a.CompareTo(b) < 0;
        public static bool operator >(PasswordSettings a, PasswordSettings b) => a.CompareTo(b) > 0;
        public static bool operator >=(PasswordSettings a, PasswordSettings b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}