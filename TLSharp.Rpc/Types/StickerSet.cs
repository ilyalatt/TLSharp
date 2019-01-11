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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xcd303b41;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool Installed;
            public readonly bool Archived;
            public readonly bool Official;
            public readonly bool Masks;
            public readonly long Id;
            public readonly long AccessHash;
            public readonly string Title;
            public readonly string ShortName;
            public readonly int Count;
            public readonly int Hash;
            
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
            
            (bool, bool, bool, bool, long, long, string, string, int, int) CmpTuple =>
                (Installed, Archived, Official, Masks, Id, AccessHash, Title, ShortName, Count, Hash);

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

            public override string ToString() => $"(Installed: {Installed}, Archived: {Archived}, Official: {Official}, Masks: {Masks}, Id: {Id}, AccessHash: {AccessHash}, Title: {Title}, ShortName: {ShortName}, Count: {Count}, Hash: {Hash})";
            
            
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(StickerSet other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is StickerSet x && Equals(x);
        public static bool operator ==(StickerSet x, StickerSet y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(StickerSet x, StickerSet y) => !(x == y);

        public int CompareTo(StickerSet other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is StickerSet x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(StickerSet x, StickerSet y) => x.CompareTo(y) <= 0;
        public static bool operator <(StickerSet x, StickerSet y) => x.CompareTo(y) < 0;
        public static bool operator >(StickerSet x, StickerSet y) => x.CompareTo(y) > 0;
        public static bool operator >=(StickerSet x, StickerSet y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"StickerSet.{_tag.GetType().Name}{_tag}";
    }
}