using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Peer : ITlType, IEquatable<Peer>, IComparable<Peer>, IComparable
    {
        public sealed class UserTag : Record<UserTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9db1bc6d;
            
            public int UserId { get; }
            
            public UserTag(
                int userId
            ) {
                UserId = userId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
            }
            
            internal static UserTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                return new UserTag(userId);
            }
        }

        public sealed class ChatTag : Record<ChatTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbad0e5bb;
            
            public int ChatId { get; }
            
            public ChatTag(
                int chatId
            ) {
                ChatId = chatId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
            }
            
            internal static ChatTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                return new ChatTag(chatId);
            }
        }

        public sealed class ChannelTag : Record<ChannelTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbddde532;
            
            public int ChannelId { get; }
            
            public ChannelTag(
                int channelId
            ) {
                ChannelId = channelId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                return new ChannelTag(channelId);
            }
        }

        readonly ITlTypeTag _tag;
        Peer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Peer(UserTag tag) => new Peer(tag);
        public static explicit operator Peer(ChatTag tag) => new Peer(tag);
        public static explicit operator Peer(ChannelTag tag) => new Peer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Peer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x9db1bc6d: return (Peer) UserTag.DeserializeTag(br);
                case 0xbad0e5bb: return (Peer) ChatTag.DeserializeTag(br);
                case 0xbddde532: return (Peer) ChannelTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x9db1bc6d, 0xbad0e5bb, 0xbddde532 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UserTag, T> userTag = null,
            Func<ChatTag, T> chatTag = null,
            Func<ChannelTag, T> channelTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UserTag x when userTag != null: return userTag(x);
                case ChatTag x when chatTag != null: return chatTag(x);
                case ChannelTag x when channelTag != null: return channelTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UserTag, T> userTag,
            Func<ChatTag, T> chatTag,
            Func<ChannelTag, T> channelTag
        ) => Match(
            () => throw new Exception("WTF"),
            userTag ?? throw new ArgumentNullException(nameof(userTag)),
            chatTag ?? throw new ArgumentNullException(nameof(chatTag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag))
        );

        public bool Equals(Peer other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Peer x && Equals(x);
        public static bool operator ==(Peer a, Peer b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Peer a, Peer b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UserTag _: return 0;
                case ChatTag _: return 1;
                case ChannelTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Peer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Peer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Peer a, Peer b) => a.CompareTo(b) <= 0;
        public static bool operator <(Peer a, Peer b) => a.CompareTo(b) < 0;
        public static bool operator >(Peer a, Peer b) => a.CompareTo(b) > 0;
        public static bool operator >=(Peer a, Peer b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}