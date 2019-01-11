using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class Password : ITlType, IEquatable<Password>, IComparable<Password>, IComparable
    {
        public sealed class NoTag : ITlTypeTag, IEquatable<NoTag>, IComparable<NoTag>, IComparable
        {
            internal const uint TypeNumber = 0x5ea182f6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<byte> NewSalt;
            public readonly Arr<byte> NewSecureSalt;
            public readonly Arr<byte> SecureRandom;
            public readonly string EmailUnconfirmedPattern;
            
            public NoTag(
                Some<Arr<byte>> newSalt,
                Some<Arr<byte>> newSecureSalt,
                Some<Arr<byte>> secureRandom,
                Some<string> emailUnconfirmedPattern
            ) {
                NewSalt = newSalt;
                NewSecureSalt = newSecureSalt;
                SecureRandom = secureRandom;
                EmailUnconfirmedPattern = emailUnconfirmedPattern;
            }
            
            (Arr<byte>, Arr<byte>, Arr<byte>, string) CmpTuple =>
                (NewSalt, NewSecureSalt, SecureRandom, EmailUnconfirmedPattern);

            public bool Equals(NoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is NoTag x && Equals(x);
            public static bool operator ==(NoTag x, NoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoTag x, NoTag y) => !(x == y);

            public int CompareTo(NoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is NoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoTag x, NoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoTag x, NoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoTag x, NoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoTag x, NoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NewSalt: {NewSalt}, NewSecureSalt: {NewSecureSalt}, SecureRandom: {SecureRandom}, EmailUnconfirmedPattern: {EmailUnconfirmedPattern})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewSalt, bw, WriteBytes);
                Write(NewSecureSalt, bw, WriteBytes);
                Write(SecureRandom, bw, WriteBytes);
                Write(EmailUnconfirmedPattern, bw, WriteString);
            }
            
            internal static NoTag DeserializeTag(BinaryReader br)
            {
                var newSalt = Read(br, ReadBytes);
                var newSecureSalt = Read(br, ReadBytes);
                var secureRandom = Read(br, ReadBytes);
                var emailUnconfirmedPattern = Read(br, ReadString);
                return new NoTag(newSalt, newSecureSalt, secureRandom, emailUnconfirmedPattern);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xca39b447;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool HasRecovery;
            public readonly bool HasSecureValues;
            public readonly Arr<byte> CurrentSalt;
            public readonly Arr<byte> NewSalt;
            public readonly Arr<byte> NewSecureSalt;
            public readonly Arr<byte> SecureRandom;
            public readonly string Hint;
            public readonly string EmailUnconfirmedPattern;
            
            public Tag(
                bool hasRecovery,
                bool hasSecureValues,
                Some<Arr<byte>> currentSalt,
                Some<Arr<byte>> newSalt,
                Some<Arr<byte>> newSecureSalt,
                Some<Arr<byte>> secureRandom,
                Some<string> hint,
                Some<string> emailUnconfirmedPattern
            ) {
                HasRecovery = hasRecovery;
                HasSecureValues = hasSecureValues;
                CurrentSalt = currentSalt;
                NewSalt = newSalt;
                NewSecureSalt = newSecureSalt;
                SecureRandom = secureRandom;
                Hint = hint;
                EmailUnconfirmedPattern = emailUnconfirmedPattern;
            }
            
            (bool, bool, Arr<byte>, Arr<byte>, Arr<byte>, Arr<byte>, string, string) CmpTuple =>
                (HasRecovery, HasSecureValues, CurrentSalt, NewSalt, NewSecureSalt, SecureRandom, Hint, EmailUnconfirmedPattern);

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

            public override string ToString() => $"(HasRecovery: {HasRecovery}, HasSecureValues: {HasSecureValues}, CurrentSalt: {CurrentSalt}, NewSalt: {NewSalt}, NewSecureSalt: {NewSecureSalt}, SecureRandom: {SecureRandom}, Hint: {Hint}, EmailUnconfirmedPattern: {EmailUnconfirmedPattern})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, HasRecovery) | MaskBit(1, HasSecureValues), bw, WriteInt);
                Write(CurrentSalt, bw, WriteBytes);
                Write(NewSalt, bw, WriteBytes);
                Write(NewSecureSalt, bw, WriteBytes);
                Write(SecureRandom, bw, WriteBytes);
                Write(Hint, bw, WriteString);
                Write(EmailUnconfirmedPattern, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var hasRecovery = Read(br, ReadOption(flags, 0));
                var hasSecureValues = Read(br, ReadOption(flags, 1));
                var currentSalt = Read(br, ReadBytes);
                var newSalt = Read(br, ReadBytes);
                var newSecureSalt = Read(br, ReadBytes);
                var secureRandom = Read(br, ReadBytes);
                var hint = Read(br, ReadString);
                var emailUnconfirmedPattern = Read(br, ReadString);
                return new Tag(hasRecovery, hasSecureValues, currentSalt, newSalt, newSecureSalt, secureRandom, hint, emailUnconfirmedPattern);
            }
        }

        readonly ITlTypeTag _tag;
        Password(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Password(NoTag tag) => new Password(tag);
        public static explicit operator Password(Tag tag) => new Password(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Password Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NoTag.TypeNumber: return (Password) NoTag.DeserializeTag(br);
                case Tag.TypeNumber: return (Password) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NoTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NoTag, T> noTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NoTag x when noTag != null: return noTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NoTag, T> noTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            noTag ?? throw new ArgumentNullException(nameof(noTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NoTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Password other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Password x && Equals(x);
        public static bool operator ==(Password x, Password y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Password x, Password y) => !(x == y);

        public int CompareTo(Password other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Password x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Password x, Password y) => x.CompareTo(y) <= 0;
        public static bool operator <(Password x, Password y) => x.CompareTo(y) < 0;
        public static bool operator >(Password x, Password y) => x.CompareTo(y) > 0;
        public static bool operator >=(Password x, Password y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Password.{_tag.GetType().Name}{_tag}";
    }
}