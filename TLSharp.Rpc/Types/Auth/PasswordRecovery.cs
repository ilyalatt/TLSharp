using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Auth
{
    public sealed class PasswordRecovery : ITlType, IEquatable<PasswordRecovery>, IComparable<PasswordRecovery>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x137948a5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string EmailPattern;
            
            public Tag(
                Some<string> emailPattern
            ) {
                EmailPattern = emailPattern;
            }
            
            string CmpTuple =>
                EmailPattern;

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

            public override string ToString() => $"(EmailPattern: {EmailPattern})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(EmailPattern, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var emailPattern = Read(br, ReadString);
                return new Tag(emailPattern);
            }
        }

        readonly ITlTypeTag _tag;
        PasswordRecovery(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PasswordRecovery(Tag tag) => new PasswordRecovery(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PasswordRecovery Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PasswordRecovery) Tag.DeserializeTag(br);
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

        public bool Equals(PasswordRecovery other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PasswordRecovery x && Equals(x);
        public static bool operator ==(PasswordRecovery x, PasswordRecovery y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PasswordRecovery x, PasswordRecovery y) => !(x == y);

        public int CompareTo(PasswordRecovery other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PasswordRecovery x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PasswordRecovery x, PasswordRecovery y) => x.CompareTo(y) <= 0;
        public static bool operator <(PasswordRecovery x, PasswordRecovery y) => x.CompareTo(y) < 0;
        public static bool operator >(PasswordRecovery x, PasswordRecovery y) => x.CompareTo(y) > 0;
        public static bool operator >=(PasswordRecovery x, PasswordRecovery y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PasswordRecovery.{_tag.GetType().Name}{_tag}";
    }
}