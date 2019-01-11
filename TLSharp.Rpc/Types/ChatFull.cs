using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChatFull : ITlType, IEquatable<ChatFull>, IComparable<ChatFull>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x2e02a614;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            public readonly T.ChatParticipants Participants;
            public readonly T.Photo ChatPhoto;
            public readonly T.PeerNotifySettings NotifySettings;
            public readonly T.ExportedChatInvite ExportedInvite;
            public readonly Arr<T.BotInfo> BotInfo;
            
            public Tag(
                int id,
                Some<T.ChatParticipants> participants,
                Some<T.Photo> chatPhoto,
                Some<T.PeerNotifySettings> notifySettings,
                Some<T.ExportedChatInvite> exportedInvite,
                Some<Arr<T.BotInfo>> botInfo
            ) {
                Id = id;
                Participants = participants;
                ChatPhoto = chatPhoto;
                NotifySettings = notifySettings;
                ExportedInvite = exportedInvite;
                BotInfo = botInfo;
            }
            
            (int, T.ChatParticipants, T.Photo, T.PeerNotifySettings, T.ExportedChatInvite, Arr<T.BotInfo>) CmpTuple =>
                (Id, Participants, ChatPhoto, NotifySettings, ExportedInvite, BotInfo);

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

            public override string ToString() => $"(Id: {Id}, Participants: {Participants}, ChatPhoto: {ChatPhoto}, NotifySettings: {NotifySettings}, ExportedInvite: {ExportedInvite}, BotInfo: {BotInfo})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(Participants, bw, WriteSerializable);
                Write(ChatPhoto, bw, WriteSerializable);
                Write(NotifySettings, bw, WriteSerializable);
                Write(ExportedInvite, bw, WriteSerializable);
                Write(BotInfo, bw, WriteVector<T.BotInfo>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var participants = Read(br, T.ChatParticipants.Deserialize);
                var chatPhoto = Read(br, T.Photo.Deserialize);
                var notifySettings = Read(br, T.PeerNotifySettings.Deserialize);
                var exportedInvite = Read(br, T.ExportedChatInvite.Deserialize);
                var botInfo = Read(br, ReadVector(T.BotInfo.Deserialize));
                return new Tag(id, participants, chatPhoto, notifySettings, exportedInvite, botInfo);
            }
        }

        public sealed class ChannelTag : ITlTypeTag, IEquatable<ChannelTag>, IComparable<ChannelTag>, IComparable
        {
            internal const uint TypeNumber = 0xc3d5512f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool CanViewParticipants;
            public readonly bool CanSetUsername;
            public readonly int Id;
            public readonly string About;
            public readonly Option<int> ParticipantsCount;
            public readonly Option<int> AdminsCount;
            public readonly Option<int> KickedCount;
            public readonly int ReadInboxMaxId;
            public readonly int ReadOutboxMaxId;
            public readonly int UnreadCount;
            public readonly T.Photo ChatPhoto;
            public readonly T.PeerNotifySettings NotifySettings;
            public readonly T.ExportedChatInvite ExportedInvite;
            public readonly Arr<T.BotInfo> BotInfo;
            public readonly Option<int> MigratedFromChatId;
            public readonly Option<int> MigratedFromMaxId;
            public readonly Option<int> PinnedMsgId;
            
            public ChannelTag(
                bool canViewParticipants,
                bool canSetUsername,
                int id,
                Some<string> about,
                Option<int> participantsCount,
                Option<int> adminsCount,
                Option<int> kickedCount,
                int readInboxMaxId,
                int readOutboxMaxId,
                int unreadCount,
                Some<T.Photo> chatPhoto,
                Some<T.PeerNotifySettings> notifySettings,
                Some<T.ExportedChatInvite> exportedInvite,
                Some<Arr<T.BotInfo>> botInfo,
                Option<int> migratedFromChatId,
                Option<int> migratedFromMaxId,
                Option<int> pinnedMsgId
            ) {
                CanViewParticipants = canViewParticipants;
                CanSetUsername = canSetUsername;
                Id = id;
                About = about;
                ParticipantsCount = participantsCount;
                AdminsCount = adminsCount;
                KickedCount = kickedCount;
                ReadInboxMaxId = readInboxMaxId;
                ReadOutboxMaxId = readOutboxMaxId;
                UnreadCount = unreadCount;
                ChatPhoto = chatPhoto;
                NotifySettings = notifySettings;
                ExportedInvite = exportedInvite;
                BotInfo = botInfo;
                MigratedFromChatId = migratedFromChatId;
                MigratedFromMaxId = migratedFromMaxId;
                PinnedMsgId = pinnedMsgId;
            }
            
            (bool, bool, int, string, Option<int>, Option<int>, Option<int>, int, int, int, T.Photo, T.PeerNotifySettings, T.ExportedChatInvite, Arr<T.BotInfo>, Option<int>, Option<int>, Option<int>) CmpTuple =>
                (CanViewParticipants, CanSetUsername, Id, About, ParticipantsCount, AdminsCount, KickedCount, ReadInboxMaxId, ReadOutboxMaxId, UnreadCount, ChatPhoto, NotifySettings, ExportedInvite, BotInfo, MigratedFromChatId, MigratedFromMaxId, PinnedMsgId);

            public bool Equals(ChannelTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChannelTag x && Equals(x);
            public static bool operator ==(ChannelTag x, ChannelTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelTag x, ChannelTag y) => !(x == y);

            public int CompareTo(ChannelTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChannelTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelTag x, ChannelTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelTag x, ChannelTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelTag x, ChannelTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelTag x, ChannelTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(CanViewParticipants: {CanViewParticipants}, CanSetUsername: {CanSetUsername}, Id: {Id}, About: {About}, ParticipantsCount: {ParticipantsCount}, AdminsCount: {AdminsCount}, KickedCount: {KickedCount}, ReadInboxMaxId: {ReadInboxMaxId}, ReadOutboxMaxId: {ReadOutboxMaxId}, UnreadCount: {UnreadCount}, ChatPhoto: {ChatPhoto}, NotifySettings: {NotifySettings}, ExportedInvite: {ExportedInvite}, BotInfo: {BotInfo}, MigratedFromChatId: {MigratedFromChatId}, MigratedFromMaxId: {MigratedFromMaxId}, PinnedMsgId: {PinnedMsgId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(3, CanViewParticipants) | MaskBit(6, CanSetUsername) | MaskBit(0, ParticipantsCount) | MaskBit(1, AdminsCount) | MaskBit(2, KickedCount) | MaskBit(4, MigratedFromChatId) | MaskBit(4, MigratedFromMaxId) | MaskBit(5, PinnedMsgId), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(About, bw, WriteString);
                Write(ParticipantsCount, bw, WriteOption<int>(WriteInt));
                Write(AdminsCount, bw, WriteOption<int>(WriteInt));
                Write(KickedCount, bw, WriteOption<int>(WriteInt));
                Write(ReadInboxMaxId, bw, WriteInt);
                Write(ReadOutboxMaxId, bw, WriteInt);
                Write(UnreadCount, bw, WriteInt);
                Write(ChatPhoto, bw, WriteSerializable);
                Write(NotifySettings, bw, WriteSerializable);
                Write(ExportedInvite, bw, WriteSerializable);
                Write(BotInfo, bw, WriteVector<T.BotInfo>(WriteSerializable));
                Write(MigratedFromChatId, bw, WriteOption<int>(WriteInt));
                Write(MigratedFromMaxId, bw, WriteOption<int>(WriteInt));
                Write(PinnedMsgId, bw, WriteOption<int>(WriteInt));
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var canViewParticipants = Read(br, ReadOption(flags, 3));
                var canSetUsername = Read(br, ReadOption(flags, 6));
                var id = Read(br, ReadInt);
                var about = Read(br, ReadString);
                var participantsCount = Read(br, ReadOption(flags, 0, ReadInt));
                var adminsCount = Read(br, ReadOption(flags, 1, ReadInt));
                var kickedCount = Read(br, ReadOption(flags, 2, ReadInt));
                var readInboxMaxId = Read(br, ReadInt);
                var readOutboxMaxId = Read(br, ReadInt);
                var unreadCount = Read(br, ReadInt);
                var chatPhoto = Read(br, T.Photo.Deserialize);
                var notifySettings = Read(br, T.PeerNotifySettings.Deserialize);
                var exportedInvite = Read(br, T.ExportedChatInvite.Deserialize);
                var botInfo = Read(br, ReadVector(T.BotInfo.Deserialize));
                var migratedFromChatId = Read(br, ReadOption(flags, 4, ReadInt));
                var migratedFromMaxId = Read(br, ReadOption(flags, 4, ReadInt));
                var pinnedMsgId = Read(br, ReadOption(flags, 5, ReadInt));
                return new ChannelTag(canViewParticipants, canSetUsername, id, about, participantsCount, adminsCount, kickedCount, readInboxMaxId, readOutboxMaxId, unreadCount, chatPhoto, notifySettings, exportedInvite, botInfo, migratedFromChatId, migratedFromMaxId, pinnedMsgId);
            }
        }

        readonly ITlTypeTag _tag;
        ChatFull(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChatFull(Tag tag) => new ChatFull(tag);
        public static explicit operator ChatFull(ChannelTag tag) => new ChatFull(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChatFull Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChatFull) Tag.DeserializeTag(br);
                case ChannelTag.TypeNumber: return (ChatFull) ChannelTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, ChannelTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<ChannelTag, T> channelTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case ChannelTag x when channelTag != null: return channelTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<ChannelTag, T> channelTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case ChannelTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChatFull other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChatFull x && Equals(x);
        public static bool operator ==(ChatFull x, ChatFull y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChatFull x, ChatFull y) => !(x == y);

        public int CompareTo(ChatFull other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChatFull x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatFull x, ChatFull y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChatFull x, ChatFull y) => x.CompareTo(y) < 0;
        public static bool operator >(ChatFull x, ChatFull y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChatFull x, ChatFull y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChatFull.{_tag.GetType().Name}{_tag}";
    }
}