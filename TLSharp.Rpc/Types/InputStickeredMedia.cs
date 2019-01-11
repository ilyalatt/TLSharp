using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputStickeredMedia : ITlType, IEquatable<InputStickeredMedia>, IComparable<InputStickeredMedia>, IComparable
    {
        public sealed class PhotoTag : ITlTypeTag, IEquatable<PhotoTag>, IComparable<PhotoTag>, IComparable
        {
            internal const uint TypeNumber = 0x4a992157;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputPhoto Id;
            
            public PhotoTag(
                Some<T.InputPhoto> id
            ) {
                Id = id;
            }
            
            T.InputPhoto CmpTuple =>
                Id;

            public bool Equals(PhotoTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is PhotoTag x && Equals(x);
            public static bool operator ==(PhotoTag x, PhotoTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(PhotoTag x, PhotoTag y) => !(x == y);

            public int CompareTo(PhotoTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is PhotoTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(PhotoTag x, PhotoTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(PhotoTag x, PhotoTag y) => x.CompareTo(y) < 0;
            public static bool operator >(PhotoTag x, PhotoTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(PhotoTag x, PhotoTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteSerializable);
            }
            
            internal static PhotoTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, T.InputPhoto.Deserialize);
                return new PhotoTag(id);
            }
        }

        public sealed class DocumentTag : ITlTypeTag, IEquatable<DocumentTag>, IComparable<DocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0x0438865b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly T.InputDocument Id;
            
            public DocumentTag(
                Some<T.InputDocument> id
            ) {
                Id = id;
            }
            
            T.InputDocument CmpTuple =>
                Id;

            public bool Equals(DocumentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DocumentTag x && Equals(x);
            public static bool operator ==(DocumentTag x, DocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentTag x, DocumentTag y) => !(x == y);

            public int CompareTo(DocumentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DocumentTag x, DocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DocumentTag x, DocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DocumentTag x, DocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DocumentTag x, DocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteSerializable);
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, T.InputDocument.Deserialize);
                return new DocumentTag(id);
            }
        }

        readonly ITlTypeTag _tag;
        InputStickeredMedia(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputStickeredMedia(PhotoTag tag) => new InputStickeredMedia(tag);
        public static explicit operator InputStickeredMedia(DocumentTag tag) => new InputStickeredMedia(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputStickeredMedia Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case PhotoTag.TypeNumber: return (InputStickeredMedia) PhotoTag.DeserializeTag(br);
                case DocumentTag.TypeNumber: return (InputStickeredMedia) DocumentTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { PhotoTag.TypeNumber, DocumentTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<PhotoTag, T> photoTag = null,
            Func<DocumentTag, T> documentTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case PhotoTag x when photoTag != null: return photoTag(x);
                case DocumentTag x when documentTag != null: return documentTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<PhotoTag, T> photoTag,
            Func<DocumentTag, T> documentTag
        ) => Match(
            () => throw new Exception("WTF"),
            photoTag ?? throw new ArgumentNullException(nameof(photoTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case PhotoTag _: return 0;
                case DocumentTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputStickeredMedia other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputStickeredMedia x && Equals(x);
        public static bool operator ==(InputStickeredMedia x, InputStickeredMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputStickeredMedia x, InputStickeredMedia y) => !(x == y);

        public int CompareTo(InputStickeredMedia other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputStickeredMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputStickeredMedia x, InputStickeredMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputStickeredMedia x, InputStickeredMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(InputStickeredMedia x, InputStickeredMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputStickeredMedia x, InputStickeredMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputStickeredMedia.{_tag.GetType().Name}{_tag}";
    }
}