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
        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xde266ef5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NotModifiedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x70b772a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.TopPeerCategoryPeers> Categories { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.TopPeerCategoryPeers>> categories,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Categories = categories;
                Chats = chats;
                Users = users;
            }
            
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

        readonly ITlTypeTag _tag;
        TopPeers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator TopPeers(NotModifiedTag tag) => new TopPeers(tag);
        public static explicit operator TopPeers(Tag tag) => new TopPeers(tag);

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

        public bool Equals(TopPeers other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is TopPeers x && Equals(x);
        public static bool operator ==(TopPeers a, TopPeers b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(TopPeers a, TopPeers b) => !(a == b);

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

        public int CompareTo(TopPeers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is TopPeers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TopPeers a, TopPeers b) => a.CompareTo(b) <= 0;
        public static bool operator <(TopPeers a, TopPeers b) => a.CompareTo(b) < 0;
        public static bool operator >(TopPeers a, TopPeers b) => a.CompareTo(b) > 0;
        public static bool operator >=(TopPeers a, TopPeers b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}