using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Contacts
{
    public sealed class Contacts : ITlType, IEquatable<Contacts>, IComparable<Contacts>, IComparable
    {
        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0xb74ba9d2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NotModifiedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NotModifiedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is NotModifiedTag x && Equals(x);
            public static bool operator ==(NotModifiedTag x, NotModifiedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NotModifiedTag x, NotModifiedTag y) => !(x == y);

            public int CompareTo(NotModifiedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is NotModifiedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xeae87e42;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.Contact> Contacts;
            public readonly int SavedCount;
            public readonly Arr<T.User> Users;
            
            public Tag(
                Some<Arr<T.Contact>> contacts,
                int savedCount,
                Some<Arr<T.User>> users
            ) {
                Contacts = contacts;
                SavedCount = savedCount;
                Users = users;
            }
            
            (Arr<T.Contact>, int, Arr<T.User>) CmpTuple =>
                (Contacts, SavedCount, Users);

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

            public override string ToString() => $"(Contacts: {Contacts}, SavedCount: {SavedCount}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Contacts, bw, WriteVector<T.Contact>(WriteSerializable));
                Write(SavedCount, bw, WriteInt);
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var contacts = Read(br, ReadVector(T.Contact.Deserialize));
                var savedCount = Read(br, ReadInt);
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(contacts, savedCount, users);
            }
        }

        readonly ITlTypeTag _tag;
        Contacts(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Contacts(NotModifiedTag tag) => new Contacts(tag);
        public static explicit operator Contacts(Tag tag) => new Contacts(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Contacts Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NotModifiedTag.TypeNumber: return (Contacts) NotModifiedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (Contacts) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NotModifiedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NotModifiedTag, T> notModifiedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NotModifiedTag, T> notModifiedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NotModifiedTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Contacts other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Contacts x && Equals(x);
        public static bool operator ==(Contacts x, Contacts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Contacts x, Contacts y) => !(x == y);

        public int CompareTo(Contacts other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Contacts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Contacts x, Contacts y) => x.CompareTo(y) <= 0;
        public static bool operator <(Contacts x, Contacts y) => x.CompareTo(y) < 0;
        public static bool operator >(Contacts x, Contacts y) => x.CompareTo(y) > 0;
        public static bool operator >=(Contacts x, Contacts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Contacts.{_tag.GetType().Name}{_tag}";
    }
}