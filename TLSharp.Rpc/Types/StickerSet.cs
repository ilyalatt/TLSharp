using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class StickerSet : ITlType, IEquatable<StickerSet>, IComparable<StickerSet>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xcd303b41;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool Installed { get; }
            public bool Archived { get; }
            public bool Official { get; }
            public bool Masks { get; }
            public long Id { get; }
            public long AccessHash { get; }
            public string Title { get; }
            public string ShortName { get; }
            public int Count { get; }
            public int Hash { get; }
            
            public Tag(
                bool installed,
                bool archived,
                bool official,
                bool masks,
                long id,
                long accessHash,
                Some<string> title,
                Some<string> shortName,
                int count,
                int hash
            ) {
                Installed = installed;
                Archived = archived;
                Official = official;
                Masks = masks;
                Id = id;
                AccessHash = accessHash;
                Title = title;
                ShortName = shortName;
                Count = count;
                Hash = hash;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Installed) | MaskBit(1, Archived) | MaskBit(2, Official) | MaskBit(3, Masks), bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Title, bw, WriteString);
                Write(ShortName, bw, WriteString);
                Write(Count, bw, WriteInt);
                Write(Hash, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var installed = Read(br, ReadOption(flags, 0));
                var archived = Read(br, ReadOption(flags, 1));
                var official = Read(br, ReadOption(flags, 2));
                var masks = Read(br, ReadOption(flags, 3));
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var title = Read(br, ReadString);
                var shortName = Read(br, ReadString);
                var count = Read(br, ReadInt);
                var hash = Read(br, ReadInt);
                return new Tag(installed, archived, official, masks, id, accessHash, title, shortName, count, hash);
            }
        }

        readonly ITlTypeTag _tag;
        StickerSet(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator StickerSet(Tag tag) => new StickerSet(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static StickerSet Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (StickerSet) Tag.DeserializeTag(br);
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

        public bool Equals(StickerSet other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is StickerSet x && Equals(x);
        public static bool operator ==(StickerSet a, StickerSet b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(StickerSet a, StickerSet b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(StickerSet other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is StickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSet a, StickerSet b) => a.CompareTo(b) <= 0;
        public static bool operator <(StickerSet a, StickerSet b) => a.CompareTo(b) < 0;
        public static bool operator >(StickerSet a, StickerSet b) => a.CompareTo(b) > 0;
        public static bool operator >=(StickerSet a, StickerSet b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}