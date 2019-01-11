using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MessageFwdHeader : ITlType, IEquatable<MessageFwdHeader>, IComparable<MessageFwdHeader>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x559ebe6d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Option<int> FromId;
            public readonly int Date;
            public readonly Option<int> ChannelId;
            public readonly Option<int> ChannelPost;
            public readonly Option<string> PostAuthor;
            public readonly Option<T.Peer> SavedFromPeer;
            public readonly Option<int> SavedFromMsgId;
            
            public Tag(
                Option<int> fromId,
                int date,
                Option<int> channelId,
                Option<int> channelPost,
                Option<string> postAuthor,
                Option<T.Peer> savedFromPeer,
                Option<int> savedFromMsgId
            ) {
                FromId = fromId;
                Date = date;
                ChannelId = channelId;
                ChannelPost = channelPost;
                PostAuthor = postAuthor;
                SavedFromPeer = savedFromPeer;
                SavedFromMsgId = savedFromMsgId;
            }
            
            (Option<int>, int, Option<int>, Option<int>, Option<string>, Option<T.Peer>, Option<int>) CmpTuple =>
                (FromId, Date, ChannelId, ChannelPost, PostAuthor, SavedFromPeer, SavedFromMsgId);

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

            public override string ToString() => $"(FromId: {FromId}, Date: {Date}, ChannelId: {ChannelId}, ChannelPost: {ChannelPost}, PostAuthor: {PostAuthor}, SavedFromPeer: {SavedFromPeer}, SavedFromMsgId: {SavedFromMsgId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, FromId) | MaskBit(1, ChannelId) | MaskBit(2, ChannelPost) | MaskBit(3, PostAuthor) | MaskBit(4, SavedFromPeer) | MaskBit(4, SavedFromMsgId), bw, WriteInt);
                Write(FromId, bw, WriteOption<int>(WriteInt));
                Write(Date, bw, WriteInt);
                Write(ChannelId, bw, WriteOption<int>(WriteInt));
                Write(ChannelPost, bw, WriteOption<int>(WriteInt));
                Write(PostAuthor, bw, WriteOption<string>(WriteString));
                Write(SavedFromPeer, bw, WriteOption<T.Peer>(WriteSerializable));
                Write(SavedFromMsgId, bw, WriteOption<int>(WriteInt));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var fromId = Read(br, ReadOption(flags, 0, ReadInt));
                var date = Read(br, ReadInt);
                var channelId = Read(br, ReadOption(flags, 1, ReadInt));
                var channelPost = Read(br, ReadOption(flags, 2, ReadInt));
                var postAuthor = Read(br, ReadOption(flags, 3, ReadString));
                var savedFromPeer = Read(br, ReadOption(flags, 4, T.Peer.Deserialize));
                var savedFromMsgId = Read(br, ReadOption(flags, 4, ReadInt));
                return new Tag(fromId, date, channelId, channelPost, postAuthor, savedFromPeer, savedFromMsgId);
            }
        }

        readonly ITlTypeTag _tag;
        MessageFwdHeader(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MessageFwdHeader(Tag tag) => new MessageFwdHeader(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MessageFwdHeader Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (MessageFwdHeader) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(MessageFwdHeader other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MessageFwdHeader x && Equals(x);
        public static bool operator ==(MessageFwdHeader x, MessageFwdHeader y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MessageFwdHeader x, MessageFwdHeader y) => !(x == y);

        public int CompareTo(MessageFwdHeader other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MessageFwdHeader x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) <= 0;
        public static bool operator <(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) < 0;
        public static bool operator >(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) > 0;
        public static bool operator >=(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MessageFwdHeader.{_tag.GetType().Name}{_tag}";
    }
}