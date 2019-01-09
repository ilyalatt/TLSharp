using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Upload
{
    public sealed class WebFile : ITlType, IEquatable<WebFile>, IComparable<WebFile>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x21e753bc;
            
            public int Size { get; }
            public string MimeType { get; }
            public T.Storage.FileType FileType { get; }
            public int Mtime { get; }
            public Arr<byte> Bytes { get; }
            
            public Tag(
                int size,
                Some<string> mimeType,
                Some<T.Storage.FileType> fileType,
                int mtime,
                Some<Arr<byte>> bytes
            ) {
                Size = size;
                MimeType = mimeType;
                FileType = fileType;
                Mtime = mtime;
                Bytes = bytes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Size, bw, WriteInt);
                Write(MimeType, bw, WriteString);
                Write(FileType, bw, WriteSerializable);
                Write(Mtime, bw, WriteInt);
                Write(Bytes, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var size = Read(br, ReadInt);
                var mimeType = Read(br, ReadString);
                var fileType = Read(br, T.Storage.FileType.Deserialize);
                var mtime = Read(br, ReadInt);
                var bytes = Read(br, ReadBytes);
                return new Tag(size, mimeType, fileType, mtime, bytes);
            }
        }

        readonly ITlTypeTag _tag;
        WebFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator WebFile(Tag tag) => new WebFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static WebFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x21e753bc: return (WebFile) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x21e753bc });
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

        public bool Equals(WebFile other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is WebFile x && Equals(x);
        public static bool operator ==(WebFile a, WebFile b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(WebFile a, WebFile b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(WebFile other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is WebFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebFile a, WebFile b) => a.CompareTo(b) <= 0;
        public static bool operator <(WebFile a, WebFile b) => a.CompareTo(b) < 0;
        public static bool operator >(WebFile a, WebFile b) => a.CompareTo(b) > 0;
        public static bool operator >=(WebFile a, WebFile b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}