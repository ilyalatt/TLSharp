using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChatParticipant : ITlType, IEquatable<ChatParticipant>, IComparable<ChatParticipant>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc8d7493e;
            
            public int UserId { get; }
            public int InviterId { get; }
            public int Date { get; }
            
            public Tag(
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
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new Tag(userId, inviterId, date);
            }
        }

        public sealed class CreatorTag : Record<CreatorTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xda13538a;
            
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

        public sealed class AdminTag : Record<AdminTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe2d6e436;
            
            public int UserId { get; }
            public int InviterId { get; }
            public int Date { get; }
            
            public AdminTag(
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
            
            internal static AdminTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new AdminTag(userId, inviterId, date);
            }
        }

        readonly ITlTypeTag _tag;
        ChatParticipant(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChatParticipant(Tag tag) => new ChatParticipant(tag);
        public static explicit operator ChatParticipant(CreatorTag tag) => new ChatParticipant(tag);
        public static explicit operator ChatParticipant(AdminTag tag) => new ChatParticipant(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChatParticipant Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xc8d7493e: return (ChatParticipant) Tag.DeserializeTag(br);
                case 0xda13538a: return (ChatParticipant) CreatorTag.DeserializeTag(br);
                case 0xe2d6e436: return (ChatParticipant) AdminTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xc8d7493e, 0xda13538a, 0xe2d6e436 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<CreatorTag, T> creatorTag = null,
            Func<AdminTag, T> adminTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case CreatorTag x when creatorTag != null: return creatorTag(x);
                case AdminTag x when adminTag != null: return adminTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<CreatorTag, T> creatorTag,
            Func<AdminTag, T> adminTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            creatorTag ?? throw new ArgumentNullException(nameof(creatorTag)),
            adminTag ?? throw new ArgumentNullException(nameof(adminTag))
        );

        public bool Equals(ChatParticipant other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChatParticipant x && Equals(x);
        public static bool operator ==(ChatParticipant a, ChatParticipant b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChatParticipant a, ChatParticipant b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case CreatorTag _: return 1;
                case AdminTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChatParticipant other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChatParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatParticipant a, ChatParticipant b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChatParticipant a, ChatParticipant b) => a.CompareTo(b) < 0;
        public static bool operator >(ChatParticipant a, ChatParticipant b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChatParticipant a, ChatParticipant b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}