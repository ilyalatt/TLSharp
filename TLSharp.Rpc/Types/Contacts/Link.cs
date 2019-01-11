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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x3ace484c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.ContactLink MyLink;
            public readonly T.ContactLink ForeignLink;
            public readonly T.User User;
            
            public Tag(
                Some<T.ContactLink> myLink,
                Some<T.ContactLink> foreignLink,
                Some<T.User> user
            ) {
                MyLink = myLink;
                ForeignLink = foreignLink;
                User = user;
            }
            
            (T.ContactLink, T.ContactLink, T.User) CmpTuple =>
                (MyLink, ForeignLink, User);

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

            public override string ToString() => $"(MyLink: {MyLink}, ForeignLink: {ForeignLink}, User: {User})";
            
            
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
                case Tag.TypeNumber: return (Link) Tag.DeserializeTag(br);
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

        public bool Equals(Link other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Link x && Equals(x);
        public static bool operator ==(Link x, Link y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Link x, Link y) => !(x == y);

        public int CompareTo(Link other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Link x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Link x, Link y) => x.CompareTo(y) <= 0;
        public static bool operator <(Link x, Link y) => x.CompareTo(y) < 0;
        public static bool operator >(Link x, Link y) => x.CompareTo(y) > 0;
        public static bool operator >=(Link x, Link y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Link.{_tag.GetType().Name}{_tag}";
    }
}