using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class Messages : ITlType, IEquatable<Messages>, IComparable<Messages>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x8c718e87;
            
            public Arr<T.Message> Messages { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.Message>> messages,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Messages = messages;
                Chats = chats;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Messages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var messages = Read(br, ReadVector(T.Message.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(messages, chats, users);
            }
        }

        public sealed class SliceTag : Record<SliceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x0b446ae3;
            
            public int Count { get; }
            public Arr<T.Message> Messages { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public SliceTag(
                int count,
                Some<Arr<T.Message>> messages,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Count = count;
                Messages = messages;
                Chats = chats;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Count, bw, WriteInt);
                Write(Messages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static SliceTag DeserializeTag(BinaryReader br)
            {
                var count = Read(br, ReadInt);
                var messages = Read(br, ReadVector(T.Message.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new SliceTag(count, messages, chats, users);
            }
        }

        public sealed class ChannelTag : Record<ChannelTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x99262e37;
            
            public int Pts { get; }
            public int Count { get; }
            public Arr<T.Message> Messages { get; }
            public Arr<T.Chat> Chats { get; }
            public Arr<T.User> Users { get; }
            
            public ChannelTag(
                int pts,
                int count,
                Some<Arr<T.Message>> messages,
                Some<Arr<T.Chat>> chats,
                Some<Arr<T.User>> users
            ) {
                Pts = pts;
                Count = count;
                Messages = messages;
                Chats = chats;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(0, bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(Count, bw, WriteInt);
                Write(Messages, bw, WriteVector<T.Message>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var pts = Read(br, ReadInt);
                var count = Read(br, ReadInt);
                var messages = Read(br, ReadVector(T.Message.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new ChannelTag(pts, count, messages, chats, users);
            }
        }

        readonly ITlTypeTag _tag;
        Messages(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Messages(Tag tag) => new Messages(tag);
        public static explicit operator Messages(SliceTag tag) => new Messages(tag);
        public static explicit operator Messages(ChannelTag tag) => new Messages(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Messages Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x8c718e87: return (Messages) Tag.DeserializeTag(br);
                case 0x0b446ae3: return (Messages) SliceTag.DeserializeTag(br);
                case 0x99262e37: return (Messages) ChannelTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x8c718e87, 0x0b446ae3, 0x99262e37 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SliceTag, T> sliceTag = null,
            Func<ChannelTag, T> channelTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SliceTag x when sliceTag != null: return sliceTag(x);
                case ChannelTag x when channelTag != null: return channelTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SliceTag, T> sliceTag,
            Func<ChannelTag, T> channelTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            sliceTag ?? throw new ArgumentNullException(nameof(sliceTag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag))
        );

        public bool Equals(Messages other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Messages x && Equals(x);
        public static bool operator ==(Messages a, Messages b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Messages a, Messages b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SliceTag _: return 1;
                case ChannelTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Messages other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Messages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Messages a, Messages b) => a.CompareTo(b) <= 0;
        public static bool operator <(Messages a, Messages b) => a.CompareTo(b) < 0;
        public static bool operator >(Messages a, Messages b) => a.CompareTo(b) > 0;
        public static bool operator >=(Messages a, Messages b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}