using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Game : ITlType, IEquatable<Game>, IComparable<Game>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xbdf9653b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly string ShortName;
            public readonly string Title;
            public readonly string Description;
            public readonly T.Photo Photo;
            public readonly Option<T.Document> Document;
            
            public Tag(
                long id,
                long accessHash,
                Some<string> shortName,
                Some<string> title,
                Some<string> description,
                Some<T.Photo> photo,
                Option<T.Document> document
            ) {
                Id = id;
                AccessHash = accessHash;
                ShortName = shortName;
                Title = title;
                Description = description;
                Photo = photo;
                Document = document;
            }
            
            (long, long, string, string, string, T.Photo, Option<T.Document>) CmpTuple =>
                (Id, AccessHash, ShortName, Title, Description, Photo, Document);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, ShortName: {ShortName}, Title: {Title}, Description: {Description}, Photo: {Photo}, Document: {Document})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, Document), bw, WriteInt);
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(ShortName, bw, WriteString);
                Write(Title, bw, WriteString);
                Write(Description, bw, WriteString);
                Write(Photo, bw, WriteSerializable);
                Write(Document, bw, WriteOption<T.Document>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var shortName = Read(br, ReadString);
                var title = Read(br, ReadString);
                var description = Read(br, ReadString);
                var photo = Read(br, T.Photo.Deserialize);
                var document = Read(br, ReadOption(flags, 0, T.Document.Deserialize));
                return new Tag(id, accessHash, shortName, title, description, photo, document);
            }
        }

        readonly ITlTypeTag _tag;
        Game(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Game(Tag tag) => new Game(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Game Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Game) Tag.DeserializeTag(br);
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

        public bool Equals(Game other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Game x && Equals(x);
        public static bool operator ==(Game x, Game y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Game x, Game y) => !(x == y);

        public int CompareTo(Game other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Game x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Game x, Game y) => x.CompareTo(y) <= 0;
        public static bool operator <(Game x, Game y) => x.CompareTo(y) < 0;
        public static bool operator >(Game x, Game y) => x.CompareTo(y) > 0;
        public static bool operator >=(Game x, Game y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Game.{_tag.GetType().Name}{_tag}";
    }
}