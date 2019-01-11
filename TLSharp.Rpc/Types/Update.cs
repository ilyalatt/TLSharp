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
        public sealed class NewMessageTag : ITlTypeTag, IEquatable<NewMessageTag>, IComparable<NewMessageTag>, IComparable
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
            
            (T.Message, int, int) CmpTuple =>
                (Message, Pts, PtsCount);

            public bool Equals(NewMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NewMessageTag x && Equals(x);
            public static bool operator ==(NewMessageTag x, NewMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NewMessageTag x, NewMessageTag y) => !(x == y);

            public int CompareTo(NewMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NewMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NewMessageTag x, NewMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NewMessageTag x, NewMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NewMessageTag x, NewMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NewMessageTag x, NewMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class MessageIdTag : ITlTypeTag, IEquatable<MessageIdTag>, IComparable<MessageIdTag>, IComparable
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
            
            (int, long) CmpTuple =>
                (Id, RandomId);

            public bool Equals(MessageIdTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MessageIdTag x && Equals(x);
            public static bool operator ==(MessageIdTag x, MessageIdTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MessageIdTag x, MessageIdTag y) => !(x == y);

            public int CompareTo(MessageIdTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is MessageIdTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MessageIdTag x, MessageIdTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MessageIdTag x, MessageIdTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MessageIdTag x, MessageIdTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MessageIdTag x, MessageIdTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, RandomId: {RandomId})";
            
            
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

        public sealed class DeleteMessagesTag : ITlTypeTag, IEquatable<DeleteMessagesTag>, IComparable<DeleteMessagesTag>, IComparable
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
            
            (Arr<int>, int, int) CmpTuple =>
                (Messages, Pts, PtsCount);

            public bool Equals(DeleteMessagesTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DeleteMessagesTag x && Equals(x);
            public static bool operator ==(DeleteMessagesTag x, DeleteMessagesTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DeleteMessagesTag x, DeleteMessagesTag y) => !(x == y);

            public int CompareTo(DeleteMessagesTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DeleteMessagesTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DeleteMessagesTag x, DeleteMessagesTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DeleteMessagesTag x, DeleteMessagesTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DeleteMessagesTag x, DeleteMessagesTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DeleteMessagesTag x, DeleteMessagesTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Messages: {Messages}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class UserTypingTag : ITlTypeTag, IEquatable<UserTypingTag>, IComparable<UserTypingTag>, IComparable
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
            
            (int, T.SendMessageAction) CmpTuple =>
                (UserId, Action);

            public bool Equals(UserTypingTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserTypingTag x && Equals(x);
            public static bool operator ==(UserTypingTag x, UserTypingTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserTypingTag x, UserTypingTag y) => !(x == y);

            public int CompareTo(UserTypingTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserTypingTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserTypingTag x, UserTypingTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserTypingTag x, UserTypingTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserTypingTag x, UserTypingTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserTypingTag x, UserTypingTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Action: {Action})";
            
            
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

        public sealed class ChatUserTypingTag : ITlTypeTag, IEquatable<ChatUserTypingTag>, IComparable<ChatUserTypingTag>, IComparable
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
            
            (int, int, T.SendMessageAction) CmpTuple =>
                (ChatId, UserId, Action);

            public bool Equals(ChatUserTypingTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatUserTypingTag x && Equals(x);
            public static bool operator ==(ChatUserTypingTag x, ChatUserTypingTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatUserTypingTag x, ChatUserTypingTag y) => !(x == y);

            public int CompareTo(ChatUserTypingTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatUserTypingTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatUserTypingTag x, ChatUserTypingTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatUserTypingTag x, ChatUserTypingTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatUserTypingTag x, ChatUserTypingTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatUserTypingTag x, ChatUserTypingTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId}, Action: {Action})";
            
            
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

        public sealed class ChatParticipantsTag : ITlTypeTag, IEquatable<ChatParticipantsTag>, IComparable<ChatParticipantsTag>, IComparable
        {
            internal const uint TypeNumber = 0x07761198;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.ChatParticipants Participants { get; }
            
            public ChatParticipantsTag(
                Some<T.ChatParticipants> participants
            ) {
                Participants = participants;
            }
            
            T.ChatParticipants CmpTuple =>
                Participants;

            public bool Equals(ChatParticipantsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatParticipantsTag x && Equals(x);
            public static bool operator ==(ChatParticipantsTag x, ChatParticipantsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatParticipantsTag x, ChatParticipantsTag y) => !(x == y);

            public int CompareTo(ChatParticipantsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatParticipantsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatParticipantsTag x, ChatParticipantsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatParticipantsTag x, ChatParticipantsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatParticipantsTag x, ChatParticipantsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatParticipantsTag x, ChatParticipantsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Participants: {Participants})";
            
            
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

        public sealed class UserStatusTag : ITlTypeTag, IEquatable<UserStatusTag>, IComparable<UserStatusTag>, IComparable
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
            
            (int, T.UserStatus) CmpTuple =>
                (UserId, Status);

            public bool Equals(UserStatusTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserStatusTag x && Equals(x);
            public static bool operator ==(UserStatusTag x, UserStatusTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserStatusTag x, UserStatusTag y) => !(x == y);

            public int CompareTo(UserStatusTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserStatusTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserStatusTag x, UserStatusTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserStatusTag x, UserStatusTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserStatusTag x, UserStatusTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserStatusTag x, UserStatusTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Status: {Status})";
            
            
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

        public sealed class UserNameTag : ITlTypeTag, IEquatable<UserNameTag>, IComparable<UserNameTag>, IComparable
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
            
            (int, string, string, string) CmpTuple =>
                (UserId, FirstName, LastName, Username);

            public bool Equals(UserNameTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserNameTag x && Equals(x);
            public static bool operator ==(UserNameTag x, UserNameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserNameTag x, UserNameTag y) => !(x == y);

            public int CompareTo(UserNameTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserNameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserNameTag x, UserNameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserNameTag x, UserNameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserNameTag x, UserNameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserNameTag x, UserNameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, FirstName: {FirstName}, LastName: {LastName}, Username: {Username})";
            
            
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

        public sealed class UserPhotoTag : ITlTypeTag, IEquatable<UserPhotoTag>, IComparable<UserPhotoTag>, IComparable
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
            
            (int, int, T.UserProfilePhoto, bool) CmpTuple =>
                (UserId, Date, Photo, Previous);

            public bool Equals(UserPhotoTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserPhotoTag x && Equals(x);
            public static bool operator ==(UserPhotoTag x, UserPhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserPhotoTag x, UserPhotoTag y) => !(x == y);

            public int CompareTo(UserPhotoTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserPhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserPhotoTag x, UserPhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserPhotoTag x, UserPhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserPhotoTag x, UserPhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserPhotoTag x, UserPhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Date: {Date}, Photo: {Photo}, Previous: {Previous})";
            
            
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

        public sealed class ContactRegisteredTag : ITlTypeTag, IEquatable<ContactRegisteredTag>, IComparable<ContactRegisteredTag>, IComparable
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
            
            (int, int) CmpTuple =>
                (UserId, Date);

            public bool Equals(ContactRegisteredTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ContactRegisteredTag x && Equals(x);
            public static bool operator ==(ContactRegisteredTag x, ContactRegisteredTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ContactRegisteredTag x, ContactRegisteredTag y) => !(x == y);

            public int CompareTo(ContactRegisteredTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ContactRegisteredTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ContactRegisteredTag x, ContactRegisteredTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ContactRegisteredTag x, ContactRegisteredTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ContactRegisteredTag x, ContactRegisteredTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ContactRegisteredTag x, ContactRegisteredTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Date: {Date})";
            
            
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

        public sealed class ContactLinkTag : ITlTypeTag, IEquatable<ContactLinkTag>, IComparable<ContactLinkTag>, IComparable
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
            
            (int, T.ContactLink, T.ContactLink) CmpTuple =>
                (UserId, MyLink, ForeignLink);

            public bool Equals(ContactLinkTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ContactLinkTag x && Equals(x);
            public static bool operator ==(ContactLinkTag x, ContactLinkTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ContactLinkTag x, ContactLinkTag y) => !(x == y);

            public int CompareTo(ContactLinkTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ContactLinkTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ContactLinkTag x, ContactLinkTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ContactLinkTag x, ContactLinkTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ContactLinkTag x, ContactLinkTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ContactLinkTag x, ContactLinkTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, MyLink: {MyLink}, ForeignLink: {ForeignLink})";
            
            
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

        public sealed class NewEncryptedMessageTag : ITlTypeTag, IEquatable<NewEncryptedMessageTag>, IComparable<NewEncryptedMessageTag>, IComparable
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
            
            (T.EncryptedMessage, int) CmpTuple =>
                (Message, Qts);

            public bool Equals(NewEncryptedMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NewEncryptedMessageTag x && Equals(x);
            public static bool operator ==(NewEncryptedMessageTag x, NewEncryptedMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NewEncryptedMessageTag x, NewEncryptedMessageTag y) => !(x == y);

            public int CompareTo(NewEncryptedMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NewEncryptedMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NewEncryptedMessageTag x, NewEncryptedMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NewEncryptedMessageTag x, NewEncryptedMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NewEncryptedMessageTag x, NewEncryptedMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NewEncryptedMessageTag x, NewEncryptedMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message}, Qts: {Qts})";
            
            
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

        public sealed class EncryptedChatTypingTag : ITlTypeTag, IEquatable<EncryptedChatTypingTag>, IComparable<EncryptedChatTypingTag>, IComparable
        {
            internal const uint TypeNumber = 0x1710f156;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChatId { get; }
            
            public EncryptedChatTypingTag(
                int chatId
            ) {
                ChatId = chatId;
            }
            
            int CmpTuple =>
                ChatId;

            public bool Equals(EncryptedChatTypingTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EncryptedChatTypingTag x && Equals(x);
            public static bool operator ==(EncryptedChatTypingTag x, EncryptedChatTypingTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EncryptedChatTypingTag x, EncryptedChatTypingTag y) => !(x == y);

            public int CompareTo(EncryptedChatTypingTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EncryptedChatTypingTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EncryptedChatTypingTag x, EncryptedChatTypingTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EncryptedChatTypingTag x, EncryptedChatTypingTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EncryptedChatTypingTag x, EncryptedChatTypingTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EncryptedChatTypingTag x, EncryptedChatTypingTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId})";
            
            
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

        public sealed class EncryptionTag : ITlTypeTag, IEquatable<EncryptionTag>, IComparable<EncryptionTag>, IComparable
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
            
            (T.EncryptedChat, int) CmpTuple =>
                (Chat, Date);

            public bool Equals(EncryptionTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EncryptionTag x && Equals(x);
            public static bool operator ==(EncryptionTag x, EncryptionTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EncryptionTag x, EncryptionTag y) => !(x == y);

            public int CompareTo(EncryptionTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EncryptionTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EncryptionTag x, EncryptionTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EncryptionTag x, EncryptionTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EncryptionTag x, EncryptionTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EncryptionTag x, EncryptionTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Chat: {Chat}, Date: {Date})";
            
            
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

        public sealed class EncryptedMessagesReadTag : ITlTypeTag, IEquatable<EncryptedMessagesReadTag>, IComparable<EncryptedMessagesReadTag>, IComparable
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
            
            (int, int, int) CmpTuple =>
                (ChatId, MaxDate, Date);

            public bool Equals(EncryptedMessagesReadTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EncryptedMessagesReadTag x && Equals(x);
            public static bool operator ==(EncryptedMessagesReadTag x, EncryptedMessagesReadTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EncryptedMessagesReadTag x, EncryptedMessagesReadTag y) => !(x == y);

            public int CompareTo(EncryptedMessagesReadTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EncryptedMessagesReadTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EncryptedMessagesReadTag x, EncryptedMessagesReadTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EncryptedMessagesReadTag x, EncryptedMessagesReadTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EncryptedMessagesReadTag x, EncryptedMessagesReadTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EncryptedMessagesReadTag x, EncryptedMessagesReadTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, MaxDate: {MaxDate}, Date: {Date})";
            
            
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

        public sealed class ChatParticipantAddTag : ITlTypeTag, IEquatable<ChatParticipantAddTag>, IComparable<ChatParticipantAddTag>, IComparable
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
            
            (int, int, int, int, int) CmpTuple =>
                (ChatId, UserId, InviterId, Date, Version);

            public bool Equals(ChatParticipantAddTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatParticipantAddTag x && Equals(x);
            public static bool operator ==(ChatParticipantAddTag x, ChatParticipantAddTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatParticipantAddTag x, ChatParticipantAddTag y) => !(x == y);

            public int CompareTo(ChatParticipantAddTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatParticipantAddTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatParticipantAddTag x, ChatParticipantAddTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatParticipantAddTag x, ChatParticipantAddTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatParticipantAddTag x, ChatParticipantAddTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatParticipantAddTag x, ChatParticipantAddTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId}, InviterId: {InviterId}, Date: {Date}, Version: {Version})";
            
            
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

        public sealed class ChatParticipantDeleteTag : ITlTypeTag, IEquatable<ChatParticipantDeleteTag>, IComparable<ChatParticipantDeleteTag>, IComparable
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
            
            (int, int, int) CmpTuple =>
                (ChatId, UserId, Version);

            public bool Equals(ChatParticipantDeleteTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatParticipantDeleteTag x && Equals(x);
            public static bool operator ==(ChatParticipantDeleteTag x, ChatParticipantDeleteTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatParticipantDeleteTag x, ChatParticipantDeleteTag y) => !(x == y);

            public int CompareTo(ChatParticipantDeleteTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatParticipantDeleteTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatParticipantDeleteTag x, ChatParticipantDeleteTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatParticipantDeleteTag x, ChatParticipantDeleteTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatParticipantDeleteTag x, ChatParticipantDeleteTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatParticipantDeleteTag x, ChatParticipantDeleteTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId}, Version: {Version})";
            
            
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

        public sealed class DcOptionsTag : ITlTypeTag, IEquatable<DcOptionsTag>, IComparable<DcOptionsTag>, IComparable
        {
            internal const uint TypeNumber = 0x8e5e9873;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.DcOption> DcOptions { get; }
            
            public DcOptionsTag(
                Some<Arr<T.DcOption>> dcOptions
            ) {
                DcOptions = dcOptions;
            }
            
            Arr<T.DcOption> CmpTuple =>
                DcOptions;

            public bool Equals(DcOptionsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DcOptionsTag x && Equals(x);
            public static bool operator ==(DcOptionsTag x, DcOptionsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DcOptionsTag x, DcOptionsTag y) => !(x == y);

            public int CompareTo(DcOptionsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DcOptionsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DcOptionsTag x, DcOptionsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DcOptionsTag x, DcOptionsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DcOptionsTag x, DcOptionsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DcOptionsTag x, DcOptionsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(DcOptions: {DcOptions})";
            
            
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

        public sealed class UserBlockedTag : ITlTypeTag, IEquatable<UserBlockedTag>, IComparable<UserBlockedTag>, IComparable
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
            
            (int, bool) CmpTuple =>
                (UserId, Blocked);

            public bool Equals(UserBlockedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserBlockedTag x && Equals(x);
            public static bool operator ==(UserBlockedTag x, UserBlockedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserBlockedTag x, UserBlockedTag y) => !(x == y);

            public int CompareTo(UserBlockedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserBlockedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserBlockedTag x, UserBlockedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserBlockedTag x, UserBlockedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserBlockedTag x, UserBlockedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserBlockedTag x, UserBlockedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Blocked: {Blocked})";
            
            
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

        public sealed class NotifySettingsTag : ITlTypeTag, IEquatable<NotifySettingsTag>, IComparable<NotifySettingsTag>, IComparable
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
            
            (T.NotifyPeer, T.PeerNotifySettings) CmpTuple =>
                (Peer, NotifySettings);

            public bool Equals(NotifySettingsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NotifySettingsTag x && Equals(x);
            public static bool operator ==(NotifySettingsTag x, NotifySettingsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NotifySettingsTag x, NotifySettingsTag y) => !(x == y);

            public int CompareTo(NotifySettingsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NotifySettingsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NotifySettingsTag x, NotifySettingsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NotifySettingsTag x, NotifySettingsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NotifySettingsTag x, NotifySettingsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NotifySettingsTag x, NotifySettingsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Peer: {Peer}, NotifySettings: {NotifySettings})";
            
            
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

        public sealed class ServiceNotificationTag : ITlTypeTag, IEquatable<ServiceNotificationTag>, IComparable<ServiceNotificationTag>, IComparable
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
            
            (bool, Option<int>, string, string, T.MessageMedia, Arr<T.MessageEntity>) CmpTuple =>
                (Popup, InboxDate, Type, Message, Media, Entities);

            public bool Equals(ServiceNotificationTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ServiceNotificationTag x && Equals(x);
            public static bool operator ==(ServiceNotificationTag x, ServiceNotificationTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ServiceNotificationTag x, ServiceNotificationTag y) => !(x == y);

            public int CompareTo(ServiceNotificationTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ServiceNotificationTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ServiceNotificationTag x, ServiceNotificationTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ServiceNotificationTag x, ServiceNotificationTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ServiceNotificationTag x, ServiceNotificationTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ServiceNotificationTag x, ServiceNotificationTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Popup: {Popup}, InboxDate: {InboxDate}, Type: {Type}, Message: {Message}, Media: {Media}, Entities: {Entities})";
            
            
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

        public sealed class PrivacyTag : ITlTypeTag, IEquatable<PrivacyTag>, IComparable<PrivacyTag>, IComparable
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
            
            (T.PrivacyKey, Arr<T.PrivacyRule>) CmpTuple =>
                (Key, Rules);

            public bool Equals(PrivacyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PrivacyTag x && Equals(x);
            public static bool operator ==(PrivacyTag x, PrivacyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PrivacyTag x, PrivacyTag y) => !(x == y);

            public int CompareTo(PrivacyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PrivacyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PrivacyTag x, PrivacyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PrivacyTag x, PrivacyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PrivacyTag x, PrivacyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PrivacyTag x, PrivacyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Key: {Key}, Rules: {Rules})";
            
            
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

        public sealed class UserPhoneTag : ITlTypeTag, IEquatable<UserPhoneTag>, IComparable<UserPhoneTag>, IComparable
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
            
            (int, string) CmpTuple =>
                (UserId, Phone);

            public bool Equals(UserPhoneTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is UserPhoneTag x && Equals(x);
            public static bool operator ==(UserPhoneTag x, UserPhoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserPhoneTag x, UserPhoneTag y) => !(x == y);

            public int CompareTo(UserPhoneTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is UserPhoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserPhoneTag x, UserPhoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserPhoneTag x, UserPhoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserPhoneTag x, UserPhoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserPhoneTag x, UserPhoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Phone: {Phone})";
            
            
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

        public sealed class ReadHistoryInboxTag : ITlTypeTag, IEquatable<ReadHistoryInboxTag>, IComparable<ReadHistoryInboxTag>, IComparable
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
            
            (T.Peer, int, int, int) CmpTuple =>
                (Peer, MaxId, Pts, PtsCount);

            public bool Equals(ReadHistoryInboxTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ReadHistoryInboxTag x && Equals(x);
            public static bool operator ==(ReadHistoryInboxTag x, ReadHistoryInboxTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReadHistoryInboxTag x, ReadHistoryInboxTag y) => !(x == y);

            public int CompareTo(ReadHistoryInboxTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ReadHistoryInboxTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReadHistoryInboxTag x, ReadHistoryInboxTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReadHistoryInboxTag x, ReadHistoryInboxTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReadHistoryInboxTag x, ReadHistoryInboxTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReadHistoryInboxTag x, ReadHistoryInboxTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Peer: {Peer}, MaxId: {MaxId}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class ReadHistoryOutboxTag : ITlTypeTag, IEquatable<ReadHistoryOutboxTag>, IComparable<ReadHistoryOutboxTag>, IComparable
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
            
            (T.Peer, int, int, int) CmpTuple =>
                (Peer, MaxId, Pts, PtsCount);

            public bool Equals(ReadHistoryOutboxTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ReadHistoryOutboxTag x && Equals(x);
            public static bool operator ==(ReadHistoryOutboxTag x, ReadHistoryOutboxTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReadHistoryOutboxTag x, ReadHistoryOutboxTag y) => !(x == y);

            public int CompareTo(ReadHistoryOutboxTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ReadHistoryOutboxTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReadHistoryOutboxTag x, ReadHistoryOutboxTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReadHistoryOutboxTag x, ReadHistoryOutboxTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReadHistoryOutboxTag x, ReadHistoryOutboxTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReadHistoryOutboxTag x, ReadHistoryOutboxTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Peer: {Peer}, MaxId: {MaxId}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class WebPageTag : ITlTypeTag, IEquatable<WebPageTag>, IComparable<WebPageTag>, IComparable
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
            
            (T.WebPage, int, int) CmpTuple =>
                (Webpage, Pts, PtsCount);

            public bool Equals(WebPageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is WebPageTag x && Equals(x);
            public static bool operator ==(WebPageTag x, WebPageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(WebPageTag x, WebPageTag y) => !(x == y);

            public int CompareTo(WebPageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is WebPageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(WebPageTag x, WebPageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(WebPageTag x, WebPageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(WebPageTag x, WebPageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(WebPageTag x, WebPageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Webpage: {Webpage}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class ReadMessagesContentsTag : ITlTypeTag, IEquatable<ReadMessagesContentsTag>, IComparable<ReadMessagesContentsTag>, IComparable
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
            
            (Arr<int>, int, int) CmpTuple =>
                (Messages, Pts, PtsCount);

            public bool Equals(ReadMessagesContentsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ReadMessagesContentsTag x && Equals(x);
            public static bool operator ==(ReadMessagesContentsTag x, ReadMessagesContentsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReadMessagesContentsTag x, ReadMessagesContentsTag y) => !(x == y);

            public int CompareTo(ReadMessagesContentsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ReadMessagesContentsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReadMessagesContentsTag x, ReadMessagesContentsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReadMessagesContentsTag x, ReadMessagesContentsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReadMessagesContentsTag x, ReadMessagesContentsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReadMessagesContentsTag x, ReadMessagesContentsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Messages: {Messages}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class ChannelTooLongTag : ITlTypeTag, IEquatable<ChannelTooLongTag>, IComparable<ChannelTooLongTag>, IComparable
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
            
            (int, Option<int>) CmpTuple =>
                (ChannelId, Pts);

            public bool Equals(ChannelTooLongTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelTooLongTag x && Equals(x);
            public static bool operator ==(ChannelTooLongTag x, ChannelTooLongTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelTooLongTag x, ChannelTooLongTag y) => !(x == y);

            public int CompareTo(ChannelTooLongTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelTooLongTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelTooLongTag x, ChannelTooLongTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelTooLongTag x, ChannelTooLongTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelTooLongTag x, ChannelTooLongTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelTooLongTag x, ChannelTooLongTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, Pts: {Pts})";
            
            
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

        public sealed class ChannelTag : ITlTypeTag, IEquatable<ChannelTag>, IComparable<ChannelTag>, IComparable
        {
            internal const uint TypeNumber = 0xb6d45656;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            
            public ChannelTag(
                int channelId
            ) {
                ChannelId = channelId;
            }
            
            int CmpTuple =>
                ChannelId;

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

            public override string ToString() => $"(ChannelId: {ChannelId})";
            
            
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

        public sealed class NewChannelMessageTag : ITlTypeTag, IEquatable<NewChannelMessageTag>, IComparable<NewChannelMessageTag>, IComparable
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
            
            (T.Message, int, int) CmpTuple =>
                (Message, Pts, PtsCount);

            public bool Equals(NewChannelMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NewChannelMessageTag x && Equals(x);
            public static bool operator ==(NewChannelMessageTag x, NewChannelMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NewChannelMessageTag x, NewChannelMessageTag y) => !(x == y);

            public int CompareTo(NewChannelMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NewChannelMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NewChannelMessageTag x, NewChannelMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NewChannelMessageTag x, NewChannelMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NewChannelMessageTag x, NewChannelMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NewChannelMessageTag x, NewChannelMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class ReadChannelInboxTag : ITlTypeTag, IEquatable<ReadChannelInboxTag>, IComparable<ReadChannelInboxTag>, IComparable
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
            
            (int, int) CmpTuple =>
                (ChannelId, MaxId);

            public bool Equals(ReadChannelInboxTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ReadChannelInboxTag x && Equals(x);
            public static bool operator ==(ReadChannelInboxTag x, ReadChannelInboxTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReadChannelInboxTag x, ReadChannelInboxTag y) => !(x == y);

            public int CompareTo(ReadChannelInboxTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ReadChannelInboxTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReadChannelInboxTag x, ReadChannelInboxTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReadChannelInboxTag x, ReadChannelInboxTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReadChannelInboxTag x, ReadChannelInboxTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReadChannelInboxTag x, ReadChannelInboxTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, MaxId: {MaxId})";
            
            
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

        public sealed class DeleteChannelMessagesTag : ITlTypeTag, IEquatable<DeleteChannelMessagesTag>, IComparable<DeleteChannelMessagesTag>, IComparable
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
            
            (int, Arr<int>, int, int) CmpTuple =>
                (ChannelId, Messages, Pts, PtsCount);

            public bool Equals(DeleteChannelMessagesTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DeleteChannelMessagesTag x && Equals(x);
            public static bool operator ==(DeleteChannelMessagesTag x, DeleteChannelMessagesTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DeleteChannelMessagesTag x, DeleteChannelMessagesTag y) => !(x == y);

            public int CompareTo(DeleteChannelMessagesTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DeleteChannelMessagesTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DeleteChannelMessagesTag x, DeleteChannelMessagesTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DeleteChannelMessagesTag x, DeleteChannelMessagesTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DeleteChannelMessagesTag x, DeleteChannelMessagesTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DeleteChannelMessagesTag x, DeleteChannelMessagesTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, Messages: {Messages}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class ChannelMessageViewsTag : ITlTypeTag, IEquatable<ChannelMessageViewsTag>, IComparable<ChannelMessageViewsTag>, IComparable
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
            
            (int, int, int) CmpTuple =>
                (ChannelId, Id, Views);

            public bool Equals(ChannelMessageViewsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelMessageViewsTag x && Equals(x);
            public static bool operator ==(ChannelMessageViewsTag x, ChannelMessageViewsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelMessageViewsTag x, ChannelMessageViewsTag y) => !(x == y);

            public int CompareTo(ChannelMessageViewsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelMessageViewsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelMessageViewsTag x, ChannelMessageViewsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelMessageViewsTag x, ChannelMessageViewsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelMessageViewsTag x, ChannelMessageViewsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelMessageViewsTag x, ChannelMessageViewsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, Id: {Id}, Views: {Views})";
            
            
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

        public sealed class ChatAdminsTag : ITlTypeTag, IEquatable<ChatAdminsTag>, IComparable<ChatAdminsTag>, IComparable
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
            
            (int, bool, int) CmpTuple =>
                (ChatId, Enabled, Version);

            public bool Equals(ChatAdminsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatAdminsTag x && Equals(x);
            public static bool operator ==(ChatAdminsTag x, ChatAdminsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatAdminsTag x, ChatAdminsTag y) => !(x == y);

            public int CompareTo(ChatAdminsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatAdminsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatAdminsTag x, ChatAdminsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatAdminsTag x, ChatAdminsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatAdminsTag x, ChatAdminsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatAdminsTag x, ChatAdminsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, Enabled: {Enabled}, Version: {Version})";
            
            
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

        public sealed class ChatParticipantAdminTag : ITlTypeTag, IEquatable<ChatParticipantAdminTag>, IComparable<ChatParticipantAdminTag>, IComparable
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
            
            (int, int, bool, int) CmpTuple =>
                (ChatId, UserId, IsAdmin, Version);

            public bool Equals(ChatParticipantAdminTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChatParticipantAdminTag x && Equals(x);
            public static bool operator ==(ChatParticipantAdminTag x, ChatParticipantAdminTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatParticipantAdminTag x, ChatParticipantAdminTag y) => !(x == y);

            public int CompareTo(ChatParticipantAdminTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChatParticipantAdminTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatParticipantAdminTag x, ChatParticipantAdminTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatParticipantAdminTag x, ChatParticipantAdminTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatParticipantAdminTag x, ChatParticipantAdminTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatParticipantAdminTag x, ChatParticipantAdminTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChatId: {ChatId}, UserId: {UserId}, IsAdmin: {IsAdmin}, Version: {Version})";
            
            
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

        public sealed class NewStickerSetTag : ITlTypeTag, IEquatable<NewStickerSetTag>, IComparable<NewStickerSetTag>, IComparable
        {
            internal const uint TypeNumber = 0x688a30aa;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Messages.StickerSet Stickerset { get; }
            
            public NewStickerSetTag(
                Some<T.Messages.StickerSet> stickerset
            ) {
                Stickerset = stickerset;
            }
            
            T.Messages.StickerSet CmpTuple =>
                Stickerset;

            public bool Equals(NewStickerSetTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NewStickerSetTag x && Equals(x);
            public static bool operator ==(NewStickerSetTag x, NewStickerSetTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NewStickerSetTag x, NewStickerSetTag y) => !(x == y);

            public int CompareTo(NewStickerSetTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NewStickerSetTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NewStickerSetTag x, NewStickerSetTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NewStickerSetTag x, NewStickerSetTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NewStickerSetTag x, NewStickerSetTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NewStickerSetTag x, NewStickerSetTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Stickerset: {Stickerset})";
            
            
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

        public sealed class StickerSetsOrderTag : ITlTypeTag, IEquatable<StickerSetsOrderTag>, IComparable<StickerSetsOrderTag>, IComparable
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
            
            (bool, Arr<long>) CmpTuple =>
                (Masks, Order);

            public bool Equals(StickerSetsOrderTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is StickerSetsOrderTag x && Equals(x);
            public static bool operator ==(StickerSetsOrderTag x, StickerSetsOrderTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(StickerSetsOrderTag x, StickerSetsOrderTag y) => !(x == y);

            public int CompareTo(StickerSetsOrderTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is StickerSetsOrderTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(StickerSetsOrderTag x, StickerSetsOrderTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(StickerSetsOrderTag x, StickerSetsOrderTag y) => x.CompareTo(y) < 0;
            public static bool operator >(StickerSetsOrderTag x, StickerSetsOrderTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(StickerSetsOrderTag x, StickerSetsOrderTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Masks: {Masks}, Order: {Order})";
            
            
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

        public sealed class StickerSetsTag : ITlTypeTag, IEquatable<StickerSetsTag>, IComparable<StickerSetsTag>, IComparable
        {
            internal const uint TypeNumber = 0x43ae3dec;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public StickerSetsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(StickerSetsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is StickerSetsTag x && Equals(x);
            public static bool operator ==(StickerSetsTag x, StickerSetsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(StickerSetsTag x, StickerSetsTag y) => !(x == y);

            public int CompareTo(StickerSetsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is StickerSetsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(StickerSetsTag x, StickerSetsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(StickerSetsTag x, StickerSetsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(StickerSetsTag x, StickerSetsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(StickerSetsTag x, StickerSetsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static StickerSetsTag DeserializeTag(BinaryReader br)
            {

                return new StickerSetsTag();
            }
        }

        public sealed class SavedGifsTag : ITlTypeTag, IEquatable<SavedGifsTag>, IComparable<SavedGifsTag>, IComparable
        {
            internal const uint TypeNumber = 0x9375341e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SavedGifsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(SavedGifsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SavedGifsTag x && Equals(x);
            public static bool operator ==(SavedGifsTag x, SavedGifsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SavedGifsTag x, SavedGifsTag y) => !(x == y);

            public int CompareTo(SavedGifsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SavedGifsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SavedGifsTag x, SavedGifsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SavedGifsTag x, SavedGifsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SavedGifsTag x, SavedGifsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SavedGifsTag x, SavedGifsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SavedGifsTag DeserializeTag(BinaryReader br)
            {

                return new SavedGifsTag();
            }
        }

        public sealed class BotInlineQueryTag : ITlTypeTag, IEquatable<BotInlineQueryTag>, IComparable<BotInlineQueryTag>, IComparable
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
            
            (long, int, string, Option<T.GeoPoint>, string) CmpTuple =>
                (QueryId, UserId, Query, Geo, Offset);

            public bool Equals(BotInlineQueryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotInlineQueryTag x && Equals(x);
            public static bool operator ==(BotInlineQueryTag x, BotInlineQueryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotInlineQueryTag x, BotInlineQueryTag y) => !(x == y);

            public int CompareTo(BotInlineQueryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotInlineQueryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotInlineQueryTag x, BotInlineQueryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotInlineQueryTag x, BotInlineQueryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotInlineQueryTag x, BotInlineQueryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotInlineQueryTag x, BotInlineQueryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(QueryId: {QueryId}, UserId: {UserId}, Query: {Query}, Geo: {Geo}, Offset: {Offset})";
            
            
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

        public sealed class BotInlineSendTag : ITlTypeTag, IEquatable<BotInlineSendTag>, IComparable<BotInlineSendTag>, IComparable
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
            
            (int, string, Option<T.GeoPoint>, string, Option<T.InputBotInlineMessageId>) CmpTuple =>
                (UserId, Query, Geo, Id, MsgId);

            public bool Equals(BotInlineSendTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotInlineSendTag x && Equals(x);
            public static bool operator ==(BotInlineSendTag x, BotInlineSendTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotInlineSendTag x, BotInlineSendTag y) => !(x == y);

            public int CompareTo(BotInlineSendTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotInlineSendTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotInlineSendTag x, BotInlineSendTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotInlineSendTag x, BotInlineSendTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotInlineSendTag x, BotInlineSendTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotInlineSendTag x, BotInlineSendTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId}, Query: {Query}, Geo: {Geo}, Id: {Id}, MsgId: {MsgId})";
            
            
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

        public sealed class EditChannelMessageTag : ITlTypeTag, IEquatable<EditChannelMessageTag>, IComparable<EditChannelMessageTag>, IComparable
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
            
            (T.Message, int, int) CmpTuple =>
                (Message, Pts, PtsCount);

            public bool Equals(EditChannelMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EditChannelMessageTag x && Equals(x);
            public static bool operator ==(EditChannelMessageTag x, EditChannelMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EditChannelMessageTag x, EditChannelMessageTag y) => !(x == y);

            public int CompareTo(EditChannelMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EditChannelMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EditChannelMessageTag x, EditChannelMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EditChannelMessageTag x, EditChannelMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EditChannelMessageTag x, EditChannelMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EditChannelMessageTag x, EditChannelMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class ChannelPinnedMessageTag : ITlTypeTag, IEquatable<ChannelPinnedMessageTag>, IComparable<ChannelPinnedMessageTag>, IComparable
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
            
            (int, int) CmpTuple =>
                (ChannelId, Id);

            public bool Equals(ChannelPinnedMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelPinnedMessageTag x && Equals(x);
            public static bool operator ==(ChannelPinnedMessageTag x, ChannelPinnedMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelPinnedMessageTag x, ChannelPinnedMessageTag y) => !(x == y);

            public int CompareTo(ChannelPinnedMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelPinnedMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelPinnedMessageTag x, ChannelPinnedMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelPinnedMessageTag x, ChannelPinnedMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelPinnedMessageTag x, ChannelPinnedMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelPinnedMessageTag x, ChannelPinnedMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, Id: {Id})";
            
            
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

        public sealed class BotCallbackQueryTag : ITlTypeTag, IEquatable<BotCallbackQueryTag>, IComparable<BotCallbackQueryTag>, IComparable
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
            
            (long, int, T.Peer, int, long, Option<Arr<byte>>, Option<string>) CmpTuple =>
                (QueryId, UserId, Peer, MsgId, ChatInstance, Data, GameShortName);

            public bool Equals(BotCallbackQueryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotCallbackQueryTag x && Equals(x);
            public static bool operator ==(BotCallbackQueryTag x, BotCallbackQueryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotCallbackQueryTag x, BotCallbackQueryTag y) => !(x == y);

            public int CompareTo(BotCallbackQueryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotCallbackQueryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotCallbackQueryTag x, BotCallbackQueryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotCallbackQueryTag x, BotCallbackQueryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotCallbackQueryTag x, BotCallbackQueryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotCallbackQueryTag x, BotCallbackQueryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(QueryId: {QueryId}, UserId: {UserId}, Peer: {Peer}, MsgId: {MsgId}, ChatInstance: {ChatInstance}, Data: {Data}, GameShortName: {GameShortName})";
            
            
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

        public sealed class EditMessageTag : ITlTypeTag, IEquatable<EditMessageTag>, IComparable<EditMessageTag>, IComparable
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
            
            (T.Message, int, int) CmpTuple =>
                (Message, Pts, PtsCount);

            public bool Equals(EditMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EditMessageTag x && Equals(x);
            public static bool operator ==(EditMessageTag x, EditMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EditMessageTag x, EditMessageTag y) => !(x == y);

            public int CompareTo(EditMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EditMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EditMessageTag x, EditMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class InlineBotCallbackQueryTag : ITlTypeTag, IEquatable<InlineBotCallbackQueryTag>, IComparable<InlineBotCallbackQueryTag>, IComparable
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
            
            (long, int, T.InputBotInlineMessageId, long, Option<Arr<byte>>, Option<string>) CmpTuple =>
                (QueryId, UserId, MsgId, ChatInstance, Data, GameShortName);

            public bool Equals(InlineBotCallbackQueryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is InlineBotCallbackQueryTag x && Equals(x);
            public static bool operator ==(InlineBotCallbackQueryTag x, InlineBotCallbackQueryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InlineBotCallbackQueryTag x, InlineBotCallbackQueryTag y) => !(x == y);

            public int CompareTo(InlineBotCallbackQueryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is InlineBotCallbackQueryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InlineBotCallbackQueryTag x, InlineBotCallbackQueryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InlineBotCallbackQueryTag x, InlineBotCallbackQueryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InlineBotCallbackQueryTag x, InlineBotCallbackQueryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InlineBotCallbackQueryTag x, InlineBotCallbackQueryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(QueryId: {QueryId}, UserId: {UserId}, MsgId: {MsgId}, ChatInstance: {ChatInstance}, Data: {Data}, GameShortName: {GameShortName})";
            
            
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

        public sealed class ReadChannelOutboxTag : ITlTypeTag, IEquatable<ReadChannelOutboxTag>, IComparable<ReadChannelOutboxTag>, IComparable
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
            
            (int, int) CmpTuple =>
                (ChannelId, MaxId);

            public bool Equals(ReadChannelOutboxTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ReadChannelOutboxTag x && Equals(x);
            public static bool operator ==(ReadChannelOutboxTag x, ReadChannelOutboxTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReadChannelOutboxTag x, ReadChannelOutboxTag y) => !(x == y);

            public int CompareTo(ReadChannelOutboxTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ReadChannelOutboxTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReadChannelOutboxTag x, ReadChannelOutboxTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReadChannelOutboxTag x, ReadChannelOutboxTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReadChannelOutboxTag x, ReadChannelOutboxTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReadChannelOutboxTag x, ReadChannelOutboxTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, MaxId: {MaxId})";
            
            
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

        public sealed class DraftMessageTag : ITlTypeTag, IEquatable<DraftMessageTag>, IComparable<DraftMessageTag>, IComparable
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
            
            (T.Peer, T.DraftMessage) CmpTuple =>
                (Peer, Draft);

            public bool Equals(DraftMessageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DraftMessageTag x && Equals(x);
            public static bool operator ==(DraftMessageTag x, DraftMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DraftMessageTag x, DraftMessageTag y) => !(x == y);

            public int CompareTo(DraftMessageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DraftMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DraftMessageTag x, DraftMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DraftMessageTag x, DraftMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DraftMessageTag x, DraftMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DraftMessageTag x, DraftMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Peer: {Peer}, Draft: {Draft})";
            
            
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

        public sealed class ReadFeaturedStickersTag : ITlTypeTag, IEquatable<ReadFeaturedStickersTag>, IComparable<ReadFeaturedStickersTag>, IComparable
        {
            internal const uint TypeNumber = 0x571d2742;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ReadFeaturedStickersTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ReadFeaturedStickersTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ReadFeaturedStickersTag x && Equals(x);
            public static bool operator ==(ReadFeaturedStickersTag x, ReadFeaturedStickersTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReadFeaturedStickersTag x, ReadFeaturedStickersTag y) => !(x == y);

            public int CompareTo(ReadFeaturedStickersTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ReadFeaturedStickersTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReadFeaturedStickersTag x, ReadFeaturedStickersTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReadFeaturedStickersTag x, ReadFeaturedStickersTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReadFeaturedStickersTag x, ReadFeaturedStickersTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReadFeaturedStickersTag x, ReadFeaturedStickersTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ReadFeaturedStickersTag DeserializeTag(BinaryReader br)
            {

                return new ReadFeaturedStickersTag();
            }
        }

        public sealed class RecentStickersTag : ITlTypeTag, IEquatable<RecentStickersTag>, IComparable<RecentStickersTag>, IComparable
        {
            internal const uint TypeNumber = 0x9a422c20;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public RecentStickersTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(RecentStickersTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is RecentStickersTag x && Equals(x);
            public static bool operator ==(RecentStickersTag x, RecentStickersTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(RecentStickersTag x, RecentStickersTag y) => !(x == y);

            public int CompareTo(RecentStickersTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is RecentStickersTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(RecentStickersTag x, RecentStickersTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(RecentStickersTag x, RecentStickersTag y) => x.CompareTo(y) < 0;
            public static bool operator >(RecentStickersTag x, RecentStickersTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(RecentStickersTag x, RecentStickersTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static RecentStickersTag DeserializeTag(BinaryReader br)
            {

                return new RecentStickersTag();
            }
        }

        public sealed class ConfigTag : ITlTypeTag, IEquatable<ConfigTag>, IComparable<ConfigTag>, IComparable
        {
            internal const uint TypeNumber = 0xa229dd06;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ConfigTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ConfigTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ConfigTag x && Equals(x);
            public static bool operator ==(ConfigTag x, ConfigTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ConfigTag x, ConfigTag y) => !(x == y);

            public int CompareTo(ConfigTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ConfigTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ConfigTag x, ConfigTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ConfigTag x, ConfigTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ConfigTag x, ConfigTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ConfigTag x, ConfigTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ConfigTag DeserializeTag(BinaryReader br)
            {

                return new ConfigTag();
            }
        }

        public sealed class PtsChangedTag : ITlTypeTag, IEquatable<PtsChangedTag>, IComparable<PtsChangedTag>, IComparable
        {
            internal const uint TypeNumber = 0x3354678f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PtsChangedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PtsChangedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PtsChangedTag x && Equals(x);
            public static bool operator ==(PtsChangedTag x, PtsChangedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PtsChangedTag x, PtsChangedTag y) => !(x == y);

            public int CompareTo(PtsChangedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PtsChangedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PtsChangedTag x, PtsChangedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PtsChangedTag x, PtsChangedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PtsChangedTag x, PtsChangedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PtsChangedTag x, PtsChangedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PtsChangedTag DeserializeTag(BinaryReader br)
            {

                return new PtsChangedTag();
            }
        }

        public sealed class ChannelWebPageTag : ITlTypeTag, IEquatable<ChannelWebPageTag>, IComparable<ChannelWebPageTag>, IComparable
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
            
            (int, T.WebPage, int, int) CmpTuple =>
                (ChannelId, Webpage, Pts, PtsCount);

            public bool Equals(ChannelWebPageTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ChannelWebPageTag x && Equals(x);
            public static bool operator ==(ChannelWebPageTag x, ChannelWebPageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelWebPageTag x, ChannelWebPageTag y) => !(x == y);

            public int CompareTo(ChannelWebPageTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ChannelWebPageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelWebPageTag x, ChannelWebPageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelWebPageTag x, ChannelWebPageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelWebPageTag x, ChannelWebPageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelWebPageTag x, ChannelWebPageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId}, Webpage: {Webpage}, Pts: {Pts}, PtsCount: {PtsCount})";
            
            
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

        public sealed class DialogPinnedTag : ITlTypeTag, IEquatable<DialogPinnedTag>, IComparable<DialogPinnedTag>, IComparable
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
            
            (bool, T.Peer) CmpTuple =>
                (Pinned, Peer);

            public bool Equals(DialogPinnedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DialogPinnedTag x && Equals(x);
            public static bool operator ==(DialogPinnedTag x, DialogPinnedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DialogPinnedTag x, DialogPinnedTag y) => !(x == y);

            public int CompareTo(DialogPinnedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DialogPinnedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DialogPinnedTag x, DialogPinnedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DialogPinnedTag x, DialogPinnedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DialogPinnedTag x, DialogPinnedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DialogPinnedTag x, DialogPinnedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Pinned: {Pinned}, Peer: {Peer})";
            
            
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

        public sealed class PinnedDialogsTag : ITlTypeTag, IEquatable<PinnedDialogsTag>, IComparable<PinnedDialogsTag>, IComparable
        {
            internal const uint TypeNumber = 0xd8caf68d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Option<Arr<T.Peer>> Order { get; }
            
            public PinnedDialogsTag(
                Option<Arr<T.Peer>> order
            ) {
                Order = order;
            }
            
            Option<Arr<T.Peer>> CmpTuple =>
                Order;

            public bool Equals(PinnedDialogsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PinnedDialogsTag x && Equals(x);
            public static bool operator ==(PinnedDialogsTag x, PinnedDialogsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PinnedDialogsTag x, PinnedDialogsTag y) => !(x == y);

            public int CompareTo(PinnedDialogsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PinnedDialogsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PinnedDialogsTag x, PinnedDialogsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PinnedDialogsTag x, PinnedDialogsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PinnedDialogsTag x, PinnedDialogsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PinnedDialogsTag x, PinnedDialogsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Order: {Order})";
            
            
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

        public sealed class BotWebhookJsonTag : ITlTypeTag, IEquatable<BotWebhookJsonTag>, IComparable<BotWebhookJsonTag>, IComparable
        {
            internal const uint TypeNumber = 0x8317c0c3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.DataJson Data { get; }
            
            public BotWebhookJsonTag(
                Some<T.DataJson> data
            ) {
                Data = data;
            }
            
            T.DataJson CmpTuple =>
                Data;

            public bool Equals(BotWebhookJsonTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotWebhookJsonTag x && Equals(x);
            public static bool operator ==(BotWebhookJsonTag x, BotWebhookJsonTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotWebhookJsonTag x, BotWebhookJsonTag y) => !(x == y);

            public int CompareTo(BotWebhookJsonTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotWebhookJsonTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotWebhookJsonTag x, BotWebhookJsonTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotWebhookJsonTag x, BotWebhookJsonTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotWebhookJsonTag x, BotWebhookJsonTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotWebhookJsonTag x, BotWebhookJsonTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Data: {Data})";
            
            
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

        public sealed class BotWebhookJsonQueryTag : ITlTypeTag, IEquatable<BotWebhookJsonQueryTag>, IComparable<BotWebhookJsonQueryTag>, IComparable
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
            
            (long, T.DataJson, int) CmpTuple =>
                (QueryId, Data, Timeout);

            public bool Equals(BotWebhookJsonQueryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotWebhookJsonQueryTag x && Equals(x);
            public static bool operator ==(BotWebhookJsonQueryTag x, BotWebhookJsonQueryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotWebhookJsonQueryTag x, BotWebhookJsonQueryTag y) => !(x == y);

            public int CompareTo(BotWebhookJsonQueryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotWebhookJsonQueryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotWebhookJsonQueryTag x, BotWebhookJsonQueryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotWebhookJsonQueryTag x, BotWebhookJsonQueryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotWebhookJsonQueryTag x, BotWebhookJsonQueryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotWebhookJsonQueryTag x, BotWebhookJsonQueryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(QueryId: {QueryId}, Data: {Data}, Timeout: {Timeout})";
            
            
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

        public sealed class BotShippingQueryTag : ITlTypeTag, IEquatable<BotShippingQueryTag>, IComparable<BotShippingQueryTag>, IComparable
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
            
            (long, int, Arr<byte>, T.PostAddress) CmpTuple =>
                (QueryId, UserId, Payload, ShippingAddress);

            public bool Equals(BotShippingQueryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotShippingQueryTag x && Equals(x);
            public static bool operator ==(BotShippingQueryTag x, BotShippingQueryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotShippingQueryTag x, BotShippingQueryTag y) => !(x == y);

            public int CompareTo(BotShippingQueryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotShippingQueryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotShippingQueryTag x, BotShippingQueryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotShippingQueryTag x, BotShippingQueryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotShippingQueryTag x, BotShippingQueryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotShippingQueryTag x, BotShippingQueryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(QueryId: {QueryId}, UserId: {UserId}, Payload: {Payload}, ShippingAddress: {ShippingAddress})";
            
            
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

        public sealed class BotPrecheckoutQueryTag : ITlTypeTag, IEquatable<BotPrecheckoutQueryTag>, IComparable<BotPrecheckoutQueryTag>, IComparable
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
            
            (long, int, Arr<byte>, Option<T.PaymentRequestedInfo>, Option<string>, string, long) CmpTuple =>
                (QueryId, UserId, Payload, Info, ShippingOptionId, Currency, TotalAmount);

            public bool Equals(BotPrecheckoutQueryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BotPrecheckoutQueryTag x && Equals(x);
            public static bool operator ==(BotPrecheckoutQueryTag x, BotPrecheckoutQueryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotPrecheckoutQueryTag x, BotPrecheckoutQueryTag y) => !(x == y);

            public int CompareTo(BotPrecheckoutQueryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BotPrecheckoutQueryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotPrecheckoutQueryTag x, BotPrecheckoutQueryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotPrecheckoutQueryTag x, BotPrecheckoutQueryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotPrecheckoutQueryTag x, BotPrecheckoutQueryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotPrecheckoutQueryTag x, BotPrecheckoutQueryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(QueryId: {QueryId}, UserId: {UserId}, Payload: {Payload}, Info: {Info}, ShippingOptionId: {ShippingOptionId}, Currency: {Currency}, TotalAmount: {TotalAmount})";
            
            
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

        public sealed class PhoneCallTag : ITlTypeTag, IEquatable<PhoneCallTag>, IComparable<PhoneCallTag>, IComparable
        {
            internal const uint TypeNumber = 0xab0f6b1e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.PhoneCall PhoneCall { get; }
            
            public PhoneCallTag(
                Some<T.PhoneCall> phoneCall
            ) {
                PhoneCall = phoneCall;
            }
            
            T.PhoneCall CmpTuple =>
                PhoneCall;

            public bool Equals(PhoneCallTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is PhoneCallTag x && Equals(x);
            public static bool operator ==(PhoneCallTag x, PhoneCallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhoneCallTag x, PhoneCallTag y) => !(x == y);

            public int CompareTo(PhoneCallTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is PhoneCallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PhoneCall: {PhoneCall})";
            
            
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

        public bool Equals(Update other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Update x && Equals(x);
        public static bool operator ==(Update x, Update y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Update x, Update y) => !(x == y);

        public int CompareTo(Update other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Update x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Update x, Update y) => x.CompareTo(y) <= 0;
        public static bool operator <(Update x, Update y) => x.CompareTo(y) < 0;
        public static bool operator >(Update x, Update y) => x.CompareTo(y) > 0;
        public static bool operator >=(Update x, Update y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Update.{_tag.GetType().Name}{_tag}";
    }
}