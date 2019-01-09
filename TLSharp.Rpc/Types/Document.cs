using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Document : ITlType, IEquatable<Document>, IComparable<Document>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x36f8c871;
            
            public long Id { get; }
            
            public EmptyTag(
                long id
            ) {
                Id = id;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                return new EmptyTag(id);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x87232bc7;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Date { get; }
            public string MimeType { get; }
            public int Size { get; }
            public T.PhotoSize Thumb { get; }
            public int DcId { get; }
            public int Version { get; }
            public Arr<T.DocumentAttribute> Attributes { get; }
            
            public Tag(
                long id,
                long accessHash,
                int date,
                Some<string> mimeType,
                int size,
                Some<T.PhotoSize> thumb,
                int dcId,
                int version,
                Some<Arr<T.DocumentAttribute>> attributes
            ) {
                Id = id;
                AccessHash = accessHash;
                Date = date;
                MimeType = mimeType;
                Size = size;
                Thumb = thumb;
                DcId = dcId;
                Version = version;
                Attributes = attributes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Date, bw, WriteInt);
                Write(MimeType, bw, WriteString);
                Write(Size, bw, WriteInt);
                Write(Thumb, bw, WriteSerializable);
                Write(DcId, bw, WriteInt);
                Write(Version, bw, WriteInt);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var date = Read(br, ReadInt);
                var mimeType = Read(br, ReadString);
                var size = Read(br, ReadInt);
                var thumb = Read(br, T.PhotoSize.Deserialize);
                var dcId = Read(br, ReadInt);
                var version = Read(br, ReadInt);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                return new Tag(id, accessHash, date, mimeType, size, thumb, dcId, version, attributes);
            }
        }

        readonly ITlTypeTag _tag;
        Document(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Document(EmptyTag tag) => new Document(tag);
        public static explicit operator Document(Tag tag) => new Document(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Document Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x36f8c871: return (Document) EmptyTag.DeserializeTag(br);
                case 0x87232bc7: return (Document) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x36f8c871, 0x87232bc7 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(Document other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Document x && Equals(x);
        public static bool operator ==(Document a, Document b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Document a, Document b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Document other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Document x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Document a, Document b) => a.CompareTo(b) <= 0;
        public static bool operator <(Document a, Document b) => a.CompareTo(b) < 0;
        public static bool operator >(Document a, Document b) => a.CompareTo(b) > 0;
        public static bool operator >=(Document a, Document b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}