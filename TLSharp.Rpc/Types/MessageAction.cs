using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MessageAction : ITlType, IEquatable<MessageAction>, IComparable<MessageAction>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xb6aef7b0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class ChatCreateTag : ITlTypeTag, IEquatable<ChatCreateTag>, IComparable<ChatCreateTag>, IComparable
        {
            internal const uint TypeNumber = 0xa6638b9a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Title;
            public readonly Arr<int> Users;
            
            public ChatCreateTag(
                Some<string> title,
                Some<Arr<int>> users
            ) {
                Title = title;
                Users = users;
            }
            
            (string, Arr<int>) CmpTuple =>
                (Title, Users);

            public bool Equals(ChatCreateTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatCreateTag x && Equals(x);
            public static bool operator ==(ChatCreateTag x, ChatCreateTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatCreateTag x, ChatCreateTag y) => !(x == y);

            public int CompareTo(ChatCreateTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatCreateTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatCreateTag x, ChatCreateTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatCreateTag x, ChatCreateTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatCreateTag x, ChatCreateTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatCreateTag x, ChatCreateTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Title: {Title}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Title, bw, WriteString);
                Write(Users, bw, WriteVector<int>(WriteInt));
            }
            
            internal static ChatCreateTag DeserializeTag(BinaryReader br)
            {
                var title = Read(br, ReadString);
                var users = Read(br, ReadVector(ReadInt));
                return new ChatCreateTag(title, users);
            }
        }

        public sealed class ChatEditTitleTag : ITlTypeTag, IEquatable<ChatEditTitleTag>, IComparable<ChatEditTitleTag>, IComparable
        {
            internal const uint TypeNumber = 0xb5a1ce5a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Title;
            
            public ChatEditTitleTag(
                Some<string> title
            ) {
                Title = title;
            }
            
            string CmpTuple =>
                Title;

            public bool Equals(ChatEditTitleTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatEditTitleTag x && Equals(x);
            public static bool operator ==(ChatEditTitleTag x, ChatEditTitleTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatEditTitleTag x, ChatEditTitleTag y) => !(x == y);

            public int CompareTo(ChatEditTitleTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatEditTitleTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatEditTitleTag x, ChatEditTitleTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatEditTitleTag x, ChatEditTitleTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatEditTitleTag x, ChatEditTitleTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatEditTitleTag x, ChatEditTitleTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Title: {Title})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Title, bw, WriteString);
            }
            
            internal static ChatEditTitleTag DeserializeTag(BinaryReader br)
            {
                var title = Read(br, ReadString);
                return new ChatEditTitleTag(title);
            }
        }

        public sealed class ChatEditPhotoTag : ITlTypeTag, IEquatable<ChatEditPhotoTag>, IComparable<ChatEditPhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0x7fcb13a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Photo Photo;
            
            public ChatEditPhotoTag(
                Some<T.Photo> photo
            ) {
                Photo = photo;
            }
            
            T.Photo CmpTuple =>
                Photo;

            public bool Equals(ChatEditPhotoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatEditPhotoTag x && Equals(x);
            public static bool operator ==(ChatEditPhotoTag x, ChatEditPhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatEditPhotoTag x, ChatEditPhotoTag y) => !(x == y);

            public int CompareTo(ChatEditPhotoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatEditPhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatEditPhotoTag x, ChatEditPhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatEditPhotoTag x, ChatEditPhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatEditPhotoTag x, ChatEditPhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatEditPhotoTag x, ChatEditPhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Photo: {Photo})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Photo, bw, WriteSerializable);
            }
            
            internal static ChatEditPhotoTag DeserializeTag(BinaryReader br)
            {
                var photo = Read(br, T.Photo.Deserialize);
                return new ChatEditPhotoTag(photo);
            }
        }

        public sealed class ChatDeletePhotoTag : ITlTypeTag, IEquatable<ChatDeletePhotoTag>, IComparable<ChatDeletePhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0x95e3fbef;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChatDeletePhotoTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ChatDeletePhotoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatDeletePhotoTag x && Equals(x);
            public static bool operator ==(ChatDeletePhotoTag x, ChatDeletePhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatDeletePhotoTag x, ChatDeletePhotoTag y) => !(x == y);

            public int CompareTo(ChatDeletePhotoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatDeletePhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatDeletePhotoTag x, ChatDeletePhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatDeletePhotoTag x, ChatDeletePhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatDeletePhotoTag x, ChatDeletePhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatDeletePhotoTag x, ChatDeletePhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatDeletePhotoTag DeserializeTag(BinaryReader br)
            {

                return new ChatDeletePhotoTag();
            }
        }

        public sealed class ChatAddUserTag : ITlTypeTag, IEquatable<ChatAddUserTag>, IComparable<ChatAddUserTag>, IComparable
        {
            internal const uint TypeNumber = 0x488a7337;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<int> Users;
            
            public ChatAddUserTag(
                Some<Arr<int>> users
            ) {
                Users = users;
            }
            
            Arr<int> CmpTuple =>
                Users;

            public bool Equals(ChatAddUserTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatAddUserTag x && Equals(x);
            public static bool operator ==(ChatAddUserTag x, ChatAddUserTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatAddUserTag x, ChatAddUserTag y) => !(x == y);

            public int CompareTo(ChatAddUserTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatAddUserTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatAddUserTag x, ChatAddUserTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatAddUserTag x, ChatAddUserTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatAddUserTag x, ChatAddUserTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatAddUserTag x, ChatAddUserTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Users, bw, WriteVector<int>(WriteInt));
            }
            
            internal static ChatAddUserTag DeserializeTag(BinaryReader br)
            {
                var users = Read(br, ReadVector(ReadInt));
                return new ChatAddUserTag(users);
            }
        }

        public sealed class ChatDeleteUserTag : ITlTypeTag, IEquatable<ChatDeleteUserTag>, IComparable<ChatDeleteUserTag>, IComparable
        {
            internal const uint TypeNumber = 0xb2ae9b0c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int UserId;
            
            public ChatDeleteUserTag(
                int userId
            ) {
                UserId = userId;
            }
            
            int CmpTuple =>
                UserId;

            public bool Equals(ChatDeleteUserTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatDeleteUserTag x && Equals(x);
            public static bool operator ==(ChatDeleteUserTag x, ChatDeleteUserTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatDeleteUserTag x, ChatDeleteUserTag y) => !(x == y);

            public int CompareTo(ChatDeleteUserTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatDeleteUserTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatDeleteUserTag x, ChatDeleteUserTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatDeleteUserTag x, ChatDeleteUserTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatDeleteUserTag x, ChatDeleteUserTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatDeleteUserTag x, ChatDeleteUserTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(UserId: {UserId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
            }
            
            internal static ChatDeleteUserTag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                return new ChatDeleteUserTag(userId);
            }
        }

        public sealed class ChatJoinedByLinkTag : ITlTypeTag, IEquatable<ChatJoinedByLinkTag>, IComparable<ChatJoinedByLinkTag>, IComparable
        {
            internal const uint TypeNumber = 0xf89cf5e8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int InviterId;
            
            public ChatJoinedByLinkTag(
                int inviterId
            ) {
                InviterId = inviterId;
            }
            
            int CmpTuple =>
                InviterId;

            public bool Equals(ChatJoinedByLinkTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatJoinedByLinkTag x && Equals(x);
            public static bool operator ==(ChatJoinedByLinkTag x, ChatJoinedByLinkTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatJoinedByLinkTag x, ChatJoinedByLinkTag y) => !(x == y);

            public int CompareTo(ChatJoinedByLinkTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatJoinedByLinkTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatJoinedByLinkTag x, ChatJoinedByLinkTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatJoinedByLinkTag x, ChatJoinedByLinkTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatJoinedByLinkTag x, ChatJoinedByLinkTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatJoinedByLinkTag x, ChatJoinedByLinkTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(InviterId: {InviterId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(InviterId, bw, WriteInt);
            }
            
            internal static ChatJoinedByLinkTag DeserializeTag(BinaryReader br)
            {
                var inviterId = Read(br, ReadInt);
                return new ChatJoinedByLinkTag(inviterId);
            }
        }

        public sealed class ChannelCreateTag : ITlTypeTag, IEquatable<ChannelCreateTag>, IComparable<ChannelCreateTag>, IComparable
        {
            internal const uint TypeNumber = 0x95d2ac92;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Title;
            
            public ChannelCreateTag(
                Some<string> title
            ) {
                Title = title;
            }
            
            string CmpTuple =>
                Title;

            public bool Equals(ChannelCreateTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChannelCreateTag x && Equals(x);
            public static bool operator ==(ChannelCreateTag x, ChannelCreateTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelCreateTag x, ChannelCreateTag y) => !(x == y);

            public int CompareTo(ChannelCreateTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChannelCreateTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelCreateTag x, ChannelCreateTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelCreateTag x, ChannelCreateTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelCreateTag x, ChannelCreateTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelCreateTag x, ChannelCreateTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Title: {Title})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Title, bw, WriteString);
            }
            
            internal static ChannelCreateTag DeserializeTag(BinaryReader br)
            {
                var title = Read(br, ReadString);
                return new ChannelCreateTag(title);
            }
        }

        public sealed class ChatMigrateToTag : ITlTypeTag, IEquatable<ChatMigrateToTag>, IComparable<ChatMigrateToTag>, IComparable
        {
            internal const uint TypeNumber = 0x51bdb021;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int ChannelId;
            
            public ChatMigrateToTag(
                int channelId
            ) {
                ChannelId = channelId;
            }
            
            int CmpTuple =>
                ChannelId;

            public bool Equals(ChatMigrateToTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatMigrateToTag x && Equals(x);
            public static bool operator ==(ChatMigrateToTag x, ChatMigrateToTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatMigrateToTag x, ChatMigrateToTag y) => !(x == y);

            public int CompareTo(ChatMigrateToTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatMigrateToTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatMigrateToTag x, ChatMigrateToTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatMigrateToTag x, ChatMigrateToTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatMigrateToTag x, ChatMigrateToTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatMigrateToTag x, ChatMigrateToTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(ChannelId: {ChannelId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ChannelId, bw, WriteInt);
            }
            
            internal static ChatMigrateToTag DeserializeTag(BinaryReader br)
            {
                var channelId = Read(br, ReadInt);
                return new ChatMigrateToTag(channelId);
            }
        }

        public sealed class ChannelMigrateFromTag : ITlTypeTag, IEquatable<ChannelMigrateFromTag>, IComparable<ChannelMigrateFromTag>, IComparable
        {
            internal const uint TypeNumber = 0xb055eaee;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Title;
            public readonly int ChatId;
            
            public ChannelMigrateFromTag(
                Some<string> title,
                int chatId
            ) {
                Title = title;
                ChatId = chatId;
            }
            
            (string, int) CmpTuple =>
                (Title, ChatId);

            public bool Equals(ChannelMigrateFromTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChannelMigrateFromTag x && Equals(x);
            public static bool operator ==(ChannelMigrateFromTag x, ChannelMigrateFromTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChannelMigrateFromTag x, ChannelMigrateFromTag y) => !(x == y);

            public int CompareTo(ChannelMigrateFromTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChannelMigrateFromTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChannelMigrateFromTag x, ChannelMigrateFromTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChannelMigrateFromTag x, ChannelMigrateFromTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChannelMigrateFromTag x, ChannelMigrateFromTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChannelMigrateFromTag x, ChannelMigrateFromTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Title: {Title}, ChatId: {ChatId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Title, bw, WriteString);
                Write(ChatId, bw, WriteInt);
            }
            
            internal static ChannelMigrateFromTag DeserializeTag(BinaryReader br)
            {
                var title = Read(br, ReadString);
                var chatId = Read(br, ReadInt);
                return new ChannelMigrateFromTag(title, chatId);
            }
        }

        public sealed class PinMessageTag : ITlTypeTag, IEquatable<PinMessageTag>, IComparable<PinMessageTag>, IComparable
        {
            internal const uint TypeNumber = 0x94bd38ed;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PinMessageTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(PinMessageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PinMessageTag x && Equals(x);
            public static bool operator ==(PinMessageTag x, PinMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PinMessageTag x, PinMessageTag y) => !(x == y);

            public int CompareTo(PinMessageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PinMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PinMessageTag x, PinMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PinMessageTag x, PinMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PinMessageTag x, PinMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PinMessageTag x, PinMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PinMessageTag DeserializeTag(BinaryReader br)
            {

                return new PinMessageTag();
            }
        }

        public sealed class HistoryClearTag : ITlTypeTag, IEquatable<HistoryClearTag>, IComparable<HistoryClearTag>, IComparable
        {
            internal const uint TypeNumber = 0x9fbab604;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public HistoryClearTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(HistoryClearTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is HistoryClearTag x && Equals(x);
            public static bool operator ==(HistoryClearTag x, HistoryClearTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(HistoryClearTag x, HistoryClearTag y) => !(x == y);

            public int CompareTo(HistoryClearTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is HistoryClearTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(HistoryClearTag x, HistoryClearTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(HistoryClearTag x, HistoryClearTag y) => x.CompareTo(y) < 0;
            public static bool operator >(HistoryClearTag x, HistoryClearTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(HistoryClearTag x, HistoryClearTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HistoryClearTag DeserializeTag(BinaryReader br)
            {

                return new HistoryClearTag();
            }
        }

        public sealed class GameScoreTag : ITlTypeTag, IEquatable<GameScoreTag>, IComparable<GameScoreTag>, IComparable
        {
            internal const uint TypeNumber = 0x92a72876;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long GameId;
            public readonly int Score;
            
            public GameScoreTag(
                long gameId,
                int score
            ) {
                GameId = gameId;
                Score = score;
            }
            
            (long, int) CmpTuple =>
                (GameId, Score);

            public bool Equals(GameScoreTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is GameScoreTag x && Equals(x);
            public static bool operator ==(GameScoreTag x, GameScoreTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(GameScoreTag x, GameScoreTag y) => !(x == y);

            public int CompareTo(GameScoreTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is GameScoreTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(GameScoreTag x, GameScoreTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(GameScoreTag x, GameScoreTag y) => x.CompareTo(y) < 0;
            public static bool operator >(GameScoreTag x, GameScoreTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(GameScoreTag x, GameScoreTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(GameId: {GameId}, Score: {Score})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(GameId, bw, WriteLong);
                Write(Score, bw, WriteInt);
            }
            
            internal static GameScoreTag DeserializeTag(BinaryReader br)
            {
                var gameId = Read(br, ReadLong);
                var score = Read(br, ReadInt);
                return new GameScoreTag(gameId, score);
            }
        }

        public sealed class PaymentSentMeTag : ITlTypeTag, IEquatable<PaymentSentMeTag>, IComparable<PaymentSentMeTag>, IComparable
        {
            internal const uint TypeNumber = 0x8f31b327;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Currency;
            public readonly long TotalAmount;
            public readonly Arr<byte> Payload;
            public readonly Option<T.PaymentRequestedInfo> Info;
            public readonly Option<string> ShippingOptionId;
            public readonly T.PaymentCharge Charge;
            
            public PaymentSentMeTag(
                Some<string> currency,
                long totalAmount,
                Some<Arr<byte>> payload,
                Option<T.PaymentRequestedInfo> info,
                Option<string> shippingOptionId,
                Some<T.PaymentCharge> charge
            ) {
                Currency = currency;
                TotalAmount = totalAmount;
                Payload = payload;
                Info = info;
                ShippingOptionId = shippingOptionId;
                Charge = charge;
            }
            
            (string, long, Arr<byte>, Option<T.PaymentRequestedInfo>, Option<string>, T.PaymentCharge) CmpTuple =>
                (Currency, TotalAmount, Payload, Info, ShippingOptionId, Charge);

            public bool Equals(PaymentSentMeTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PaymentSentMeTag x && Equals(x);
            public static bool operator ==(PaymentSentMeTag x, PaymentSentMeTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PaymentSentMeTag x, PaymentSentMeTag y) => !(x == y);

            public int CompareTo(PaymentSentMeTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PaymentSentMeTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PaymentSentMeTag x, PaymentSentMeTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PaymentSentMeTag x, PaymentSentMeTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PaymentSentMeTag x, PaymentSentMeTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PaymentSentMeTag x, PaymentSentMeTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Currency: {Currency}, TotalAmount: {TotalAmount}, Payload: {Payload}, Info: {Info}, ShippingOptionId: {ShippingOptionId}, Charge: {Charge})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Info) | MaskBit(1, ShippingOptionId), bw, WriteInt);
                Write(Currency, bw, WriteString);
                Write(TotalAmount, bw, WriteLong);
                Write(Payload, bw, WriteBytes);
                Write(Info, bw, WriteOption<T.PaymentRequestedInfo>(WriteSerializable));
                Write(ShippingOptionId, bw, WriteOption<string>(WriteString));
                Write(Charge, bw, WriteSerializable);
            }
            
            internal static PaymentSentMeTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var currency = Read(br, ReadString);
                var totalAmount = Read(br, ReadLong);
                var payload = Read(br, ReadBytes);
                var info = Read(br, ReadOption(flags, 0, T.PaymentRequestedInfo.Deserialize));
                var shippingOptionId = Read(br, ReadOption(flags, 1, ReadString));
                var charge = Read(br, T.PaymentCharge.Deserialize);
                return new PaymentSentMeTag(currency, totalAmount, payload, info, shippingOptionId, charge);
            }
        }

        public sealed class PaymentSentTag : ITlTypeTag, IEquatable<PaymentSentTag>, IComparable<PaymentSentTag>, IComparable
        {
            internal const uint TypeNumber = 0x40699cd0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Currency;
            public readonly long TotalAmount;
            
            public PaymentSentTag(
                Some<string> currency,
                long totalAmount
            ) {
                Currency = currency;
                TotalAmount = totalAmount;
            }
            
            (string, long) CmpTuple =>
                (Currency, TotalAmount);

            public bool Equals(PaymentSentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PaymentSentTag x && Equals(x);
            public static bool operator ==(PaymentSentTag x, PaymentSentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PaymentSentTag x, PaymentSentTag y) => !(x == y);

            public int CompareTo(PaymentSentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PaymentSentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PaymentSentTag x, PaymentSentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PaymentSentTag x, PaymentSentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PaymentSentTag x, PaymentSentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PaymentSentTag x, PaymentSentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Currency: {Currency}, TotalAmount: {TotalAmount})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Currency, bw, WriteString);
                Write(TotalAmount, bw, WriteLong);
            }
            
            internal static PaymentSentTag DeserializeTag(BinaryReader br)
            {
                var currency = Read(br, ReadString);
                var totalAmount = Read(br, ReadLong);
                return new PaymentSentTag(currency, totalAmount);
            }
        }

        public sealed class PhoneCallTag : ITlTypeTag, IEquatable<PhoneCallTag>, IComparable<PhoneCallTag>, IComparable
        {
            internal const uint TypeNumber = 0x80e11a7f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long CallId;
            public readonly Option<T.PhoneCallDiscardReason> Reason;
            public readonly Option<int> Duration;
            
            public PhoneCallTag(
                long callId,
                Option<T.PhoneCallDiscardReason> reason,
                Option<int> duration
            ) {
                CallId = callId;
                Reason = reason;
                Duration = duration;
            }
            
            (long, Option<T.PhoneCallDiscardReason>, Option<int>) CmpTuple =>
                (CallId, Reason, Duration);

            public bool Equals(PhoneCallTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PhoneCallTag x && Equals(x);
            public static bool operator ==(PhoneCallTag x, PhoneCallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhoneCallTag x, PhoneCallTag y) => !(x == y);

            public int CompareTo(PhoneCallTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PhoneCallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhoneCallTag x, PhoneCallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(CallId: {CallId}, Reason: {Reason}, Duration: {Duration})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Reason) | MaskBit(1, Duration), bw, WriteInt);
                Write(CallId, bw, WriteLong);
                Write(Reason, bw, WriteOption<T.PhoneCallDiscardReason>(WriteSerializable));
                Write(Duration, bw, WriteOption<int>(WriteInt));
            }
            
            internal static PhoneCallTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var callId = Read(br, ReadLong);
                var reason = Read(br, ReadOption(flags, 0, T.PhoneCallDiscardReason.Deserialize));
                var duration = Read(br, ReadOption(flags, 1, ReadInt));
                return new PhoneCallTag(callId, reason, duration);
            }
        }

        public sealed class ScreenshotTakenTag : ITlTypeTag, IEquatable<ScreenshotTakenTag>, IComparable<ScreenshotTakenTag>, IComparable
        {
            internal const uint TypeNumber = 0x4792929b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ScreenshotTakenTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ScreenshotTakenTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ScreenshotTakenTag x && Equals(x);
            public static bool operator ==(ScreenshotTakenTag x, ScreenshotTakenTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ScreenshotTakenTag x, ScreenshotTakenTag y) => !(x == y);

            public int CompareTo(ScreenshotTakenTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ScreenshotTakenTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ScreenshotTakenTag x, ScreenshotTakenTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ScreenshotTakenTag x, ScreenshotTakenTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ScreenshotTakenTag x, ScreenshotTakenTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ScreenshotTakenTag x, ScreenshotTakenTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ScreenshotTakenTag DeserializeTag(BinaryReader br)
            {

                return new ScreenshotTakenTag();
            }
        }

        public sealed class CustomTag : ITlTypeTag, IEquatable<CustomTag>, IComparable<CustomTag>, IComparable
        {
            internal const uint TypeNumber = 0xfae69f56;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Message;
            
            public CustomTag(
                Some<string> message
            ) {
                Message = message;
            }
            
            string CmpTuple =>
                Message;

            public bool Equals(CustomTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CustomTag x && Equals(x);
            public static bool operator ==(CustomTag x, CustomTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CustomTag x, CustomTag y) => !(x == y);

            public int CompareTo(CustomTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CustomTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CustomTag x, CustomTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CustomTag x, CustomTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CustomTag x, CustomTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CustomTag x, CustomTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Message: {Message})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Message, bw, WriteString);
            }
            
            internal static CustomTag DeserializeTag(BinaryReader br)
            {
                var message = Read(br, ReadString);
                return new CustomTag(message);
            }
        }

        public sealed class BotAllowedTag : ITlTypeTag, IEquatable<BotAllowedTag>, IComparable<BotAllowedTag>, IComparable
        {
            internal const uint TypeNumber = 0xabe9affe;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Domain;
            
            public BotAllowedTag(
                Some<string> domain
            ) {
                Domain = domain;
            }
            
            string CmpTuple =>
                Domain;

            public bool Equals(BotAllowedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BotAllowedTag x && Equals(x);
            public static bool operator ==(BotAllowedTag x, BotAllowedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotAllowedTag x, BotAllowedTag y) => !(x == y);

            public int CompareTo(BotAllowedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BotAllowedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotAllowedTag x, BotAllowedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotAllowedTag x, BotAllowedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotAllowedTag x, BotAllowedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotAllowedTag x, BotAllowedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Domain: {Domain})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Domain, bw, WriteString);
            }
            
            internal static BotAllowedTag DeserializeTag(BinaryReader br)
            {
                var domain = Read(br, ReadString);
                return new BotAllowedTag(domain);
            }
        }

        public sealed class SecureValuesSentMeTag : ITlTypeTag, IEquatable<SecureValuesSentMeTag>, IComparable<SecureValuesSentMeTag>, IComparable
        {
            internal const uint TypeNumber = 0x1b287353;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.SecureValue> Values;
            public readonly T.SecureCredentialsEncrypted Credentials;
            
            public SecureValuesSentMeTag(
                Some<Arr<T.SecureValue>> values,
                Some<T.SecureCredentialsEncrypted> credentials
            ) {
                Values = values;
                Credentials = credentials;
            }
            
            (Arr<T.SecureValue>, T.SecureCredentialsEncrypted) CmpTuple =>
                (Values, Credentials);

            public bool Equals(SecureValuesSentMeTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SecureValuesSentMeTag x && Equals(x);
            public static bool operator ==(SecureValuesSentMeTag x, SecureValuesSentMeTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SecureValuesSentMeTag x, SecureValuesSentMeTag y) => !(x == y);

            public int CompareTo(SecureValuesSentMeTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SecureValuesSentMeTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SecureValuesSentMeTag x, SecureValuesSentMeTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SecureValuesSentMeTag x, SecureValuesSentMeTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SecureValuesSentMeTag x, SecureValuesSentMeTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SecureValuesSentMeTag x, SecureValuesSentMeTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Values: {Values}, Credentials: {Credentials})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Values, bw, WriteVector<T.SecureValue>(WriteSerializable));
                Write(Credentials, bw, WriteSerializable);
            }
            
            internal static SecureValuesSentMeTag DeserializeTag(BinaryReader br)
            {
                var values = Read(br, ReadVector(T.SecureValue.Deserialize));
                var credentials = Read(br, T.SecureCredentialsEncrypted.Deserialize);
                return new SecureValuesSentMeTag(values, credentials);
            }
        }

        public sealed class SecureValuesSentTag : ITlTypeTag, IEquatable<SecureValuesSentTag>, IComparable<SecureValuesSentTag>, IComparable
        {
            internal const uint TypeNumber = 0xd95c6154;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.SecureValueType> Types;
            
            public SecureValuesSentTag(
                Some<Arr<T.SecureValueType>> types
            ) {
                Types = types;
            }
            
            Arr<T.SecureValueType> CmpTuple =>
                Types;

            public bool Equals(SecureValuesSentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SecureValuesSentTag x && Equals(x);
            public static bool operator ==(SecureValuesSentTag x, SecureValuesSentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SecureValuesSentTag x, SecureValuesSentTag y) => !(x == y);

            public int CompareTo(SecureValuesSentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SecureValuesSentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SecureValuesSentTag x, SecureValuesSentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SecureValuesSentTag x, SecureValuesSentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SecureValuesSentTag x, SecureValuesSentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SecureValuesSentTag x, SecureValuesSentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Types: {Types})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Types, bw, WriteVector<T.SecureValueType>(WriteSerializable));
            }
            
            internal static SecureValuesSentTag DeserializeTag(BinaryReader br)
            {
                var types = Read(br, ReadVector(T.SecureValueType.Deserialize));
                return new SecureValuesSentTag(types);
            }
        }

        readonly ITlTypeTag _tag;
        MessageAction(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MessageAction(EmptyTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatCreateTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatEditTitleTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatEditPhotoTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatDeletePhotoTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatAddUserTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatDeleteUserTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatJoinedByLinkTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChannelCreateTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChatMigrateToTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ChannelMigrateFromTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(PinMessageTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(HistoryClearTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(GameScoreTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(PaymentSentMeTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(PaymentSentTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(PhoneCallTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(ScreenshotTakenTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(CustomTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(BotAllowedTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(SecureValuesSentMeTag tag) => new MessageAction(tag);
        public static explicit operator MessageAction(SecureValuesSentTag tag) => new MessageAction(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MessageAction Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (MessageAction) EmptyTag.DeserializeTag(br);
                case ChatCreateTag.TypeNumber: return (MessageAction) ChatCreateTag.DeserializeTag(br);
                case ChatEditTitleTag.TypeNumber: return (MessageAction) ChatEditTitleTag.DeserializeTag(br);
                case ChatEditPhotoTag.TypeNumber: return (MessageAction) ChatEditPhotoTag.DeserializeTag(br);
                case ChatDeletePhotoTag.TypeNumber: return (MessageAction) ChatDeletePhotoTag.DeserializeTag(br);
                case ChatAddUserTag.TypeNumber: return (MessageAction) ChatAddUserTag.DeserializeTag(br);
                case ChatDeleteUserTag.TypeNumber: return (MessageAction) ChatDeleteUserTag.DeserializeTag(br);
                case ChatJoinedByLinkTag.TypeNumber: return (MessageAction) ChatJoinedByLinkTag.DeserializeTag(br);
                case ChannelCreateTag.TypeNumber: return (MessageAction) ChannelCreateTag.DeserializeTag(br);
                case ChatMigrateToTag.TypeNumber: return (MessageAction) ChatMigrateToTag.DeserializeTag(br);
                case ChannelMigrateFromTag.TypeNumber: return (MessageAction) ChannelMigrateFromTag.DeserializeTag(br);
                case PinMessageTag.TypeNumber: return (MessageAction) PinMessageTag.DeserializeTag(br);
                case HistoryClearTag.TypeNumber: return (MessageAction) HistoryClearTag.DeserializeTag(br);
                case GameScoreTag.TypeNumber: return (MessageAction) GameScoreTag.DeserializeTag(br);
                case PaymentSentMeTag.TypeNumber: return (MessageAction) PaymentSentMeTag.DeserializeTag(br);
                case PaymentSentTag.TypeNumber: return (MessageAction) PaymentSentTag.DeserializeTag(br);
                case PhoneCallTag.TypeNumber: return (MessageAction) PhoneCallTag.DeserializeTag(br);
                case ScreenshotTakenTag.TypeNumber: return (MessageAction) ScreenshotTakenTag.DeserializeTag(br);
                case CustomTag.TypeNumber: return (MessageAction) CustomTag.DeserializeTag(br);
                case BotAllowedTag.TypeNumber: return (MessageAction) BotAllowedTag.DeserializeTag(br);
                case SecureValuesSentMeTag.TypeNumber: return (MessageAction) SecureValuesSentMeTag.DeserializeTag(br);
                case SecureValuesSentTag.TypeNumber: return (MessageAction) SecureValuesSentTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, ChatCreateTag.TypeNumber, ChatEditTitleTag.TypeNumber, ChatEditPhotoTag.TypeNumber, ChatDeletePhotoTag.TypeNumber, ChatAddUserTag.TypeNumber, ChatDeleteUserTag.TypeNumber, ChatJoinedByLinkTag.TypeNumber, ChannelCreateTag.TypeNumber, ChatMigrateToTag.TypeNumber, ChannelMigrateFromTag.TypeNumber, PinMessageTag.TypeNumber, HistoryClearTag.TypeNumber, GameScoreTag.TypeNumber, PaymentSentMeTag.TypeNumber, PaymentSentTag.TypeNumber, PhoneCallTag.TypeNumber, ScreenshotTakenTag.TypeNumber, CustomTag.TypeNumber, BotAllowedTag.TypeNumber, SecureValuesSentMeTag.TypeNumber, SecureValuesSentTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<ChatCreateTag, T> chatCreateTag = null,
            Func<ChatEditTitleTag, T> chatEditTitleTag = null,
            Func<ChatEditPhotoTag, T> chatEditPhotoTag = null,
            Func<ChatDeletePhotoTag, T> chatDeletePhotoTag = null,
            Func<ChatAddUserTag, T> chatAddUserTag = null,
            Func<ChatDeleteUserTag, T> chatDeleteUserTag = null,
            Func<ChatJoinedByLinkTag, T> chatJoinedByLinkTag = null,
            Func<ChannelCreateTag, T> channelCreateTag = null,
            Func<ChatMigrateToTag, T> chatMigrateToTag = null,
            Func<ChannelMigrateFromTag, T> channelMigrateFromTag = null,
            Func<PinMessageTag, T> pinMessageTag = null,
            Func<HistoryClearTag, T> historyClearTag = null,
            Func<GameScoreTag, T> gameScoreTag = null,
            Func<PaymentSentMeTag, T> paymentSentMeTag = null,
            Func<PaymentSentTag, T> paymentSentTag = null,
            Func<PhoneCallTag, T> phoneCallTag = null,
            Func<ScreenshotTakenTag, T> screenshotTakenTag = null,
            Func<CustomTag, T> customTag = null,
            Func<BotAllowedTag, T> botAllowedTag = null,
            Func<SecureValuesSentMeTag, T> secureValuesSentMeTag = null,
            Func<SecureValuesSentTag, T> secureValuesSentTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case ChatCreateTag x when chatCreateTag != null: return chatCreateTag(x);
                case ChatEditTitleTag x when chatEditTitleTag != null: return chatEditTitleTag(x);
                case ChatEditPhotoTag x when chatEditPhotoTag != null: return chatEditPhotoTag(x);
                case ChatDeletePhotoTag x when chatDeletePhotoTag != null: return chatDeletePhotoTag(x);
                case ChatAddUserTag x when chatAddUserTag != null: return chatAddUserTag(x);
                case ChatDeleteUserTag x when chatDeleteUserTag != null: return chatDeleteUserTag(x);
                case ChatJoinedByLinkTag x when chatJoinedByLinkTag != null: return chatJoinedByLinkTag(x);
                case ChannelCreateTag x when channelCreateTag != null: return channelCreateTag(x);
                case ChatMigrateToTag x when chatMigrateToTag != null: return chatMigrateToTag(x);
                case ChannelMigrateFromTag x when channelMigrateFromTag != null: return channelMigrateFromTag(x);
                case PinMessageTag x when pinMessageTag != null: return pinMessageTag(x);
                case HistoryClearTag x when historyClearTag != null: return historyClearTag(x);
                case GameScoreTag x when gameScoreTag != null: return gameScoreTag(x);
                case PaymentSentMeTag x when paymentSentMeTag != null: return paymentSentMeTag(x);
                case PaymentSentTag x when paymentSentTag != null: return paymentSentTag(x);
                case PhoneCallTag x when phoneCallTag != null: return phoneCallTag(x);
                case ScreenshotTakenTag x when screenshotTakenTag != null: return screenshotTakenTag(x);
                case CustomTag x when customTag != null: return customTag(x);
                case BotAllowedTag x when botAllowedTag != null: return botAllowedTag(x);
                case SecureValuesSentMeTag x when secureValuesSentMeTag != null: return secureValuesSentMeTag(x);
                case SecureValuesSentTag x when secureValuesSentTag != null: return secureValuesSentTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<ChatCreateTag, T> chatCreateTag,
            Func<ChatEditTitleTag, T> chatEditTitleTag,
            Func<ChatEditPhotoTag, T> chatEditPhotoTag,
            Func<ChatDeletePhotoTag, T> chatDeletePhotoTag,
            Func<ChatAddUserTag, T> chatAddUserTag,
            Func<ChatDeleteUserTag, T> chatDeleteUserTag,
            Func<ChatJoinedByLinkTag, T> chatJoinedByLinkTag,
            Func<ChannelCreateTag, T> channelCreateTag,
            Func<ChatMigrateToTag, T> chatMigrateToTag,
            Func<ChannelMigrateFromTag, T> channelMigrateFromTag,
            Func<PinMessageTag, T> pinMessageTag,
            Func<HistoryClearTag, T> historyClearTag,
            Func<GameScoreTag, T> gameScoreTag,
            Func<PaymentSentMeTag, T> paymentSentMeTag,
            Func<PaymentSentTag, T> paymentSentTag,
            Func<PhoneCallTag, T> phoneCallTag,
            Func<ScreenshotTakenTag, T> screenshotTakenTag,
            Func<CustomTag, T> customTag,
            Func<BotAllowedTag, T> botAllowedTag,
            Func<SecureValuesSentMeTag, T> secureValuesSentMeTag,
            Func<SecureValuesSentTag, T> secureValuesSentTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            chatCreateTag ?? throw new ArgumentNullException(nameof(chatCreateTag)),
            chatEditTitleTag ?? throw new ArgumentNullException(nameof(chatEditTitleTag)),
            chatEditPhotoTag ?? throw new ArgumentNullException(nameof(chatEditPhotoTag)),
            chatDeletePhotoTag ?? throw new ArgumentNullException(nameof(chatDeletePhotoTag)),
            chatAddUserTag ?? throw new ArgumentNullException(nameof(chatAddUserTag)),
            chatDeleteUserTag ?? throw new ArgumentNullException(nameof(chatDeleteUserTag)),
            chatJoinedByLinkTag ?? throw new ArgumentNullException(nameof(chatJoinedByLinkTag)),
            channelCreateTag ?? throw new ArgumentNullException(nameof(channelCreateTag)),
            chatMigrateToTag ?? throw new ArgumentNullException(nameof(chatMigrateToTag)),
            channelMigrateFromTag ?? throw new ArgumentNullException(nameof(channelMigrateFromTag)),
            pinMessageTag ?? throw new ArgumentNullException(nameof(pinMessageTag)),
            historyClearTag ?? throw new ArgumentNullException(nameof(historyClearTag)),
            gameScoreTag ?? throw new ArgumentNullException(nameof(gameScoreTag)),
            paymentSentMeTag ?? throw new ArgumentNullException(nameof(paymentSentMeTag)),
            paymentSentTag ?? throw new ArgumentNullException(nameof(paymentSentTag)),
            phoneCallTag ?? throw new ArgumentNullException(nameof(phoneCallTag)),
            screenshotTakenTag ?? throw new ArgumentNullException(nameof(screenshotTakenTag)),
            customTag ?? throw new ArgumentNullException(nameof(customTag)),
            botAllowedTag ?? throw new ArgumentNullException(nameof(botAllowedTag)),
            secureValuesSentMeTag ?? throw new ArgumentNullException(nameof(secureValuesSentMeTag)),
            secureValuesSentTag ?? throw new ArgumentNullException(nameof(secureValuesSentTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case ChatCreateTag _: return 1;
                case ChatEditTitleTag _: return 2;
                case ChatEditPhotoTag _: return 3;
                case ChatDeletePhotoTag _: return 4;
                case ChatAddUserTag _: return 5;
                case ChatDeleteUserTag _: return 6;
                case ChatJoinedByLinkTag _: return 7;
                case ChannelCreateTag _: return 8;
                case ChatMigrateToTag _: return 9;
                case ChannelMigrateFromTag _: return 10;
                case PinMessageTag _: return 11;
                case HistoryClearTag _: return 12;
                case GameScoreTag _: return 13;
                case PaymentSentMeTag _: return 14;
                case PaymentSentTag _: return 15;
                case PhoneCallTag _: return 16;
                case ScreenshotTakenTag _: return 17;
                case CustomTag _: return 18;
                case BotAllowedTag _: return 19;
                case SecureValuesSentMeTag _: return 20;
                case SecureValuesSentTag _: return 21;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(MessageAction other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MessageAction x && Equals(x);
        public static bool operator ==(MessageAction x, MessageAction y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MessageAction x, MessageAction y) => !(x == y);

        public int CompareTo(MessageAction other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MessageAction x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageAction x, MessageAction y) => x.CompareTo(y) <= 0;
        public static bool operator <(MessageAction x, MessageAction y) => x.CompareTo(y) < 0;
        public static bool operator >(MessageAction x, MessageAction y) => x.CompareTo(y) > 0;
        public static bool operator >=(MessageAction x, MessageAction y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MessageAction.{_tag.GetType().Name}{_tag}";
    }
}