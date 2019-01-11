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
        public sealed class ForbiddenTag : ITlTypeTag, IEquatable<ForbiddenTag>, IComparable<ForbiddenTag>, IComparable
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
            
            (int, Option<T.ChatParticipant>) CmpTuple =>
                (ChatId, SelfParticipant);

            public bool Equals(ForbiddenTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ForbiddenTag x && Equals(x);
            public static bool operator ==(ForbiddenTag x, ForbiddenTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ForbiddenTag x, ForbiddenTag y) => !(x == y);

            public int CompareTo(ForbiddenTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ForbiddenTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ForbiddenTag x, ForbiddenTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ForbiddenTag x, ForbiddenTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ForbiddenTag x, ForbiddenTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ForbiddenTag x, ForbiddenTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, SelfParticipant: {SelfParticipant})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
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
            
            (int, Arr<T.ChatParticipant>, int) CmpTuple =>
                (ChatId, Participants, Version);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, Participants: {Participants}, Version: {Version})";
            
            
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

        public bool Equals(ChatParticipants other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ChatParticipants x && Equals(x);
        public static bool operator ==(ChatParticipants x, ChatParticipants y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChatParticipants x, ChatParticipants y) => !(x == y);

        public int CompareTo(ChatParticipants other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChatParticipants x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatParticipants x, ChatParticipants y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChatParticipants x, ChatParticipants y) => x.CompareTo(y) < 0;
        public static bool operator >(ChatParticipants x, ChatParticipants y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChatParticipants x, ChatParticipants y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChatParticipants.{_tag.GetType().Name}{_tag}";
    }
}