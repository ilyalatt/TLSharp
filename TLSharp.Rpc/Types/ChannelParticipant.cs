using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelParticipant : ITlType, IEquatable<ChannelParticipant>, IComparable<ChannelParticipant>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x15ebac1d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int Date { get; }
            
            public Tag(
                int userId,
                int date
            ) {
                UserId = userId;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new Tag(userId, date);
            }
        }

        public sealed class SelfTag : Record<SelfTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa3289a6d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int InviterId { get; }
            public int Date { get; }
            
            public SelfTag(
                int userId,
                int inviterId,
                int date
            ) {
                UserId = userId;
                InviterId = inviterId;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(InviterId, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static SelfTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new SelfTag(userId, inviterId, date);
            }
        }

        public sealed class ModeratorTag : Record<ModeratorTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x91057fef;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int InviterId { get; }
            public int Date { get; }
            
            public ModeratorTag(
                int userId,
                int inviterId,
                int date
            ) {
                UserId = userId;
                InviterId = inviterId;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(InviterId, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static ModeratorTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new ModeratorTag(userId, inviterId, date);
            }
        }

        public sealed class EditorTag : Record<EditorTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x98192d61;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int InviterId { get; }
            public int Date { get; }
            
            public EditorTag(
                int userId,
                int inviterId,
                int date
            ) {
                UserId = userId;
                InviterId = inviterId;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(InviterId, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static EditorTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new EditorTag(userId, inviterId, date);
            }
        }

        public sealed class KickedTag : Record<KickedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x8cc5e69a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int KickedBy { get; }
            public int Date { get; }
            
            public KickedTag(
                int userId,
                int kickedBy,
                int date
            ) {
                UserId = userId;
                KickedBy = kickedBy;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(KickedBy, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static KickedTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var kickedBy = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new KickedTag(userId, kickedBy, date);
            }
        }

        public sealed class CreatorTag : Record<CreatorTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe3e2e1f9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            
            public CreatorTag(
                int userId
            ) {
                UserId = userId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
            }
            
            internal static CreatorTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                return new CreatorTag(userId);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelParticipant(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipant(Tag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(SelfTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(ModeratorTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(EditorTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(KickedTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(CreatorTag tag) => new ChannelParticipant(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelParticipant Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelParticipant) Tag.DeserializeTag(br);
                case SelfTag.TypeNumber: return (ChannelParticipant) SelfTag.DeserializeTag(br);
                case ModeratorTag.TypeNumber: return (ChannelParticipant) ModeratorTag.DeserializeTag(br);
                case EditorTag.TypeNumber: return (ChannelParticipant) EditorTag.DeserializeTag(br);
                case KickedTag.TypeNumber: return (ChannelParticipant) KickedTag.DeserializeTag(br);
                case CreatorTag.TypeNumber: return (ChannelParticipant) CreatorTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, SelfTag.TypeNumber, ModeratorTag.TypeNumber, EditorTag.TypeNumber, KickedTag.TypeNumber, CreatorTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SelfTag, T> selfTag = null,
            Func<ModeratorTag, T> moderatorTag = null,
            Func<EditorTag, T> editorTag = null,
            Func<KickedTag, T> kickedTag = null,
            Func<CreatorTag, T> creatorTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SelfTag x when selfTag != null: return selfTag(x);
                case ModeratorTag x when moderatorTag != null: return moderatorTag(x);
                case EditorTag x when editorTag != null: return editorTag(x);
                case KickedTag x when kickedTag != null: return kickedTag(x);
                case CreatorTag x when creatorTag != null: return creatorTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SelfTag, T> selfTag,
            Func<ModeratorTag, T> moderatorTag,
            Func<EditorTag, T> editorTag,
            Func<KickedTag, T> kickedTag,
            Func<CreatorTag, T> creatorTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            selfTag ?? throw new ArgumentNullException(nameof(selfTag)),
            moderatorTag ?? throw new ArgumentNullException(nameof(moderatorTag)),
            editorTag ?? throw new ArgumentNullException(nameof(editorTag)),
            kickedTag ?? throw new ArgumentNullException(nameof(kickedTag)),
            creatorTag ?? throw new ArgumentNullException(nameof(creatorTag))
        );

        public bool Equals(ChannelParticipant other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChannelParticipant x && Equals(x);
        public static bool operator ==(ChannelParticipant a, ChannelParticipant b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChannelParticipant a, ChannelParticipant b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SelfTag _: return 1;
                case ModeratorTag _: return 2;
                case EditorTag _: return 3;
                case KickedTag _: return 4;
                case CreatorTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChannelParticipant other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) < 0;
        public static bool operator >(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}