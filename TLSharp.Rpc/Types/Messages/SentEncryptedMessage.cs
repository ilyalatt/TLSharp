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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x560f8935;
            
            public int Date { get; }
            
            public Tag(
                int date
            ) {
                Date = date;
            }
            
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

        public sealed class FileTag : Record<FileTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9493ff32;
            
            public int Date { get; }
            public T.EncryptedFile File { get; }
            
            public FileTag(
                int date,
                Some<T.EncryptedFile> file
            ) {
                Date = date;
                File = file;
            }
            
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
                case 0x560f8935: return (SentEncryptedMessage) Tag.DeserializeTag(br);
                case 0x9493ff32: return (SentEncryptedMessage) FileTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x560f8935, 0x9493ff32 });
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

        public bool Equals(SentEncryptedMessage other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is SentEncryptedMessage x && Equals(x);
        public static bool operator ==(SentEncryptedMessage a, SentEncryptedMessage b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(SentEncryptedMessage a, SentEncryptedMessage b) => !(a == b);

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

        public int CompareTo(SentEncryptedMessage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SentEncryptedMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SentEncryptedMessage a, SentEncryptedMessage b) => a.CompareTo(b) <= 0;
        public static bool operator <(SentEncryptedMessage a, SentEncryptedMessage b) => a.CompareTo(b) < 0;
        public static bool operator >(SentEncryptedMessage a, SentEncryptedMessage b) => a.CompareTo(b) > 0;
        public static bool operator >=(SentEncryptedMessage a, SentEncryptedMessage b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}