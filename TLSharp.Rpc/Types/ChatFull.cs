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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2e02a614;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Id { get; }
            public T.ChatParticipants Participants { get; }
            public T.Photo ChatPhoto { get; }
            public T.PeerNotifySettings NotifySettings { get; }
            public T.ExportedChatInvite ExportedInvite { get; }
            public Arr<T.BotInfo> BotInfo { get; }
            
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

        public sealed class ChannelTag : Record<ChannelTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc3d5512f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool CanViewParticipants { get; }
            public bool CanSetUsername { get; }
            public int Id { get; }
            public string About { get; }
            public Option<int> ParticipantsCount { get; }
            public Option<int> AdminsCount { get; }
            public Option<int> KickedCount { get; }
            public int ReadInboxMaxId { get; }
            public int ReadOutboxMaxId { get; }
            public int UnreadCount { get; }
            public T.Photo ChatPhoto { get; }
            public T.PeerNotifySettings NotifySettings { get; }
            public T.ExportedChatInvite ExportedInvite { get; }
            public Arr<T.BotInfo> BotInfo { get; }
            public Option<int> MigratedFromChatId { get; }
            public Option<int> MigratedFromMaxId { get; }
            public Option<int> PinnedMsgId { get; }
            
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

        public bool Equals(ChatFull other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChatFull x && Equals(x);
        public static bool operator ==(ChatFull a, ChatFull b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChatFull a, ChatFull b) => !(a == b);

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

        public int CompareTo(ChatFull other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChatFull x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatFull a, ChatFull b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChatFull a, ChatFull b) => a.CompareTo(b) < 0;
        public static bool operator >(ChatFull a, ChatFull b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChatFull a, ChatFull b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}