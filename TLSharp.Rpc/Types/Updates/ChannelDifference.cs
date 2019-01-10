using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Updates
{
    public sealed class ChannelDifference : ITlType, IEquatable<ChannelDifference>, IComparable<ChannelDifference>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x3e11affb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Final { get; }
            public int Pts { get; }
            public Option<int> Timeout { get; }
            
            public EmptyTag(
                bool final,
                int pts,
                Option<int> timeout
            ) {
                Final = final;
                Pts = pts;
                Timeout = timeout;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Final) | MaskBit(1, Timeout), bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(Timeout, bw, WriteOption<int>(WriteInt));
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var final = Read(br, ReadOption(flags, 0));
                var pts = Read(br, ReadInt);
                var timeout = Read(br, ReadOption(flags, 1, ReadInt));
                return new EmptyTag(final, pts, timeout);
            }
        }

        public sealed class TooLongTag : Record<TooLongTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x410dee07;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Final { get; }
            public int Pts { get; }
            public Option<int> Timeout { get; }
            public int TopMessage { get; }
            public int ReadInboxMaxId { get; }
            public int ReadOutboxMaxId { get; }
            public int UnreadCount { get; }
            public Arr<T.Message> Messages { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public TooLongTag(
                bool final,
                int pts,
                Option<int> timeout,
                int topMessage,
                int readInboxMaxId,
                int readOutboxMaxId,
                int unreadCount,
                Some<Arr<T.Message>> messages,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Final = final;
                Pts = pts;
                Timeout = timeout;
                TopMessage = topMessage;
                ReadInboxMaxId = readInboxMaxId;
                ReadOutboxMaxId = readOutboxMaxId;
                UnreadCount = unreadCount;
                Messages = messages;
                Chats = chats;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Final) | MaskBit(1, Timeout), bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(Timeout, bw, WriteOption<int>(WriteInt));
                Write(TopMessage, bw, WriteInt);
                Write(ReadInboxMaxId, bw, WriteInt);
                Write(ReadOutboxMaxId, bw, WriteInt);
                Write(UnreadCount, bw, WriteInt);
                Write(Messages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static TooLongTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var final = Read(br, ReadOption(flags, 0));
                var pts = Read(br, ReadInt);
                var timeout = Read(br, ReadOption(flags, 1, ReadInt));
                var topMessage = Read(br, ReadInt);
                var readInboxMaxId = Read(br, ReadInt);
                var readOutboxMaxId = Read(br, ReadInt);
                var unreadCount = Read(br, ReadInt);
                var messages = Read(br, ReadVector(T.Message.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new TooLongTag(final, pts, timeout, topMessage, readInboxMaxId, readOutboxMaxId, unreadCount, messages, chats, users);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2064674e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Final { get; }
            public int Pts { get; }
            public Option<int> Timeout { get; }
            public Arr<T.Message> NewMessages { get; }
            public Arr<T.Update> OtherUpdates { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                bool final,
                int pts,
                Option<int> timeout,
                Some<Arr<T.Message>> newMessages,
                Some<Arr<T.Update>> otherUpdates,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Final = final;
                Pts = pts;
                Timeout = timeout;
                NewMessages = newMessages;
                OtherUpdates = otherUpdates;
                Chats = chats;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Final) | MaskBit(1, Timeout), bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(Timeout, bw, WriteOption<int>(WriteInt));
                Write(NewMessages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(OtherUpdates, bw, WriteVector<T.Update>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var final = Read(br, ReadOption(flags, 0));
                var pts = Read(br, ReadInt);
                var timeout = Read(br, ReadOption(flags, 1, ReadInt));
                var newMessages = Read(br, ReadVector(T.Message.Deserialize));
                var otherUpdates = Read(br, ReadVector(T.Update.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(final, pts, timeout, newMessages, otherUpdates, chats, users);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelDifference(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelDifference(EmptyTag tag) => new ChannelDifference(tag);
        public static explicit operator ChannelDifference(TooLongTag tag) => new ChannelDifference(tag);
        public static explicit operator ChannelDifference(Tag tag) => new ChannelDifference(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelDifference Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (ChannelDifference) EmptyTag.DeserializeTag(br);
                case TooLongTag.TypeNumber: return (ChannelDifference) TooLongTag.DeserializeTag(br);
                case Tag.TypeNumber: return (ChannelDifference) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, TooLongTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<TooLongTag, T> tooLongTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case TooLongTag x when tooLongTag != null: return tooLongTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<TooLongTag, T> tooLongTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tooLongTag ?? throw new ArgumentNullException(nameof(tooLongTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(ChannelDifference other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChannelDifference x && Equals(x);
        public static bool operator ==(ChannelDifference a, ChannelDifference b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChannelDifference a, ChannelDifference b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case TooLongTag _: return 1;
                case Tag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChannelDifference other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelDifference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelDifference a, ChannelDifference b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChannelDifference a, ChannelDifference b) => a.CompareTo(b) < 0;
        public static bool operator >(ChannelDifference a, ChannelDifference b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChannelDifference a, ChannelDifference b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}