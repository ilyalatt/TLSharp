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
        public sealed class UserTag : ITlTypeTag, IEquatable<UserTag>, IComparable<UserTag>, IComparable
        {
            internal const uint TypeNumber = 0x9db1bc6d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            
            public UserTag(
                int userId
            ) {
                UserId = userId;
            }
            
            int CmpTuple =>
                UserId;

            public bool Equals(UserTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserTag x && Equals(x);
            public static bool operator ==(UserTag x, UserTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserTag x, UserTag y) => !(x == y);

            public int CompareTo(UserTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserTag x, UserTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserTag x, UserTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserTag x, UserTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserTag x, UserTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId})";
            
            
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

        public sealed class ChatTag : ITlTypeTag, IEquatable<ChatTag>, IComparable<ChatTag>, IComparable
        {
            internal const uint TypeNumber = 0xbad0e5bb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            
            public ChatTag(
                int chatId
            ) {
                ChatId = chatId;
            }
            
            int CmpTuple =>
                ChatId;

            public bool Equals(ChatTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatTag x && Equals(x);
            public static bool operator ==(ChatTag x, ChatTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatTag x, ChatTag y) => !(x == y);

            public int CompareTo(ChatTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatTag x, ChatTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatTag x, ChatTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatTag x, ChatTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatTag x, ChatTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId})";
            
            
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

        public sealed class ChannelTag : ITlTypeTag, IEquatable<ChannelTag>, IComparable<ChannelTag>, IComparable
        {
            internal const uint TypeNumber = 0xbddde532;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            
            public ChannelTag(
                int channelId
            ) {
                ChannelId = channelId;
            }
            
            int CmpTuple =>
                ChannelId;

            public bool Equals(ChannelTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelTag x && Equals(x);
            public static bool operator ==(ChannelTag x, ChannelTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelTag x, ChannelTag y) => !(x == y);

            public int CompareTo(ChannelTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelTag x, ChannelTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelTag x, ChannelTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelTag x, ChannelTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelTag x, ChannelTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId})";
            
            
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
                case UserTag.TypeNumber: return (Peer) UserTag.DeserializeTag(br);
                case ChatTag.TypeNumber: return (Peer) ChatTag.DeserializeTag(br);
                case ChannelTag.TypeNumber: return (Peer) ChannelTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UserTag.TypeNumber, ChatTag.TypeNumber, ChannelTag.TypeNumber });
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

        public bool Equals(Peer other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Peer x && Equals(x);
        public static bool operator ==(Peer x, Peer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Peer x, Peer y) => !(x == y);

        public int CompareTo(Peer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Peer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Peer x, Peer y) => x.CompareTo(y) <= 0;
        public static bool operator <(Peer x, Peer y) => x.CompareTo(y) < 0;
        public static bool operator >(Peer x, Peer y) => x.CompareTo(y) > 0;
        public static bool operator >=(Peer x, Peer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Peer.{_tag.GetType().Name}{_tag}";
    }
}