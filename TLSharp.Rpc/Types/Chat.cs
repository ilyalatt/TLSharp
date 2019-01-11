using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Chat : ITlType, IEquatable<Chat>, IComparable<Chat>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x9ba2d800;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Id { get; }
            
            public EmptyTag(
                int id
            ) {
                Id = id;
            }
            
            int CmpTuple =>
                Id;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                return new EmptyTag(id);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xd91cdd54;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Creator { get; }
            public bool Kicked { get; }
            public bool Left { get; }
            public bool AdminsEnabled { get; }
            public bool Admin { get; }
            public bool Deactivated { get; }
            public int Id { get; }
            public string Title { get; }
            public T.ChatPhoto Photo { get; }
            public int ParticipantsCount { get; }
            public int Date { get; }
            public int Version { get; }
            public Option<T.InputChannel> MigratedTo { get; }
            
            public Tag(
                bool creator,
                bool kicked,
                bool left,
                bool adminsEnabled,
                bool admin,
                bool deactivated,
                int id,
                Some<string> title,
                Some<T.ChatPhoto> photo,
                int participantsCount,
                int date,
                int version,
                Option<T.InputChannel> migratedTo
            ) {
                Creator = creator;
                Kicked = kicked;
                Left = left;
                AdminsEnabled = adminsEnabled;
                Admin = admin;
                Deactivated = deactivated;
                Id = id;
                Title = title;
                Photo = photo;
                ParticipantsCount = participantsCount;
                Date = date;
                Version = version;
                MigratedTo = migratedTo;
            }
            
            (bool, bool, bool, bool, bool, bool, int, string, T.ChatPhoto, int, int, int, Option<T.InputChannel>) CmpTuple =>
                (Creator, Kicked, Left, AdminsEnabled, Admin, Deactivated, Id, Title, Photo, ParticipantsCount, Date, Version, MigratedTo);

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

            public override string ToString() => $"(Creator: {Creator}, Kicked: {Kicked}, Left: {Left}, AdminsEnabled: {AdminsEnabled}, Admin: {Admin}, Deactivated: {Deactivated}, Id: {Id}, Title: {Title}, Photo: {Photo}, ParticipantsCount: {ParticipantsCount}, Date: {Date}, Version: {Version}, MigratedTo: {MigratedTo})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Creator) | MaskBit(1, Kicked) | MaskBit(2, Left) | MaskBit(3, AdminsEnabled) | MaskBit(4, Admin) | MaskBit(5, Deactivated) | MaskBit(6, MigratedTo), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(Title, bw, WriteString);
                Write(Photo, bw, WriteSerializable);
                Write(ParticipantsCount, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Version, bw, WriteInt);
                Write(MigratedTo, bw, WriteOption<T.InputChannel>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var creator = Read(br, ReadOption(flags, 0));
                var kicked = Read(br, ReadOption(flags, 1));
                var left = Read(br, ReadOption(flags, 2));
                var adminsEnabled = Read(br, ReadOption(flags, 3));
                var admin = Read(br, ReadOption(flags, 4));
                var deactivated = Read(br, ReadOption(flags, 5));
                var id = Read(br, ReadInt);
                var title = Read(br, ReadString);
                var photo = Read(br, T.ChatPhoto.Deserialize);
                var participantsCount = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var version = Read(br, ReadInt);
                var migratedTo = Read(br, ReadOption(flags, 6, T.InputChannel.Deserialize));
                return new Tag(creator, kicked, left, adminsEnabled, admin, deactivated, id, title, photo, participantsCount, date, version, migratedTo);
            }
        }

        public sealed class ForbiddenTag : ITlTypeTag, IEquatable<ForbiddenTag>, IComparable<ForbiddenTag>, IComparable
        {
            internal const uint TypeNumber = 0x07328bdb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Id { get; }
            public string Title { get; }
            
            public ForbiddenTag(
                int id,
                Some<string> title
            ) {
                Id = id;
                Title = title;
            }
            
            (int, string) CmpTuple =>
                (Id, Title);

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

            public override string ToString() => $"(Id: {Id}, Title: {Title})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(Title, bw, WriteString);
            }
            
            internal static ForbiddenTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var title = Read(br, ReadString);
                return new ForbiddenTag(id, title);
            }
        }

        public sealed class ChannelTag : ITlTypeTag, IEquatable<ChannelTag>, IComparable<ChannelTag>, IComparable
        {
            internal const uint TypeNumber = 0xa14dca52;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Creator { get; }
            public bool Kicked { get; }
            public bool Left { get; }
            public bool Editor { get; }
            public bool Moderator { get; }
            public bool Broadcast { get; }
            public bool Verified { get; }
            public bool Megagroup { get; }
            public bool Restricted { get; }
            public bool Democracy { get; }
            public bool Signatures { get; }
            public bool Min { get; }
            public int Id { get; }
            public Option<long> AccessHash { get; }
            public string Title { get; }
            public Option<string> Username { get; }
            public T.ChatPhoto Photo { get; }
            public int Date { get; }
            public int Version { get; }
            public Option<string> RestrictionReason { get; }
            
            public ChannelTag(
                bool creator,
                bool kicked,
                bool left,
                bool editor,
                bool moderator,
                bool broadcast,
                bool verified,
                bool megagroup,
                bool restricted,
                bool democracy,
                bool signatures,
                bool min,
                int id,
                Option<long> accessHash,
                Some<string> title,
                Option<string> username,
                Some<T.ChatPhoto> photo,
                int date,
                int version,
                Option<string> restrictionReason
            ) {
                Creator = creator;
                Kicked = kicked;
                Left = left;
                Editor = editor;
                Moderator = moderator;
                Broadcast = broadcast;
                Verified = verified;
                Megagroup = megagroup;
                Restricted = restricted;
                Democracy = democracy;
                Signatures = signatures;
                Min = min;
                Id = id;
                AccessHash = accessHash;
                Title = title;
                Username = username;
                Photo = photo;
                Date = date;
                Version = version;
                RestrictionReason = restrictionReason;
            }
            
            (bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, int, Option<long>, string, Option<string>, T.ChatPhoto, int, int, Option<string>) CmpTuple =>
                (Creator, Kicked, Left, Editor, Moderator, Broadcast, Verified, Megagroup, Restricted, Democracy, Signatures, Min, Id, AccessHash, Title, Username, Photo, Date, Version, RestrictionReason);

            public bool Equals(ChannelTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelTag x && Equals(x);
            public static bool operator ==(ChannelTag x, ChannelTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelTag x, ChannelTag y) => !(x == y);

            public int CompareTo(ChannelTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelTag x, ChannelTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelTag x, ChannelTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelTag x, ChannelTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelTag x, ChannelTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Creator: {Creator}, Kicked: {Kicked}, Left: {Left}, Editor: {Editor}, Moderator: {Moderator}, Broadcast: {Broadcast}, Verified: {Verified}, Megagroup: {Megagroup}, Restricted: {Restricted}, Democracy: {Democracy}, Signatures: {Signatures}, Min: {Min}, Id: {Id}, AccessHash: {AccessHash}, Title: {Title}, Username: {Username}, Photo: {Photo}, Date: {Date}, Version: {Version}, RestrictionReason: {RestrictionReason})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Creator) | MaskBit(1, Kicked) | MaskBit(2, Left) | MaskBit(3, Editor) | MaskBit(4, Moderator) | MaskBit(5, Broadcast) | MaskBit(7, Verified) | MaskBit(8, Megagroup) | MaskBit(9, Restricted) | MaskBit(10, Democracy) | MaskBit(11, Signatures) | MaskBit(12, Min) | MaskBit(13, AccessHash) | MaskBit(6, Username) | MaskBit(9, RestrictionReason), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(AccessHash, bw, WriteOption<long>(WriteLong));
                Write(Title, bw, WriteString);
                Write(Username, bw, WriteOption<string>(WriteString));
                Write(Photo, bw, WriteSerializable);
                Write(Date, bw, WriteInt);
                Write(Version, bw, WriteInt);
                Write(RestrictionReason, bw, WriteOption<string>(WriteString));
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var creator = Read(br, ReadOption(flags, 0));
                var kicked = Read(br, ReadOption(flags, 1));
                var left = Read(br, ReadOption(flags, 2));
                var editor = Read(br, ReadOption(flags, 3));
                var moderator = Read(br, ReadOption(flags, 4));
                var broadcast = Read(br, ReadOption(flags, 5));
                var verified = Read(br, ReadOption(flags, 7));
                var megagroup = Read(br, ReadOption(flags, 8));
                var restricted = Read(br, ReadOption(flags, 9));
                var democracy = Read(br, ReadOption(flags, 10));
                var signatures = Read(br, ReadOption(flags, 11));
                var min = Read(br, ReadOption(flags, 12));
                var id = Read(br, ReadInt);
                var accessHash = Read(br, ReadOption(flags, 13, ReadLong));
                var title = Read(br, ReadString);
                var username = Read(br, ReadOption(flags, 6, ReadString));
                var photo = Read(br, T.ChatPhoto.Deserialize);
                var date = Read(br, ReadInt);
                var version = Read(br, ReadInt);
                var restrictionReason = Read(br, ReadOption(flags, 9, ReadString));
                return new ChannelTag(creator, kicked, left, editor, moderator, broadcast, verified, megagroup, restricted, democracy, signatures, min, id, accessHash, title, username, photo, date, version, restrictionReason);
            }
        }

        public sealed class ChannelForbiddenTag : ITlTypeTag, IEquatable<ChannelForbiddenTag>, IComparable<ChannelForbiddenTag>, IComparable
        {
            internal const uint TypeNumber = 0x8537784f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Broadcast { get; }
            public bool Megagroup { get; }
            public int Id { get; }
            public long AccessHash { get; }
            public string Title { get; }
            
            public ChannelForbiddenTag(
                bool broadcast,
                bool megagroup,
                int id,
                long accessHash,
                Some<string> title
            ) {
                Broadcast = broadcast;
                Megagroup = megagroup;
                Id = id;
                AccessHash = accessHash;
                Title = title;
            }
            
            (bool, bool, int, long, string) CmpTuple =>
                (Broadcast, Megagroup, Id, AccessHash, Title);

            public bool Equals(ChannelForbiddenTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelForbiddenTag x && Equals(x);
            public static bool operator ==(ChannelForbiddenTag x, ChannelForbiddenTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelForbiddenTag x, ChannelForbiddenTag y) => !(x == y);

            public int CompareTo(ChannelForbiddenTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelForbiddenTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelForbiddenTag x, ChannelForbiddenTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelForbiddenTag x, ChannelForbiddenTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelForbiddenTag x, ChannelForbiddenTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelForbiddenTag x, ChannelForbiddenTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Broadcast: {Broadcast}, Megagroup: {Megagroup}, Id: {Id}, AccessHash: {AccessHash}, Title: {Title})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(5, Broadcast) | MaskBit(8, Megagroup), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(AccessHash, bw, WriteLong);
                Write(Title, bw, WriteString);
            }
            
            internal static ChannelForbiddenTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var broadcast = Read(br, ReadOption(flags, 5));
                var megagroup = Read(br, ReadOption(flags, 8));
                var id = Read(br, ReadInt);
                var accessHash = Read(br, ReadLong);
                var title = Read(br, ReadString);
                return new ChannelForbiddenTag(broadcast, megagroup, id, accessHash, title);
            }
        }

        readonly ITlTypeTag _tag;
        Chat(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Chat(EmptyTag tag) => new Chat(tag);
        public static explicit operator Chat(Tag tag) => new Chat(tag);
        public static explicit operator Chat(ForbiddenTag tag) => new Chat(tag);
        public static explicit operator Chat(ChannelTag tag) => new Chat(tag);
        public static explicit operator Chat(ChannelForbiddenTag tag) => new Chat(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Chat Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (Chat) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (Chat) Tag.DeserializeTag(br);
                case ForbiddenTag.TypeNumber: return (Chat) ForbiddenTag.DeserializeTag(br);
                case ChannelTag.TypeNumber: return (Chat) ChannelTag.DeserializeTag(br);
                case ChannelForbiddenTag.TypeNumber: return (Chat) ChannelForbiddenTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber, ForbiddenTag.TypeNumber, ChannelTag.TypeNumber, ChannelForbiddenTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null,
            Func<ForbiddenTag, T> forbiddenTag = null,
            Func<ChannelTag, T> channelTag = null,
            Func<ChannelForbiddenTag, T> channelForbiddenTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                case ForbiddenTag x when forbiddenTag != null: return forbiddenTag(x);
                case ChannelTag x when channelTag != null: return channelTag(x);
                case ChannelForbiddenTag x when channelForbiddenTag != null: return channelForbiddenTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag,
            Func<ForbiddenTag, T> forbiddenTag,
            Func<ChannelTag, T> channelTag,
            Func<ChannelForbiddenTag, T> channelForbiddenTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            forbiddenTag ?? throw new ArgumentNullException(nameof(forbiddenTag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag)),
            channelForbiddenTag ?? throw new ArgumentNullException(nameof(channelForbiddenTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                case ForbiddenTag _: return 2;
                case ChannelTag _: return 3;
                case ChannelForbiddenTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Chat other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Chat x && Equals(x);
        public static bool operator ==(Chat x, Chat y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Chat x, Chat y) => !(x == y);

        public int CompareTo(Chat other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Chat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Chat x, Chat y) => x.CompareTo(y) <= 0;
        public static bool operator <(Chat x, Chat y) => x.CompareTo(y) < 0;
        public static bool operator >(Chat x, Chat y) => x.CompareTo(y) > 0;
        public static bool operator >=(Chat x, Chat y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Chat.{_tag.GetType().Name}{_tag}";
    }
}