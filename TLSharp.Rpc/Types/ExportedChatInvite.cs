using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ExportedChatInvite : ITlType, IEquatable<ExportedChatInvite>, IComparable<ExportedChatInvite>, IComparable
    {
        public sealed class ChatInviteEmptyTag : ITlTypeTag, IEquatable<ChatInviteEmptyTag>, IComparable<ChatInviteEmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x69df3769;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ChatInviteEmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ChatInviteEmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatInviteEmptyTag x && Equals(x);
            public static bool operator ==(ChatInviteEmptyTag x, ChatInviteEmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatInviteEmptyTag x, ChatInviteEmptyTag y) => !(x == y);

            public int CompareTo(ChatInviteEmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatInviteEmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatInviteEmptyTag x, ChatInviteEmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatInviteEmptyTag x, ChatInviteEmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatInviteEmptyTag x, ChatInviteEmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatInviteEmptyTag x, ChatInviteEmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatInviteEmptyTag DeserializeTag(BinaryReader br)
            {

                return new ChatInviteEmptyTag();
            }
        }

        public sealed class ChatInviteExportedTag : ITlTypeTag, IEquatable<ChatInviteExportedTag>, IComparable<ChatInviteExportedTag>, IComparable
        {
            internal const uint TypeNumber = 0xfc2e05bc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Link;
            
            public ChatInviteExportedTag(
                Some<string> link
            ) {
                Link = link;
            }
            
            string CmpTuple =>
                Link;

            public bool Equals(ChatInviteExportedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ChatInviteExportedTag x && Equals(x);
            public static bool operator ==(ChatInviteExportedTag x, ChatInviteExportedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ChatInviteExportedTag x, ChatInviteExportedTag y) => !(x == y);

            public int CompareTo(ChatInviteExportedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ChatInviteExportedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ChatInviteExportedTag x, ChatInviteExportedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ChatInviteExportedTag x, ChatInviteExportedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ChatInviteExportedTag x, ChatInviteExportedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ChatInviteExportedTag x, ChatInviteExportedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Link: {Link})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Link, bw, WriteString);
            }
            
            internal static ChatInviteExportedTag DeserializeTag(BinaryReader br)
            {
                var link = Read(br, ReadString);
                return new ChatInviteExportedTag(link);
            }
        }

        readonly ITlTypeTag _tag;
        ExportedChatInvite(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ExportedChatInvite(ChatInviteEmptyTag tag) => new ExportedChatInvite(tag);
        public static explicit operator ExportedChatInvite(ChatInviteExportedTag tag) => new ExportedChatInvite(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ExportedChatInvite Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case ChatInviteEmptyTag.TypeNumber: return (ExportedChatInvite) ChatInviteEmptyTag.DeserializeTag(br);
                case ChatInviteExportedTag.TypeNumber: return (ExportedChatInvite) ChatInviteExportedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ChatInviteEmptyTag.TypeNumber, ChatInviteExportedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<ChatInviteEmptyTag, T> chatInviteEmptyTag = null,
            Func<ChatInviteExportedTag, T> chatInviteExportedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case ChatInviteEmptyTag x when chatInviteEmptyTag != null: return chatInviteEmptyTag(x);
                case ChatInviteExportedTag x when chatInviteExportedTag != null: return chatInviteExportedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<ChatInviteEmptyTag, T> chatInviteEmptyTag,
            Func<ChatInviteExportedTag, T> chatInviteExportedTag
        ) => Match(
            () => throw new Exception("WTF"),
            chatInviteEmptyTag ?? throw new ArgumentNullException(nameof(chatInviteEmptyTag)),
            chatInviteExportedTag ?? throw new ArgumentNullException(nameof(chatInviteExportedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case ChatInviteEmptyTag _: return 0;
                case ChatInviteExportedTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ExportedChatInvite other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ExportedChatInvite x && Equals(x);
        public static bool operator ==(ExportedChatInvite x, ExportedChatInvite y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ExportedChatInvite x, ExportedChatInvite y) => !(x == y);

        public int CompareTo(ExportedChatInvite other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ExportedChatInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportedChatInvite x, ExportedChatInvite y) => x.CompareTo(y) <= 0;
        public static bool operator <(ExportedChatInvite x, ExportedChatInvite y) => x.CompareTo(y) < 0;
        public static bool operator >(ExportedChatInvite x, ExportedChatInvite y) => x.CompareTo(y) > 0;
        public static bool operator >=(ExportedChatInvite x, ExportedChatInvite y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ExportedChatInvite.{_tag.GetType().Name}{_tag}";
    }
}