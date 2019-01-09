using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Contacts
{
    public sealed class Link : ITlType, IEquatable<Link>, IComparable<Link>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3ace484c;
            
            public T.ContactLink MyLink { get; }
            public T.ContactLink ForeignLink { get; }
            public T.User User { get; }
            
            public Tag(
                Some<T.ContactLink> myLink,
                Some<T.ContactLink> foreignLink,
                Some<T.User> user
            ) {
                MyLink = myLink;
                ForeignLink = foreignLink;
                User = user;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MyLink, bw, WriteSerializable);
                Write(ForeignLink, bw, WriteSerializable);
                Write(User, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var myLink = Read(br, T.ContactLink.Deserialize);
                var foreignLink = Read(br, T.ContactLink.Deserialize);
                var user = Read(br, T.User.Deserialize);
                return new Tag(myLink, foreignLink, user);
            }
        }

        readonly ITlTypeTag _tag;
        Link(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Link(Tag tag) => new Link(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Link Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x3ace484c: return (Link) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x3ace484c });
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

        public bool Equals(Link other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Link x && Equals(x);
        public static bool operator ==(Link a, Link b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Link a, Link b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Link other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Link x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Link a, Link b) => a.CompareTo(b) <= 0;
        public static bool operator <(Link a, Link b) => a.CompareTo(b) < 0;
        public static bool operator >(Link a, Link b) => a.CompareTo(b) > 0;
        public static bool operator >=(Link a, Link b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}