using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Contacts
{
    public sealed class TopPeers : ITlType, IEquatable<TopPeers>, IComparable<TopPeers>, IComparable
    {
        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0xde266ef5;
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
            internal const uint TypeNumber = 0x70b772a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.TopPeerCategoryPeers> Categories;
            public readonly Arr<T.Chat> Chats;
            public readonly Arr<T.User> Users;
            
            public Tag(
                Some<Arr<T.TopPeerCategoryPeers>> categories,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Categories = categories;
                Chats = chats;
                Users = users;
            }
            
            (Arr<T.TopPeerCategoryPeers>, Arr<T.Chat>, Arr<T.User>) CmpTuple =>
                (Categories, Chats, Users);

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

            public override string ToString() => $"(Categories: {Categories}, Chats: {Chats}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Categories, bw, WriteVector<T.TopPeerCategoryPeers>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var categories = Read(br, ReadVector(T.TopPeerCategoryPeers.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(categories, chats, users);
            }
        }

        public sealed class DisabledTag : ITlTypeTag, IEquatable<DisabledTag>, IComparable<DisabledTag>, IComparable
        {
            internal const uint TypeNumber = 0xb52c939d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public DisabledTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(DisabledTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DisabledTag x && Equals(x);
            public static bool operator ==(DisabledTag x, DisabledTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DisabledTag x, DisabledTag y) => !(x == y);

            public int CompareTo(DisabledTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DisabledTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DisabledTag x, DisabledTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DisabledTag x, DisabledTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DisabledTag x, DisabledTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DisabledTag x, DisabledTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static DisabledTag DeserializeTag(BinaryReader br)
            {

                return new DisabledTag();
            }
        }

        readonly ITlTypeTag _tag;
        TopPeers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TopPeers(NotModifiedTag tag) => new TopPeers(tag);
        public static explicit operator TopPeers(Tag tag) => new TopPeers(tag);
        public static explicit operator TopPeers(DisabledTag tag) => new TopPeers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static TopPeers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NotModifiedTag.TypeNumber: return (TopPeers) NotModifiedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (TopPeers) Tag.DeserializeTag(br);
                case DisabledTag.TypeNumber: return (TopPeers) DisabledTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NotModifiedTag.TypeNumber, Tag.TypeNumber, DisabledTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NotModifiedTag, T> notModifiedTag = null,
            Func<Tag, T> tag = null,
            Func<DisabledTag, T> disabledTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                case Tag x when tag != null: return tag(x);
                case DisabledTag x when disabledTag != null: return disabledTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NotModifiedTag, T> notModifiedTag,
            Func<Tag, T> tag,
            Func<DisabledTag, T> disabledTag
        ) => Match(
            () => throw new Exception("WTF"),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            disabledTag ?? throw new ArgumentNullException(nameof(disabledTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NotModifiedTag _: return 0;
                case Tag _: return 1;
                case DisabledTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(TopPeers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is TopPeers x && Equals(x);
        public static bool operator ==(TopPeers x, TopPeers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TopPeers x, TopPeers y) => !(x == y);

        public int CompareTo(TopPeers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is TopPeers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeers x, TopPeers y) => x.CompareTo(y) <= 0;
        public static bool operator <(TopPeers x, TopPeers y) => x.CompareTo(y) < 0;
        public static bool operator >(TopPeers x, TopPeers y) => x.CompareTo(y) > 0;
        public static bool operator >=(TopPeers x, TopPeers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"TopPeers.{_tag.GetType().Name}{_tag}";
    }
}