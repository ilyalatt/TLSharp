using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputWebDocument : ITlType, IEquatable<InputWebDocument>, IComparable<InputWebDocument>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9bed434d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Url;
            public readonly int Size;
            public readonly string MimeType;
            public readonly Arr<T.DocumentAttribute> Attributes;
            
            public Tag(
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

            public override string ToString() => $"(Url: {Url}, Size: {Size}, MimeType: {MimeType}, Attributes: {Attributes})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Url, bw, WriteString);
                Write(Size, bw, WriteInt);
                Write(MimeType, bw, WriteString);
                Write(Attributes, bw, WriteVector<T.DocumentAttribute>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var url = Read(br, ReadString);
                var size = Read(br, ReadInt);
                var mimeType = Read(br, ReadString);
                var attributes = Read(br, ReadVector(T.DocumentAttribute.Deserialize));
                return new Tag(url, size, mimeType, attributes);
            }
        }

        readonly ITlTypeTag _tag;
        InputWebDocument(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputWebDocument(Tag tag) => new InputWebDocument(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputWebDocument Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputWebDocument) Tag.DeserializeTag(br);
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

        public bool Equals(InputWebDocument other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputWebDocument x && Equals(x);
        public static bool operator ==(InputWebDocument x, InputWebDocument y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputWebDocument x, InputWebDocument y) => !(x == y);

        public int CompareTo(InputWebDocument other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputWebDocument x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputWebDocument x, InputWebDocument y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputWebDocument x, InputWebDocument y) => x.CompareTo(y) < 0;
        public static bool operator >(InputWebDocument x, InputWebDocument y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputWebDocument x, InputWebDocument y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputWebDocument.{_tag.GetType().Name}{_tag}";
    }
}