using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Message : ITlType, IEquatable<Message>, IComparable<Message>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x83e5de54;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            
            public EmptyTag(
                int id
            ) {
                Id = id;
            }
            
            int CmpTuple =>
                Id;

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
            internal const uint TypeNumber = 0xc09be45f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Out;
            public readonly bool Mentioned;
            public readonly bool MediaUnread;
            public readonly bool Silent;
            public readonly bool Post;
            public readonly int Id;
            public readonly Option<int> FromId;
            public readonly T.Peer ToId;
            public readonly Option<T.MessageFwdHeader> FwdFrom;
            public readonly Option<int> ViaBotId;
            public readonly Option<int> ReplyToMsgId;
            public readonly int Date;
            public readonly string Message;
            public readonly Option<T.MessageMedia> Media;
            public readonly Option<T.ReplyMarkup> ReplyMarkup;
            public readonly Option<Arr<T.MessageEntity>> Entities;
            public readonly Option<int> Views;
            public readonly Option<int> EditDate;
            
            public Tag(
                bool @out,
                bool mentioned,
                bool mediaUnread,
                bool silent,
                bool post,
                int id,
                Option<int> fromId,
                Some<T.Peer> toId,
                Option<T.MessageFwdHeader> fwdFrom,
                Option<int> viaBotId,
                Option<int> replyToMsgId,
                int date,
                Some<string> message,
                Option<T.MessageMedia> media,
                Option<T.ReplyMarkup> replyMarkup,
                Option<Arr<T.MessageEntity>> entities,
                Option<int> views,
                Option<int> editDate
            ) {
                Out = @out;
                Mentioned = mentioned;
                MediaUnread = mediaUnread;
                Silent = silent;
                Post = post;
                Id = id;
                FromId = fromId;
                ToId = toId;
                FwdFrom = fwdFrom;
                ViaBotId = viaBotId;
                ReplyToMsgId = replyToMsgId;
                Date = date;
                Message = message;
                Media = media;
                ReplyMarkup = replyMarkup;
                Entities = entities;
                Views = views;
                EditDate = editDate;
            }
            
            (bool, bool, bool, bool, bool, int, Option<int>, T.Peer, Option<T.MessageFwdHeader>, Option<int>, Option<int>, int, string, Option<T.MessageMedia>, Option<T.ReplyMarkup>, Option<Arr<T.MessageEntity>>, Option<int>, Option<int>) CmpTuple =>
                (Out, Mentioned, MediaUnread, Silent, Post, Id, FromId, ToId, FwdFrom, ViaBotId, ReplyToMsgId, Date, Message, Media, ReplyMarkup, Entities, Views, EditDate);

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

            public override string ToString() => $"(Out: {Out}, Mentioned: {Mentioned}, MediaUnread: {MediaUnread}, Silent: {Silent}, Post: {Post}, Id: {Id}, FromId: {FromId}, ToId: {ToId}, FwdFrom: {FwdFrom}, ViaBotId: {ViaBotId}, ReplyToMsgId: {ReplyToMsgId}, Date: {Date}, Message: {Message}, Media: {Media}, ReplyMarkup: {ReplyMarkup}, Entities: {Entities}, Views: {Views}, EditDate: {EditDate})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Out) | MaskBit(4, Mentioned) | MaskBit(5, MediaUnread) | MaskBit(13, Silent) | MaskBit(14, Post) | MaskBit(8, FromId) | MaskBit(2, FwdFrom) | MaskBit(11, ViaBotId) | MaskBit(3, ReplyToMsgId) | MaskBit(9, Media) | MaskBit(6, ReplyMarkup) | MaskBit(7, Entities) | MaskBit(10, Views) | MaskBit(15, EditDate), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(FromId, bw, WriteOption<int>(WriteInt));
                Write(ToId, bw, WriteSerializable);
                Write(FwdFrom, bw, WriteOption<T.MessageFwdHeader>(WriteSerializable));
                Write(ViaBotId, bw, WriteOption<int>(WriteInt));
                Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
                Write(Date, bw, WriteInt);
                Write(Message, bw, WriteString);
                Write(Media, bw, WriteOption<T.MessageMedia>(WriteSerializable));
                Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
                Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
                Write(Views, bw, WriteOption<int>(WriteInt));
                Write(EditDate, bw, WriteOption<int>(WriteInt));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var @out = Read(br, ReadOption(flags, 1));
                var mentioned = Read(br, ReadOption(flags, 4));
                var mediaUnread = Read(br, ReadOption(flags, 5));
                var silent = Read(br, ReadOption(flags, 13));
                var post = Read(br, ReadOption(flags, 14));
                var id = Read(br, ReadInt);
                var fromId = Read(br, ReadOption(flags, 8, ReadInt));
                var toId = Read(br, T.Peer.Deserialize);
                var fwdFrom = Read(br, ReadOption(flags, 2, T.MessageFwdHeader.Deserialize));
                var viaBotId = Read(br, ReadOption(flags, 11, ReadInt));
                var replyToMsgId = Read(br, ReadOption(flags, 3, ReadInt));
                var date = Read(br, ReadInt);
                var message = Read(br, ReadString);
                var media = Read(br, ReadOption(flags, 9, T.MessageMedia.Deserialize));
                var replyMarkup = Read(br, ReadOption(flags, 6, T.ReplyMarkup.Deserialize));
                var entities = Read(br, ReadOption(flags, 7, ReadVector(T.MessageEntity.Deserialize)));
                var views = Read(br, ReadOption(flags, 10, ReadInt));
                var editDate = Read(br, ReadOption(flags, 15, ReadInt));
                return new Tag(@out, mentioned, mediaUnread, silent, post, id, fromId, toId, fwdFrom, viaBotId, replyToMsgId, date, message, media, replyMarkup, entities, views, editDate);
            }
        }

        public sealed class ServiceTag : ITlTypeTag, IEquatable<ServiceTag>, IComparable<ServiceTag>, IComparable
        {
            internal const uint TypeNumber = 0x9e19a1f6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Out;
            public readonly bool Mentioned;
            public readonly bool MediaUnread;
            public readonly bool Silent;
            public readonly bool Post;
            public readonly int Id;
            public readonly Option<int> FromId;
            public readonly T.Peer ToId;
            public readonly Option<int> ReplyToMsgId;
            public readonly int Date;
            public readonly T.MessageAction Action;
            
            public ServiceTag(
                bool @out,
                bool mentioned,
                bool mediaUnread,
                bool silent,
                bool post,
                int id,
                Option<int> fromId,
                Some<T.Peer> toId,
                Option<int> replyToMsgId,
                int date,
                Some<T.MessageAction> action
            ) {
                Out = @out;
                Mentioned = mentioned;
                MediaUnread = mediaUnread;
                Silent = silent;
                Post = post;
                Id = id;
                FromId = fromId;
                ToId = toId;
                ReplyToMsgId = replyToMsgId;
                Date = date;
                Action = action;
            }
            
            (bool, bool, bool, bool, bool, int, Option<int>, T.Peer, Option<int>, int, T.MessageAction) CmpTuple =>
                (Out, Mentioned, MediaUnread, Silent, Post, Id, FromId, ToId, ReplyToMsgId, Date, Action);

            public bool Equals(ServiceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ServiceTag x && Equals(x);
            public static bool operator ==(ServiceTag x, ServiceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ServiceTag x, ServiceTag y) => !(x == y);

            public int CompareTo(ServiceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ServiceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ServiceTag x, ServiceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ServiceTag x, ServiceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ServiceTag x, ServiceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ServiceTag x, ServiceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Out: {Out}, Mentioned: {Mentioned}, MediaUnread: {MediaUnread}, Silent: {Silent}, Post: {Post}, Id: {Id}, FromId: {FromId}, ToId: {ToId}, ReplyToMsgId: {ReplyToMsgId}, Date: {Date}, Action: {Action})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, Out) | MaskBit(4, Mentioned) | MaskBit(5, MediaUnread) | MaskBit(13, Silent) | MaskBit(14, Post) | MaskBit(8, FromId) | MaskBit(3, ReplyToMsgId), bw, WriteInt);
                Write(Id, bw, WriteInt);
                Write(FromId, bw, WriteOption<int>(WriteInt));
                Write(ToId, bw, WriteSerializable);
                Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
                Write(Date, bw, WriteInt);
                Write(Action, bw, WriteSerializable);
            }
            
            internal static ServiceTag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var @out = Read(br, ReadOption(flags, 1));
                var mentioned = Read(br, ReadOption(flags, 4));
                var mediaUnread = Read(br, ReadOption(flags, 5));
                var silent = Read(br, ReadOption(flags, 13));
                var post = Read(br, ReadOption(flags, 14));
                var id = Read(br, ReadInt);
                var fromId = Read(br, ReadOption(flags, 8, ReadInt));
                var toId = Read(br, T.Peer.Deserialize);
                var replyToMsgId = Read(br, ReadOption(flags, 3, ReadInt));
                var date = Read(br, ReadInt);
                var action = Read(br, T.MessageAction.Deserialize);
                return new ServiceTag(@out, mentioned, mediaUnread, silent, post, id, fromId, toId, replyToMsgId, date, action);
            }
        }

        readonly ITlTypeTag _tag;
        Message(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Message(EmptyTag tag) => new Message(tag);
        public static explicit operator Message(Tag tag) => new Message(tag);
        public static explicit operator Message(ServiceTag tag) => new Message(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Message Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (Message) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (Message) Tag.DeserializeTag(br);
                case ServiceTag.TypeNumber: return (Message) ServiceTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber, ServiceTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null,
            Func<ServiceTag, T> serviceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                case ServiceTag x when serviceTag != null: return serviceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag,
            Func<ServiceTag, T> serviceTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            serviceTag ?? throw new ArgumentNullException(nameof(serviceTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                case ServiceTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Message other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Message x && Equals(x);
        public static bool operator ==(Message x, Message y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Message x, Message y) => !(x == y);

        public int CompareTo(Message other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Message x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Message x, Message y) => x.CompareTo(y) <= 0;
        public static bool operator <(Message x, Message y) => x.CompareTo(y) < 0;
        public static bool operator >(Message x, Message y) => x.CompareTo(y) > 0;
        public static bool operator >=(Message x, Message y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Message.{_tag.GetType().Name}{_tag}";
    }
}