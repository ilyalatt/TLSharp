using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class NotifyPeer : ITlType, IEquatable<NotifyPeer>, IComparable<NotifyPeer>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9fd40bd8;
            
            public T.Peer Peer { get; }
            
            public Tag(
                Some<T.Peer> peer
            ) {
                Peer = peer;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.Peer.Deserialize);
                return new Tag(peer);
            }
        }

        public sealed class UsersTag : Record<UsersTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xb4c83b4c;
            

            
            public UsersTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static UsersTag DeserializeTag(BinaryReader br)
            {

                return new UsersTag();
            }
        }

        public sealed class ChatsTag : Record<ChatsTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc007cec3;
            

            
            public ChatsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatsTag DeserializeTag(BinaryReader br)
            {

                return new ChatsTag();
            }
        }

        public sealed class AllTag : Record<AllTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x74d07c60;
            

            
            public AllTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AllTag DeserializeTag(BinaryReader br)
            {

                return new AllTag();
            }
        }

        readonly ITlTypeTag _tag;
        NotifyPeer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator NotifyPeer(Tag tag) => new NotifyPeer(tag);
        public static explicit operator NotifyPeer(UsersTag tag) => new NotifyPeer(tag);
        public static explicit operator NotifyPeer(ChatsTag tag) => new NotifyPeer(tag);
        public static explicit operator NotifyPeer(AllTag tag) => new NotifyPeer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static NotifyPeer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x9fd40bd8: return (NotifyPeer) Tag.DeserializeTag(br);
                case 0xb4c83b4c: return (NotifyPeer) UsersTag.DeserializeTag(br);
                case 0xc007cec3: return (NotifyPeer) ChatsTag.DeserializeTag(br);
                case 0x74d07c60: return (NotifyPeer) AllTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x9fd40bd8, 0xb4c83b4c, 0xc007cec3, 0x74d07c60 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<UsersTag, T> usersTag = null,
            Func<ChatsTag, T> chatsTag = null,
            Func<AllTag, T> allTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case UsersTag x when usersTag != null: return usersTag(x);
                case ChatsTag x when chatsTag != null: return chatsTag(x);
                case AllTag x when allTag != null: return allTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<UsersTag, T> usersTag,
            Func<ChatsTag, T> chatsTag,
            Func<AllTag, T> allTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            usersTag ?? throw new ArgumentNullException(nameof(usersTag)),
            chatsTag ?? throw new ArgumentNullException(nameof(chatsTag)),
            allTag ?? throw new ArgumentNullException(nameof(allTag))
        );

        public bool Equals(NotifyPeer other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is NotifyPeer x && Equals(x);
        public static bool operator ==(NotifyPeer a, NotifyPeer b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(NotifyPeer a, NotifyPeer b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case UsersTag _: return 1;
                case ChatsTag _: return 2;
                case AllTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(NotifyPeer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is NotifyPeer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(NotifyPeer a, NotifyPeer b) => a.CompareTo(b) <= 0;
        public static bool operator <(NotifyPeer a, NotifyPeer b) => a.CompareTo(b) < 0;
        public static bool operator >(NotifyPeer a, NotifyPeer b) => a.CompareTo(b) > 0;
        public static bool operator >=(NotifyPeer a, NotifyPeer b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}