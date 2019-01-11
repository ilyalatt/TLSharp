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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xc8d7493e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            public readonly int InviterId;
            public readonly int Date;
            
            public Tag(
                int userId,
                int inviterId,
                int date
            ) {
                UserId = userId;
                InviterId = inviterId;
                Date = date;
            }
            
            (int, int, int) CmpTuple =>
                (UserId, InviterId, Date);

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

            public override string ToString() => $"(UserId: {UserId}, InviterId: {InviterId}, Date: {Date})";
            
            
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

        public sealed class CreatorTag : ITlTypeTag, IEquatable<CreatorTag>, IComparable<CreatorTag>, IComparable
        {
            internal const uint TypeNumber = 0xda13538a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            
            public CreatorTag(
                int userId
            ) {
                UserId = userId;
            }
            
            int CmpTuple =>
                UserId;

            public bool Equals(CreatorTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CreatorTag x && Equals(x);
            public static bool operator ==(CreatorTag x, CreatorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CreatorTag x, CreatorTag y) => !(x == y);

            public int CompareTo(CreatorTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CreatorTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CreatorTag x, CreatorTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CreatorTag x, CreatorTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CreatorTag x, CreatorTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CreatorTag x, CreatorTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId})";
            
            
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

        public sealed class AdminTag : ITlTypeTag, IEquatable<AdminTag>, IComparable<AdminTag>, IComparable
        {
            internal const uint TypeNumber = 0xe2d6e436;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            public readonly int InviterId;
            public readonly int Date;
            
            public AdminTag(
                int userId,
                int inviterId,
                int date
            ) {
                UserId = userId;
                InviterId = inviterId;
                Date = date;
            }
            
            (int, int, int) CmpTuple =>
                (UserId, InviterId, Date);

            public bool Equals(AdminTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AdminTag x && Equals(x);
            public static bool operator ==(AdminTag x, AdminTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AdminTag x, AdminTag y) => !(x == y);

            public int CompareTo(AdminTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AdminTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AdminTag x, AdminTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AdminTag x, AdminTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AdminTag x, AdminTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AdminTag x, AdminTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, InviterId: {InviterId}, Date: {Date})";
            
            
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
                case Tag.TypeNumber: return (ChatParticipant) Tag.DeserializeTag(br);
                case CreatorTag.TypeNumber: return (ChatParticipant) CreatorTag.DeserializeTag(br);
                case AdminTag.TypeNumber: return (ChatParticipant) AdminTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, CreatorTag.TypeNumber, AdminTag.TypeNumber });
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

        public bool Equals(ChatParticipant other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChatParticipant x && Equals(x);
        public static bool operator ==(ChatParticipant x, ChatParticipant y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChatParticipant x, ChatParticipant y) => !(x == y);

        public int CompareTo(ChatParticipant other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChatParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatParticipant x, ChatParticipant y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChatParticipant x, ChatParticipant y) => x.CompareTo(y) < 0;
        public static bool operator >(ChatParticipant x, ChatParticipant y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChatParticipant x, ChatParticipant y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChatParticipant.{_tag.GetType().Name}{_tag}";
    }
}