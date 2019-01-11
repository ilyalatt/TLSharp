using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class SentEncryptedMessage : ITlType, IEquatable<SentEncryptedMessage>, IComparable<SentEncryptedMessage>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x560f8935;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Date;
            
            public Tag(
                int date
            ) {
                Date = date;
            }
            
            int CmpTuple =>
                Date;

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

            public override string ToString() => $"(Date: {Date})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Date, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var date = Read(br, ReadInt);
                return new Tag(date);
            }
        }

        public sealed class FileTag : ITlTypeTag, IEquatable<FileTag>, IComparable<FileTag>, IComparable
        {
            internal const uint TypeNumber = 0x9493ff32;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Date;
            public readonly T.EncryptedFile File;
            
            public FileTag(
                int date,
                Some<T.EncryptedFile> file
            ) {
                Date = date;
                File = file;
            }
            
            (int, T.EncryptedFile) CmpTuple =>
                (Date, File);

            public bool Equals(FileTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FileTag x && Equals(x);
            public static bool operator ==(FileTag x, FileTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FileTag x, FileTag y) => !(x == y);

            public int CompareTo(FileTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FileTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FileTag x, FileTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FileTag x, FileTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FileTag x, FileTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FileTag x, FileTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Date: {Date}, File: {File})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Date, bw, WriteInt);
                Write(File, bw, WriteSerializable);
            }
            
            internal static FileTag DeserializeTag(BinaryReader br)
            {
                var date = Read(br, ReadInt);
                var file = Read(br, T.EncryptedFile.Deserialize);
                return new FileTag(date, file);
            }
        }

        readonly ITlTypeTag _tag;
        SentEncryptedMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SentEncryptedMessage(Tag tag) => new SentEncryptedMessage(tag);
        public static explicit operator SentEncryptedMessage(FileTag tag) => new SentEncryptedMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SentEncryptedMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (SentEncryptedMessage) Tag.DeserializeTag(br);
                case FileTag.TypeNumber: return (SentEncryptedMessage) FileTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, FileTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<FileTag, T> fileTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case FileTag x when fileTag != null: return fileTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<FileTag, T> fileTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            fileTag ?? throw new ArgumentNullException(nameof(fileTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case FileTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(SentEncryptedMessage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SentEncryptedMessage x && Equals(x);
        public static bool operator ==(SentEncryptedMessage x, SentEncryptedMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SentEncryptedMessage x, SentEncryptedMessage y) => !(x == y);

        public int CompareTo(SentEncryptedMessage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SentEncryptedMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SentEncryptedMessage x, SentEncryptedMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(SentEncryptedMessage x, SentEncryptedMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(SentEncryptedMessage x, SentEncryptedMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(SentEncryptedMessage x, SentEncryptedMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SentEncryptedMessage.{_tag.GetType().Name}{_tag}";
    }
}