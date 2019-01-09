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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x12b299d4;
            
            public string Emoticon { get; }
            public Arr<long> Documents { get; }
            
            public Tag(
                Some<string> emoticon,
                Some<Arr<long>> documents
            ) {
                Emoticon = emoticon;
                Documents = documents;
            }
            
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
                case 0x12b299d4: return (StickerPack) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x12b299d4 });
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

        public bool Equals(StickerPack other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is StickerPack x && Equals(x);
        public static bool operator ==(StickerPack a, StickerPack b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(StickerPack a, StickerPack b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(StickerPack other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is StickerPack x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerPack a, StickerPack b) => a.CompareTo(b) <= 0;
        public static bool operator <(StickerPack a, StickerPack b) => a.CompareTo(b) < 0;
        public static bool operator >(StickerPack a, StickerPack b) => a.CompareTo(b) > 0;
        public static bool operator >=(StickerPack a, StickerPack b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}