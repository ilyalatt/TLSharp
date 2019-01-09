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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xbdf9653b;
            
            public long Id { get; }
            public long AccessHash { get; }
            public string ShortName { get; }
            public string Title { get; }
            public string Description { get; }
            public T.Photo Photo { get; }
            public Option<T.Document> Document { get; }
            
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
                case 0xbdf9653b: return (Game) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xbdf9653b });
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

        public bool Equals(Game other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Game x && Equals(x);
        public static bool operator ==(Game a, Game b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Game a, Game b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Game other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Game x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Game a, Game b) => a.CompareTo(b) <= 0;
        public static bool operator <(Game a, Game b) => a.CompareTo(b) < 0;
        public static bool operator >(Game a, Game b) => a.CompareTo(b) > 0;
        public static bool operator >=(Game a, Game b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}