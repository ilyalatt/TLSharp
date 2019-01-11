using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class StickerPack : ITlType, IEquatable<StickerPack>, IComparable<StickerPack>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x12b299d4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Emoticon;
            public readonly Arr<long> Documents;
            
            public Tag(
                Some<string> emoticon,
                Some<Arr<long>> documents
            ) {
                Emoticon = emoticon;
                Documents = documents;
            }
            
            (string, Arr<long>) CmpTuple =>
                (Emoticon, Documents);

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

            public override string ToString() => $"(Emoticon: {Emoticon}, Documents: {Documents})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Emoticon, bw, WriteString);
                Write(Documents, bw, WriteVector<long>(WriteLong));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var emoticon = Read(br, ReadString);
                var documents = Read(br, ReadVector(ReadLong));
                return new Tag(emoticon, documents);
            }
        }

        readonly ITlTypeTag _tag;
        StickerPack(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator StickerPack(Tag tag) => new StickerPack(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static StickerPack Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (StickerPack) Tag.DeserializeTag(br);
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

        public bool Equals(StickerPack other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is StickerPack x && Equals(x);
        public static bool operator ==(StickerPack x, StickerPack y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(StickerPack x, StickerPack y) => !(x == y);

        public int CompareTo(StickerPack other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is StickerPack x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerPack x, StickerPack y) => x.CompareTo(y) <= 0;
        public static bool operator <(StickerPack x, StickerPack y) => x.CompareTo(y) < 0;
        public static bool operator >(StickerPack x, StickerPack y) => x.CompareTo(y) > 0;
        public static bool operator >=(StickerPack x, StickerPack y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"StickerPack.{_tag.GetType().Name}{_tag}";
    }
}