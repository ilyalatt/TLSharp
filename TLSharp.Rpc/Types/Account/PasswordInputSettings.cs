using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class PasswordInputSettings : ITlType, IEquatable<PasswordInputSettings>, IComparable<PasswordInputSettings>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x86916deb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<Arr<byte>> NewSalt;
            public readonly Option<Arr<byte>> NewPasswordHash;
            public readonly Option<string> Hint;
            public readonly Option<string> Email;
            
            public Tag(
                Option<Arr<byte>> newSalt,
                Option<Arr<byte>> newPasswordHash,
                Option<string> hint,
                Option<string> email
            ) {
                NewSalt = newSalt;
                NewPasswordHash = newPasswordHash;
                Hint = hint;
                Email = email;
            }
            
            (Option<Arr<byte>>, Option<Arr<byte>>, Option<string>, Option<string>) CmpTuple =>
                (NewSalt, NewPasswordHash, Hint, Email);

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

            public override string ToString() => $"(NewSalt: {NewSalt}, NewPasswordHash: {NewPasswordHash}, Hint: {Hint}, Email: {Email})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, NewSalt) | MaskBit(0, NewPasswordHash) | MaskBit(0, Hint) | MaskBit(1, Email), bw, WriteInt);
                Write(NewSalt, bw, WriteOption<Arr<byte>>(WriteBytes));
                Write(NewPasswordHash, bw, WriteOption<Arr<byte>>(WriteBytes));
                Write(Hint, bw, WriteOption<string>(WriteString));
                Write(Email, bw, WriteOption<string>(WriteString));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var newSalt = Read(br, ReadOption(flags, 0, ReadBytes));
                var newPasswordHash = Read(br, ReadOption(flags, 0, ReadBytes));
                var hint = Read(br, ReadOption(flags, 0, ReadString));
                var email = Read(br, ReadOption(flags, 1, ReadString));
                return new Tag(newSalt, newPasswordHash, hint, email);
            }
        }

        readonly ITlTypeTag _tag;
        PasswordInputSettings(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PasswordInputSettings(Tag tag) => new PasswordInputSettings(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PasswordInputSettings Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PasswordInputSettings) Tag.DeserializeTag(br);
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

        public bool Equals(PasswordInputSettings other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PasswordInputSettings x && Equals(x);
        public static bool operator ==(PasswordInputSettings x, PasswordInputSettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PasswordInputSettings x, PasswordInputSettings y) => !(x == y);

        public int CompareTo(PasswordInputSettings other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PasswordInputSettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PasswordInputSettings x, PasswordInputSettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(PasswordInputSettings x, PasswordInputSettings y) => x.CompareTo(y) < 0;
        public static bool operator >(PasswordInputSettings x, PasswordInputSettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(PasswordInputSettings x, PasswordInputSettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PasswordInputSettings.{_tag.GetType().Name}{_tag}";
    }
}