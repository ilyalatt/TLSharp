using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChatParticipants : ITlType, IEquatable<ChatParticipants>, IComparable<ChatParticipants>, IComparable
    {
        public sealed class ForbiddenTag : Record<ForbiddenTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xfc900c2b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public Option<T.ChatParticipant> SelfParticipant { get; }
            
            public ForbiddenTag(
                int chatId,
                Option<T.ChatParticipant> selfParticipant
            ) {
                ChatId = chatId;
                SelfParticipant = selfParticipant;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, SelfParticipant), bw, WriteInt);
                Write(ChatId, bw, WriteInt);
                Write(SelfParticipant, bw, WriteOption<T.ChatParticipant>(WriteSerializable));
            }
            
            internal static ForbiddenTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var chatId = Read(br, ReadInt);
                var selfParticipant = Read(br, ReadOption(flags, 0, T.ChatParticipant.Deserialize));
                return new ForbiddenTag(chatId, selfParticipant);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x3f460fed;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public Arr<T.ChatParticipant> Participants { get; }
            public int Version { get; }
            
            public Tag(
                int chatId,
                Some<Arr<T.ChatParticipant>> participants,
                int version
            ) {
                ChatId = chatId;
                Participants = participants;
                Version = version;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(Participants, bw, WriteVector<T.ChatParticipant>(WriteSerializable));
                Write(Version, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var participants = Read(br, ReadVector(T.ChatParticipant.Deserialize));
                var version = Read(br, ReadInt);
                return new Tag(chatId, participants, version);
            }
        }

        readonly ITlTypeTag _tag;
        ChatParticipants(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChatParticipants(ForbiddenTag tag) => new ChatParticipants(tag);
        public static explicit operator ChatParticipants(Tag tag) => new ChatParticipants(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChatParticipants Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case ForbiddenTag.TypeNumber: return (ChatParticipants) ForbiddenTag.DeserializeTag(br);
                case Tag.TypeNumber: return (ChatParticipants) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ForbiddenTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<ForbiddenTag, T> forbiddenTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case ForbiddenTag x when forbiddenTag != null: return forbiddenTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<ForbiddenTag, T> forbiddenTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            forbiddenTag ?? throw new ArgumentNullException(nameof(forbiddenTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(ChatParticipants other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChatParticipants x && Equals(x);
        public static bool operator ==(ChatParticipants a, ChatParticipants b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChatParticipants a, ChatParticipants b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case ForbiddenTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChatParticipants other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChatParticipants x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatParticipants a, ChatParticipants b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChatParticipants a, ChatParticipants b) => a.CompareTo(b) < 0;
        public static bool operator >(ChatParticipants a, ChatParticipants b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChatParticipants a, ChatParticipants b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}