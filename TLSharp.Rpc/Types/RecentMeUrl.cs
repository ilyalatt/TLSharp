using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class RecentMeUrl : ITlType, IEquatable<RecentMeUrl>, IComparable<RecentMeUrl>, IComparable
    {
        public sealed class UnknownTag : ITlTypeTag, IEquatable<UnknownTag>, IComparable<UnknownTag>, IComparable
        {
            internal const uint TypeNumber = 0x46e1d13d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            
            public UnknownTag(
                Some<string> url
            ) {
                Url = url;
            }
            
            string CmpTuple =>
                Url;

            public bool Equals(UnknownTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UnknownTag x && Equals(x);
            public static bool operator ==(UnknownTag x, UnknownTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UnknownTag x, UnknownTag y) => !(x == y);

            public int CompareTo(UnknownTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UnknownTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UnknownTag x, UnknownTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UnknownTag x, UnknownTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UnknownTag x, UnknownTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UnknownTag x, UnknownTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
            }
            
            internal static UnknownTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                return new UnknownTag(url);
            }
        }

        public sealed class UserTag : ITlTypeTag, IEquatable<UserTag>, IComparable<UserTag>, IComparable
        {
            internal const uint TypeNumber = 0x8dbc3336;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly int UserId;
            
            public UserTag(
                Some<string> url,
                int userId
            ) {
                Url = url;
                UserId = userId;
            }
            
            (string, int) CmpTuple =>
                (Url, UserId);

            public bool Equals(UserTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UserTag x && Equals(x);
            public static bool operator ==(UserTag x, UserTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UserTag x, UserTag y) => !(x == y);

            public int CompareTo(UserTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UserTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UserTag x, UserTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UserTag x, UserTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UserTag x, UserTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UserTag x, UserTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, UserId: {UserId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(UserId, bw, WriteInt);
            }
            
            internal static UserTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var userId = Read(br, ReadInt);
                return new UserTag(url, userId);
            }
        }

        public sealed class ChatTag : ITlTypeTag, IEquatable<ChatTag>, IComparable<ChatTag>, IComparable
        {
            internal const uint TypeNumber = 0xa01b22f9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly int ChatId;
            
            public ChatTag(
                Some<string> url,
                int chatId
            ) {
                Url = url;
                ChatId = chatId;
            }
            
            (string, int) CmpTuple =>
                (Url, ChatId);

            public bool Equals(ChatTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatTag x && Equals(x);
            public static bool operator ==(ChatTag x, ChatTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatTag x, ChatTag y) => !(x == y);

            public int CompareTo(ChatTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatTag x, ChatTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatTag x, ChatTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatTag x, ChatTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatTag x, ChatTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, ChatId: {ChatId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(ChatId, bw, WriteInt);
            }
            
            internal static ChatTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var chatId = Read(br, ReadInt);
                return new ChatTag(url, chatId);
            }
        }

        public sealed class ChatInviteTag : ITlTypeTag, IEquatable<ChatInviteTag>, IComparable<ChatInviteTag>, IComparable
        {
            internal const uint TypeNumber = 0xeb49081d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly T.ChatInvite ChatInvite;
            
            public ChatInviteTag(
                Some<string> url,
                Some<T.ChatInvite> chatInvite
            ) {
                Url = url;
                ChatInvite = chatInvite;
            }
            
            (string, T.ChatInvite) CmpTuple =>
                (Url, ChatInvite);

            public bool Equals(ChatInviteTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatInviteTag x && Equals(x);
            public static bool operator ==(ChatInviteTag x, ChatInviteTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatInviteTag x, ChatInviteTag y) => !(x == y);

            public int CompareTo(ChatInviteTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatInviteTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatInviteTag x, ChatInviteTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, ChatInvite: {ChatInvite})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(ChatInvite, bw, WriteSerializable);
            }
            
            internal static ChatInviteTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var chatInvite = Read(br, T.ChatInvite.Deserialize);
                return new ChatInviteTag(url, chatInvite);
            }
        }

        public sealed class StickerSetTag : ITlTypeTag, IEquatable<StickerSetTag>, IComparable<StickerSetTag>, IComparable
        {
            internal const uint TypeNumber = 0xbc0a57dc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly T.StickerSetCovered Set;
            
            public StickerSetTag(
                Some<string> url,
                Some<T.StickerSetCovered> set
            ) {
                Url = url;
                Set = set;
            }
            
            (string, T.StickerSetCovered) CmpTuple =>
                (Url, Set);

            public bool Equals(StickerSetTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is StickerSetTag x && Equals(x);
            public static bool operator ==(StickerSetTag x, StickerSetTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(StickerSetTag x, StickerSetTag y) => !(x == y);

            public int CompareTo(StickerSetTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is StickerSetTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(StickerSetTag x, StickerSetTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(StickerSetTag x, StickerSetTag y) => x.CompareTo(y) < 0;
            public static bool operator >(StickerSetTag x, StickerSetTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(StickerSetTag x, StickerSetTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, Set: {Set})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Set, bw, WriteSerializable);
            }
            
            internal static StickerSetTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var set = Read(br, T.StickerSetCovered.Deserialize);
                return new StickerSetTag(url, set);
            }
        }

        readonly ITlTypeTag _tag;
        RecentMeUrl(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator RecentMeUrl(UnknownTag tag) => new RecentMeUrl(tag);
        public static explicit operator RecentMeUrl(UserTag tag) => new RecentMeUrl(tag);
        public static explicit operator RecentMeUrl(ChatTag tag) => new RecentMeUrl(tag);
        public static explicit operator RecentMeUrl(ChatInviteTag tag) => new RecentMeUrl(tag);
        public static explicit operator RecentMeUrl(StickerSetTag tag) => new RecentMeUrl(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static RecentMeUrl Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case UnknownTag.TypeNumber: return (RecentMeUrl) UnknownTag.DeserializeTag(br);
                case UserTag.TypeNumber: return (RecentMeUrl) UserTag.DeserializeTag(br);
                case ChatTag.TypeNumber: return (RecentMeUrl) ChatTag.DeserializeTag(br);
                case ChatInviteTag.TypeNumber: return (RecentMeUrl) ChatInviteTag.DeserializeTag(br);
                case StickerSetTag.TypeNumber: return (RecentMeUrl) StickerSetTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UnknownTag.TypeNumber, UserTag.TypeNumber, ChatTag.TypeNumber, ChatInviteTag.TypeNumber, StickerSetTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UnknownTag, T> unknownTag = null,
            Func<UserTag, T> userTag = null,
            Func<ChatTag, T> chatTag = null,
            Func<ChatInviteTag, T> chatInviteTag = null,
            Func<StickerSetTag, T> stickerSetTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UnknownTag x when unknownTag != null: return unknownTag(x);
                case UserTag x when userTag != null: return userTag(x);
                case ChatTag x when chatTag != null: return chatTag(x);
                case ChatInviteTag x when chatInviteTag != null: return chatInviteTag(x);
                case StickerSetTag x when stickerSetTag != null: return stickerSetTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UnknownTag, T> unknownTag,
            Func<UserTag, T> userTag,
            Func<ChatTag, T> chatTag,
            Func<ChatInviteTag, T> chatInviteTag,
            Func<StickerSetTag, T> stickerSetTag
        ) => Match(
            () => throw new Exception("WTF"),
            unknownTag ?? throw new ArgumentNullException(nameof(unknownTag)),
            userTag ?? throw new ArgumentNullException(nameof(userTag)),
            chatTag ?? throw new ArgumentNullException(nameof(chatTag)),
            chatInviteTag ?? throw new ArgumentNullException(nameof(chatInviteTag)),
            stickerSetTag ?? throw new ArgumentNullException(nameof(stickerSetTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UnknownTag _: return 0;
                case UserTag _: return 1;
                case ChatTag _: return 2;
                case ChatInviteTag _: return 3;
                case StickerSetTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(RecentMeUrl other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is RecentMeUrl x && Equals(x);
        public static bool operator ==(RecentMeUrl x, RecentMeUrl y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RecentMeUrl x, RecentMeUrl y) => !(x == y);

        public int CompareTo(RecentMeUrl other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is RecentMeUrl x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RecentMeUrl x, RecentMeUrl y) => x.CompareTo(y) <= 0;
        public static bool operator <(RecentMeUrl x, RecentMeUrl y) => x.CompareTo(y) < 0;
        public static bool operator >(RecentMeUrl x, RecentMeUrl y) => x.CompareTo(y) > 0;
        public static bool operator >=(RecentMeUrl x, RecentMeUrl y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"RecentMeUrl.{_tag.GetType().Name}{_tag}";
    }
}