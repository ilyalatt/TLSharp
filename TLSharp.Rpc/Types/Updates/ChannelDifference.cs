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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x3e11affb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Final;
            public readonly int Pts;
            public readonly Option<int> Timeout;
            
            public EmptyTag(
                bool final,
                int pts,
                Option<int> timeout
            ) {
                Final = final;
                Pts = pts;
                Timeout = timeout;
            }
            
            (bool, int, Option<int>) CmpTuple =>
                (Final, Pts, Timeout);

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Final: {Final}, Pts: {Pts}, Timeout: {Timeout})";
            
            
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

        public sealed class TooLongTag : ITlTypeTag, IEquatable<TooLongTag>, IComparable<TooLongTag>, IComparable
        {
            internal const uint TypeNumber = 0x410dee07;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Final;
            public readonly int Pts;
            public readonly Option<int> Timeout;
            public readonly int TopMessage;
            public readonly int ReadInboxMaxId;
            public readonly int ReadOutboxMaxId;
            public readonly int UnreadCount;
            public readonly Arr<T.Message> Messages;
            public readonly Arr<T.Chat> Chats;
            public readonly Arr<T.User> Users;
            
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
            
            (bool, int, Option<int>, int, int, int, int, Arr<T.Message>, Arr<T.Chat>, Arr<T.User>) CmpTuple =>
                (Final, Pts, Timeout, TopMessage, ReadInboxMaxId, ReadOutboxMaxId, UnreadCount, Messages, Chats, Users);

            public bool Equals(TooLongTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TooLongTag x && Equals(x);
            public static bool operator ==(TooLongTag x, TooLongTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TooLongTag x, TooLongTag y) => !(x == y);

            public int CompareTo(TooLongTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TooLongTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TooLongTag x, TooLongTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TooLongTag x, TooLongTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TooLongTag x, TooLongTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TooLongTag x, TooLongTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Final: {Final}, Pts: {Pts}, Timeout: {Timeout}, TopMessage: {TopMessage}, ReadInboxMaxId: {ReadInboxMaxId}, ReadOutboxMaxId: {ReadOutboxMaxId}, UnreadCount: {UnreadCount}, Messages: {Messages}, Chats: {Chats}, Users: {Users})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x2064674e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Final;
            public readonly int Pts;
            public readonly Option<int> Timeout;
            public readonly Arr<T.Message> NewMessages;
            public readonly Arr<T.Update> OtherUpdates;
            public readonly Arr<T.Chat> Chats;
            public readonly Arr<T.User> Users;
            
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
            
            (bool, int, Option<int>, Arr<T.Message>, Arr<T.Update>, Arr<T.Chat>, Arr<T.User>) CmpTuple =>
                (Final, Pts, Timeout, NewMessages, OtherUpdates, Chats, Users);

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

            public override string ToString() => $"(Final: {Final}, Pts: {Pts}, Timeout: {Timeout}, NewMessages: {NewMessages}, OtherUpdates: {OtherUpdates}, Chats: {Chats}, Users: {Users})";
            
            
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

        public bool Equals(ChannelDifference other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelDifference x && Equals(x);
        public static bool operator ==(ChannelDifference x, ChannelDifference y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelDifference x, ChannelDifference y) => !(x == y);

        public int CompareTo(ChannelDifference other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelDifference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelDifference x, ChannelDifference y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelDifference x, ChannelDifference y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelDifference x, ChannelDifference y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelDifference x, ChannelDifference y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelDifference.{_tag.GetType().Name}{_tag}";
    }
}