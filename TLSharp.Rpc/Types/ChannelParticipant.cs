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
            
            public int UserId { get; }
            public int Date { get; }
            
            public Tag(
                int userId,
                int date
            ) {
                UserId = userId;
                Date = date;
            }
            
            (int, int) CmpTuple =>
                (UserId, Date);

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
            
            (int, int, int) CmpTuple =>
                (UserId, InviterId, Date);

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

        public sealed class ModeratorTag : ITlTypeTag, IEquatable<ModeratorTag>, IComparable<ModeratorTag>, IComparable
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
            
            (int, int, int) CmpTuple =>
                (UserId, InviterId, Date);

            public bool Equals(ModeratorTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ModeratorTag x && Equals(x);
            public static bool operator ==(ModeratorTag x, ModeratorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ModeratorTag x, ModeratorTag y) => !(x == y);

            public int CompareTo(ModeratorTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ModeratorTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ModeratorTag x, ModeratorTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ModeratorTag x, ModeratorTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ModeratorTag x, ModeratorTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ModeratorTag x, ModeratorTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, InviterId: {InviterId}, Date: {Date})";
            
            
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

        public sealed class EditorTag : ITlTypeTag, IEquatable<EditorTag>, IComparable<EditorTag>, IComparable
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
            
            (int, int, int) CmpTuple =>
                (UserId, InviterId, Date);

            public bool Equals(EditorTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EditorTag x && Equals(x);
            public static bool operator ==(EditorTag x, EditorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EditorTag x, EditorTag y) => !(x == y);

            public int CompareTo(EditorTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EditorTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EditorTag x, EditorTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EditorTag x, EditorTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EditorTag x, EditorTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EditorTag x, EditorTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, InviterId: {InviterId}, Date: {Date})";
            
            
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

        public sealed class KickedTag : ITlTypeTag, IEquatable<KickedTag>, IComparable<KickedTag>, IComparable
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
            
            (int, int, int) CmpTuple =>
                (UserId, KickedBy, Date);

            public bool Equals(KickedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is KickedTag x && Equals(x);
            public static bool operator ==(KickedTag x, KickedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(KickedTag x, KickedTag y) => !(x == y);

            public int CompareTo(KickedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is KickedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(KickedTag x, KickedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(KickedTag x, KickedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(KickedTag x, KickedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(KickedTag x, KickedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, KickedBy: {KickedBy}, Date: {Date})";
            
            
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

        public sealed class CreatorTag : ITlTypeTag, IEquatable<CreatorTag>, IComparable<CreatorTag>, IComparable
        {
            internal const uint TypeNumber = 0xe3e2e1f9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            
            public CreatorTag(
                int userId
            ) {
                UserId = userId;
            }
            
            int CmpTuple =>
                UserId;

            public bool Equals(CreatorTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CreatorTag x && Equals(x);
            public static bool operator ==(CreatorTag x, CreatorTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CreatorTag x, CreatorTag y) => !(x == y);

            public int CompareTo(CreatorTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
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

        public bool Equals(ChannelParticipant other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ChannelParticipant x && Equals(x);
        public static bool operator ==(ChannelParticipant x, ChannelParticipant y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelParticipant x, ChannelParticipant y) => !(x == y);

        public int CompareTo(ChannelParticipant other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelParticipant.{_tag.GetType().Name}{_tag}";
    }
}