using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class WebDocument : ITlType, IEquatable<WebDocument>, IComparable<WebDocument>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xc61acbd8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Url { get; }
            public long AccessHash { get; }
            public int Size { get; }
            public string MimeType { get; }
            public Arr<T.DocumentAttribute> Attributes { get; }
            public int DcId { get; }
            
            public Tag(
                Some<string> url,
                long accessHash,
                int size,
                Some<string> mimeType,
                Some<Arr<T.DocumentAttribute>> attributes,
                int dcId
            ) {
                Url = url;
                AccessHash = accessHash;
                Size = size;
                MimeType = mimeType;
                Attributes = attributes;
                DcId = dcId;
            }
            
            (string, long, int, string, Arr<T.DocumentAttribute>, int) CmpTuple =>
                (Url, AccessHash, Size, MimeType, Attributes, DcId);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, AccessHash: {AccessHash}, Size: {Size}, MimeType: {MimeType}, Attributes: {Attributes}, DcId: {DcId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(AccessHash, bw, WriteLong);
                Write(Size, bw, WriteInt);
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
                Write(DcId, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var accessHash = Read(br, ReadLong);
                var size = Read(br, ReadInt);
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                var dcId = Read(br, ReadInt);
                return new Tag(url, accessHash, size, mimeType, attributes, dcId);
            }
        }

        readonly ITlTypeTag _tag;
        WebDocument(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator WebDocument(Tag tag) => new WebDocument(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static WebDocument Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (WebDocument) Tag.DeserializeTag(br);
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

        public bool Equals(WebDocument other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is WebDocument x && Equals(x);
        public static bool operator ==(WebDocument x, WebDocument y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(WebDocument x, WebDocument y) => !(x == y);

        public int CompareTo(WebDocument other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is WebDocument x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebDocument x, WebDocument y) => x.CompareTo(y) <= 0;
        public static bool operator <(WebDocument x, WebDocument y) => x.CompareTo(y) < 0;
        public static bool operator >(WebDocument x, WebDocument y) => x.CompareTo(y) > 0;
        public static bool operator >=(WebDocument x, WebDocument y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"WebDocument.{_tag.GetType().Name}{_tag}";
    }
}