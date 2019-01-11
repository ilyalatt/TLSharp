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
            internal const uint TypeNumber = 0x96dabc18;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<byte> NewSalt { get; }
            public string EmailUnconfirmedPattern { get; }
            
            public NoTag(
                Some<Arr<byte>> newSalt,
                Some<string> emailUnconfirmedPattern
            ) {
                NewSalt = newSalt;
                EmailUnconfirmedPattern = emailUnconfirmedPattern;
            }
            
            (Arr<byte>, string) CmpTuple =>
                (NewSalt, EmailUnconfirmedPattern);

            public bool Equals(NoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NoTag x && Equals(x);
            public static bool operator ==(NoTag x, NoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoTag x, NoTag y) => !(x == y);

            public int CompareTo(NoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoTag x, NoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoTag x, NoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoTag x, NoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoTag x, NoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(NewSalt: {NewSalt}, EmailUnconfirmedPattern: {EmailUnconfirmedPattern})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NewSalt, bw, WriteBytes);
                Write(EmailUnconfirmedPattern, bw, WriteString);
            }
            
            internal static NoTag DeserializeTag(BinaryReader br)
            {
                var newSalt = Read(br, ReadBytes);
                var emailUnconfirmedPattern = Read(br, ReadString);
                return new NoTag(newSalt, emailUnconfirmedPattern);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x7c18141c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<byte> CurrentSalt { get; }
            public Arr<byte> NewSalt { get; }
            public string Hint { get; }
            public bool HasRecovery { get; }
            public string EmailUnconfirmedPattern { get; }
            
            public Tag(
                Some<Arr<byte>> currentSalt,
                Some<Arr<byte>> newSalt,
                Some<string> hint,
                bool hasRecovery,
                Some<string> emailUnconfirmedPattern
            ) {
                CurrentSalt = currentSalt;
                NewSalt = newSalt;
                Hint = hint;
                HasRecovery = hasRecovery;
                EmailUnconfirmedPattern = emailUnconfirmedPattern;
            }
            
            (Arr<byte>, Arr<byte>, string, bool, string) CmpTuple =>
                (CurrentSalt, NewSalt, Hint, HasRecovery, EmailUnconfirmedPattern);

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

            public override string ToString() => $"(CurrentSalt: {CurrentSalt}, NewSalt: {NewSalt}, Hint: {Hint}, HasRecovery: {HasRecovery}, EmailUnconfirmedPattern: {EmailUnconfirmedPattern})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(CurrentSalt, bw, WriteBytes);
                Write(NewSalt, bw, WriteBytes);
                Write(Hint, bw, WriteString);
                Write(HasRecovery, bw, WriteBool);
                Write(EmailUnconfirmedPattern, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var currentSalt = Read(br, ReadBytes);
                var newSalt = Read(br, ReadBytes);
                var hint = Read(br, ReadString);
                var hasRecovery = Read(br, ReadBool);
                var emailUnconfirmedPattern = Read(br, ReadString);
                return new Tag(currentSalt, newSalt, hint, hasRecovery, emailUnconfirmedPattern);
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

        public bool Equals(Password other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Password x && Equals(x);
        public static bool operator ==(Password x, Password y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Password x, Password y) => !(x == y);

        public int CompareTo(Password other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Password x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Password x, Password y) => x.CompareTo(y) <= 0;
        public static bool operator <(Password x, Password y) => x.CompareTo(y) < 0;
        public static bool operator >(Password x, Password y) => x.CompareTo(y) > 0;
        public static bool operator >=(Password x, Password y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Password.{_tag.GetType().Name}{_tag}";
    }
}