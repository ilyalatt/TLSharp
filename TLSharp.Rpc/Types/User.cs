using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class User : ITlType, IEquatable<User>, IComparable<User>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x200250ba;
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
            internal const uint TypeNumber = 0x2e13f4c3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Self { get; }
            public bool Contact { get; }
            public bool MutualContact { get; }
            public bool Deleted { get; }
            public bool Bot { get; }
            public bool BotChatHistory { get; }
            public bool BotNochats { get; }
            public bool Verified { get; }
            public bool Restricted { get; }
            public bool Min { get; }
            public bool BotInlineGeo { get; }
            public int Id { get; }
            public Option<long> AccessHash { get; }
            public Option<string> FirstName { get; }
            public Option<string> LastName { get; }
            public Option<string> Username { get; }
            public Option<string> Phone { get; }
            public Option<T.UserProfilePhoto> Photo { get; }
            public Option<T.UserStatus> Status { get; }
            public Option<int> BotInfoVersion { get; }
            public Option<string> RestrictionReason { get; }
            public Option<string> BotInlinePlaceholder { get; }
            public Option<string> LangCode { get; }
            
            public Tag(
                bool self,
                bool contact,
                bool mutualContact,
                bool deleted,
                bool bot,
                bool botChatHistory,
                bool botNochats,
                bool verified,
                bool restricted,
                bool min,
                bool botInlineGeo,
                int id,
                Option<long> accessHash,
                Option<string> firstName,
                Option<string> lastName,
                Option<string> username,
                Option<string> phone,
                Option<T.UserProfilePhoto> photo,
                Option<T.UserStatus> status,
                Option<int> botInfoVersion,
                Option<string> restrictionReason,
                Option<string> botInlinePlaceholder,
                Option<string> langCode
            ) {
                Self = self;
                Contact = contact;
                MutualContact = mutualContact;
                Deleted = deleted;
                Bot = bot;
                BotChatHistory = botChatHistory;
                BotNochats = botNochats;
                Verified = verified;
                Restricted = restricted;
                Min = min;
                BotInlineGeo = botInlineGeo;
                Id = id;
                AccessHash = accessHash;
                FirstName = firstName;
                LastName = lastName;
                Username = username;
                Phone = phone;
                Photo = photo;
                Status = status;
                BotInfoVersion = botInfoVersion;
                RestrictionReason = restrictionReason;
                BotInlinePlaceholder = botInlinePlaceholder;
                LangCode = langCode;
            }
            
            (bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, int, Option<long>, Option<string>, Option<string>, Option<string>, Option<string>, Option<T.UserProfilePhoto>, Option<T.UserStatus>, Option<int>, Option<string>, Option<string>, Option<string>) CmpTuple =>
                (Self, Contact, MutualContact, Deleted, Bot, BotChatHistory, BotNochats, Verified, Restricted, Min, BotInlineGeo, Id, AccessHash, FirstName, LastName, Username, Phone, Photo, Status, BotInfoVersion, RestrictionReason, BotInlinePlaceholder, LangCode);

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

            public override string ToString() => $"(Self: {Self}, Contact: {Contact}, MutualContact: {MutualContact}, Deleted: {Deleted}, Bot: {Bot}, BotChatHistory: {BotChatHistory}, BotNochats: {BotNochats}, Verified: {Verified}, Restricted: {Restricted}, Min: {Min}, BotInlineGeo: {BotInlineGeo}, Id: {Id}, AccessHash: {AccessHash}, FirstName: {FirstName}, LastName: {LastName}, Username: {Username}, Phone: {Phone}, Photo: {Photo}, Status: {Status}, BotInfoVersion: {BotInfoVersion}, RestrictionReason: {RestrictionReason}, BotInlinePlaceholder: {BotInlinePlaceholder}, LangCode: {LangCode})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(10, Self) | MaskBit(11, Contact) | MaskBit(12, MutualContact) | MaskBit(13, Deleted) | MaskBit(14, Bot) | MaskBit(15, BotChatHistory) | MaskBit(16, BotNochats) | MaskBit(17, Verified) | MaskBit(18, Restricted) | MaskBit(20, Min) | MaskBit(21, BotInlineGeo) | MaskBit(0, AccessHash) | MaskBit(1, FirstName) | MaskBit(2, LastName) | MaskBit(3, Username) | MaskBit(4, Phone) | MaskBit(5, Photo) | MaskBit(6, Status) | MaskBit(14, BotInfoVersion) | MaskBit(18, RestrictionReason) | MaskBit(19, BotInlinePlaceholder) | MaskBit(22, LangCode), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(AccessHash, bw, WriteOption<long>(WriteLong));
                Write(FirstName, bw, WriteOption<string>(WriteString));
                Write(LastName, bw, WriteOption<string>(WriteString));
                Write(Username, bw, WriteOption<string>(WriteString));
                Write(Phone, bw, WriteOption<string>(WriteString));
                Write(Photo, bw, WriteOption<T.UserProfilePhoto>(WriteSerializable));
                Write(Status, bw, WriteOption<T.UserStatus>(WriteSerializable));
                Write(BotInfoVersion, bw, WriteOption<int>(WriteInt));
                Write(RestrictionReason, bw, WriteOption<string>(WriteString));
                Write(BotInlinePlaceholder, bw, WriteOption<string>(WriteString));
                Write(LangCode, bw, WriteOption<string>(WriteString));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var self = Read(br, ReadOption(flags, 10));
                var contact = Read(br, ReadOption(flags, 11));
                var mutualContact = Read(br, ReadOption(flags, 12));
                var deleted = Read(br, ReadOption(flags, 13));
                var bot = Read(br, ReadOption(flags, 14));
                var botChatHistory = Read(br, ReadOption(flags, 15));
                var botNochats = Read(br, ReadOption(flags, 16));
                var verified = Read(br, ReadOption(flags, 17));
                var restricted = Read(br, ReadOption(flags, 18));
                var min = Read(br, ReadOption(flags, 20));
                var botInlineGeo = Read(br, ReadOption(flags, 21));
                var id = Read(br, ReadInt);
                var accessHash = Read(br, ReadOption(flags, 0, ReadLong));
                var firstName = Read(br, ReadOption(flags, 1, ReadString));
                var lastName = Read(br, ReadOption(flags, 2, ReadString));
                var username = Read(br, ReadOption(flags, 3, ReadString));
                var phone = Read(br, ReadOption(flags, 4, ReadString));
                var photo = Read(br, ReadOption(flags, 5, T.UserProfilePhoto.Deserialize));
                var status = Read(br, ReadOption(flags, 6, T.UserStatus.Deserialize));
                var botInfoVersion = Read(br, ReadOption(flags, 14, ReadInt));
                var restrictionReason = Read(br, ReadOption(flags, 18, ReadString));
                var botInlinePlaceholder = Read(br, ReadOption(flags, 19, ReadString));
                var langCode = Read(br, ReadOption(flags, 22, ReadString));
                return new Tag(self, contact, mutualContact, deleted, bot, botChatHistory, botNochats, verified, restricted, min, botInlineGeo, id, accessHash, firstName, lastName, username, phone, photo, status, botInfoVersion, restrictionReason, botInlinePlaceholder, langCode);
            }
        }

        readonly ITlTypeTag _tag;
        User(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator User(EmptyTag tag) => new User(tag);
        public static explicit operator User(Tag tag) => new User(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static User Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (User) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (User) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(User other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is User x && Equals(x);
        public static bool operator ==(User x, User y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(User x, User y) => !(x == y);

        public int CompareTo(User other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is User x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(User x, User y) => x.CompareTo(y) <= 0;
        public static bool operator <(User x, User y) => x.CompareTo(y) < 0;
        public static bool operator >(User x, User y) => x.CompareTo(y) > 0;
        public static bool operator >=(User x, User y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"User.{_tag.GetType().Name}{_tag}";
    }
}