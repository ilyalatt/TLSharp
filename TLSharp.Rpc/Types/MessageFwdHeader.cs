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
            internal const uint TypeNumber = 0xc786ddcb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Option<int> FromId { get; }
            public int Date { get; }
            public Option<int> ChannelId { get; }
            public Option<int> ChannelPost { get; }
            
            public Tag(
                Option<int> fromId,
                int date,
                Option<int> channelId,
                Option<int> channelPost
            ) {
                FromId = fromId;
                Date = date;
                ChannelId = channelId;
                ChannelPost = channelPost;
            }
            
            (Option<int>, int, Option<int>, Option<int>) CmpTuple =>
                (FromId, Date, ChannelId, ChannelPost);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(FromId: {FromId}, Date: {Date}, ChannelId: {ChannelId}, ChannelPost: {ChannelPost})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, FromId) | MaskBit(1, ChannelId) | MaskBit(2, ChannelPost), bw, WriteInt);
                Write(FromId, bw, WriteOption<int>(WriteInt));
                Write(Date, bw, WriteInt);
                Write(ChannelId, bw, WriteOption<int>(WriteInt));
                Write(ChannelPost, bw, WriteOption<int>(WriteInt));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var fromId = Read(br, ReadOption(flags, 0, ReadInt));
                var date = Read(br, ReadInt);
                var channelId = Read(br, ReadOption(flags, 1, ReadInt));
                var channelPost = Read(br, ReadOption(flags, 2, ReadInt));
                return new Tag(fromId, date, channelId, channelPost);
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

        public bool Equals(MessageFwdHeader other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is MessageFwdHeader x && Equals(x);
        public static bool operator ==(MessageFwdHeader x, MessageFwdHeader y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MessageFwdHeader x, MessageFwdHeader y) => !(x == y);

        public int CompareTo(MessageFwdHeader other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MessageFwdHeader x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) <= 0;
        public static bool operator <(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) < 0;
        public static bool operator >(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) > 0;
        public static bool operator >=(MessageFwdHeader x, MessageFwdHeader y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MessageFwdHeader.{_tag.GetType().Name}{_tag}";
    }
}