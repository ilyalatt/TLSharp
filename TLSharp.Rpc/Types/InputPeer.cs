using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputPeer : ITlType, IEquatable<InputPeer>, IComparable<InputPeer>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7f3b18ea;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class SelfTag : Record<SelfTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7da07ec9;
            

            
            public SelfTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SelfTag DeserializeTag(BinaryReader br)
            {

                return new SelfTag();
            }
        }

        public sealed class ChatTag : Record<ChatTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x179be863;
            
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

        public sealed class UserTag : Record<UserTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7b8e7de6;
            
            public int UserId { get; }
            public long AccessHash { get; }
            
            public UserTag(
                int userId,
                long accessHash
            ) {
                UserId = userId;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static UserTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                return new UserTag(userId, accessHash);
            }
        }

        public sealed class ChannelTag : Record<ChannelTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x20adaef8;
            
            public int ChannelId { get; }
            public long AccessHash { get; }
            
            public ChannelTag(
                int channelId,
                long accessHash
            ) {
                ChannelId = channelId;
                AccessHash = accessHash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                return new ChannelTag(channelId, accessHash);
            }
        }

        readonly ITlTypeTag _tag;
        InputPeer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPeer(EmptyTag tag) => new InputPeer(tag);
        public static explicit operator InputPeer(SelfTag tag) => new InputPeer(tag);
        public static explicit operator InputPeer(ChatTag tag) => new InputPeer(tag);
        public static explicit operator InputPeer(UserTag tag) => new InputPeer(tag);
        public static explicit operator InputPeer(ChannelTag tag) => new InputPeer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputPeer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x7f3b18ea: return (InputPeer) EmptyTag.DeserializeTag(br);
                case 0x7da07ec9: return (InputPeer) SelfTag.DeserializeTag(br);
                case 0x179be863: return (InputPeer) ChatTag.DeserializeTag(br);
                case 0x7b8e7de6: return (InputPeer) UserTag.DeserializeTag(br);
                case 0x20adaef8: return (InputPeer) ChannelTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x7f3b18ea, 0x7da07ec9, 0x179be863, 0x7b8e7de6, 0x20adaef8 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<SelfTag, T> selfTag = null,
            Func<ChatTag, T> chatTag = null,
            Func<UserTag, T> userTag = null,
            Func<ChannelTag, T> channelTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case SelfTag x when selfTag != null: return selfTag(x);
                case ChatTag x when chatTag != null: return chatTag(x);
                case UserTag x when userTag != null: return userTag(x);
                case ChannelTag x when channelTag != null: return channelTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<SelfTag, T> selfTag,
            Func<ChatTag, T> chatTag,
            Func<UserTag, T> userTag,
            Func<ChannelTag, T> channelTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            selfTag ?? throw new ArgumentNullException(nameof(selfTag)),
            chatTag ?? throw new ArgumentNullException(nameof(chatTag)),
            userTag ?? throw new ArgumentNullException(nameof(userTag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag))
        );

        public bool Equals(InputPeer other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputPeer x && Equals(x);
        public static bool operator ==(InputPeer a, InputPeer b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputPeer a, InputPeer b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case SelfTag _: return 1;
                case ChatTag _: return 2;
                case UserTag _: return 3;
                case ChannelTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputPeer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPeer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPeer a, InputPeer b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputPeer a, InputPeer b) => a.CompareTo(b) < 0;
        public static bool operator >(InputPeer a, InputPeer b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputPeer a, InputPeer b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}