using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Update : ITlType, IEquatable<Update>, IComparable<Update>, IComparable
    {
        public sealed class NewMessageTag : Record<NewMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x1f2b0afd;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Message Message { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public NewMessageTag(
                Some<T.Message> message,
                int pts,
                int ptsCount
            ) {
                Message = message;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static NewMessageTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.Message.Deserialize);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new NewMessageTag(message, pts, ptsCount);
            }
        }

        public sealed class MessageIdTag : Record<MessageIdTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x4e90bfd6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Id { get; }
            public long RandomId { get; }
            
            public MessageIdTag(
                int id,
                long randomId
            ) {
                Id = id;
                RandomId = randomId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(RandomId, bw, WriteLong);
            }
            
            internal static MessageIdTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var randomId = Read(br, ReadLong);
                return new MessageIdTag(id, randomId);
            }
        }

        public sealed class DeleteMessagesTag : Record<DeleteMessagesTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa20db0e5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Messages { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public DeleteMessagesTag(
                Some<Arr<int>> messages,
                int pts,
                int ptsCount
            ) {
                Messages = messages;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Messages, bw, WriteVector<int>(WriteInt));
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static DeleteMessagesTag DeserializeTag(BinaryReader br)
            {
                var messages = Read(br, ReadVector(ReadInt));
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new DeleteMessagesTag(messages, pts, ptsCount);
            }
        }

        public sealed class UserTypingTag : Record<UserTypingTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x5c486927;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public T.SendMessageAction Action { get; }
            
            public UserTypingTag(
                int userId,
                Some<T.SendMessageAction> action
            ) {
                UserId = userId;
                Action = action;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Action, bw, WriteSerializable);
            }
            
            internal static UserTypingTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var action = Read(br, T.SendMessageAction.Deserialize);
                return new UserTypingTag(userId, action);
            }
        }

        public sealed class ChatUserTypingTag : Record<ChatUserTypingTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9a65ea1f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public int UserId { get; }
            public T.SendMessageAction Action { get; }
            
            public ChatUserTypingTag(
                int chatId,
                int userId,
                Some<T.SendMessageAction> action
            ) {
                ChatId = chatId;
                UserId = userId;
                Action = action;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(Action, bw, WriteSerializable);
            }
            
            internal static ChatUserTypingTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var action = Read(br, T.SendMessageAction.Deserialize);
                return new ChatUserTypingTag(chatId, userId, action);
            }
        }

        public sealed class ChatParticipantsTag : Record<ChatParticipantsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x07761198;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.ChatParticipants Participants { get; }
            
            public ChatParticipantsTag(
                Some<T.ChatParticipants> participants
            ) {
                Participants = participants;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Participants, bw, WriteSerializable);
            }
            
            internal static ChatParticipantsTag DeserializeTag(BinaryReader br)
            {
                var participants = Read(br, T.ChatParticipants.Deserialize);
                return new ChatParticipantsTag(participants);
            }
        }

        public sealed class UserStatusTag : Record<UserStatusTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x1bfbd823;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public T.UserStatus Status { get; }
            
            public UserStatusTag(
                int userId,
                Some<T.UserStatus> status
            ) {
                UserId = userId;
                Status = status;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Status, bw, WriteSerializable);
            }
            
            internal static UserStatusTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var status = Read(br, T.UserStatus.Deserialize);
                return new UserStatusTag(userId, status);
            }
        }

        public sealed class UserNameTag : Record<UserNameTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa7332b73;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public string Username { get; }
            
            public UserNameTag(
                int userId,
                Some<string> firstName,
                Some<string> lastName,
                Some<string> username
            ) {
                UserId = userId;
                FirstName = firstName;
                LastName = lastName;
                Username = username;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(FirstName, bw, WriteString);
                Write(LastName, bw, WriteString);
                Write(Username, bw, WriteString);
            }
            
            internal static UserNameTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var firstName = Read(br, ReadString);
                var lastName = Read(br, ReadString);
                var username = Read(br, ReadString);
                return new UserNameTag(userId, firstName, lastName, username);
            }
        }

        public sealed class UserPhotoTag : Record<UserPhotoTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x95313b0c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int Date { get; }
            public T.UserProfilePhoto Photo { get; }
            public bool Previous { get; }
            
            public UserPhotoTag(
                int userId,
                int date,
                Some<T.UserProfilePhoto> photo,
                bool previous
            ) {
                UserId = userId;
                Date = date;
                Photo = photo;
                Previous = previous;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Photo, bw, WriteSerializable);
                Write(Previous, bw, WriteBool);
            }
            
            internal static UserPhotoTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var photo = Read(br, T.UserProfilePhoto.Deserialize);
                var previous = Read(br, ReadBool);
                return new UserPhotoTag(userId, date, photo, previous);
            }
        }

        public sealed class ContactRegisteredTag : Record<ContactRegisteredTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2575bbb9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public int Date { get; }
            
            public ContactRegisteredTag(
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
            
            internal static ContactRegisteredTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new ContactRegisteredTag(userId, date);
            }
        }

        public sealed class ContactLinkTag : Record<ContactLinkTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9d2e67c5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public T.ContactLink MyLink { get; }
            public T.ContactLink ForeignLink { get; }
            
            public ContactLinkTag(
                int userId,
                Some<T.ContactLink> myLink,
                Some<T.ContactLink> foreignLink
            ) {
                UserId = userId;
                MyLink = myLink;
                ForeignLink = foreignLink;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(MyLink, bw, WriteSerializable);
                Write(ForeignLink, bw, WriteSerializable);
            }
            
            internal static ContactLinkTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var myLink = Read(br, T.ContactLink.Deserialize);
                var foreignLink = Read(br, T.ContactLink.Deserialize);
                return new ContactLinkTag(userId, myLink, foreignLink);
            }
        }

        public sealed class NewEncryptedMessageTag : Record<NewEncryptedMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x12bcbd9a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.EncryptedMessage Message { get; }
            public int Qts { get; }
            
            public NewEncryptedMessageTag(
                Some<T.EncryptedMessage> message,
                int qts
            ) {
                Message = message;
                Qts = qts;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
                Write(Qts, bw, WriteInt);
            }
            
            internal static NewEncryptedMessageTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.EncryptedMessage.Deserialize);
                var qts = Read(br, ReadInt);
                return new NewEncryptedMessageTag(message, qts);
            }
        }

        public sealed class EncryptedChatTypingTag : Record<EncryptedChatTypingTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x1710f156;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            
            public EncryptedChatTypingTag(
                int chatId
            ) {
                ChatId = chatId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
            }
            
            internal static EncryptedChatTypingTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                return new EncryptedChatTypingTag(chatId);
            }
        }

        public sealed class EncryptionTag : Record<EncryptionTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb4a2e88d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.EncryptedChat Chat { get; }
            public int Date { get; }
            
            public EncryptionTag(
                Some<T.EncryptedChat> chat,
                int date
            ) {
                Chat = chat;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Chat, bw, WriteSerializable);
                Write(Date, bw, WriteInt);
            }
            
            internal static EncryptionTag DeserializeTag(BinaryReader br)
            {
                var chat = Read(br, T.EncryptedChat.Deserialize);
                var date = Read(br, ReadInt);
                return new EncryptionTag(chat, date);
            }
        }

        public sealed class EncryptedMessagesReadTag : Record<EncryptedMessagesReadTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x38fe25b7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public int MaxDate { get; }
            public int Date { get; }
            
            public EncryptedMessagesReadTag(
                int chatId,
                int maxDate,
                int date
            ) {
                ChatId = chatId;
                MaxDate = maxDate;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(MaxDate, bw, WriteInt);
                Write(Date, bw, WriteInt);
            }
            
            internal static EncryptedMessagesReadTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var maxDate = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                return new EncryptedMessagesReadTag(chatId, maxDate, date);
            }
        }

        public sealed class ChatParticipantAddTag : Record<ChatParticipantAddTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xea4b0e5c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public int UserId { get; }
            public int InviterId { get; }
            public int Date { get; }
            public int Version { get; }
            
            public ChatParticipantAddTag(
                int chatId,
                int userId,
                int inviterId,
                int date,
                int version
            ) {
                ChatId = chatId;
                UserId = userId;
                InviterId = inviterId;
                Date = date;
                Version = version;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(InviterId, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Version, bw, WriteInt);
            }
            
            internal static ChatParticipantAddTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var inviterId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var version = Read(br, ReadInt);
                return new ChatParticipantAddTag(chatId, userId, inviterId, date, version);
            }
        }

        public sealed class ChatParticipantDeleteTag : Record<ChatParticipantDeleteTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x6e5f8c22;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public int UserId { get; }
            public int Version { get; }
            
            public ChatParticipantDeleteTag(
                int chatId,
                int userId,
                int version
            ) {
                ChatId = chatId;
                UserId = userId;
                Version = version;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(Version, bw, WriteInt);
            }
            
            internal static ChatParticipantDeleteTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var version = Read(br, ReadInt);
                return new ChatParticipantDeleteTag(chatId, userId, version);
            }
        }

        public sealed class DcOptionsTag : Record<DcOptionsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x8e5e9873;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.DcOption> DcOptions { get; }
            
            public DcOptionsTag(
                Some<Arr<T.DcOption>> dcOptions
            ) {
                DcOptions = dcOptions;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(DcOptions, bw, WriteVector<T.DcOption>(WriteSerializable));
            }
            
            internal static DcOptionsTag DeserializeTag(BinaryReader br)
            {
                var dcOptions = Read(br, ReadVector(T.DcOption.Deserialize));
                return new DcOptionsTag(dcOptions);
            }
        }

        public sealed class UserBlockedTag : Record<UserBlockedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x80ece81a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public bool Blocked { get; }
            
            public UserBlockedTag(
                int userId,
                bool blocked
            ) {
                UserId = userId;
                Blocked = blocked;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Blocked, bw, WriteBool);
            }
            
            internal static UserBlockedTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var blocked = Read(br, ReadBool);
                return new UserBlockedTag(userId, blocked);
            }
        }

        public sealed class NotifySettingsTag : Record<NotifySettingsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xbec268ef;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.NotifyPeer Peer { get; }
            public T.PeerNotifySettings NotifySettings { get; }
            
            public NotifySettingsTag(
                Some<T.NotifyPeer> peer,
                Some<T.PeerNotifySettings> notifySettings
            ) {
                Peer = peer;
                NotifySettings = notifySettings;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
                Write(NotifySettings, bw, WriteSerializable);
            }
            
            internal static NotifySettingsTag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.NotifyPeer.Deserialize);
                var notifySettings = Read(br, T.PeerNotifySettings.Deserialize);
                return new NotifySettingsTag(peer, notifySettings);
            }
        }

        public sealed class ServiceNotificationTag : Record<ServiceNotificationTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xebe46819;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Popup { get; }
            public Option<int> InboxDate { get; }
            public string Type { get; }
            public string Message { get; }
            public T.MessageMedia Media { get; }
            public Arr<T.MessageEntity> Entities { get; }
            
            public ServiceNotificationTag(
                bool popup,
                Option<int> inboxDate,
                Some<string> type,
                Some<string> message,
                Some<T.MessageMedia> media,
                Some<Arr<T.MessageEntity>> entities
            ) {
                Popup = popup;
                InboxDate = inboxDate;
                Type = type;
                Message = message;
                Media = media;
                Entities = entities;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Popup) | MaskBit(1, InboxDate), bw, WriteInt);
                Write(InboxDate, bw, WriteOption<int>(WriteInt));
                Write(Type, bw, WriteString);
                Write(Message, bw, WriteString);
                Write(Media, bw, WriteSerializable);
                Write(Entities, bw, WriteVector<T.MessageEntity>(WriteSerializable));
            }
            
            internal static ServiceNotificationTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var popup = Read(br, ReadOption(flags, 0));
                var inboxDate = Read(br, ReadOption(flags, 1, ReadInt));
                var type = Read(br, ReadString);
                var message = Read(br, ReadString);
                var media = Read(br, T.MessageMedia.Deserialize);
                var entities = Read(br, ReadVector(T.MessageEntity.Deserialize));
                return new ServiceNotificationTag(popup, inboxDate, type, message, media, entities);
            }
        }

        public sealed class PrivacyTag : Record<PrivacyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xee3b272a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.PrivacyKey Key { get; }
            public Arr<T.PrivacyRule> Rules { get; }
            
            public PrivacyTag(
                Some<T.PrivacyKey> key,
                Some<Arr<T.PrivacyRule>> rules
            ) {
                Key = key;
                Rules = rules;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Key, bw, WriteSerializable);
                Write(Rules, bw, WriteVector<T.PrivacyRule>(WriteSerializable));
            }
            
            internal static PrivacyTag DeserializeTag(BinaryReader br)
            {
                var key = Read(br, T.PrivacyKey.Deserialize);
                var rules = Read(br, ReadVector(T.PrivacyRule.Deserialize));
                return new PrivacyTag(key, rules);
            }
        }

        public sealed class UserPhoneTag : Record<UserPhoneTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x12b9417b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public string Phone { get; }
            
            public UserPhoneTag(
                int userId,
                Some<string> phone
            ) {
                UserId = userId;
                Phone = phone;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(Phone, bw, WriteString);
            }
            
            internal static UserPhoneTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var phone = Read(br, ReadString);
                return new UserPhoneTag(userId, phone);
            }
        }

        public sealed class ReadHistoryInboxTag : Record<ReadHistoryInboxTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9961fd5c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Peer Peer { get; }
            public int MaxId { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public ReadHistoryInboxTag(
                Some<T.Peer> peer,
                int maxId,
                int pts,
                int ptsCount
            ) {
                Peer = peer;
                MaxId = maxId;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
                Write(MaxId, bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static ReadHistoryInboxTag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.Peer.Deserialize);
                var maxId = Read(br, ReadInt);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new ReadHistoryInboxTag(peer, maxId, pts, ptsCount);
            }
        }

        public sealed class ReadHistoryOutboxTag : Record<ReadHistoryOutboxTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x2f2f21bf;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Peer Peer { get; }
            public int MaxId { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public ReadHistoryOutboxTag(
                Some<T.Peer> peer,
                int maxId,
                int pts,
                int ptsCount
            ) {
                Peer = peer;
                MaxId = maxId;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
                Write(MaxId, bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static ReadHistoryOutboxTag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.Peer.Deserialize);
                var maxId = Read(br, ReadInt);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new ReadHistoryOutboxTag(peer, maxId, pts, ptsCount);
            }
        }

        public sealed class WebPageTag : Record<WebPageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x7f891213;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.WebPage Webpage { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public WebPageTag(
                Some<T.WebPage> webpage,
                int pts,
                int ptsCount
            ) {
                Webpage = webpage;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Webpage, bw, WriteSerializable);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static WebPageTag DeserializeTag(BinaryReader br)
            {
                var webpage = Read(br, T.WebPage.Deserialize);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new WebPageTag(webpage, pts, ptsCount);
            }
        }

        public sealed class ReadMessagesContentsTag : Record<ReadMessagesContentsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x68c13933;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Messages { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public ReadMessagesContentsTag(
                Some<Arr<int>> messages,
                int pts,
                int ptsCount
            ) {
                Messages = messages;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Messages, bw, WriteVector<int>(WriteInt));
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static ReadMessagesContentsTag DeserializeTag(BinaryReader br)
            {
                var messages = Read(br, ReadVector(ReadInt));
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new ReadMessagesContentsTag(messages, pts, ptsCount);
            }
        }

        public sealed class ChannelTooLongTag : Record<ChannelTooLongTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xeb0467fb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public Option<int> Pts { get; }
            
            public ChannelTooLongTag(
                int channelId,
                Option<int> pts
            ) {
                ChannelId = channelId;
                Pts = pts;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Pts), bw, WriteInt);
                Write(ChannelId, bw, WriteInt);
                Write(Pts, bw, WriteOption<int>(WriteInt));
            }
            
            internal static ChannelTooLongTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var channelId = Read(br, ReadInt);
                var pts = Read(br, ReadOption(flags, 0, ReadInt));
                return new ChannelTooLongTag(channelId, pts);
            }
        }

        public sealed class ChannelTag : Record<ChannelTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb6d45656;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            
            public ChannelTag(
                int channelId
            ) {
                ChannelId = channelId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
            }
            
            internal static ChannelTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                return new ChannelTag(channelId);
            }
        }

        public sealed class NewChannelMessageTag : Record<NewChannelMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x62ba04d9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Message Message { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public NewChannelMessageTag(
                Some<T.Message> message,
                int pts,
                int ptsCount
            ) {
                Message = message;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static NewChannelMessageTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.Message.Deserialize);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new NewChannelMessageTag(message, pts, ptsCount);
            }
        }

        public sealed class ReadChannelInboxTag : Record<ReadChannelInboxTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x4214f37f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public int MaxId { get; }
            
            public ReadChannelInboxTag(
                int channelId,
                int maxId
            ) {
                ChannelId = channelId;
                MaxId = maxId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(MaxId, bw, WriteInt);
            }
            
            internal static ReadChannelInboxTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var maxId = Read(br, ReadInt);
                return new ReadChannelInboxTag(channelId, maxId);
            }
        }

        public sealed class DeleteChannelMessagesTag : Record<DeleteChannelMessagesTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc37521c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public Arr<int> Messages { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public DeleteChannelMessagesTag(
                int channelId,
                Some<Arr<int>> messages,
                int pts,
                int ptsCount
            ) {
                ChannelId = channelId;
                Messages = messages;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(Messages, bw, WriteVector<int>(WriteInt));
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static DeleteChannelMessagesTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var messages = Read(br, ReadVector(ReadInt));
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new DeleteChannelMessagesTag(channelId, messages, pts, ptsCount);
            }
        }

        public sealed class ChannelMessageViewsTag : Record<ChannelMessageViewsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x98a12b4b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public int Id { get; }
            public int Views { get; }
            
            public ChannelMessageViewsTag(
                int channelId,
                int id,
                int views
            ) {
                ChannelId = channelId;
                Id = id;
                Views = views;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(Views, bw, WriteInt);
            }
            
            internal static ChannelMessageViewsTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var id = Read(br, ReadInt);
                var views = Read(br, ReadInt);
                return new ChannelMessageViewsTag(channelId, id, views);
            }
        }

        public sealed class ChatAdminsTag : Record<ChatAdminsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x6e947941;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public bool Enabled { get; }
            public int Version { get; }
            
            public ChatAdminsTag(
                int chatId,
                bool enabled,
                int version
            ) {
                ChatId = chatId;
                Enabled = enabled;
                Version = version;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(Enabled, bw, WriteBool);
                Write(Version, bw, WriteInt);
            }
            
            internal static ChatAdminsTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var enabled = Read(br, ReadBool);
                var version = Read(br, ReadInt);
                return new ChatAdminsTag(chatId, enabled, version);
            }
        }

        public sealed class ChatParticipantAdminTag : Record<ChatParticipantAdminTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb6901959;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            public int UserId { get; }
            public bool IsAdmin { get; }
            public int Version { get; }
            
            public ChatParticipantAdminTag(
                int chatId,
                int userId,
                bool isAdmin,
                int version
            ) {
                ChatId = chatId;
                UserId = userId;
                IsAdmin = isAdmin;
                Version = version;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChatId, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(IsAdmin, bw, WriteBool);
                Write(Version, bw, WriteInt);
            }
            
            internal static ChatParticipantAdminTag DeserializeTag(BinaryReader br)
            {
                var chatId = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var isAdmin = Read(br, ReadBool);
                var version = Read(br, ReadInt);
                return new ChatParticipantAdminTag(chatId, userId, isAdmin, version);
            }
        }

        public sealed class NewStickerSetTag : Record<NewStickerSetTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x688a30aa;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Messages.StickerSet Stickerset { get; }
            
            public NewStickerSetTag(
                Some<T.Messages.StickerSet> stickerset
            ) {
                Stickerset = stickerset;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Stickerset, bw, WriteSerializable);
            }
            
            internal static NewStickerSetTag DeserializeTag(BinaryReader br)
            {
                var stickerset = Read(br, T.Messages.StickerSet.Deserialize);
                return new NewStickerSetTag(stickerset);
            }
        }

        public sealed class StickerSetsOrderTag : Record<StickerSetsOrderTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x0bb2d201;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Masks { get; }
            public Arr<long> Order { get; }
            
            public StickerSetsOrderTag(
                bool masks,
                Some<Arr<long>> order
            ) {
                Masks = masks;
                Order = order;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Masks), bw, WriteInt);
                Write(Order, bw, WriteVector<long>(WriteLong));
            }
            
            internal static StickerSetsOrderTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var masks = Read(br, ReadOption(flags, 0));
                var order = Read(br, ReadVector(ReadLong));
                return new StickerSetsOrderTag(masks, order);
            }
        }

        public sealed class StickerSetsTag : Record<StickerSetsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x43ae3dec;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public StickerSetsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static StickerSetsTag DeserializeTag(BinaryReader br)
            {

                return new StickerSetsTag();
            }
        }

        public sealed class SavedGifsTag : Record<SavedGifsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9375341e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SavedGifsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SavedGifsTag DeserializeTag(BinaryReader br)
            {

                return new SavedGifsTag();
            }
        }

        public sealed class BotInlineQueryTag : Record<BotInlineQueryTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x54826690;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long QueryId { get; }
            public int UserId { get; }
            public string Query { get; }
            public Option<T.GeoPoint> Geo { get; }
            public string Offset { get; }
            
            public BotInlineQueryTag(
                long queryId,
                int userId,
                Some<string> query,
                Option<T.GeoPoint> geo,
                Some<string> offset
            ) {
                QueryId = queryId;
                UserId = userId;
                Query = query;
                Geo = geo;
                Offset = offset;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Geo), bw, WriteInt);
                Write(QueryId, bw, WriteLong);
                Write(UserId, bw, WriteInt);
                Write(Query, bw, WriteString);
                Write(Geo, bw, WriteOption<T.GeoPoint>(WriteSerializable));
                Write(Offset, bw, WriteString);
            }
            
            internal static BotInlineQueryTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var queryId = Read(br, ReadLong);
                var userId = Read(br, ReadInt);
                var query = Read(br, ReadString);
                var geo = Read(br, ReadOption(flags, 0, T.GeoPoint.Deserialize));
                var offset = Read(br, ReadString);
                return new BotInlineQueryTag(queryId, userId, query, geo, offset);
            }
        }

        public sealed class BotInlineSendTag : Record<BotInlineSendTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x0e48f964;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public string Query { get; }
            public Option<T.GeoPoint> Geo { get; }
            public string Id { get; }
            public Option<T.InputBotInlineMessageId> MsgId { get; }
            
            public BotInlineSendTag(
                int userId,
                Some<string> query,
                Option<T.GeoPoint> geo,
                Some<string> id,
                Option<T.InputBotInlineMessageId> msgId
            ) {
                UserId = userId;
                Query = query;
                Geo = geo;
                Id = id;
                MsgId = msgId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Geo) | MaskBit(1, MsgId), bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(Query, bw, WriteString);
                Write(Geo, bw, WriteOption<T.GeoPoint>(WriteSerializable));
                Write(Id, bw, WriteString);
                Write(MsgId, bw, WriteOption<T.InputBotInlineMessageId>(WriteSerializable));
            }
            
            internal static BotInlineSendTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var query = Read(br, ReadString);
                var geo = Read(br, ReadOption(flags, 0, T.GeoPoint.Deserialize));
                var id = Read(br, ReadString);
                var msgId = Read(br, ReadOption(flags, 1, T.InputBotInlineMessageId.Deserialize));
                return new BotInlineSendTag(userId, query, geo, id, msgId);
            }
        }

        public sealed class EditChannelMessageTag : Record<EditChannelMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x1b3f4df7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Message Message { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public EditChannelMessageTag(
                Some<T.Message> message,
                int pts,
                int ptsCount
            ) {
                Message = message;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static EditChannelMessageTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.Message.Deserialize);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new EditChannelMessageTag(message, pts, ptsCount);
            }
        }

        public sealed class ChannelPinnedMessageTag : Record<ChannelPinnedMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x98592475;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public int Id { get; }
            
            public ChannelPinnedMessageTag(
                int channelId,
                int id
            ) {
                ChannelId = channelId;
                Id = id;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(Id, bw, WriteInt);
            }
            
            internal static ChannelPinnedMessageTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var id = Read(br, ReadInt);
                return new ChannelPinnedMessageTag(channelId, id);
            }
        }

        public sealed class BotCallbackQueryTag : Record<BotCallbackQueryTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe73547e1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long QueryId { get; }
            public int UserId { get; }
            public T.Peer Peer { get; }
            public int MsgId { get; }
            public long ChatInstance { get; }
            public Option<Arr<byte>> Data { get; }
            public Option<string> GameShortName { get; }
            
            public BotCallbackQueryTag(
                long queryId,
                int userId,
                Some<T.Peer> peer,
                int msgId,
                long chatInstance,
                Option<Arr<byte>> data,
                Option<string> gameShortName
            ) {
                QueryId = queryId;
                UserId = userId;
                Peer = peer;
                MsgId = msgId;
                ChatInstance = chatInstance;
                Data = data;
                GameShortName = gameShortName;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Data) | MaskBit(1, GameShortName), bw, WriteInt);
                Write(QueryId, bw, WriteLong);
                Write(UserId, bw, WriteInt);
                Write(Peer, bw, WriteSerializable);
                Write(MsgId, bw, WriteInt);
                Write(ChatInstance, bw, WriteLong);
                Write(Data, bw, WriteOption<Arr<byte>>(WriteBytes));
                Write(GameShortName, bw, WriteOption<string>(WriteString));
            }
            
            internal static BotCallbackQueryTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var queryId = Read(br, ReadLong);
                var userId = Read(br, ReadInt);
                var peer = Read(br, T.Peer.Deserialize);
                var msgId = Read(br, ReadInt);
                var chatInstance = Read(br, ReadLong);
                var data = Read(br, ReadOption(flags, 0, ReadBytes));
                var gameShortName = Read(br, ReadOption(flags, 1, ReadString));
                return new BotCallbackQueryTag(queryId, userId, peer, msgId, chatInstance, data, gameShortName);
            }
        }

        public sealed class EditMessageTag : Record<EditMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe40370a3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Message Message { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public EditMessageTag(
                Some<T.Message> message,
                int pts,
                int ptsCount
            ) {
                Message = message;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteSerializable);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static EditMessageTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, T.Message.Deserialize);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new EditMessageTag(message, pts, ptsCount);
            }
        }

        public sealed class InlineBotCallbackQueryTag : Record<InlineBotCallbackQueryTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf9d27a5a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long QueryId { get; }
            public int UserId { get; }
            public T.InputBotInlineMessageId MsgId { get; }
            public long ChatInstance { get; }
            public Option<Arr<byte>> Data { get; }
            public Option<string> GameShortName { get; }
            
            public InlineBotCallbackQueryTag(
                long queryId,
                int userId,
                Some<T.InputBotInlineMessageId> msgId,
                long chatInstance,
                Option<Arr<byte>> data,
                Option<string> gameShortName
            ) {
                QueryId = queryId;
                UserId = userId;
                MsgId = msgId;
                ChatInstance = chatInstance;
                Data = data;
                GameShortName = gameShortName;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Data) | MaskBit(1, GameShortName), bw, WriteInt);
                Write(QueryId, bw, WriteLong);
                Write(UserId, bw, WriteInt);
                Write(MsgId, bw, WriteSerializable);
                Write(ChatInstance, bw, WriteLong);
                Write(Data, bw, WriteOption<Arr<byte>>(WriteBytes));
                Write(GameShortName, bw, WriteOption<string>(WriteString));
            }
            
            internal static InlineBotCallbackQueryTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var queryId = Read(br, ReadLong);
                var userId = Read(br, ReadInt);
                var msgId = Read(br, T.InputBotInlineMessageId.Deserialize);
                var chatInstance = Read(br, ReadLong);
                var data = Read(br, ReadOption(flags, 0, ReadBytes));
                var gameShortName = Read(br, ReadOption(flags, 1, ReadString));
                return new InlineBotCallbackQueryTag(queryId, userId, msgId, chatInstance, data, gameShortName);
            }
        }

        public sealed class ReadChannelOutboxTag : Record<ReadChannelOutboxTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x25d6c9c7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public int MaxId { get; }
            
            public ReadChannelOutboxTag(
                int channelId,
                int maxId
            ) {
                ChannelId = channelId;
                MaxId = maxId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(MaxId, bw, WriteInt);
            }
            
            internal static ReadChannelOutboxTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var maxId = Read(br, ReadInt);
                return new ReadChannelOutboxTag(channelId, maxId);
            }
        }

        public sealed class DraftMessageTag : Record<DraftMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xee2bb969;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Peer Peer { get; }
            public T.DraftMessage Draft { get; }
            
            public DraftMessageTag(
                Some<T.Peer> peer,
                Some<T.DraftMessage> draft
            ) {
                Peer = peer;
                Draft = draft;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Peer, bw, WriteSerializable);
                Write(Draft, bw, WriteSerializable);
            }
            
            internal static DraftMessageTag DeserializeTag(BinaryReader br)
            {
                var peer = Read(br, T.Peer.Deserialize);
                var draft = Read(br, T.DraftMessage.Deserialize);
                return new DraftMessageTag(peer, draft);
            }
        }

        public sealed class ReadFeaturedStickersTag : Record<ReadFeaturedStickersTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x571d2742;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ReadFeaturedStickersTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ReadFeaturedStickersTag DeserializeTag(BinaryReader br)
            {

                return new ReadFeaturedStickersTag();
            }
        }

        public sealed class RecentStickersTag : Record<RecentStickersTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9a422c20;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecentStickersTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecentStickersTag DeserializeTag(BinaryReader br)
            {

                return new RecentStickersTag();
            }
        }

        public sealed class ConfigTag : Record<ConfigTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa229dd06;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ConfigTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ConfigTag DeserializeTag(BinaryReader br)
            {

                return new ConfigTag();
            }
        }

        public sealed class PtsChangedTag : Record<PtsChangedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x3354678f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PtsChangedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PtsChangedTag DeserializeTag(BinaryReader br)
            {

                return new PtsChangedTag();
            }
        }

        public sealed class ChannelWebPageTag : Record<ChannelWebPageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x40771900;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            public T.WebPage Webpage { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            
            public ChannelWebPageTag(
                int channelId,
                Some<T.WebPage> webpage,
                int pts,
                int ptsCount
            ) {
                ChannelId = channelId;
                Webpage = webpage;
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
                Write(Webpage, bw, WriteSerializable);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static ChannelWebPageTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                var webpage = Read(br, T.WebPage.Deserialize);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new ChannelWebPageTag(channelId, webpage, pts, ptsCount);
            }
        }

        public sealed class DialogPinnedTag : Record<DialogPinnedTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd711a2cc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Pinned { get; }
            public T.Peer Peer { get; }
            
            public DialogPinnedTag(
                bool pinned,
                Some<T.Peer> peer
            ) {
                Pinned = pinned;
                Peer = peer;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Pinned), bw, WriteInt);
                Write(Peer, bw, WriteSerializable);
            }
            
            internal static DialogPinnedTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var pinned = Read(br, ReadOption(flags, 0));
                var peer = Read(br, T.Peer.Deserialize);
                return new DialogPinnedTag(pinned, peer);
            }
        }

        public sealed class PinnedDialogsTag : Record<PinnedDialogsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd8caf68d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Option<Arr<T.Peer>> Order { get; }
            
            public PinnedDialogsTag(
                Option<Arr<T.Peer>> order
            ) {
                Order = order;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Order), bw, WriteInt);
                Write(Order, bw, WriteOption<Arr<T.Peer>>(WriteVector<T.Peer>(WriteSerializable)));
            }
            
            internal static PinnedDialogsTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var order = Read(br, ReadOption(flags, 0, ReadVector(T.Peer.Deserialize)));
                return new PinnedDialogsTag(order);
            }
        }

        public sealed class BotWebhookJsonTag : Record<BotWebhookJsonTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x8317c0c3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.DataJson Data { get; }
            
            public BotWebhookJsonTag(
                Some<T.DataJson> data
            ) {
                Data = data;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Data, bw, WriteSerializable);
            }
            
            internal static BotWebhookJsonTag DeserializeTag(BinaryReader br)
            {
                var data = Read(br, T.DataJson.Deserialize);
                return new BotWebhookJsonTag(data);
            }
        }

        public sealed class BotWebhookJsonQueryTag : Record<BotWebhookJsonQueryTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9b9240a6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long QueryId { get; }
            public T.DataJson Data { get; }
            public int Timeout { get; }
            
            public BotWebhookJsonQueryTag(
                long queryId,
                Some<T.DataJson> data,
                int timeout
            ) {
                QueryId = queryId;
                Data = data;
                Timeout = timeout;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(QueryId, bw, WriteLong);
                Write(Data, bw, WriteSerializable);
                Write(Timeout, bw, WriteInt);
            }
            
            internal static BotWebhookJsonQueryTag DeserializeTag(BinaryReader br)
            {
                var queryId = Read(br, ReadLong);
                var data = Read(br, T.DataJson.Deserialize);
                var timeout = Read(br, ReadInt);
                return new BotWebhookJsonQueryTag(queryId, data, timeout);
            }
        }

        public sealed class BotShippingQueryTag : Record<BotShippingQueryTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xe0cdc940;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long QueryId { get; }
            public int UserId { get; }
            public Arr<byte> Payload { get; }
            public T.PostAddress ShippingAddress { get; }
            
            public BotShippingQueryTag(
                long queryId,
                int userId,
                Some<Arr<byte>> payload,
                Some<T.PostAddress> shippingAddress
            ) {
                QueryId = queryId;
                UserId = userId;
                Payload = payload;
                ShippingAddress = shippingAddress;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(QueryId, bw, WriteLong);
                Write(UserId, bw, WriteInt);
                Write(Payload, bw, WriteBytes);
                Write(ShippingAddress, bw, WriteSerializable);
            }
            
            internal static BotShippingQueryTag DeserializeTag(BinaryReader br)
            {
                var queryId = Read(br, ReadLong);
                var userId = Read(br, ReadInt);
                var payload = Read(br, ReadBytes);
                var shippingAddress = Read(br, T.PostAddress.Deserialize);
                return new BotShippingQueryTag(queryId, userId, payload, shippingAddress);
            }
        }

        public sealed class BotPrecheckoutQueryTag : Record<BotPrecheckoutQueryTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x5d2f3aa9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long QueryId { get; }
            public int UserId { get; }
            public Arr<byte> Payload { get; }
            public Option<T.PaymentRequestedInfo> Info { get; }
            public Option<string> ShippingOptionId { get; }
            public string Currency { get; }
            public long TotalAmount { get; }
            
            public BotPrecheckoutQueryTag(
                long queryId,
                int userId,
                Some<Arr<byte>> payload,
                Option<T.PaymentRequestedInfo> info,
                Option<string> shippingOptionId,
                Some<string> currency,
                long totalAmount
            ) {
                QueryId = queryId;
                UserId = userId;
                Payload = payload;
                Info = info;
                ShippingOptionId = shippingOptionId;
                Currency = currency;
                TotalAmount = totalAmount;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Info) | MaskBit(1, ShippingOptionId), bw, WriteInt);
                Write(QueryId, bw, WriteLong);
                Write(UserId, bw, WriteInt);
                Write(Payload, bw, WriteBytes);
                Write(Info, bw, WriteOption<T.PaymentRequestedInfo>(WriteSerializable));
                Write(ShippingOptionId, bw, WriteOption<string>(WriteString));
                Write(Currency, bw, WriteString);
                Write(TotalAmount, bw, WriteLong);
            }
            
            internal static BotPrecheckoutQueryTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var queryId = Read(br, ReadLong);
                var userId = Read(br, ReadInt);
                var payload = Read(br, ReadBytes);
                var info = Read(br, ReadOption(flags, 0, T.PaymentRequestedInfo.Deserialize));
                var shippingOptionId = Read(br, ReadOption(flags, 1, ReadString));
                var currency = Read(br, ReadString);
                var totalAmount = Read(br, ReadLong);
                return new BotPrecheckoutQueryTag(queryId, userId, payload, info, shippingOptionId, currency, totalAmount);
            }
        }

        public sealed class PhoneCallTag : Record<PhoneCallTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xab0f6b1e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.PhoneCall PhoneCall { get; }
            
            public PhoneCallTag(
                Some<T.PhoneCall> phoneCall
            ) {
                PhoneCall = phoneCall;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(PhoneCall, bw, WriteSerializable);
            }
            
            internal static PhoneCallTag DeserializeTag(BinaryReader br)
            {
                var phoneCall = Read(br, T.PhoneCall.Deserialize);
                return new PhoneCallTag(phoneCall);
            }
        }

        readonly ITlTypeTag _tag;
        Update(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Update(NewMessageTag tag) => new Update(tag);
        public static explicit operator Update(MessageIdTag tag) => new Update(tag);
        public static explicit operator Update(DeleteMessagesTag tag) => new Update(tag);
        public static explicit operator Update(UserTypingTag tag) => new Update(tag);
        public static explicit operator Update(ChatUserTypingTag tag) => new Update(tag);
        public static explicit operator Update(ChatParticipantsTag tag) => new Update(tag);
        public static explicit operator Update(UserStatusTag tag) => new Update(tag);
        public static explicit operator Update(UserNameTag tag) => new Update(tag);
        public static explicit operator Update(UserPhotoTag tag) => new Update(tag);
        public static explicit operator Update(ContactRegisteredTag tag) => new Update(tag);
        public static explicit operator Update(ContactLinkTag tag) => new Update(tag);
        public static explicit operator Update(NewEncryptedMessageTag tag) => new Update(tag);
        public static explicit operator Update(EncryptedChatTypingTag tag) => new Update(tag);
        public static explicit operator Update(EncryptionTag tag) => new Update(tag);
        public static explicit operator Update(EncryptedMessagesReadTag tag) => new Update(tag);
        public static explicit operator Update(ChatParticipantAddTag tag) => new Update(tag);
        public static explicit operator Update(ChatParticipantDeleteTag tag) => new Update(tag);
        public static explicit operator Update(DcOptionsTag tag) => new Update(tag);
        public static explicit operator Update(UserBlockedTag tag) => new Update(tag);
        public static explicit operator Update(NotifySettingsTag tag) => new Update(tag);
        public static explicit operator Update(ServiceNotificationTag tag) => new Update(tag);
        public static explicit operator Update(PrivacyTag tag) => new Update(tag);
        public static explicit operator Update(UserPhoneTag tag) => new Update(tag);
        public static explicit operator Update(ReadHistoryInboxTag tag) => new Update(tag);
        public static explicit operator Update(ReadHistoryOutboxTag tag) => new Update(tag);
        public static explicit operator Update(WebPageTag tag) => new Update(tag);
        public static explicit operator Update(ReadMessagesContentsTag tag) => new Update(tag);
        public static explicit operator Update(ChannelTooLongTag tag) => new Update(tag);
        public static explicit operator Update(ChannelTag tag) => new Update(tag);
        public static explicit operator Update(NewChannelMessageTag tag) => new Update(tag);
        public static explicit operator Update(ReadChannelInboxTag tag) => new Update(tag);
        public static explicit operator Update(DeleteChannelMessagesTag tag) => new Update(tag);
        public static explicit operator Update(ChannelMessageViewsTag tag) => new Update(tag);
        public static explicit operator Update(ChatAdminsTag tag) => new Update(tag);
        public static explicit operator Update(ChatParticipantAdminTag tag) => new Update(tag);
        public static explicit operator Update(NewStickerSetTag tag) => new Update(tag);
        public static explicit operator Update(StickerSetsOrderTag tag) => new Update(tag);
        public static explicit operator Update(StickerSetsTag tag) => new Update(tag);
        public static explicit operator Update(SavedGifsTag tag) => new Update(tag);
        public static explicit operator Update(BotInlineQueryTag tag) => new Update(tag);
        public static explicit operator Update(BotInlineSendTag tag) => new Update(tag);
        public static explicit operator Update(EditChannelMessageTag tag) => new Update(tag);
        public static explicit operator Update(ChannelPinnedMessageTag tag) => new Update(tag);
        public static explicit operator Update(BotCallbackQueryTag tag) => new Update(tag);
        public static explicit operator Update(EditMessageTag tag) => new Update(tag);
        public static explicit operator Update(InlineBotCallbackQueryTag tag) => new Update(tag);
        public static explicit operator Update(ReadChannelOutboxTag tag) => new Update(tag);
        public static explicit operator Update(DraftMessageTag tag) => new Update(tag);
        public static explicit operator Update(ReadFeaturedStickersTag tag) => new Update(tag);
        public static explicit operator Update(RecentStickersTag tag) => new Update(tag);
        public static explicit operator Update(ConfigTag tag) => new Update(tag);
        public static explicit operator Update(PtsChangedTag tag) => new Update(tag);
        public static explicit operator Update(ChannelWebPageTag tag) => new Update(tag);
        public static explicit operator Update(DialogPinnedTag tag) => new Update(tag);
        public static explicit operator Update(PinnedDialogsTag tag) => new Update(tag);
        public static explicit operator Update(BotWebhookJsonTag tag) => new Update(tag);
        public static explicit operator Update(BotWebhookJsonQueryTag tag) => new Update(tag);
        public static explicit operator Update(BotShippingQueryTag tag) => new Update(tag);
        public static explicit operator Update(BotPrecheckoutQueryTag tag) => new Update(tag);
        public static explicit operator Update(PhoneCallTag tag) => new Update(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Update Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NewMessageTag.TypeNumber: return (Update) NewMessageTag.DeserializeTag(br);
                case MessageIdTag.TypeNumber: return (Update) MessageIdTag.DeserializeTag(br);
                case DeleteMessagesTag.TypeNumber: return (Update) DeleteMessagesTag.DeserializeTag(br);
                case UserTypingTag.TypeNumber: return (Update) UserTypingTag.DeserializeTag(br);
                case ChatUserTypingTag.TypeNumber: return (Update) ChatUserTypingTag.DeserializeTag(br);
                case ChatParticipantsTag.TypeNumber: return (Update) ChatParticipantsTag.DeserializeTag(br);
                case UserStatusTag.TypeNumber: return (Update) UserStatusTag.DeserializeTag(br);
                case UserNameTag.TypeNumber: return (Update) UserNameTag.DeserializeTag(br);
                case UserPhotoTag.TypeNumber: return (Update) UserPhotoTag.DeserializeTag(br);
                case ContactRegisteredTag.TypeNumber: return (Update) ContactRegisteredTag.DeserializeTag(br);
                case ContactLinkTag.TypeNumber: return (Update) ContactLinkTag.DeserializeTag(br);
                case NewEncryptedMessageTag.TypeNumber: return (Update) NewEncryptedMessageTag.DeserializeTag(br);
                case EncryptedChatTypingTag.TypeNumber: return (Update) EncryptedChatTypingTag.DeserializeTag(br);
                case EncryptionTag.TypeNumber: return (Update) EncryptionTag.DeserializeTag(br);
                case EncryptedMessagesReadTag.TypeNumber: return (Update) EncryptedMessagesReadTag.DeserializeTag(br);
                case ChatParticipantAddTag.TypeNumber: return (Update) ChatParticipantAddTag.DeserializeTag(br);
                case ChatParticipantDeleteTag.TypeNumber: return (Update) ChatParticipantDeleteTag.DeserializeTag(br);
                case DcOptionsTag.TypeNumber: return (Update) DcOptionsTag.DeserializeTag(br);
                case UserBlockedTag.TypeNumber: return (Update) UserBlockedTag.DeserializeTag(br);
                case NotifySettingsTag.TypeNumber: return (Update) NotifySettingsTag.DeserializeTag(br);
                case ServiceNotificationTag.TypeNumber: return (Update) ServiceNotificationTag.DeserializeTag(br);
                case PrivacyTag.TypeNumber: return (Update) PrivacyTag.DeserializeTag(br);
                case UserPhoneTag.TypeNumber: return (Update) UserPhoneTag.DeserializeTag(br);
                case ReadHistoryInboxTag.TypeNumber: return (Update) ReadHistoryInboxTag.DeserializeTag(br);
                case ReadHistoryOutboxTag.TypeNumber: return (Update) ReadHistoryOutboxTag.DeserializeTag(br);
                case WebPageTag.TypeNumber: return (Update) WebPageTag.DeserializeTag(br);
                case ReadMessagesContentsTag.TypeNumber: return (Update) ReadMessagesContentsTag.DeserializeTag(br);
                case ChannelTooLongTag.TypeNumber: return (Update) ChannelTooLongTag.DeserializeTag(br);
                case ChannelTag.TypeNumber: return (Update) ChannelTag.DeserializeTag(br);
                case NewChannelMessageTag.TypeNumber: return (Update) NewChannelMessageTag.DeserializeTag(br);
                case ReadChannelInboxTag.TypeNumber: return (Update) ReadChannelInboxTag.DeserializeTag(br);
                case DeleteChannelMessagesTag.TypeNumber: return (Update) DeleteChannelMessagesTag.DeserializeTag(br);
                case ChannelMessageViewsTag.TypeNumber: return (Update) ChannelMessageViewsTag.DeserializeTag(br);
                case ChatAdminsTag.TypeNumber: return (Update) ChatAdminsTag.DeserializeTag(br);
                case ChatParticipantAdminTag.TypeNumber: return (Update) ChatParticipantAdminTag.DeserializeTag(br);
                case NewStickerSetTag.TypeNumber: return (Update) NewStickerSetTag.DeserializeTag(br);
                case StickerSetsOrderTag.TypeNumber: return (Update) StickerSetsOrderTag.DeserializeTag(br);
                case StickerSetsTag.TypeNumber: return (Update) StickerSetsTag.DeserializeTag(br);
                case SavedGifsTag.TypeNumber: return (Update) SavedGifsTag.DeserializeTag(br);
                case BotInlineQueryTag.TypeNumber: return (Update) BotInlineQueryTag.DeserializeTag(br);
                case BotInlineSendTag.TypeNumber: return (Update) BotInlineSendTag.DeserializeTag(br);
                case EditChannelMessageTag.TypeNumber: return (Update) EditChannelMessageTag.DeserializeTag(br);
                case ChannelPinnedMessageTag.TypeNumber: return (Update) ChannelPinnedMessageTag.DeserializeTag(br);
                case BotCallbackQueryTag.TypeNumber: return (Update) BotCallbackQueryTag.DeserializeTag(br);
                case EditMessageTag.TypeNumber: return (Update) EditMessageTag.DeserializeTag(br);
                case InlineBotCallbackQueryTag.TypeNumber: return (Update) InlineBotCallbackQueryTag.DeserializeTag(br);
                case ReadChannelOutboxTag.TypeNumber: return (Update) ReadChannelOutboxTag.DeserializeTag(br);
                case DraftMessageTag.TypeNumber: return (Update) DraftMessageTag.DeserializeTag(br);
                case ReadFeaturedStickersTag.TypeNumber: return (Update) ReadFeaturedStickersTag.DeserializeTag(br);
                case RecentStickersTag.TypeNumber: return (Update) RecentStickersTag.DeserializeTag(br);
                case ConfigTag.TypeNumber: return (Update) ConfigTag.DeserializeTag(br);
                case PtsChangedTag.TypeNumber: return (Update) PtsChangedTag.DeserializeTag(br);
                case ChannelWebPageTag.TypeNumber: return (Update) ChannelWebPageTag.DeserializeTag(br);
                case DialogPinnedTag.TypeNumber: return (Update) DialogPinnedTag.DeserializeTag(br);
                case PinnedDialogsTag.TypeNumber: return (Update) PinnedDialogsTag.DeserializeTag(br);
                case BotWebhookJsonTag.TypeNumber: return (Update) BotWebhookJsonTag.DeserializeTag(br);
                case BotWebhookJsonQueryTag.TypeNumber: return (Update) BotWebhookJsonQueryTag.DeserializeTag(br);
                case BotShippingQueryTag.TypeNumber: return (Update) BotShippingQueryTag.DeserializeTag(br);
                case BotPrecheckoutQueryTag.TypeNumber: return (Update) BotPrecheckoutQueryTag.DeserializeTag(br);
                case PhoneCallTag.TypeNumber: return (Update) PhoneCallTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NewMessageTag.TypeNumber, MessageIdTag.TypeNumber, DeleteMessagesTag.TypeNumber, UserTypingTag.TypeNumber, ChatUserTypingTag.TypeNumber, ChatParticipantsTag.TypeNumber, UserStatusTag.TypeNumber, UserNameTag.TypeNumber, UserPhotoTag.TypeNumber, ContactRegisteredTag.TypeNumber, ContactLinkTag.TypeNumber, NewEncryptedMessageTag.TypeNumber, EncryptedChatTypingTag.TypeNumber, EncryptionTag.TypeNumber, EncryptedMessagesReadTag.TypeNumber, ChatParticipantAddTag.TypeNumber, ChatParticipantDeleteTag.TypeNumber, DcOptionsTag.TypeNumber, UserBlockedTag.TypeNumber, NotifySettingsTag.TypeNumber, ServiceNotificationTag.TypeNumber, PrivacyTag.TypeNumber, UserPhoneTag.TypeNumber, ReadHistoryInboxTag.TypeNumber, ReadHistoryOutboxTag.TypeNumber, WebPageTag.TypeNumber, ReadMessagesContentsTag.TypeNumber, ChannelTooLongTag.TypeNumber, ChannelTag.TypeNumber, NewChannelMessageTag.TypeNumber, ReadChannelInboxTag.TypeNumber, DeleteChannelMessagesTag.TypeNumber, ChannelMessageViewsTag.TypeNumber, ChatAdminsTag.TypeNumber, ChatParticipantAdminTag.TypeNumber, NewStickerSetTag.TypeNumber, StickerSetsOrderTag.TypeNumber, StickerSetsTag.TypeNumber, SavedGifsTag.TypeNumber, BotInlineQueryTag.TypeNumber, BotInlineSendTag.TypeNumber, EditChannelMessageTag.TypeNumber, ChannelPinnedMessageTag.TypeNumber, BotCallbackQueryTag.TypeNumber, EditMessageTag.TypeNumber, InlineBotCallbackQueryTag.TypeNumber, ReadChannelOutboxTag.TypeNumber, DraftMessageTag.TypeNumber, ReadFeaturedStickersTag.TypeNumber, RecentStickersTag.TypeNumber, ConfigTag.TypeNumber, PtsChangedTag.TypeNumber, ChannelWebPageTag.TypeNumber, DialogPinnedTag.TypeNumber, PinnedDialogsTag.TypeNumber, BotWebhookJsonTag.TypeNumber, BotWebhookJsonQueryTag.TypeNumber, BotShippingQueryTag.TypeNumber, BotPrecheckoutQueryTag.TypeNumber, PhoneCallTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NewMessageTag, T> newMessageTag = null,
            Func<MessageIdTag, T> messageIdTag = null,
            Func<DeleteMessagesTag, T> deleteMessagesTag = null,
            Func<UserTypingTag, T> userTypingTag = null,
            Func<ChatUserTypingTag, T> chatUserTypingTag = null,
            Func<ChatParticipantsTag, T> chatParticipantsTag = null,
            Func<UserStatusTag, T> userStatusTag = null,
            Func<UserNameTag, T> userNameTag = null,
            Func<UserPhotoTag, T> userPhotoTag = null,
            Func<ContactRegisteredTag, T> contactRegisteredTag = null,
            Func<ContactLinkTag, T> contactLinkTag = null,
            Func<NewEncryptedMessageTag, T> newEncryptedMessageTag = null,
            Func<EncryptedChatTypingTag, T> encryptedChatTypingTag = null,
            Func<EncryptionTag, T> encryptionTag = null,
            Func<EncryptedMessagesReadTag, T> encryptedMessagesReadTag = null,
            Func<ChatParticipantAddTag, T> chatParticipantAddTag = null,
            Func<ChatParticipantDeleteTag, T> chatParticipantDeleteTag = null,
            Func<DcOptionsTag, T> dcOptionsTag = null,
            Func<UserBlockedTag, T> userBlockedTag = null,
            Func<NotifySettingsTag, T> notifySettingsTag = null,
            Func<ServiceNotificationTag, T> serviceNotificationTag = null,
            Func<PrivacyTag, T> privacyTag = null,
            Func<UserPhoneTag, T> userPhoneTag = null,
            Func<ReadHistoryInboxTag, T> readHistoryInboxTag = null,
            Func<ReadHistoryOutboxTag, T> readHistoryOutboxTag = null,
            Func<WebPageTag, T> webPageTag = null,
            Func<ReadMessagesContentsTag, T> readMessagesContentsTag = null,
            Func<ChannelTooLongTag, T> channelTooLongTag = null,
            Func<ChannelTag, T> channelTag = null,
            Func<NewChannelMessageTag, T> newChannelMessageTag = null,
            Func<ReadChannelInboxTag, T> readChannelInboxTag = null,
            Func<DeleteChannelMessagesTag, T> deleteChannelMessagesTag = null,
            Func<ChannelMessageViewsTag, T> channelMessageViewsTag = null,
            Func<ChatAdminsTag, T> chatAdminsTag = null,
            Func<ChatParticipantAdminTag, T> chatParticipantAdminTag = null,
            Func<NewStickerSetTag, T> newStickerSetTag = null,
            Func<StickerSetsOrderTag, T> stickerSetsOrderTag = null,
            Func<StickerSetsTag, T> stickerSetsTag = null,
            Func<SavedGifsTag, T> savedGifsTag = null,
            Func<BotInlineQueryTag, T> botInlineQueryTag = null,
            Func<BotInlineSendTag, T> botInlineSendTag = null,
            Func<EditChannelMessageTag, T> editChannelMessageTag = null,
            Func<ChannelPinnedMessageTag, T> channelPinnedMessageTag = null,
            Func<BotCallbackQueryTag, T> botCallbackQueryTag = null,
            Func<EditMessageTag, T> editMessageTag = null,
            Func<InlineBotCallbackQueryTag, T> inlineBotCallbackQueryTag = null,
            Func<ReadChannelOutboxTag, T> readChannelOutboxTag = null,
            Func<DraftMessageTag, T> draftMessageTag = null,
            Func<ReadFeaturedStickersTag, T> readFeaturedStickersTag = null,
            Func<RecentStickersTag, T> recentStickersTag = null,
            Func<ConfigTag, T> configTag = null,
            Func<PtsChangedTag, T> ptsChangedTag = null,
            Func<ChannelWebPageTag, T> channelWebPageTag = null,
            Func<DialogPinnedTag, T> dialogPinnedTag = null,
            Func<PinnedDialogsTag, T> pinnedDialogsTag = null,
            Func<BotWebhookJsonTag, T> botWebhookJsonTag = null,
            Func<BotWebhookJsonQueryTag, T> botWebhookJsonQueryTag = null,
            Func<BotShippingQueryTag, T> botShippingQueryTag = null,
            Func<BotPrecheckoutQueryTag, T> botPrecheckoutQueryTag = null,
            Func<PhoneCallTag, T> phoneCallTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NewMessageTag x when newMessageTag != null: return newMessageTag(x);
                case MessageIdTag x when messageIdTag != null: return messageIdTag(x);
                case DeleteMessagesTag x when deleteMessagesTag != null: return deleteMessagesTag(x);
                case UserTypingTag x when userTypingTag != null: return userTypingTag(x);
                case ChatUserTypingTag x when chatUserTypingTag != null: return chatUserTypingTag(x);
                case ChatParticipantsTag x when chatParticipantsTag != null: return chatParticipantsTag(x);
                case UserStatusTag x when userStatusTag != null: return userStatusTag(x);
                case UserNameTag x when userNameTag != null: return userNameTag(x);
                case UserPhotoTag x when userPhotoTag != null: return userPhotoTag(x);
                case ContactRegisteredTag x when contactRegisteredTag != null: return contactRegisteredTag(x);
                case ContactLinkTag x when contactLinkTag != null: return contactLinkTag(x);
                case NewEncryptedMessageTag x when newEncryptedMessageTag != null: return newEncryptedMessageTag(x);
                case EncryptedChatTypingTag x when encryptedChatTypingTag != null: return encryptedChatTypingTag(x);
                case EncryptionTag x when encryptionTag != null: return encryptionTag(x);
                case EncryptedMessagesReadTag x when encryptedMessagesReadTag != null: return encryptedMessagesReadTag(x);
                case ChatParticipantAddTag x when chatParticipantAddTag != null: return chatParticipantAddTag(x);
                case ChatParticipantDeleteTag x when chatParticipantDeleteTag != null: return chatParticipantDeleteTag(x);
                case DcOptionsTag x when dcOptionsTag != null: return dcOptionsTag(x);
                case UserBlockedTag x when userBlockedTag != null: return userBlockedTag(x);
                case NotifySettingsTag x when notifySettingsTag != null: return notifySettingsTag(x);
                case ServiceNotificationTag x when serviceNotificationTag != null: return serviceNotificationTag(x);
                case PrivacyTag x when privacyTag != null: return privacyTag(x);
                case UserPhoneTag x when userPhoneTag != null: return userPhoneTag(x);
                case ReadHistoryInboxTag x when readHistoryInboxTag != null: return readHistoryInboxTag(x);
                case ReadHistoryOutboxTag x when readHistoryOutboxTag != null: return readHistoryOutboxTag(x);
                case WebPageTag x when webPageTag != null: return webPageTag(x);
                case ReadMessagesContentsTag x when readMessagesContentsTag != null: return readMessagesContentsTag(x);
                case ChannelTooLongTag x when channelTooLongTag != null: return channelTooLongTag(x);
                case ChannelTag x when channelTag != null: return channelTag(x);
                case NewChannelMessageTag x when newChannelMessageTag != null: return newChannelMessageTag(x);
                case ReadChannelInboxTag x when readChannelInboxTag != null: return readChannelInboxTag(x);
                case DeleteChannelMessagesTag x when deleteChannelMessagesTag != null: return deleteChannelMessagesTag(x);
                case ChannelMessageViewsTag x when channelMessageViewsTag != null: return channelMessageViewsTag(x);
                case ChatAdminsTag x when chatAdminsTag != null: return chatAdminsTag(x);
                case ChatParticipantAdminTag x when chatParticipantAdminTag != null: return chatParticipantAdminTag(x);
                case NewStickerSetTag x when newStickerSetTag != null: return newStickerSetTag(x);
                case StickerSetsOrderTag x when stickerSetsOrderTag != null: return stickerSetsOrderTag(x);
                case StickerSetsTag x when stickerSetsTag != null: return stickerSetsTag(x);
                case SavedGifsTag x when savedGifsTag != null: return savedGifsTag(x);
                case BotInlineQueryTag x when botInlineQueryTag != null: return botInlineQueryTag(x);
                case BotInlineSendTag x when botInlineSendTag != null: return botInlineSendTag(x);
                case EditChannelMessageTag x when editChannelMessageTag != null: return editChannelMessageTag(x);
                case ChannelPinnedMessageTag x when channelPinnedMessageTag != null: return channelPinnedMessageTag(x);
                case BotCallbackQueryTag x when botCallbackQueryTag != null: return botCallbackQueryTag(x);
                case EditMessageTag x when editMessageTag != null: return editMessageTag(x);
                case InlineBotCallbackQueryTag x when inlineBotCallbackQueryTag != null: return inlineBotCallbackQueryTag(x);
                case ReadChannelOutboxTag x when readChannelOutboxTag != null: return readChannelOutboxTag(x);
                case DraftMessageTag x when draftMessageTag != null: return draftMessageTag(x);
                case ReadFeaturedStickersTag x when readFeaturedStickersTag != null: return readFeaturedStickersTag(x);
                case RecentStickersTag x when recentStickersTag != null: return recentStickersTag(x);
                case ConfigTag x when configTag != null: return configTag(x);
                case PtsChangedTag x when ptsChangedTag != null: return ptsChangedTag(x);
                case ChannelWebPageTag x when channelWebPageTag != null: return channelWebPageTag(x);
                case DialogPinnedTag x when dialogPinnedTag != null: return dialogPinnedTag(x);
                case PinnedDialogsTag x when pinnedDialogsTag != null: return pinnedDialogsTag(x);
                case BotWebhookJsonTag x when botWebhookJsonTag != null: return botWebhookJsonTag(x);
                case BotWebhookJsonQueryTag x when botWebhookJsonQueryTag != null: return botWebhookJsonQueryTag(x);
                case BotShippingQueryTag x when botShippingQueryTag != null: return botShippingQueryTag(x);
                case BotPrecheckoutQueryTag x when botPrecheckoutQueryTag != null: return botPrecheckoutQueryTag(x);
                case PhoneCallTag x when phoneCallTag != null: return phoneCallTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NewMessageTag, T> newMessageTag,
            Func<MessageIdTag, T> messageIdTag,
            Func<DeleteMessagesTag, T> deleteMessagesTag,
            Func<UserTypingTag, T> userTypingTag,
            Func<ChatUserTypingTag, T> chatUserTypingTag,
            Func<ChatParticipantsTag, T> chatParticipantsTag,
            Func<UserStatusTag, T> userStatusTag,
            Func<UserNameTag, T> userNameTag,
            Func<UserPhotoTag, T> userPhotoTag,
            Func<ContactRegisteredTag, T> contactRegisteredTag,
            Func<ContactLinkTag, T> contactLinkTag,
            Func<NewEncryptedMessageTag, T> newEncryptedMessageTag,
            Func<EncryptedChatTypingTag, T> encryptedChatTypingTag,
            Func<EncryptionTag, T> encryptionTag,
            Func<EncryptedMessagesReadTag, T> encryptedMessagesReadTag,
            Func<ChatParticipantAddTag, T> chatParticipantAddTag,
            Func<ChatParticipantDeleteTag, T> chatParticipantDeleteTag,
            Func<DcOptionsTag, T> dcOptionsTag,
            Func<UserBlockedTag, T> userBlockedTag,
            Func<NotifySettingsTag, T> notifySettingsTag,
            Func<ServiceNotificationTag, T> serviceNotificationTag,
            Func<PrivacyTag, T> privacyTag,
            Func<UserPhoneTag, T> userPhoneTag,
            Func<ReadHistoryInboxTag, T> readHistoryInboxTag,
            Func<ReadHistoryOutboxTag, T> readHistoryOutboxTag,
            Func<WebPageTag, T> webPageTag,
            Func<ReadMessagesContentsTag, T> readMessagesContentsTag,
            Func<ChannelTooLongTag, T> channelTooLongTag,
            Func<ChannelTag, T> channelTag,
            Func<NewChannelMessageTag, T> newChannelMessageTag,
            Func<ReadChannelInboxTag, T> readChannelInboxTag,
            Func<DeleteChannelMessagesTag, T> deleteChannelMessagesTag,
            Func<ChannelMessageViewsTag, T> channelMessageViewsTag,
            Func<ChatAdminsTag, T> chatAdminsTag,
            Func<ChatParticipantAdminTag, T> chatParticipantAdminTag,
            Func<NewStickerSetTag, T> newStickerSetTag,
            Func<StickerSetsOrderTag, T> stickerSetsOrderTag,
            Func<StickerSetsTag, T> stickerSetsTag,
            Func<SavedGifsTag, T> savedGifsTag,
            Func<BotInlineQueryTag, T> botInlineQueryTag,
            Func<BotInlineSendTag, T> botInlineSendTag,
            Func<EditChannelMessageTag, T> editChannelMessageTag,
            Func<ChannelPinnedMessageTag, T> channelPinnedMessageTag,
            Func<BotCallbackQueryTag, T> botCallbackQueryTag,
            Func<EditMessageTag, T> editMessageTag,
            Func<InlineBotCallbackQueryTag, T> inlineBotCallbackQueryTag,
            Func<ReadChannelOutboxTag, T> readChannelOutboxTag,
            Func<DraftMessageTag, T> draftMessageTag,
            Func<ReadFeaturedStickersTag, T> readFeaturedStickersTag,
            Func<RecentStickersTag, T> recentStickersTag,
            Func<ConfigTag, T> configTag,
            Func<PtsChangedTag, T> ptsChangedTag,
            Func<ChannelWebPageTag, T> channelWebPageTag,
            Func<DialogPinnedTag, T> dialogPinnedTag,
            Func<PinnedDialogsTag, T> pinnedDialogsTag,
            Func<BotWebhookJsonTag, T> botWebhookJsonTag,
            Func<BotWebhookJsonQueryTag, T> botWebhookJsonQueryTag,
            Func<BotShippingQueryTag, T> botShippingQueryTag,
            Func<BotPrecheckoutQueryTag, T> botPrecheckoutQueryTag,
            Func<PhoneCallTag, T> phoneCallTag
        ) => Match(
            () => throw new Exception("WTF"),
            newMessageTag ?? throw new ArgumentNullException(nameof(newMessageTag)),
            messageIdTag ?? throw new ArgumentNullException(nameof(messageIdTag)),
            deleteMessagesTag ?? throw new ArgumentNullException(nameof(deleteMessagesTag)),
            userTypingTag ?? throw new ArgumentNullException(nameof(userTypingTag)),
            chatUserTypingTag ?? throw new ArgumentNullException(nameof(chatUserTypingTag)),
            chatParticipantsTag ?? throw new ArgumentNullException(nameof(chatParticipantsTag)),
            userStatusTag ?? throw new ArgumentNullException(nameof(userStatusTag)),
            userNameTag ?? throw new ArgumentNullException(nameof(userNameTag)),
            userPhotoTag ?? throw new ArgumentNullException(nameof(userPhotoTag)),
            contactRegisteredTag ?? throw new ArgumentNullException(nameof(contactRegisteredTag)),
            contactLinkTag ?? throw new ArgumentNullException(nameof(contactLinkTag)),
            newEncryptedMessageTag ?? throw new ArgumentNullException(nameof(newEncryptedMessageTag)),
            encryptedChatTypingTag ?? throw new ArgumentNullException(nameof(encryptedChatTypingTag)),
            encryptionTag ?? throw new ArgumentNullException(nameof(encryptionTag)),
            encryptedMessagesReadTag ?? throw new ArgumentNullException(nameof(encryptedMessagesReadTag)),
            chatParticipantAddTag ?? throw new ArgumentNullException(nameof(chatParticipantAddTag)),
            chatParticipantDeleteTag ?? throw new ArgumentNullException(nameof(chatParticipantDeleteTag)),
            dcOptionsTag ?? throw new ArgumentNullException(nameof(dcOptionsTag)),
            userBlockedTag ?? throw new ArgumentNullException(nameof(userBlockedTag)),
            notifySettingsTag ?? throw new ArgumentNullException(nameof(notifySettingsTag)),
            serviceNotificationTag ?? throw new ArgumentNullException(nameof(serviceNotificationTag)),
            privacyTag ?? throw new ArgumentNullException(nameof(privacyTag)),
            userPhoneTag ?? throw new ArgumentNullException(nameof(userPhoneTag)),
            readHistoryInboxTag ?? throw new ArgumentNullException(nameof(readHistoryInboxTag)),
            readHistoryOutboxTag ?? throw new ArgumentNullException(nameof(readHistoryOutboxTag)),
            webPageTag ?? throw new ArgumentNullException(nameof(webPageTag)),
            readMessagesContentsTag ?? throw new ArgumentNullException(nameof(readMessagesContentsTag)),
            channelTooLongTag ?? throw new ArgumentNullException(nameof(channelTooLongTag)),
            channelTag ?? throw new ArgumentNullException(nameof(channelTag)),
            newChannelMessageTag ?? throw new ArgumentNullException(nameof(newChannelMessageTag)),
            readChannelInboxTag ?? throw new ArgumentNullException(nameof(readChannelInboxTag)),
            deleteChannelMessagesTag ?? throw new ArgumentNullException(nameof(deleteChannelMessagesTag)),
            channelMessageViewsTag ?? throw new ArgumentNullException(nameof(channelMessageViewsTag)),
            chatAdminsTag ?? throw new ArgumentNullException(nameof(chatAdminsTag)),
            chatParticipantAdminTag ?? throw new ArgumentNullException(nameof(chatParticipantAdminTag)),
            newStickerSetTag ?? throw new ArgumentNullException(nameof(newStickerSetTag)),
            stickerSetsOrderTag ?? throw new ArgumentNullException(nameof(stickerSetsOrderTag)),
            stickerSetsTag ?? throw new ArgumentNullException(nameof(stickerSetsTag)),
            savedGifsTag ?? throw new ArgumentNullException(nameof(savedGifsTag)),
            botInlineQueryTag ?? throw new ArgumentNullException(nameof(botInlineQueryTag)),
            botInlineSendTag ?? throw new ArgumentNullException(nameof(botInlineSendTag)),
            editChannelMessageTag ?? throw new ArgumentNullException(nameof(editChannelMessageTag)),
            channelPinnedMessageTag ?? throw new ArgumentNullException(nameof(channelPinnedMessageTag)),
            botCallbackQueryTag ?? throw new ArgumentNullException(nameof(botCallbackQueryTag)),
            editMessageTag ?? throw new ArgumentNullException(nameof(editMessageTag)),
            inlineBotCallbackQueryTag ?? throw new ArgumentNullException(nameof(inlineBotCallbackQueryTag)),
            readChannelOutboxTag ?? throw new ArgumentNullException(nameof(readChannelOutboxTag)),
            draftMessageTag ?? throw new ArgumentNullException(nameof(draftMessageTag)),
            readFeaturedStickersTag ?? throw new ArgumentNullException(nameof(readFeaturedStickersTag)),
            recentStickersTag ?? throw new ArgumentNullException(nameof(recentStickersTag)),
            configTag ?? throw new ArgumentNullException(nameof(configTag)),
            ptsChangedTag ?? throw new ArgumentNullException(nameof(ptsChangedTag)),
            channelWebPageTag ?? throw new ArgumentNullException(nameof(channelWebPageTag)),
            dialogPinnedTag ?? throw new ArgumentNullException(nameof(dialogPinnedTag)),
            pinnedDialogsTag ?? throw new ArgumentNullException(nameof(pinnedDialogsTag)),
            botWebhookJsonTag ?? throw new ArgumentNullException(nameof(botWebhookJsonTag)),
            botWebhookJsonQueryTag ?? throw new ArgumentNullException(nameof(botWebhookJsonQueryTag)),
            botShippingQueryTag ?? throw new ArgumentNullException(nameof(botShippingQueryTag)),
            botPrecheckoutQueryTag ?? throw new ArgumentNullException(nameof(botPrecheckoutQueryTag)),
            phoneCallTag ?? throw new ArgumentNullException(nameof(phoneCallTag))
        );

        public bool Equals(Update other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Update x && Equals(x);
        public static bool operator ==(Update a, Update b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Update a, Update b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NewMessageTag _: return 0;
                case MessageIdTag _: return 1;
                case DeleteMessagesTag _: return 2;
                case UserTypingTag _: return 3;
                case ChatUserTypingTag _: return 4;
                case ChatParticipantsTag _: return 5;
                case UserStatusTag _: return 6;
                case UserNameTag _: return 7;
                case UserPhotoTag _: return 8;
                case ContactRegisteredTag _: return 9;
                case ContactLinkTag _: return 10;
                case NewEncryptedMessageTag _: return 11;
                case EncryptedChatTypingTag _: return 12;
                case EncryptionTag _: return 13;
                case EncryptedMessagesReadTag _: return 14;
                case ChatParticipantAddTag _: return 15;
                case ChatParticipantDeleteTag _: return 16;
                case DcOptionsTag _: return 17;
                case UserBlockedTag _: return 18;
                case NotifySettingsTag _: return 19;
                case ServiceNotificationTag _: return 20;
                case PrivacyTag _: return 21;
                case UserPhoneTag _: return 22;
                case ReadHistoryInboxTag _: return 23;
                case ReadHistoryOutboxTag _: return 24;
                case WebPageTag _: return 25;
                case ReadMessagesContentsTag _: return 26;
                case ChannelTooLongTag _: return 27;
                case ChannelTag _: return 28;
                case NewChannelMessageTag _: return 29;
                case ReadChannelInboxTag _: return 30;
                case DeleteChannelMessagesTag _: return 31;
                case ChannelMessageViewsTag _: return 32;
                case ChatAdminsTag _: return 33;
                case ChatParticipantAdminTag _: return 34;
                case NewStickerSetTag _: return 35;
                case StickerSetsOrderTag _: return 36;
                case StickerSetsTag _: return 37;
                case SavedGifsTag _: return 38;
                case BotInlineQueryTag _: return 39;
                case BotInlineSendTag _: return 40;
                case EditChannelMessageTag _: return 41;
                case ChannelPinnedMessageTag _: return 42;
                case BotCallbackQueryTag _: return 43;
                case EditMessageTag _: return 44;
                case InlineBotCallbackQueryTag _: return 45;
                case ReadChannelOutboxTag _: return 46;
                case DraftMessageTag _: return 47;
                case ReadFeaturedStickersTag _: return 48;
                case RecentStickersTag _: return 49;
                case ConfigTag _: return 50;
                case PtsChangedTag _: return 51;
                case ChannelWebPageTag _: return 52;
                case DialogPinnedTag _: return 53;
                case PinnedDialogsTag _: return 54;
                case BotWebhookJsonTag _: return 55;
                case BotWebhookJsonQueryTag _: return 56;
                case BotShippingQueryTag _: return 57;
                case BotPrecheckoutQueryTag _: return 58;
                case PhoneCallTag _: return 59;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Update other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Update x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Update a, Update b) => a.CompareTo(b) <= 0;
        public static bool operator <(Update a, Update b) => a.CompareTo(b) < 0;
        public static bool operator >(Update a, Update b) => a.CompareTo(b) > 0;
        public static bool operator >=(Update a, Update b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}