using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PhotoSize : ITlType, IEquatable<PhotoSize>, IComparable<PhotoSize>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x0e17e23c;
            
            public string Type { get; }
            
            public EmptyTag(
                Some<string> type
            ) {
                Type = type;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteString);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, ReadString);
                return new EmptyTag(type);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x77bfb61b;
            
            public string Type { get; }
            public T.FileLocation Location { get; }
            public int W { get; }
            public int H { get; }
            public int Size { get; }
            
            public Tag(
                Some<string> type,
                Some<T.FileLocation> location,
                int w,
                int h,
                int size
            ) {
                Type = type;
                Location = location;
                W = w;
                H = h;
                Size = size;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteString);
                Write(Location, bw, WriteSerializable);
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
                Write(Size, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, ReadString);
                var location = Read(br, T.FileLocation.Deserialize);
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                var size = Read(br, ReadInt);
                return new Tag(type, location, w, h, size);
            }
        }

        public sealed class CachedTag : Record<CachedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe9a734fa;
            
            public string Type { get; }
            public T.FileLocation Location { get; }
            public int W { get; }
            public int H { get; }
            public Arr<byte> Bytes { get; }
            
            public CachedTag(
                Some<string> type,
                Some<T.FileLocation> location,
                int w,
                int h,
                Some<Arr<byte>> bytes
            ) {
                Type = type;
                Location = location;
                W = w;
                H = h;
                Bytes = bytes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteString);
                Write(Location, bw, WriteSerializable);
                Write(W, bw, WriteInt);
                Write(H, bw, WriteInt);
                Write(Bytes, bw, WriteBytes);
            }
            
            internal static CachedTag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, ReadString);
                var location = Read(br, T.FileLocation.Deserialize);
                var w = Read(br, ReadInt);
                var h = Read(br, ReadInt);
                var bytes = Read(br, ReadBytes);
                return new CachedTag(type, location, w, h, bytes);
            }
        }

        readonly ITlTypeTag _tag;
        PhotoSize(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PhotoSize(EmptyTag tag) => new PhotoSize(tag);
        public static explicit operator PhotoSize(Tag tag) => new PhotoSize(tag);
        public static explicit operator PhotoSize(CachedTag tag) => new PhotoSize(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PhotoSize Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x0e17e23c: return (PhotoSize) EmptyTag.DeserializeTag(br);
                case 0x77bfb61b: return (PhotoSize) Tag.DeserializeTag(br);
                case 0xe9a734fa: return (PhotoSize) CachedTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x0e17e23c, 0x77bfb61b, 0xe9a734fa });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null,
            Func<CachedTag, T> cachedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                case CachedTag x when cachedTag != null: return cachedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag,
            Func<CachedTag, T> cachedTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            cachedTag ?? throw new ArgumentNullException(nameof(cachedTag))
        );

        public bool Equals(PhotoSize other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PhotoSize x && Equals(x);
        public static bool operator ==(PhotoSize a, PhotoSize b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PhotoSize a, PhotoSize b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                case CachedTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PhotoSize other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhotoSize x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhotoSize a, PhotoSize b) => a.CompareTo(b) <= 0;
        public static bool operator <(PhotoSize a, PhotoSize b) => a.CompareTo(b) < 0;
        public static bool operator >(PhotoSize a, PhotoSize b) => a.CompareTo(b) > 0;
        public static bool operator >=(PhotoSize a, PhotoSize b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}