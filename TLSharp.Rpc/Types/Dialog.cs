using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Dialog : ITlType, IEquatable<Dialog>, IComparable<Dialog>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x66ffba14;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Pinned;
            public readonly T.Peer Peer;
            public readonly int TopMessage;
            public readonly int ReadInboxMaxId;
            public readonly int ReadOutboxMaxId;
            public readonly int UnreadCount;
            public readonly T.PeerNotifySettings NotifySettings;
            public readonly Option<int> Pts;
            public readonly Option<T.DraftMessage> Draft;
            
            public Tag(
                bool pinned,
                Some<T.Peer> peer,
                int topMessage,
                int readInboxMaxId,
                int readOutboxMaxId,
                int unreadCount,
                Some<T.PeerNotifySettings> notifySettings,
                Option<int> pts,
                Option<T.DraftMessage> draft
            ) {
                Pinned = pinned;
                Peer = peer;
                TopMessage = topMessage;
                ReadInboxMaxId = readInboxMaxId;
                ReadOutboxMaxId = readOutboxMaxId;
                UnreadCount = unreadCount;
                NotifySettings = notifySettings;
                Pts = pts;
                Draft = draft;
            }
            
            (bool, T.Peer, int, int, int, int, T.PeerNotifySettings, Option<int>, Option<T.DraftMessage>) CmpTuple =>
                (Pinned, Peer, TopMessage, ReadInboxMaxId, ReadOutboxMaxId, UnreadCount, NotifySettings, Pts, Draft);

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

            public override string ToString() => $"(Pinned: {Pinned}, Peer: {Peer}, TopMessage: {TopMessage}, ReadInboxMaxId: {ReadInboxMaxId}, ReadOutboxMaxId: {ReadOutboxMaxId}, UnreadCount: {UnreadCount}, NotifySettings: {NotifySettings}, Pts: {Pts}, Draft: {Draft})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(2, Pinned) | MaskBit(0, Pts) | MaskBit(1, Draft), bw, WriteInt);
                Write(Peer, bw, WriteSerializable);
                Write(TopMessage, bw, WriteInt);
                Write(ReadInboxMaxId, bw, WriteInt);
                Write(ReadOutboxMaxId, bw, WriteInt);
                Write(UnreadCount, bw, WriteInt);
                Write(NotifySettings, bw, WriteSerializable);
                Write(Pts, bw, WriteOption<int>(WriteInt));
                Write(Draft, bw, WriteOption<T.DraftMessage>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var pinned = Read(br, ReadOption(flags, 2));
                var peer = Read(br, T.Peer.Deserialize);
                var topMessage = Read(br, ReadInt);
                var readInboxMaxId = Read(br, ReadInt);
                var readOutboxMaxId = Read(br, ReadInt);
                var unreadCount = Read(br, ReadInt);
                var notifySettings = Read(br, T.PeerNotifySettings.Deserialize);
                var pts = Read(br, ReadOption(flags, 0, ReadInt));
                var draft = Read(br, ReadOption(flags, 1, T.DraftMessage.Deserialize));
                return new Tag(pinned, peer, topMessage, readInboxMaxId, readOutboxMaxId, unreadCount, notifySettings, pts, draft);
            }
        }

        readonly ITlTypeTag _tag;
        Dialog(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Dialog(Tag tag) => new Dialog(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Dialog Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Dialog) Tag.DeserializeTag(br);
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

        public bool Equals(Dialog other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Dialog x && Equals(x);
        public static bool operator ==(Dialog x, Dialog y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Dialog x, Dialog y) => !(x == y);

        public int CompareTo(Dialog other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Dialog x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Dialog x, Dialog y) => x.CompareTo(y) <= 0;
        public static bool operator <(Dialog x, Dialog y) => x.CompareTo(y) < 0;
        public static bool operator >(Dialog x, Dialog y) => x.CompareTo(y) > 0;
        public static bool operator >=(Dialog x, Dialog y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Dialog.{_tag.GetType().Name}{_tag}";
    }
}