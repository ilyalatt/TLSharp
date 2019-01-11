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
        public sealed class TooLongTag : ITlTypeTag, IEquatable<TooLongTag>, IComparable<TooLongTag>, IComparable
        {
            internal const uint TypeNumber = 0xe317af7e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public TooLongTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(TooLongTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TooLongTag x && Equals(x);
            public static bool operator ==(TooLongTag x, TooLongTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TooLongTag x, TooLongTag y) => !(x == y);

            public int CompareTo(TooLongTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TooLongTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TooLongTag x, TooLongTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TooLongTag x, TooLongTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TooLongTag x, TooLongTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TooLongTag x, TooLongTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static TooLongTag DeserializeTag(BinaryReader br)
            {

                return new TooLongTag();
            }
        }

        public sealed class UpdateShortMessageTag : ITlTypeTag, IEquatable<UpdateShortMessageTag>, IComparable<UpdateShortMessageTag>, IComparable
        {
            internal const uint TypeNumber = 0x914fbf11;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Out;
            public readonly bool Mentioned;
            public readonly bool MediaUnread;
            public readonly bool Silent;
            public readonly int Id;
            public readonly int UserId;
            public readonly string Message;
            public readonly int Pts;
            public readonly int PtsCount;
            public readonly int Date;
            public readonly Option<T.MessageFwdHeader> FwdFrom;
            public readonly Option<int> ViaBotId;
            public readonly Option<int> ReplyToMsgId;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            
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
            
            (bool, bool, bool, bool, int, int, string, int, int, int, Option<T.MessageFwdHeader>, Option<int>, Option<int>, Option<Arr<T.MessageEntity>>) CmpTuple =>
                (Out, Mentioned, MediaUnread, Silent, Id, UserId, Message, Pts, PtsCount, Date, FwdFrom, ViaBotId, ReplyToMsgId, Entities);

            public bool Equals(UpdateShortMessageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UpdateShortMessageTag x && Equals(x);
            public static bool operator ==(UpdateShortMessageTag x, UpdateShortMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UpdateShortMessageTag x, UpdateShortMessageTag y) => !(x == y);

            public int CompareTo(UpdateShortMessageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UpdateShortMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UpdateShortMessageTag x, UpdateShortMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UpdateShortMessageTag x, UpdateShortMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UpdateShortMessageTag x, UpdateShortMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UpdateShortMessageTag x, UpdateShortMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Out: {Out}, Mentioned: {Mentioned}, MediaUnread: {MediaUnread}, Silent: {Silent}, Id: {Id}, UserId: {UserId}, Message: {Message}, Pts: {Pts}, PtsCount: {PtsCount}, Date: {Date}, FwdFrom: {FwdFrom}, ViaBotId: {ViaBotId}, ReplyToMsgId: {ReplyToMsgId}, Entities: {Entities})";
            
            
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

        public sealed class UpdateShortChatMessageTag : ITlTypeTag, IEquatable<UpdateShortChatMessageTag>, IComparable<UpdateShortChatMessageTag>, IComparable
        {
            internal const uint TypeNumber = 0x16812688;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Out;
            public readonly bool Mentioned;
            public readonly bool MediaUnread;
            public readonly bool Silent;
            public readonly int Id;
            public readonly int FromId;
            public readonly int ChatId;
            public readonly string Message;
            public readonly int Pts;
            public readonly int PtsCount;
            public readonly int Date;
            public readonly Option<T.MessageFwdHeader> FwdFrom;
            public readonly Option<int> ViaBotId;
            public readonly Option<int> ReplyToMsgId;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            
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
            
            (bool, bool, bool, bool, int, int, int, string, int, int, int, Option<T.MessageFwdHeader>, Option<int>, Option<int>, Option<Arr<T.MessageEntity>>) CmpTuple =>
                (Out, Mentioned, MediaUnread, Silent, Id, FromId, ChatId, Message, Pts, PtsCount, Date, FwdFrom, ViaBotId, ReplyToMsgId, Entities);

            public bool Equals(UpdateShortChatMessageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UpdateShortChatMessageTag x && Equals(x);
            public static bool operator ==(UpdateShortChatMessageTag x, UpdateShortChatMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UpdateShortChatMessageTag x, UpdateShortChatMessageTag y) => !(x == y);

            public int CompareTo(UpdateShortChatMessageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UpdateShortChatMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UpdateShortChatMessageTag x, UpdateShortChatMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UpdateShortChatMessageTag x, UpdateShortChatMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UpdateShortChatMessageTag x, UpdateShortChatMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UpdateShortChatMessageTag x, UpdateShortChatMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Out: {Out}, Mentioned: {Mentioned}, MediaUnread: {MediaUnread}, Silent: {Silent}, Id: {Id}, FromId: {FromId}, ChatId: {ChatId}, Message: {Message}, Pts: {Pts}, PtsCount: {PtsCount}, Date: {Date}, FwdFrom: {FwdFrom}, ViaBotId: {ViaBotId}, ReplyToMsgId: {ReplyToMsgId}, Entities: {Entities})";
            
            
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

        public sealed class UpdateShortTag : ITlTypeTag, IEquatable<UpdateShortTag>, IComparable<UpdateShortTag>, IComparable
        {
            internal const uint TypeNumber = 0x78d4dec1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Update Update;
            public readonly int Date;
            
            public UpdateShortTag(
                Some<T.Update> update,
                int date
            ) {
                Update = update;
                Date = date;
            }
            
            (T.Update, int) CmpTuple =>
                (Update, Date);

            public bool Equals(UpdateShortTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UpdateShortTag x && Equals(x);
            public static bool operator ==(UpdateShortTag x, UpdateShortTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UpdateShortTag x, UpdateShortTag y) => !(x == y);

            public int CompareTo(UpdateShortTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UpdateShortTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UpdateShortTag x, UpdateShortTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UpdateShortTag x, UpdateShortTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UpdateShortTag x, UpdateShortTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UpdateShortTag x, UpdateShortTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Update: {Update}, Date: {Date})";
            
            
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

        public sealed class CombinedTag : ITlTypeTag, IEquatable<CombinedTag>, IComparable<CombinedTag>, IComparable
        {
            internal const uint TypeNumber = 0x725b04c3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.Update> Updates;
            public readonly Arr<T.User> Users;
            public readonly Arr<T.Chat> Chats;
            public readonly int Date;
            public readonly int SeqStart;
            public readonly int Seq;
            
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
            
            (Arr<T.Update>, Arr<T.User>, Arr<T.Chat>, int, int, int) CmpTuple =>
                (Updates, Users, Chats, Date, SeqStart, Seq);

            public bool Equals(CombinedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CombinedTag x && Equals(x);
            public static bool operator ==(CombinedTag x, CombinedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CombinedTag x, CombinedTag y) => !(x == y);

            public int CompareTo(CombinedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CombinedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CombinedTag x, CombinedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CombinedTag x, CombinedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CombinedTag x, CombinedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CombinedTag x, CombinedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Updates: {Updates}, Users: {Users}, Chats: {Chats}, Date: {Date}, SeqStart: {SeqStart}, Seq: {Seq})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x74ae4240;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.Update> Updates;
            public readonly Arr<T.User> Users;
            public readonly Arr<T.Chat> Chats;
            public readonly int Date;
            public readonly int Seq;
            
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
            
            (Arr<T.Update>, Arr<T.User>, Arr<T.Chat>, int, int) CmpTuple =>
                (Updates, Users, Chats, Date, Seq);

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

            public override string ToString() => $"(Updates: {Updates}, Users: {Users}, Chats: {Chats}, Date: {Date}, Seq: {Seq})";
            
            
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

        public sealed class UpdateShortSentMessageTag : ITlTypeTag, IEquatable<UpdateShortSentMessageTag>, IComparable<UpdateShortSentMessageTag>, IComparable
        {
            internal const uint TypeNumber = 0x11f1331c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Out;
            public readonly int Id;
            public readonly int Pts;
            public readonly int PtsCount;
            public readonly int Date;
            public readonly Option<T.MessageMedia> Media;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            
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
            
            (bool, int, int, int, int, Option<T.MessageMedia>, Option<Arr<T.MessageEntity>>) CmpTuple =>
                (Out, Id, Pts, PtsCount, Date, Media, Entities);

            public bool Equals(UpdateShortSentMessageTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UpdateShortSentMessageTag x && Equals(x);
            public static bool operator ==(UpdateShortSentMessageTag x, UpdateShortSentMessageTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UpdateShortSentMessageTag x, UpdateShortSentMessageTag y) => !(x == y);

            public int CompareTo(UpdateShortSentMessageTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UpdateShortSentMessageTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UpdateShortSentMessageTag x, UpdateShortSentMessageTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UpdateShortSentMessageTag x, UpdateShortSentMessageTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UpdateShortSentMessageTag x, UpdateShortSentMessageTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UpdateShortSentMessageTag x, UpdateShortSentMessageTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Out: {Out}, Id: {Id}, Pts: {Pts}, PtsCount: {PtsCount}, Date: {Date}, Media: {Media}, Entities: {Entities})";
            
            
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
                case TooLongTag.TypeNumber: return (UpdatesType) TooLongTag.DeserializeTag(br);
                case UpdateShortMessageTag.TypeNumber: return (UpdatesType) UpdateShortMessageTag.DeserializeTag(br);
                case UpdateShortChatMessageTag.TypeNumber: return (UpdatesType) UpdateShortChatMessageTag.DeserializeTag(br);
                case UpdateShortTag.TypeNumber: return (UpdatesType) UpdateShortTag.DeserializeTag(br);
                case CombinedTag.TypeNumber: return (UpdatesType) CombinedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (UpdatesType) Tag.DeserializeTag(br);
                case UpdateShortSentMessageTag.TypeNumber: return (UpdatesType) UpdateShortSentMessageTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { TooLongTag.TypeNumber, UpdateShortMessageTag.TypeNumber, UpdateShortChatMessageTag.TypeNumber, UpdateShortTag.TypeNumber, CombinedTag.TypeNumber, Tag.TypeNumber, UpdateShortSentMessageTag.TypeNumber });
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

        public bool Equals(UpdatesType other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is UpdatesType x && Equals(x);
        public static bool operator ==(UpdatesType x, UpdatesType y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdatesType x, UpdatesType y) => !(x == y);

        public int CompareTo(UpdatesType other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is UpdatesType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdatesType x, UpdatesType y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdatesType x, UpdatesType y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdatesType x, UpdatesType y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdatesType x, UpdatesType y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"UpdatesType.{_tag.GetType().Name}{_tag}";
    }
}