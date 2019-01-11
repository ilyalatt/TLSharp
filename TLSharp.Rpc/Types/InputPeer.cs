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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x7f3b18ea;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class SelfTag : ITlTypeTag, IEquatable<SelfTag>, IComparable<SelfTag>, IComparable
        {
            internal const uint TypeNumber = 0x7da07ec9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SelfTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(SelfTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SelfTag x && Equals(x);
            public static bool operator ==(SelfTag x, SelfTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SelfTag x, SelfTag y) => !(x == y);

            public int CompareTo(SelfTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SelfTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SelfTag x, SelfTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SelfTag x, SelfTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SelfTag x, SelfTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SelfTag x, SelfTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SelfTag DeserializeTag(BinaryReader br)
            {

                return new SelfTag();
            }
        }

        public sealed class ChatTag : ITlTypeTag, IEquatable<ChatTag>, IComparable<ChatTag>, IComparable
        {
            internal const uint TypeNumber = 0x179be863;
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

        public sealed class UserTag : ITlTypeTag, IEquatable<UserTag>, IComparable<UserTag>, IComparable
        {
            internal const uint TypeNumber = 0x7b8e7de6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public long AccessHash { get; }
            
            public UserTag(
                int userId,
                long accessHash
            ) {
                UserId = userId;
                AccessHash = accessHash;
            }
            
            (int, long) CmpTuple =>
                (UserId, AccessHash);

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

            public override string ToString() => $"(UserId: {UserId}, AccessHash: {AccessHash})";
            
            
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

        public sealed class ChannelTag : ITlTypeTag, IEquatable<ChannelTag>, IComparable<ChannelTag>, IComparable
        {
            internal const uint TypeNumber = 0x20adaef8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public long AccessHash { get; }
            
            public ChannelTag(
                int channelId,
                long accessHash
            ) {
                ChannelId = channelId;
                AccessHash = accessHash;
            }
            
            (int, long) CmpTuple =>
                (ChannelId, AccessHash);

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

            public override string ToString() => $"(ChannelId: {ChannelId}, AccessHash: {AccessHash})";
            
            
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
                case EmptyTag.TypeNumber: return (InputPeer) EmptyTag.DeserializeTag(br);
                case SelfTag.TypeNumber: return (InputPeer) SelfTag.DeserializeTag(br);
                case ChatTag.TypeNumber: return (InputPeer) ChatTag.DeserializeTag(br);
                case UserTag.TypeNumber: return (InputPeer) UserTag.DeserializeTag(br);
                case ChannelTag.TypeNumber: return (InputPeer) ChannelTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, SelfTag.TypeNumber, ChatTag.TypeNumber, UserTag.TypeNumber, ChannelTag.TypeNumber });
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

        public bool Equals(InputPeer other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputPeer x && Equals(x);
        public static bool operator ==(InputPeer x, InputPeer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputPeer x, InputPeer y) => !(x == y);

        public int CompareTo(InputPeer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPeer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPeer x, InputPeer y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputPeer x, InputPeer y) => x.CompareTo(y) < 0;
        public static bool operator >(InputPeer x, InputPeer y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputPeer x, InputPeer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputPeer.{_tag.GetType().Name}{_tag}";
    }
}