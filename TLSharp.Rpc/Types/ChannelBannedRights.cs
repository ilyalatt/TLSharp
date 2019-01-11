using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChannelBannedRights : ITlType, IEquatable<ChannelBannedRights>, IComparable<ChannelBannedRights>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x58cf4249;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool ViewMessages;
            public readonly bool SendMessages;
            public readonly bool SendMedia;
            public readonly bool SendStickers;
            public readonly bool SendGifs;
            public readonly bool SendGames;
            public readonly bool SendInline;
            public readonly bool EmbedLinks;
            public readonly int UntilDate;
            
            public Tag(
                bool viewMessages,
                bool sendMessages,
                bool sendMedia,
                bool sendStickers,
                bool sendGifs,
                bool sendGames,
                bool sendInline,
                bool embedLinks,
                int untilDate
            ) {
                ViewMessages = viewMessages;
                SendMessages = sendMessages;
                SendMedia = sendMedia;
                SendStickers = sendStickers;
                SendGifs = sendGifs;
                SendGames = sendGames;
                SendInline = sendInline;
                EmbedLinks = embedLinks;
                UntilDate = untilDate;
            }
            
            (bool, bool, bool, bool, bool, bool, bool, bool, int) CmpTuple =>
                (ViewMessages, SendMessages, SendMedia, SendStickers, SendGifs, SendGames, SendInline, EmbedLinks, UntilDate);

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

            public override string ToString() => $"(ViewMessages: {ViewMessages}, SendMessages: {SendMessages}, SendMedia: {SendMedia}, SendStickers: {SendStickers}, SendGifs: {SendGifs}, SendGames: {SendGames}, SendInline: {SendInline}, EmbedLinks: {EmbedLinks}, UntilDate: {UntilDate})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, ViewMessages) | MaskBit(1, SendMessages) | MaskBit(2, SendMedia) | MaskBit(3, SendStickers) | MaskBit(4, SendGifs) | MaskBit(5, SendGames) | MaskBit(6, SendInline) | MaskBit(7, EmbedLinks), bw, WriteInt);
                Write(UntilDate, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var viewMessages = Read(br, ReadOption(flags, 0));
                var sendMessages = Read(br, ReadOption(flags, 1));
                var sendMedia = Read(br, ReadOption(flags, 2));
                var sendStickers = Read(br, ReadOption(flags, 3));
                var sendGifs = Read(br, ReadOption(flags, 4));
                var sendGames = Read(br, ReadOption(flags, 5));
                var sendInline = Read(br, ReadOption(flags, 6));
                var embedLinks = Read(br, ReadOption(flags, 7));
                var untilDate = Read(br, ReadInt);
                return new Tag(viewMessages, sendMessages, sendMedia, sendStickers, sendGifs, sendGames, sendInline, embedLinks, untilDate);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelBannedRights(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelBannedRights(Tag tag) => new ChannelBannedRights(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelBannedRights Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelBannedRights) Tag.DeserializeTag(br);
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

        public bool Equals(ChannelBannedRights other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelBannedRights x && Equals(x);
        public static bool operator ==(ChannelBannedRights x, ChannelBannedRights y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelBannedRights x, ChannelBannedRights y) => !(x == y);

        public int CompareTo(ChannelBannedRights other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelBannedRights x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelBannedRights x, ChannelBannedRights y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelBannedRights x, ChannelBannedRights y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelBannedRights x, ChannelBannedRights y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelBannedRights x, ChannelBannedRights y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelBannedRights.{_tag.GetType().Name}{_tag}";
    }
}