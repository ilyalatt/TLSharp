using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ChatInvite : ITlType, IEquatable<ChatInvite>, IComparable<ChatInvite>, IComparable
    {
        public sealed class AlreadyTag : ITlTypeTag, IEquatable<AlreadyTag>, IComparable<AlreadyTag>, IComparable
        {
            internal const uint TypeNumber = 0x5a686d7c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.Chat Chat;
            
            public AlreadyTag(
                Some<T.Chat> chat
            ) {
                Chat = chat;
            }
            
            T.Chat CmpTuple =>
                Chat;

            public bool Equals(AlreadyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AlreadyTag x && Equals(x);
            public static bool operator ==(AlreadyTag x, AlreadyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AlreadyTag x, AlreadyTag y) => !(x == y);

            public int CompareTo(AlreadyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AlreadyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AlreadyTag x, AlreadyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AlreadyTag x, AlreadyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AlreadyTag x, AlreadyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AlreadyTag x, AlreadyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Chat: {Chat})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Chat, bw, WriteSerializable);
            }
            
            internal static AlreadyTag DeserializeTag(BinaryReader br)
            {
                var chat = Read(br, T.Chat.Deserialize);
                return new AlreadyTag(chat);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xdb74f558;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Channel;
            public readonly bool Broadcast;
            public readonly bool Public;
            public readonly bool Megagroup;
            public readonly string Title;
            public readonly T.ChatPhoto Photo;
            public readonly int ParticipantsCount;
            public readonly Option<Arr<T.User>> Participants;
            
            public Tag(
                bool channel,
                bool broadcast,
                bool @public,
                bool megagroup,
                Some<string> title,
                Some<T.ChatPhoto> photo,
                int participantsCount,
                Option<Arr<T.User>> participants
            ) {
                Channel = channel;
                Broadcast = broadcast;
                Public = @public;
                Megagroup = megagroup;
                Title = title;
                Photo = photo;
                ParticipantsCount = participantsCount;
                Participants = participants;
            }
            
            (bool, bool, bool, bool, string, T.ChatPhoto, int, Option<Arr<T.User>>) CmpTuple =>
                (Channel, Broadcast, Public, Megagroup, Title, Photo, ParticipantsCount, Participants);

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

            public override string ToString() => $"(Channel: {Channel}, Broadcast: {Broadcast}, Public: {Public}, Megagroup: {Megagroup}, Title: {Title}, Photo: {Photo}, ParticipantsCount: {ParticipantsCount}, Participants: {Participants})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Channel) | MaskBit(1, Broadcast) | MaskBit(2, Public) | MaskBit(3, Megagroup) | MaskBit(4, Participants), bw, WriteInt);
                Write(Title, bw, WriteString);
                Write(Photo, bw, WriteSerializable);
                Write(ParticipantsCount, bw, WriteInt);
                Write(Participants, bw, WriteOption<Arr<T.User>>(WriteVector<T.User>(WriteSerializable)));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var channel = Read(br, ReadOption(flags, 0));
                var broadcast = Read(br, ReadOption(flags, 1));
                var @public = Read(br, ReadOption(flags, 2));
                var megagroup = Read(br, ReadOption(flags, 3));
                var title = Read(br, ReadString);
                var photo = Read(br, T.ChatPhoto.Deserialize);
                var participantsCount = Read(br, ReadInt);
                var participants = Read(br, ReadOption(flags, 4, ReadVector(T.User.Deserialize)));
                return new Tag(channel, broadcast, @public, megagroup, title, photo, participantsCount, participants);
            }
        }

        readonly ITlTypeTag _tag;
        ChatInvite(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChatInvite(AlreadyTag tag) => new ChatInvite(tag);
        public static explicit operator ChatInvite(Tag tag) => new ChatInvite(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChatInvite Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case AlreadyTag.TypeNumber: return (ChatInvite) AlreadyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (ChatInvite) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { AlreadyTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<AlreadyTag, T> alreadyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case AlreadyTag x when alreadyTag != null: return alreadyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<AlreadyTag, T> alreadyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            alreadyTag ?? throw new ArgumentNullException(nameof(alreadyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case AlreadyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChatInvite other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChatInvite x && Equals(x);
        public static bool operator ==(ChatInvite x, ChatInvite y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChatInvite x, ChatInvite y) => !(x == y);

        public int CompareTo(ChatInvite other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChatInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChatInvite x, ChatInvite y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChatInvite x, ChatInvite y) => x.CompareTo(y) < 0;
        public static bool operator >(ChatInvite x, ChatInvite y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChatInvite x, ChatInvite y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChatInvite.{_tag.GetType().Name}{_tag}";
    }
}