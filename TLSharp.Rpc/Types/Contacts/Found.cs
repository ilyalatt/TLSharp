using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Contacts
{
    public sealed class Found : ITlType, IEquatable<Found>, IComparable<Found>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1aa1f784;
            
            public Arr<T.Peer> Results { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.Peer>> results,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Results = results;
                Chats = chats;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Results, bw, WriteVector<T.Peer>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var results = Read(br, ReadVector(T.Peer.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(results, chats, users);
            }
        }

        readonly ITlTypeTag _tag;
        Found(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Found(Tag tag) => new Found(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Found Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x1aa1f784: return (Found) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x1aa1f784 });
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

        public bool Equals(Found other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Found x && Equals(x);
        public static bool operator ==(Found a, Found b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Found a, Found b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Found other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Found x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Found a, Found b) => a.CompareTo(b) <= 0;
        public static bool operator <(Found a, Found b) => a.CompareTo(b) < 0;
        public static bool operator >(Found a, Found b) => a.CompareTo(b) > 0;
        public static bool operator >=(Found a, Found b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}