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
            internal const uint TypeNumber = 0x1c570ed1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly long AccessHash;
            public readonly int Size;
            public readonly string MimeType;
            public readonly Arr<T.DocumentAttribute> Attributes;
            
            public Tag(
                Some<string> url,
                long accessHash,
                int size,
                Some<string> mimeType,
                Some<Arr<T.DocumentAttribute>> attributes
            ) {
                Url = url;
                AccessHash = accessHash;
                Size = size;
                MimeType = mimeType;
                Attributes = attributes;
            }
            
            (string, long, int, string, Arr<T.DocumentAttribute>) CmpTuple =>
                (Url, AccessHash, Size, MimeType, Attributes);

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

            public override string ToString() => $"(Url: {Url}, AccessHash: {AccessHash}, Size: {Size}, MimeType: {MimeType}, Attributes: {Attributes})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(AccessHash, bw, WriteLong);
                Write(Size, bw, WriteInt);
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var accessHash = Read(br, ReadLong);
                var size = Read(br, ReadInt);
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                return new Tag(url, accessHash, size, mimeType, attributes);
            }
        }

        public sealed class NoProxyTag : ITlTypeTag, IEquatable<NoProxyTag>, IComparable<NoProxyTag>, IComparable
        {
            internal const uint TypeNumber = 0xf9c8bcc6;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly int Size;
            public readonly string MimeType;
            public readonly Arr<T.DocumentAttribute> Attributes;
            
            public NoProxyTag(
                Some<string> url,
                int size,
                Some<string> mimeType,
                Some<Arr<T.DocumentAttribute>> attributes
            ) {
                Url = url;
                Size = size;
                MimeType = mimeType;
                Attributes = attributes;
            }
            
            (string, int, string, Arr<T.DocumentAttribute>) CmpTuple =>
                (Url, Size, MimeType, Attributes);

            public bool Equals(NoProxyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is NoProxyTag x && Equals(x);
            public static bool operator ==(NoProxyTag x, NoProxyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoProxyTag x, NoProxyTag y) => !(x == y);

            public int CompareTo(NoProxyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is NoProxyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoProxyTag x, NoProxyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoProxyTag x, NoProxyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoProxyTag x, NoProxyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoProxyTag x, NoProxyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Url: {Url}, Size: {Size}, MimeType: {MimeType}, Attributes: {Attributes})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Size, bw, WriteInt);
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
            }
            
            internal static NoProxyTag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var size = Read(br, ReadInt);
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                return new NoProxyTag(url, size, mimeType, attributes);
            }
        }

        readonly ITlTypeTag _tag;
        WebDocument(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator WebDocument(Tag tag) => new WebDocument(tag);
        public static explicit operator WebDocument(NoProxyTag tag) => new WebDocument(tag);

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
                case NoProxyTag.TypeNumber: return (WebDocument) NoProxyTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, NoProxyTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<NoProxyTag, T> noProxyTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case NoProxyTag x when noProxyTag != null: return noProxyTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<NoProxyTag, T> noProxyTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            noProxyTag ?? throw new ArgumentNullException(nameof(noProxyTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case NoProxyTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(WebDocument other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is WebDocument x && Equals(x);
        public static bool operator ==(WebDocument x, WebDocument y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(WebDocument x, WebDocument y) => !(x == y);

        public int CompareTo(WebDocument other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is WebDocument x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebDocument x, WebDocument y) => x.CompareTo(y) <= 0;
        public static bool operator <(WebDocument x, WebDocument y) => x.CompareTo(y) < 0;
        public static bool operator >(WebDocument x, WebDocument y) => x.CompareTo(y) > 0;
        public static bool operator >=(WebDocument x, WebDocument y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"WebDocument.{_tag.GetType().Name}{_tag}";
    }
}