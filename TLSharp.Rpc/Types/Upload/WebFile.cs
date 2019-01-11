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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x21e753bc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Size;
            public readonly string MimeType;
            public readonly T.Storage.FileType FileType;
            public readonly int Mtime;
            public readonly Arr<byte> Bytes;
            
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
            
            (int, string, T.Storage.FileType, int, Arr<byte>) CmpTuple =>
                (Size, MimeType, FileType, Mtime, Bytes);

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

            public override string ToString() => $"(Size: {Size}, MimeType: {MimeType}, FileType: {FileType}, Mtime: {Mtime}, Bytes: {Bytes})";
            
            
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
                case Tag.TypeNumber: return (WebFile) Tag.DeserializeTag(br);
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(WebFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is WebFile x && Equals(x);
        public static bool operator ==(WebFile x, WebFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(WebFile x, WebFile y) => !(x == y);

        public int CompareTo(WebFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is WebFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebFile x, WebFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(WebFile x, WebFile y) => x.CompareTo(y) < 0;
        public static bool operator >(WebFile x, WebFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(WebFile x, WebFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"WebFile.{_tag.GetType().Name}{_tag}";
    }
}