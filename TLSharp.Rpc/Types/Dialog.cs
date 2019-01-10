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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x66ffba14;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Pinned { get; }
            public T.Peer Peer { get; }
            public int TopMessage { get; }
            public int ReadInboxMaxId { get; }
            public int ReadOutboxMaxId { get; }
            public int UnreadCount { get; }
            public T.PeerNotifySettings NotifySettings { get; }
            public Option<int> Pts { get; }
            public Option<T.DraftMessage> Draft { get; }
            
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

        public bool Equals(Dialog other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Dialog x && Equals(x);
        public static bool operator ==(Dialog a, Dialog b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Dialog a, Dialog b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Dialog other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Dialog x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Dialog a, Dialog b) => a.CompareTo(b) <= 0;
        public static bool operator <(Dialog a, Dialog b) => a.CompareTo(b) < 0;
        public static bool operator >(Dialog a, Dialog b) => a.CompareTo(b) > 0;
        public static bool operator >=(Dialog a, Dialog b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}