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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x15ebac1d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            public readonly int Date;
            
            public Tag(
                int userId,
                int date
            ) {
                UserId = userId;
                Date = date;
            }
            
            (int, int) CmpTuple =>
                (UserId, Date);

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

            public override string ToString() => $"(UserId: {UserId}, Date: {Date})";
            
            
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

        public sealed class SelfTag : ITlTypeTag, IEquatable<SelfTag>, IComparable<SelfTag>, IComparable
        {
            internal const uint TypeNumber = 0xa3289a6d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            public readonly int InviterId;
            public readonly int Date;
            
            public SelfTag(
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

            public bool Equals(SelfTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SelfTag x && Equals(x);
            public static bool operator ==(SelfTag x, SelfTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SelfTag x, SelfTag y) => !(x == y);

            public int CompareTo(SelfTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SelfTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SelfTag x, SelfTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SelfTag x, SelfTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SelfTag x, SelfTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SelfTag x, SelfTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, InviterId: {InviterId}, Date: {Date})";
            
            
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

        public sealed class CreatorTag : ITlTypeTag, IEquatable<CreatorTag>, IComparable<CreatorTag>, IComparable
        {
            internal const uint TypeNumber = 0xe3e2e1f9;
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
            internal const uint TypeNumber = 0xa82fa898;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool CanEdit;
            public readonly int UserId;
            public readonly int InviterId;
            public readonly int PromotedBy;
            public readonly int Date;
            public readonly T.ChannelAdminRights AdminRights;
            
            public AdminTag(
                bool canEdit,
                int userId,
                int inviterId,
                int promotedBy,
                int date,
                Some<T.ChannelAdminRights> adminRights
            ) {
                CanEdit = canEdit;
                UserId = userId;
                InviterId = inviterId;
                PromotedBy = promotedBy;
                Date = date;
                AdminRights = adminRights;
            }
            
            (bool, int, int, int, int, T.ChannelAdminRights) CmpTuple =>
                (CanEdit, UserId, InviterId, PromotedBy, Date, AdminRights);

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

            public override string ToString() => $"(CanEdit: {CanEdit}, UserId: {UserId}, InviterId: {InviterId}, PromotedBy: {PromotedBy}, Date: {Date}, AdminRights: {AdminRights})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, CanEdit), bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(InviterId, bw, WriteInt);
                Write(PromotedBy, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(AdminRights, bw, WriteSerializable);
            }
            
            internal static AdminTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var canEdit = Read(br, ReadOption(flags, 0));
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var promotedBy = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var adminRights = Read(br, T.ChannelAdminRights.Deserialize);
                return new AdminTag(canEdit, userId, inviterId, promotedBy, date, adminRights);
            }
        }

        public sealed class BannedTag : ITlTypeTag, IEquatable<BannedTag>, IComparable<BannedTag>, IComparable
        {
            internal const uint TypeNumber = 0x222c1886;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Left;
            public readonly int UserId;
            public readonly int KickedBy;
            public readonly int Date;
            public readonly T.ChannelBannedRights BannedRights;
            
            public BannedTag(
                bool left,
                int userId,
                int kickedBy,
                int date,
                Some<T.ChannelBannedRights> bannedRights
            ) {
                Left = left;
                UserId = userId;
                KickedBy = kickedBy;
                Date = date;
                BannedRights = bannedRights;
            }
            
            (bool, int, int, int, T.ChannelBannedRights) CmpTuple =>
                (Left, UserId, KickedBy, Date, BannedRights);

            public bool Equals(BannedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BannedTag x && Equals(x);
            public static bool operator ==(BannedTag x, BannedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BannedTag x, BannedTag y) => !(x == y);

            public int CompareTo(BannedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BannedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BannedTag x, BannedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BannedTag x, BannedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BannedTag x, BannedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BannedTag x, BannedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Left: {Left}, UserId: {UserId}, KickedBy: {KickedBy}, Date: {Date}, BannedRights: {BannedRights})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Left), bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(KickedBy, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(BannedRights, bw, WriteSerializable);
            }
            
            internal static BannedTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var left = Read(br, ReadOption(flags, 0));
                var userId = Read(br, ReadInt);
                var kickedBy = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var bannedRights = Read(br, T.ChannelBannedRights.Deserialize);
                return new BannedTag(left, userId, kickedBy, date, bannedRights);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelParticipant(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipant(Tag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(SelfTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(CreatorTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(AdminTag tag) => new ChannelParticipant(tag);
        public static explicit operator ChannelParticipant(BannedTag tag) => new ChannelParticipant(tag);

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
                case CreatorTag.TypeNumber: return (ChannelParticipant) CreatorTag.DeserializeTag(br);
                case AdminTag.TypeNumber: return (ChannelParticipant) AdminTag.DeserializeTag(br);
                case BannedTag.TypeNumber: return (ChannelParticipant) BannedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, SelfTag.TypeNumber, CreatorTag.TypeNumber, AdminTag.TypeNumber, BannedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SelfTag, T> selfTag = null,
            Func<CreatorTag, T> creatorTag = null,
            Func<AdminTag, T> adminTag = null,
            Func<BannedTag, T> bannedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SelfTag x when selfTag != null: return selfTag(x);
                case CreatorTag x when creatorTag != null: return creatorTag(x);
                case AdminTag x when adminTag != null: return adminTag(x);
                case BannedTag x when bannedTag != null: return bannedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SelfTag, T> selfTag,
            Func<CreatorTag, T> creatorTag,
            Func<AdminTag, T> adminTag,
            Func<BannedTag, T> bannedTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            selfTag ?? throw new ArgumentNullException(nameof(selfTag)),
            creatorTag ?? throw new ArgumentNullException(nameof(creatorTag)),
            adminTag ?? throw new ArgumentNullException(nameof(adminTag)),
            bannedTag ?? throw new ArgumentNullException(nameof(bannedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SelfTag _: return 1;
                case CreatorTag _: return 2;
                case AdminTag _: return 3;
                case BannedTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChannelParticipant other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelParticipant x && Equals(x);
        public static bool operator ==(ChannelParticipant x, ChannelParticipant y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelParticipant x, ChannelParticipant y) => !(x == y);

        public int CompareTo(ChannelParticipant other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelParticipant.{_tag.GetType().Name}{_tag}";
    }
}