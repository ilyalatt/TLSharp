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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc61acbd8;
            
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
                case 0xc61acbd8: return (WebDocument) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xc61acbd8 });
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

        public bool Equals(WebDocument other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is WebDocument x && Equals(x);
        public static bool operator ==(WebDocument a, WebDocument b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(WebDocument a, WebDocument b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(WebDocument other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is WebDocument x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebDocument a, WebDocument b) => a.CompareTo(b) <= 0;
        public static bool operator <(WebDocument a, WebDocument b) => a.CompareTo(b) < 0;
        public static bool operator >(WebDocument a, WebDocument b) => a.CompareTo(b) > 0;
        public static bool operator >=(WebDocument a, WebDocument b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}