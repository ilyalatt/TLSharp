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
        public sealed class UnknownTag : ITlTypeTag, IEquatable<UnknownTag>, IComparable<UnknownTag>, IComparable
        {
            internal const uint TypeNumber = 0xbb92ba95;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public UnknownTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

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

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class MentionTag : ITlTypeTag, IEquatable<MentionTag>, IComparable<MentionTag>, IComparable
        {
            internal const uint TypeNumber = 0xfa04579d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public MentionTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(MentionTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MentionTag x && Equals(x);
            public static bool operator ==(MentionTag x, MentionTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MentionTag x, MentionTag y) => !(x == y);

            public int CompareTo(MentionTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MentionTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MentionTag x, MentionTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MentionTag x, MentionTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MentionTag x, MentionTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MentionTag x, MentionTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class HashtagTag : ITlTypeTag, IEquatable<HashtagTag>, IComparable<HashtagTag>, IComparable
        {
            internal const uint TypeNumber = 0x6f635b0d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public HashtagTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(HashtagTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is HashtagTag x && Equals(x);
            public static bool operator ==(HashtagTag x, HashtagTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(HashtagTag x, HashtagTag y) => !(x == y);

            public int CompareTo(HashtagTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is HashtagTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(HashtagTag x, HashtagTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(HashtagTag x, HashtagTag y) => x.CompareTo(y) < 0;
            public static bool operator >(HashtagTag x, HashtagTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(HashtagTag x, HashtagTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class BotCommandTag : ITlTypeTag, IEquatable<BotCommandTag>, IComparable<BotCommandTag>, IComparable
        {
            internal const uint TypeNumber = 0x6cef8ac7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public BotCommandTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(BotCommandTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BotCommandTag x && Equals(x);
            public static bool operator ==(BotCommandTag x, BotCommandTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BotCommandTag x, BotCommandTag y) => !(x == y);

            public int CompareTo(BotCommandTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BotCommandTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BotCommandTag x, BotCommandTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BotCommandTag x, BotCommandTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BotCommandTag x, BotCommandTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BotCommandTag x, BotCommandTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class UrlTag : ITlTypeTag, IEquatable<UrlTag>, IComparable<UrlTag>, IComparable
        {
            internal const uint TypeNumber = 0x6ed02538;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public UrlTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(UrlTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UrlTag x && Equals(x);
            public static bool operator ==(UrlTag x, UrlTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UrlTag x, UrlTag y) => !(x == y);

            public int CompareTo(UrlTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UrlTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UrlTag x, UrlTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UrlTag x, UrlTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UrlTag x, UrlTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UrlTag x, UrlTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class EmailTag : ITlTypeTag, IEquatable<EmailTag>, IComparable<EmailTag>, IComparable
        {
            internal const uint TypeNumber = 0x64e475c2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public EmailTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(EmailTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmailTag x && Equals(x);
            public static bool operator ==(EmailTag x, EmailTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmailTag x, EmailTag y) => !(x == y);

            public int CompareTo(EmailTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmailTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmailTag x, EmailTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmailTag x, EmailTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmailTag x, EmailTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmailTag x, EmailTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class BoldTag : ITlTypeTag, IEquatable<BoldTag>, IComparable<BoldTag>, IComparable
        {
            internal const uint TypeNumber = 0xbd610bc9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public BoldTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(BoldTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is BoldTag x && Equals(x);
            public static bool operator ==(BoldTag x, BoldTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BoldTag x, BoldTag y) => !(x == y);

            public int CompareTo(BoldTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is BoldTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BoldTag x, BoldTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BoldTag x, BoldTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BoldTag x, BoldTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BoldTag x, BoldTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class ItalicTag : ITlTypeTag, IEquatable<ItalicTag>, IComparable<ItalicTag>, IComparable
        {
            internal const uint TypeNumber = 0x826f8b60;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public ItalicTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(ItalicTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ItalicTag x && Equals(x);
            public static bool operator ==(ItalicTag x, ItalicTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ItalicTag x, ItalicTag y) => !(x == y);

            public int CompareTo(ItalicTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ItalicTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ItalicTag x, ItalicTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ItalicTag x, ItalicTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ItalicTag x, ItalicTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ItalicTag x, ItalicTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class CodeTag : ITlTypeTag, IEquatable<CodeTag>, IComparable<CodeTag>, IComparable
        {
            internal const uint TypeNumber = 0x28a20571;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            
            public CodeTag(
                int offset,
                int length
            ) {
                Offset = offset;
                Length = length;
            }
            
            (int, int) CmpTuple =>
                (Offset, Length);

            public bool Equals(CodeTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CodeTag x && Equals(x);
            public static bool operator ==(CodeTag x, CodeTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CodeTag x, CodeTag y) => !(x == y);

            public int CompareTo(CodeTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CodeTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CodeTag x, CodeTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CodeTag x, CodeTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CodeTag x, CodeTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CodeTag x, CodeTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length})";
            
            
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

        public sealed class PreTag : ITlTypeTag, IEquatable<PreTag>, IComparable<PreTag>, IComparable
        {
            internal const uint TypeNumber = 0x73924be0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            public readonly string Language;
            
            public PreTag(
                int offset,
                int length,
                Some<string> language
            ) {
                Offset = offset;
                Length = length;
                Language = language;
            }
            
            (int, int, string) CmpTuple =>
                (Offset, Length, Language);

            public bool Equals(PreTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PreTag x && Equals(x);
            public static bool operator ==(PreTag x, PreTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PreTag x, PreTag y) => !(x == y);

            public int CompareTo(PreTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PreTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PreTag x, PreTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PreTag x, PreTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PreTag x, PreTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PreTag x, PreTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length}, Language: {Language})";
            
            
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

        public sealed class TextUrlTag : ITlTypeTag, IEquatable<TextUrlTag>, IComparable<TextUrlTag>, IComparable
        {
            internal const uint TypeNumber = 0x76a6d327;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            public readonly string Url;
            
            public TextUrlTag(
                int offset,
                int length,
                Some<string> url
            ) {
                Offset = offset;
                Length = length;
                Url = url;
            }
            
            (int, int, string) CmpTuple =>
                (Offset, Length, Url);

            public bool Equals(TextUrlTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TextUrlTag x && Equals(x);
            public static bool operator ==(TextUrlTag x, TextUrlTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TextUrlTag x, TextUrlTag y) => !(x == y);

            public int CompareTo(TextUrlTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TextUrlTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TextUrlTag x, TextUrlTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TextUrlTag x, TextUrlTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TextUrlTag x, TextUrlTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TextUrlTag x, TextUrlTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length}, Url: {Url})";
            
            
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

        public sealed class MentionNameTag : ITlTypeTag, IEquatable<MentionNameTag>, IComparable<MentionNameTag>, IComparable
        {
            internal const uint TypeNumber = 0x352dca58;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            public readonly int UserId;
            
            public MentionNameTag(
                int offset,
                int length,
                int userId
            ) {
                Offset = offset;
                Length = length;
                UserId = userId;
            }
            
            (int, int, int) CmpTuple =>
                (Offset, Length, UserId);

            public bool Equals(MentionNameTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is MentionNameTag x && Equals(x);
            public static bool operator ==(MentionNameTag x, MentionNameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MentionNameTag x, MentionNameTag y) => !(x == y);

            public int CompareTo(MentionNameTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is MentionNameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MentionNameTag x, MentionNameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MentionNameTag x, MentionNameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MentionNameTag x, MentionNameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MentionNameTag x, MentionNameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length}, UserId: {UserId})";
            
            
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

        public sealed class InputMentionNameTag : ITlTypeTag, IEquatable<InputMentionNameTag>, IComparable<InputMentionNameTag>, IComparable
        {
            internal const uint TypeNumber = 0x208e68c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Length;
            public readonly T.InputUser UserId;
            
            public InputMentionNameTag(
                int offset,
                int length,
                Some<T.InputUser> userId
            ) {
                Offset = offset;
                Length = length;
                UserId = userId;
            }
            
            (int, int, T.InputUser) CmpTuple =>
                (Offset, Length, UserId);

            public bool Equals(InputMentionNameTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is InputMentionNameTag x && Equals(x);
            public static bool operator ==(InputMentionNameTag x, InputMentionNameTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(InputMentionNameTag x, InputMentionNameTag y) => !(x == y);

            public int CompareTo(InputMentionNameTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is InputMentionNameTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(InputMentionNameTag x, InputMentionNameTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(InputMentionNameTag x, InputMentionNameTag y) => x.CompareTo(y) < 0;
            public static bool operator >(InputMentionNameTag x, InputMentionNameTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(InputMentionNameTag x, InputMentionNameTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Offset: {Offset}, Length: {Length}, UserId: {UserId})";
            
            
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
                case UnknownTag.TypeNumber: return (MessageEntity) UnknownTag.DeserializeTag(br);
                case MentionTag.TypeNumber: return (MessageEntity) MentionTag.DeserializeTag(br);
                case HashtagTag.TypeNumber: return (MessageEntity) HashtagTag.DeserializeTag(br);
                case BotCommandTag.TypeNumber: return (MessageEntity) BotCommandTag.DeserializeTag(br);
                case UrlTag.TypeNumber: return (MessageEntity) UrlTag.DeserializeTag(br);
                case EmailTag.TypeNumber: return (MessageEntity) EmailTag.DeserializeTag(br);
                case BoldTag.TypeNumber: return (MessageEntity) BoldTag.DeserializeTag(br);
                case ItalicTag.TypeNumber: return (MessageEntity) ItalicTag.DeserializeTag(br);
                case CodeTag.TypeNumber: return (MessageEntity) CodeTag.DeserializeTag(br);
                case PreTag.TypeNumber: return (MessageEntity) PreTag.DeserializeTag(br);
                case TextUrlTag.TypeNumber: return (MessageEntity) TextUrlTag.DeserializeTag(br);
                case MentionNameTag.TypeNumber: return (MessageEntity) MentionNameTag.DeserializeTag(br);
                case InputMentionNameTag.TypeNumber: return (MessageEntity) InputMentionNameTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UnknownTag.TypeNumber, MentionTag.TypeNumber, HashtagTag.TypeNumber, BotCommandTag.TypeNumber, UrlTag.TypeNumber, EmailTag.TypeNumber, BoldTag.TypeNumber, ItalicTag.TypeNumber, CodeTag.TypeNumber, PreTag.TypeNumber, TextUrlTag.TypeNumber, MentionNameTag.TypeNumber, InputMentionNameTag.TypeNumber });
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

        public bool Equals(MessageEntity other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MessageEntity x && Equals(x);
        public static bool operator ==(MessageEntity x, MessageEntity y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MessageEntity x, MessageEntity y) => !(x == y);

        public int CompareTo(MessageEntity other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MessageEntity x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MessageEntity x, MessageEntity y) => x.CompareTo(y) <= 0;
        public static bool operator <(MessageEntity x, MessageEntity y) => x.CompareTo(y) < 0;
        public static bool operator >(MessageEntity x, MessageEntity y) => x.CompareTo(y) > 0;
        public static bool operator >=(MessageEntity x, MessageEntity y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MessageEntity.{_tag.GetType().Name}{_tag}";
    }
}