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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x137948a5;
            
            public string EmailPattern { get; }
            
            public Tag(
                Some<string> emailPattern
            ) {
                EmailPattern = emailPattern;
            }
            
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
                case 0x137948a5: return (PasswordRecovery) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x137948a5 });
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

        public bool Equals(PasswordRecovery other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PasswordRecovery x && Equals(x);
        public static bool operator ==(PasswordRecovery a, PasswordRecovery b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PasswordRecovery a, PasswordRecovery b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PasswordRecovery other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PasswordRecovery x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PasswordRecovery a, PasswordRecovery b) => a.CompareTo(b) <= 0;
        public static bool operator <(PasswordRecovery a, PasswordRecovery b) => a.CompareTo(b) < 0;
        public static bool operator >(PasswordRecovery a, PasswordRecovery b) => a.CompareTo(b) > 0;
        public static bool operator >=(PasswordRecovery a, PasswordRecovery b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}