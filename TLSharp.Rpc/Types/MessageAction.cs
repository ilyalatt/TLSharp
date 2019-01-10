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
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb6aef7b0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class ChatCreateTag : Record<ChatCreateTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xa6638b9a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Title { get; }
            public Arr<int> Users { get; }
            
            public ChatCreateTag(
                Some<string> title,
                Some<Arr<int>> users
            ) {
                Title = title;
                Users = users;
            }
            
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

        public sealed class ChatEditTitleTag : Record<ChatEditTitleTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb5a1ce5a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Title { get; }
            
            public ChatEditTitleTag(
                Some<string> title
            ) {
                Title = title;
            }
            
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

        public sealed class ChatEditPhotoTag : Record<ChatEditPhotoTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x7fcb13a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.Photo Photo { get; }
            
            public ChatEditPhotoTag(
                Some<T.Photo> photo
            ) {
                Photo = photo;
            }
            
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

        public sealed class ChatDeletePhotoTag : Record<ChatDeletePhotoTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x95e3fbef;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChatDeletePhotoTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatDeletePhotoTag DeserializeTag(BinaryReader br)
            {

                return new ChatDeletePhotoTag();
            }
        }

        public sealed class ChatAddUserTag : Record<ChatAddUserTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x488a7337;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Users { get; }
            
            public ChatAddUserTag(
                Some<Arr<int>> users
            ) {
                Users = users;
            }
            
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

        public sealed class ChatDeleteUserTag : Record<ChatDeleteUserTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb2ae9b0c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            
            public ChatDeleteUserTag(
                int userId
            ) {
                UserId = userId;
            }
            
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

        public sealed class ChatJoinedByLinkTag : Record<ChatJoinedByLinkTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf89cf5e8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int InviterId { get; }
            
            public ChatJoinedByLinkTag(
                int inviterId
            ) {
                InviterId = inviterId;
            }
            
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

        public sealed class ChannelCreateTag : Record<ChannelCreateTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x95d2ac92;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Title { get; }
            
            public ChannelCreateTag(
                Some<string> title
            ) {
                Title = title;
            }
            
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

        public sealed class ChatMigrateToTag : Record<ChatMigrateToTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x51bdb021;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int ChannelId { get; }
            
            public ChatMigrateToTag(
                int channelId
            ) {
                ChannelId = channelId;
            }
            
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

        public sealed class ChannelMigrateFromTag : Record<ChannelMigrateFromTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xb055eaee;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Title { get; }
            public int ChatId { get; }
            
            public ChannelMigrateFromTag(
                Some<string> title,
                int chatId
            ) {
                Title = title;
                ChatId = chatId;
            }
            
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

        public sealed class PinMessageTag : Record<PinMessageTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x94bd38ed;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public PinMessageTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static PinMessageTag DeserializeTag(BinaryReader br)
            {

                return new PinMessageTag();
            }
        }

        public sealed class HistoryClearTag : Record<HistoryClearTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x9fbab604;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public HistoryClearTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HistoryClearTag DeserializeTag(BinaryReader br)
            {

                return new HistoryClearTag();
            }
        }

        public sealed class GameScoreTag : Record<GameScoreTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x92a72876;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long GameId { get; }
            public int Score { get; }
            
            public GameScoreTag(
                long gameId,
                int score
            ) {
                GameId = gameId;
                Score = score;
            }
            
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

        public sealed class PaymentSentMeTag : Record<PaymentSentMeTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x8f31b327;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Currency { get; }
            public long TotalAmount { get; }
            public Arr<byte> Payload { get; }
            public Option<T.PaymentRequestedInfo> Info { get; }
            public Option<string> ShippingOptionId { get; }
            public T.PaymentCharge Charge { get; }
            
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

        public sealed class PaymentSentTag : Record<PaymentSentTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x40699cd0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Currency { get; }
            public long TotalAmount { get; }
            
            public PaymentSentTag(
                Some<string> currency,
                long totalAmount
            ) {
                Currency = currency;
                TotalAmount = totalAmount;
            }
            
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

        public sealed class PhoneCallTag : Record<PhoneCallTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x80e11a7f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long CallId { get; }
            public Option<T.PhoneCallDiscardReason> Reason { get; }
            public Option<int> Duration { get; }
            
            public PhoneCallTag(
                long callId,
                Option<T.PhoneCallDiscardReason> reason,
                Option<int> duration
            ) {
                CallId = callId;
                Reason = reason;
                Duration = duration;
            }
            
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
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, ChatCreateTag.TypeNumber, ChatEditTitleTag.TypeNumber, ChatEditPhotoTag.TypeNumber, ChatDeletePhotoTag.TypeNumber, ChatAddUserTag.TypeNumber, ChatDeleteUserTag.TypeNumber, ChatJoinedByLinkTag.TypeNumber, ChannelCreateTag.TypeNumber, ChatMigrateToTag.TypeNumber, ChannelMigrateFromTag.TypeNumber, PinMessageTag.TypeNumber, HistoryClearTag.TypeNumber, GameScoreTag.TypeNumber, PaymentSentMeTag.TypeNumber, PaymentSentTag.TypeNumber, PhoneCallTag.TypeNumber });
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
            Func<PhoneCallTag, T> phoneCallTag = null
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
            Func<PhoneCallTag, T> phoneCallTag
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
            phoneCallTag ?? throw new ArgumentNullException(nameof(phoneCallTag))
        );

        public bool Equals(MessageAction other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MessageAction x && Equals(x);
        public static bool operator ==(MessageAction a, MessageAction b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MessageAction a, MessageAction b) => !(a == b);

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
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MessageAction other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MessageAction x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageAction a, MessageAction b) => a.CompareTo(b) <= 0;
        public static bool operator <(MessageAction a, MessageAction b) => a.CompareTo(b) < 0;
        public static bool operator >(MessageAction a, MessageAction b) => a.CompareTo(b) > 0;
        public static bool operator >=(MessageAction a, MessageAction b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}