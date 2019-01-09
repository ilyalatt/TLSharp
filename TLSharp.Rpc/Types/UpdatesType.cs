using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class UpdatesType : ITlType, IEquatable<UpdatesType>, IComparable<UpdatesType>, IComparable
    {
        public sealed class TooLongTag : Record<TooLongTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe317af7e;
            

            
            public TooLongTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static TooLongTag DeserializeTag(BinaryReader br)
            {

                return new TooLongTag();
            }
        }

        public sealed class UpdateShortMessageTag : Record<UpdateShortMessageTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x914fbf11;
            
            public bool Out { get; }
            public bool Mentioned { get; }
            public bool MediaUnread { get; }
            public bool Silent { get; }
            public int Id { get; }
            public int UserId { get; }
            public string Message { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            public int Date { get; }
            public Option<T.MessageFwdHeader> FwdFrom { get; }
            public Option<int> ViaBotId { get; }
            public Option<int> ReplyToMsgId { get; }
            public Option<Arr<T.MessageEntity>> Entities { get; }
            
            public UpdateShortMessageTag(
                bool @out,
                bool mentioned,
                bool mediaUnread,
                bool silent,
                int id,
                int userId,
                Some<string> message,
                int pts,
                int ptsCount,
                int date,
                Option<T.MessageFwdHeader> fwdFrom,
                Option<int> viaBotId,
                Option<int> replyToMsgId,
                Option<Arr<T.MessageEntity>> entities
            ) {
                Out = @out;
                Mentioned = mentioned;
                MediaUnread = mediaUnread;
                Silent = silent;
                Id = id;
                UserId = userId;
                Message = message;
                Pts = pts;
                PtsCount = ptsCount;
                Date = date;
                FwdFrom = fwdFrom;
                ViaBotId = viaBotId;
                ReplyToMsgId = replyToMsgId;
                Entities = entities;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Out) | MaskBit(4, Mentioned) | MaskBit(5, MediaUnread) | MaskBit(13, Silent) | MaskBit(2, FwdFrom) | MaskBit(11, ViaBotId) | MaskBit(3, ReplyToMsgId) | MaskBit(7, Entities), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(Message, bw, WriteString);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(FwdFrom, bw, WriteOption<T.MessageFwdHeader>(WriteSerializable));
                Write(ViaBotId, bw, WriteOption<int>(WriteInt));
                Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            }
            
            internal static UpdateShortMessageTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var @out = Read(br, ReadOption(flags, 1));
                var mentioned = Read(br, ReadOption(flags, 4));
                var mediaUnread = Read(br, ReadOption(flags, 5));
                var silent = Read(br, ReadOption(flags, 13));
                var id = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var message = Read(br, ReadString);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var fwdFrom = Read(br, ReadOption(flags, 2, T.MessageFwdHeader.Deserialize));
                var viaBotId = Read(br, ReadOption(flags, 11, ReadInt));
                var replyToMsgId = Read(br, ReadOption(flags, 3, ReadInt));
                var entities = Read(br, ReadOption(flags, 7, ReadVector(T.MessageEntity.Deserialize)));
                return new UpdateShortMessageTag(@out, mentioned, mediaUnread, silent, id, userId, message, pts, ptsCount, date, fwdFrom, viaBotId, replyToMsgId, entities);
            }
        }

        public sealed class UpdateShortChatMessageTag : Record<UpdateShortChatMessageTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x16812688;
            
            public bool Out { get; }
            public bool Mentioned { get; }
            public bool MediaUnread { get; }
            public bool Silent { get; }
            public int Id { get; }
            public int FromId { get; }
            public int ChatId { get; }
            public string Message { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            public int Date { get; }
            public Option<T.MessageFwdHeader> FwdFrom { get; }
            public Option<int> ViaBotId { get; }
            public Option<int> ReplyToMsgId { get; }
            public Option<Arr<T.MessageEntity>> Entities { get; }
            
            public UpdateShortChatMessageTag(
                bool @out,
                bool mentioned,
                bool mediaUnread,
                bool silent,
                int id,
                int fromId,
                int chatId,
                Some<string> message,
                int pts,
                int ptsCount,
                int date,
                Option<T.MessageFwdHeader> fwdFrom,
                Option<int> viaBotId,
                Option<int> replyToMsgId,
                Option<Arr<T.MessageEntity>> entities
            ) {
                Out = @out;
                Mentioned = mentioned;
                MediaUnread = mediaUnread;
                Silent = silent;
                Id = id;
                FromId = fromId;
                ChatId = chatId;
                Message = message;
                Pts = pts;
                PtsCount = ptsCount;
                Date = date;
                FwdFrom = fwdFrom;
                ViaBotId = viaBotId;
                ReplyToMsgId = replyToMsgId;
                Entities = entities;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Out) | MaskBit(4, Mentioned) | MaskBit(5, MediaUnread) | MaskBit(13, Silent) | MaskBit(2, FwdFrom) | MaskBit(11, ViaBotId) | MaskBit(3, ReplyToMsgId) | MaskBit(7, Entities), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(FromId, bw, WriteInt);
                Write(ChatId, bw, WriteInt);
                Write(Message, bw, WriteString);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(FwdFrom, bw, WriteOption<T.MessageFwdHeader>(WriteSerializable));
                Write(ViaBotId, bw, WriteOption<int>(WriteInt));
                Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            }
            
            internal static UpdateShortChatMessageTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var @out = Read(br, ReadOption(flags, 1));
                var mentioned = Read(br, ReadOption(flags, 4));
                var mediaUnread = Read(br, ReadOption(flags, 5));
                var silent = Read(br, ReadOption(flags, 13));
                var id = Read(br, ReadInt);
                var fromId = Read(br, ReadInt);
                var chatId = Read(br, ReadInt);
                var message = Read(br, ReadString);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var fwdFrom = Read(br, ReadOption(flags, 2, T.MessageFwdHeader.Deserialize));
                var viaBotId = Read(br, ReadOption(flags, 11, ReadInt));
                var replyToMsgId = Read(br, ReadOption(flags, 3, ReadInt));
                var entities = Read(br, ReadOption(flags, 7, ReadVector(T.MessageEntity.Deserialize)));
                return new UpdateShortChatMessageTag(@out, mentioned, mediaUnread, silent, id, fromId, chatId, message, pts, ptsCount, date, fwdFrom, viaBotId, replyToMsgId, entities);
            }
        }

        public sealed class UpdateShortTag : Record<UpdateShortTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x78d4dec1;
            
            public T.Update Update { get; }
            public int Date { get; }
            
            public UpdateShortTag(
                Some<T.Update> update,
                int date
            ) {
                Update = update;
                Date = date;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Update, bw, WriteSerializable);
                Write(Date, bw, WriteInt);
            }
            
            internal static UpdateShortTag DeserializeTag(BinaryReader br)
            {
                var update = Read(br, T.Update.Deserialize);
                var date = Read(br, ReadInt);
                return new UpdateShortTag(update, date);
            }
        }

        public sealed class CombinedTag : Record<CombinedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x725b04c3;
            
            public Arr<T.Update> Updates { get; }
            public Arr<T.User> Users { get; }
            public Arr<T.Chat> Chats { get; }
            public int Date { get; }
            public int SeqStart { get; }
            public int Seq { get; }
            
            public CombinedTag(
                Some<Arr<T.Update>> updates,
                Some<Arr<T.User>> users,
                Some<Arr<T.Chat>> chats,
                int date,
                int seqStart,
                int seq
            ) {
                Updates = updates;
                Users = users;
                Chats = chats;
                Date = date;
                SeqStart = seqStart;
                Seq = seq;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Updates, bw, WriteVector<T.Update>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Date, bw, WriteInt);
                Write(SeqStart, bw, WriteInt);
                Write(Seq, bw, WriteInt);
            }
            
            internal static CombinedTag DeserializeTag(BinaryReader br)
            {
                var updates = Read(br, ReadVector(T.Update.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var date = Read(br, ReadInt);
                var seqStart = Read(br, ReadInt);
                var seq = Read(br, ReadInt);
                return new CombinedTag(updates, users, chats, date, seqStart, seq);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x74ae4240;
            
            public Arr<T.Update> Updates { get; }
            public Arr<T.User> Users { get; }
            public Arr<T.Chat> Chats { get; }
            public int Date { get; }
            public int Seq { get; }
            
            public Tag(
                Some<Arr<T.Update>> updates,
                Some<Arr<T.User>> users,
                Some<Arr<T.Chat>> chats,
                int date,
                int seq
            ) {
                Updates = updates;
                Users = users;
                Chats = chats;
                Date = date;
                Seq = seq;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Updates, bw, WriteVector<T.Update>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
                Write(Date, bw, WriteInt);
                Write(Seq, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var updates = Read(br, ReadVector(T.Update.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                var date = Read(br, ReadInt);
                var seq = Read(br, ReadInt);
                return new Tag(updates, users, chats, date, seq);
            }
        }

        public sealed class UpdateShortSentMessageTag : Record<UpdateShortSentMessageTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x11f1331c;
            
            public bool Out { get; }
            public int Id { get; }
            public int Pts { get; }
            public int PtsCount { get; }
            public int Date { get; }
            public Option<T.MessageMedia> Media { get; }
            public Option<Arr<T.MessageEntity>> Entities { get; }
            
            public UpdateShortSentMessageTag(
                bool @out,
                int id,
                int pts,
                int ptsCount,
                int date,
                Option<T.MessageMedia> media,
                Option<Arr<T.MessageEntity>> entities
            ) {
                Out = @out;
                Id = id;
                Pts = pts;
                PtsCount = ptsCount;
                Date = date;
                Media = media;
                Entities = entities;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Out) | MaskBit(9, Media) | MaskBit(7, Entities), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Media, bw, WriteOption<T.MessageMedia>(WriteSerializable));
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            }
            
            internal static UpdateShortSentMessageTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var @out = Read(br, ReadOption(flags, 1));
                var id = Read(br, ReadInt);
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var media = Read(br, ReadOption(flags, 9, T.MessageMedia.Deserialize));
                var entities = Read(br, ReadOption(flags, 7, ReadVector(T.MessageEntity.Deserialize)));
                return new UpdateShortSentMessageTag(@out, id, pts, ptsCount, date, media, entities);
            }
        }

        readonly ITlTypeTag _tag;
        UpdatesType(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator UpdatesType(TooLongTag tag) => new UpdatesType(tag);
        public static explicit operator UpdatesType(UpdateShortMessageTag tag) => new UpdatesType(tag);
        public static explicit operator UpdatesType(UpdateShortChatMessageTag tag) => new UpdatesType(tag);
        public static explicit operator UpdatesType(UpdateShortTag tag) => new UpdatesType(tag);
        public static explicit operator UpdatesType(CombinedTag tag) => new UpdatesType(tag);
        public static explicit operator UpdatesType(Tag tag) => new UpdatesType(tag);
        public static explicit operator UpdatesType(UpdateShortSentMessageTag tag) => new UpdatesType(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static UpdatesType Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xe317af7e: return (UpdatesType) TooLongTag.DeserializeTag(br);
                case 0x914fbf11: return (UpdatesType) UpdateShortMessageTag.DeserializeTag(br);
                case 0x16812688: return (UpdatesType) UpdateShortChatMessageTag.DeserializeTag(br);
                case 0x78d4dec1: return (UpdatesType) UpdateShortTag.DeserializeTag(br);
                case 0x725b04c3: return (UpdatesType) CombinedTag.DeserializeTag(br);
                case 0x74ae4240: return (UpdatesType) Tag.DeserializeTag(br);
                case 0x11f1331c: return (UpdatesType) UpdateShortSentMessageTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xe317af7e, 0x914fbf11, 0x16812688, 0x78d4dec1, 0x725b04c3, 0x74ae4240, 0x11f1331c });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<TooLongTag, T> tooLongTag = null,
            Func<UpdateShortMessageTag, T> updateShortMessageTag = null,
            Func<UpdateShortChatMessageTag, T> updateShortChatMessageTag = null,
            Func<UpdateShortTag, T> updateShortTag = null,
            Func<CombinedTag, T> combinedTag = null,
            Func<Tag, T> tag = null,
            Func<UpdateShortSentMessageTag, T> updateShortSentMessageTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case TooLongTag x when tooLongTag != null: return tooLongTag(x);
                case UpdateShortMessageTag x when updateShortMessageTag != null: return updateShortMessageTag(x);
                case UpdateShortChatMessageTag x when updateShortChatMessageTag != null: return updateShortChatMessageTag(x);
                case UpdateShortTag x when updateShortTag != null: return updateShortTag(x);
                case CombinedTag x when combinedTag != null: return combinedTag(x);
                case Tag x when tag != null: return tag(x);
                case UpdateShortSentMessageTag x when updateShortSentMessageTag != null: return updateShortSentMessageTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<TooLongTag, T> tooLongTag,
            Func<UpdateShortMessageTag, T> updateShortMessageTag,
            Func<UpdateShortChatMessageTag, T> updateShortChatMessageTag,
            Func<UpdateShortTag, T> updateShortTag,
            Func<CombinedTag, T> combinedTag,
            Func<Tag, T> tag,
            Func<UpdateShortSentMessageTag, T> updateShortSentMessageTag
        ) => Match(
            () => throw new Exception("WTF"),
            tooLongTag ?? throw new ArgumentNullException(nameof(tooLongTag)),
            updateShortMessageTag ?? throw new ArgumentNullException(nameof(updateShortMessageTag)),
            updateShortChatMessageTag ?? throw new ArgumentNullException(nameof(updateShortChatMessageTag)),
            updateShortTag ?? throw new ArgumentNullException(nameof(updateShortTag)),
            combinedTag ?? throw new ArgumentNullException(nameof(combinedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            updateShortSentMessageTag ?? throw new ArgumentNullException(nameof(updateShortSentMessageTag))
        );

        public bool Equals(UpdatesType other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is UpdatesType x && Equals(x);
        public static bool operator ==(UpdatesType a, UpdatesType b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(UpdatesType a, UpdatesType b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case TooLongTag _: return 0;
                case UpdateShortMessageTag _: return 1;
                case UpdateShortChatMessageTag _: return 2;
                case UpdateShortTag _: return 3;
                case CombinedTag _: return 4;
                case Tag _: return 5;
                case UpdateShortSentMessageTag _: return 6;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(UpdatesType other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UpdatesType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdatesType a, UpdatesType b) => a.CompareTo(b) <= 0;
        public static bool operator <(UpdatesType a, UpdatesType b) => a.CompareTo(b) < 0;
        public static bool operator >(UpdatesType a, UpdatesType b) => a.CompareTo(b) > 0;
        public static bool operator >=(UpdatesType a, UpdatesType b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}