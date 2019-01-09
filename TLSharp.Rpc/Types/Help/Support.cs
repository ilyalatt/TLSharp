using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class Support : ITlType, IEquatable<Support>, IComparable<Support>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x17c6b5f6;
            
            public string PhoneNumber { get; }
            public T.User User { get; }
            
            public Tag(
                Some<string> phoneNumber,
                Some<T.User> user
            ) {
                PhoneNumber = phoneNumber;
                User = user;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhoneNumber, bw, WriteString);
                Write(User, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var phoneNumber = Read(br, ReadString);
                var user = Read(br, T.User.Deserialize);
                return new Tag(phoneNumber, user);
            }
        }

        readonly ITlTypeTag _tag;
        Support(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Support(Tag tag) => new Support(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Support Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x17c6b5f6: return (Support) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x17c6b5f6 });
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

        public bool Equals(Support other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Support x && Equals(x);
        public static bool operator ==(Support a, Support b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Support a, Support b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Support other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Support x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Support a, Support b) => a.CompareTo(b) <= 0;
        public static bool operator <(Support a, Support b) => a.CompareTo(b) < 0;
        public static bool operator >(Support a, Support b) => a.CompareTo(b) > 0;
        public static bool operator >=(Support a, Support b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}