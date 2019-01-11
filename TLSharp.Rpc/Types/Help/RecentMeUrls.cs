using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Help
{
    public sealed class RecentMeUrls : ITlType, IEquatable<RecentMeUrls>, IComparable<RecentMeUrls>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x0e0310d7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.RecentMeUrl> Urls;
            public readonly Arr<T.Chat> Chats;
            public readonly Arr<T.User> Users;
            
            public Tag(
                Some<Arr<T.RecentMeUrl>> urls,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Urls = urls;
                Chats = chats;
                Users = users;
            }
            
            (Arr<T.RecentMeUrl>, Arr<T.Chat>, Arr<T.User>) CmpTuple =>
                (Urls, Chats, Users);

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

            public override string ToString() => $"(Urls: {Urls}, Chats: {Chats}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Urls, bw, WriteVector<T.RecentMeUrl>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var urls = Read(br, ReadVector(T.RecentMeUrl.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(urls, chats, users);
            }
        }

        readonly ITlTypeTag _tag;
        RecentMeUrls(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator RecentMeUrls(Tag tag) => new RecentMeUrls(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static RecentMeUrls Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (RecentMeUrls) Tag.DeserializeTag(br);
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

        public bool Equals(RecentMeUrls other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is RecentMeUrls x && Equals(x);
        public static bool operator ==(RecentMeUrls x, RecentMeUrls y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RecentMeUrls x, RecentMeUrls y) => !(x == y);

        public int CompareTo(RecentMeUrls other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is RecentMeUrls x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RecentMeUrls x, RecentMeUrls y) => x.CompareTo(y) <= 0;
        public static bool operator <(RecentMeUrls x, RecentMeUrls y) => x.CompareTo(y) < 0;
        public static bool operator >(RecentMeUrls x, RecentMeUrls y) => x.CompareTo(y) > 0;
        public static bool operator >=(RecentMeUrls x, RecentMeUrls y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"RecentMeUrls.{_tag.GetType().Name}{_tag}";
    }
}