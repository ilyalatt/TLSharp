using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MessageEntity : ITlType, IEquatable<MessageEntity>, IComparable<MessageEntity>, IComparable
    {
        public sealed class UnknownTag : Record<UnknownTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbb92ba95;
            
            public int Offset { get; }
            public int Length { get; }
            
            public UnknownTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static UnknownTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new UnknownTag(offset, length);
            }
        }

        public sealed class MentionTag : Record<MentionTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfa04579d;
            
            public int Offset { get; }
            public int Length { get; }
            
            public MentionTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static MentionTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new MentionTag(offset, length);
            }
        }

        public sealed class HashtagTag : Record<HashtagTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x6f635b0d;
            
            public int Offset { get; }
            public int Length { get; }
            
            public HashtagTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static HashtagTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new HashtagTag(offset, length);
            }
        }

        public sealed class BotCommandTag : Record<BotCommandTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x6cef8ac7;
            
            public int Offset { get; }
            public int Length { get; }
            
            public BotCommandTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static BotCommandTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new BotCommandTag(offset, length);
            }
        }

        public sealed class UrlTag : Record<UrlTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x6ed02538;
            
            public int Offset { get; }
            public int Length { get; }
            
            public UrlTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static UrlTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new UrlTag(offset, length);
            }
        }

        public sealed class EmailTag : Record<EmailTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x64e475c2;
            
            public int Offset { get; }
            public int Length { get; }
            
            public EmailTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static EmailTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new EmailTag(offset, length);
            }
        }

        public sealed class BoldTag : Record<BoldTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbd610bc9;
            
            public int Offset { get; }
            public int Length { get; }
            
            public BoldTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static BoldTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new BoldTag(offset, length);
            }
        }

        public sealed class ItalicTag : Record<ItalicTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x826f8b60;
            
            public int Offset { get; }
            public int Length { get; }
            
            public ItalicTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static ItalicTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new ItalicTag(offset, length);
            }
        }

        public sealed class CodeTag : Record<CodeTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x28a20571;
            
            public int Offset { get; }
            public int Length { get; }
            
            public CodeTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
            }
            
            internal static CodeTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                return new CodeTag(offset, length);
            }
        }

        public sealed class PreTag : Record<PreTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x73924be0;
            
            public int Offset { get; }
            public int Length { get; }
            public string Language { get; }
            
            public PreTag(
                int offset,
                int length,
                Some<string> language
            ) {
                Offset = offset;
                Length = length;
                Language = language;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
                Write(Language, bw, WriteString);
            }
            
            internal static PreTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                var language = Read(br, ReadString);
                return new PreTag(offset, length, language);
            }
        }

        public sealed class TextUrlTag : Record<TextUrlTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x76a6d327;
            
            public int Offset { get; }
            public int Length { get; }
            public string Url { get; }
            
            public TextUrlTag(
                int offset,
                int length,
                Some<string> url
            ) {
                Offset = offset;
                Length = length;
                Url = url;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
                Write(Url, bw, WriteString);
            }
            
            internal static TextUrlTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                var url = Read(br, ReadString);
                return new TextUrlTag(offset, length, url);
            }
        }

        public sealed class MentionNameTag : Record<MentionNameTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x352dca58;
            
            public int Offset { get; }
            public int Length { get; }
            public int UserId { get; }
            
            public MentionNameTag(
                int offset,
                int length,
                int userId
            ) {
                Offset = offset;
                Length = length;
                UserId = userId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
                Write(UserId, bw, WriteInt);
            }
            
            internal static MentionNameTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                return new MentionNameTag(offset, length, userId);
            }
        }

        public sealed class InputMentionNameTag : Record<InputMentionNameTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x208e68c9;
            
            public int Offset { get; }
            public int Length { get; }
            public T.InputUser UserId { get; }
            
            public InputMentionNameTag(
                int offset,
                int length,
                Some<T.InputUser> userId
            ) {
                Offset = offset;
                Length = length;
                UserId = userId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Length, bw, WriteInt);
                Write(UserId, bw, WriteSerializable);
            }
            
            internal static InputMentionNameTag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var length = Read(br, ReadInt);
                var userId = Read(br, T.InputUser.Deserialize);
                return new InputMentionNameTag(offset, length, userId);
            }
        }

        readonly ITlTypeTag _tag;
        MessageEntity(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MessageEntity(UnknownTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(MentionTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(HashtagTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(BotCommandTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(UrlTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(EmailTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(BoldTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(ItalicTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(CodeTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(PreTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(TextUrlTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(MentionNameTag tag) => new MessageEntity(tag);
        public static explicit operator MessageEntity(InputMentionNameTag tag) => new MessageEntity(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MessageEntity Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xbb92ba95: return (MessageEntity) UnknownTag.DeserializeTag(br);
                case 0xfa04579d: return (MessageEntity) MentionTag.DeserializeTag(br);
                case 0x6f635b0d: return (MessageEntity) HashtagTag.DeserializeTag(br);
                case 0x6cef8ac7: return (MessageEntity) BotCommandTag.DeserializeTag(br);
                case 0x6ed02538: return (MessageEntity) UrlTag.DeserializeTag(br);
                case 0x64e475c2: return (MessageEntity) EmailTag.DeserializeTag(br);
                case 0xbd610bc9: return (MessageEntity) BoldTag.DeserializeTag(br);
                case 0x826f8b60: return (MessageEntity) ItalicTag.DeserializeTag(br);
                case 0x28a20571: return (MessageEntity) CodeTag.DeserializeTag(br);
                case 0x73924be0: return (MessageEntity) PreTag.DeserializeTag(br);
                case 0x76a6d327: return (MessageEntity) TextUrlTag.DeserializeTag(br);
                case 0x352dca58: return (MessageEntity) MentionNameTag.DeserializeTag(br);
                case 0x208e68c9: return (MessageEntity) InputMentionNameTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xbb92ba95, 0xfa04579d, 0x6f635b0d, 0x6cef8ac7, 0x6ed02538, 0x64e475c2, 0xbd610bc9, 0x826f8b60, 0x28a20571, 0x73924be0, 0x76a6d327, 0x352dca58, 0x208e68c9 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UnknownTag, T> unknownTag = null,
            Func<MentionTag, T> mentionTag = null,
            Func<HashtagTag, T> hashtagTag = null,
            Func<BotCommandTag, T> botCommandTag = null,
            Func<UrlTag, T> urlTag = null,
            Func<EmailTag, T> emailTag = null,
            Func<BoldTag, T> boldTag = null,
            Func<ItalicTag, T> italicTag = null,
            Func<CodeTag, T> codeTag = null,
            Func<PreTag, T> preTag = null,
            Func<TextUrlTag, T> textUrlTag = null,
            Func<MentionNameTag, T> mentionNameTag = null,
            Func<InputMentionNameTag, T> inputMentionNameTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UnknownTag x when unknownTag != null: return unknownTag(x);
                case MentionTag x when mentionTag != null: return mentionTag(x);
                case HashtagTag x when hashtagTag != null: return hashtagTag(x);
                case BotCommandTag x when botCommandTag != null: return botCommandTag(x);
                case UrlTag x when urlTag != null: return urlTag(x);
                case EmailTag x when emailTag != null: return emailTag(x);
                case BoldTag x when boldTag != null: return boldTag(x);
                case ItalicTag x when italicTag != null: return italicTag(x);
                case CodeTag x when codeTag != null: return codeTag(x);
                case PreTag x when preTag != null: return preTag(x);
                case TextUrlTag x when textUrlTag != null: return textUrlTag(x);
                case MentionNameTag x when mentionNameTag != null: return mentionNameTag(x);
                case InputMentionNameTag x when inputMentionNameTag != null: return inputMentionNameTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UnknownTag, T> unknownTag,
            Func<MentionTag, T> mentionTag,
            Func<HashtagTag, T> hashtagTag,
            Func<BotCommandTag, T> botCommandTag,
            Func<UrlTag, T> urlTag,
            Func<EmailTag, T> emailTag,
            Func<BoldTag, T> boldTag,
            Func<ItalicTag, T> italicTag,
            Func<CodeTag, T> codeTag,
            Func<PreTag, T> preTag,
            Func<TextUrlTag, T> textUrlTag,
            Func<MentionNameTag, T> mentionNameTag,
            Func<InputMentionNameTag, T> inputMentionNameTag
        ) => Match(
            () => throw new Exception("WTF"),
            unknownTag ?? throw new ArgumentNullException(nameof(unknownTag)),
            mentionTag ?? throw new ArgumentNullException(nameof(mentionTag)),
            hashtagTag ?? throw new ArgumentNullException(nameof(hashtagTag)),
            botCommandTag ?? throw new ArgumentNullException(nameof(botCommandTag)),
            urlTag ?? throw new ArgumentNullException(nameof(urlTag)),
            emailTag ?? throw new ArgumentNullException(nameof(emailTag)),
            boldTag ?? throw new ArgumentNullException(nameof(boldTag)),
            italicTag ?? throw new ArgumentNullException(nameof(italicTag)),
            codeTag ?? throw new ArgumentNullException(nameof(codeTag)),
            preTag ?? throw new ArgumentNullException(nameof(preTag)),
            textUrlTag ?? throw new ArgumentNullException(nameof(textUrlTag)),
            mentionNameTag ?? throw new ArgumentNullException(nameof(mentionNameTag)),
            inputMentionNameTag ?? throw new ArgumentNullException(nameof(inputMentionNameTag))
        );

        public bool Equals(MessageEntity other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MessageEntity x && Equals(x);
        public static bool operator ==(MessageEntity a, MessageEntity b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MessageEntity a, MessageEntity b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UnknownTag _: return 0;
                case MentionTag _: return 1;
                case HashtagTag _: return 2;
                case BotCommandTag _: return 3;
                case UrlTag _: return 4;
                case EmailTag _: return 5;
                case BoldTag _: return 6;
                case ItalicTag _: return 7;
                case CodeTag _: return 8;
                case PreTag _: return 9;
                case TextUrlTag _: return 10;
                case MentionNameTag _: return 11;
                case InputMentionNameTag _: return 12;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MessageEntity other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MessageEntity x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageEntity a, MessageEntity b) => a.CompareTo(b) <= 0;
        public static bool operator <(MessageEntity a, MessageEntity b) => a.CompareTo(b) < 0;
        public static bool operator >(MessageEntity a, MessageEntity b) => a.CompareTo(b) > 0;
        public static bool operator >=(MessageEntity a, MessageEntity b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}