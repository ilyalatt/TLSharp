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
        public sealed class ChatInviteEmptyTag : Record<ChatInviteEmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x69df3769;
            

            
            public ChatInviteEmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ChatInviteEmptyTag DeserializeTag(BinaryReader br)
            {

                return new ChatInviteEmptyTag();
            }
        }

        public sealed class ChatInviteExportedTag : Record<ChatInviteExportedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfc2e05bc;
            
            public string Link { get; }
            
            public ChatInviteExportedTag(
                Some<string> link
            ) {
                Link = link;
            }
            
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
                case 0x69df3769: return (ExportedChatInvite) ChatInviteEmptyTag.DeserializeTag(br);
                case 0xfc2e05bc: return (ExportedChatInvite) ChatInviteExportedTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x69df3769, 0xfc2e05bc });
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

        public bool Equals(ExportedChatInvite other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ExportedChatInvite x && Equals(x);
        public static bool operator ==(ExportedChatInvite a, ExportedChatInvite b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ExportedChatInvite a, ExportedChatInvite b) => !(a == b);

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

        public int CompareTo(ExportedChatInvite other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ExportedChatInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportedChatInvite a, ExportedChatInvite b) => a.CompareTo(b) <= 0;
        public static bool operator <(ExportedChatInvite a, ExportedChatInvite b) => a.CompareTo(b) < 0;
        public static bool operator >(ExportedChatInvite a, ExportedChatInvite b) => a.CompareTo(b) > 0;
        public static bool operator >=(ExportedChatInvite a, ExportedChatInvite b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}