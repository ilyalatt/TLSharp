using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class FileHash : ITlType, IEquatable<FileHash>, IComparable<FileHash>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x6242c773;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Offset;
            public readonly int Limit;
            public readonly Arr<byte> Hash;
            
            public Tag(
                int offset,
                int limit,
                Some<Arr<byte>> hash
            ) {
                Offset = offset;
                Limit = limit;
                Hash = hash;
            }
            
            (int, int, Arr<byte>) CmpTuple =>
                (Offset, Limit, Hash);

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

            public override string ToString() => $"(Offset: {Offset}, Limit: {Limit}, Hash: {Hash})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Offset, bw, WriteInt);
                Write(Limit, bw, WriteInt);
                Write(Hash, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var offset = Read(br, ReadInt);
                var limit = Read(br, ReadInt);
                var hash = Read(br, ReadBytes);
                return new Tag(offset, limit, hash);
            }
        }

        readonly ITlTypeTag _tag;
        FileHash(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FileHash(Tag tag) => new FileHash(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FileHash Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (FileHash) Tag.DeserializeTag(br);
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

        public bool Equals(FileHash other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is FileHash x && Equals(x);
        public static bool operator ==(FileHash x, FileHash y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FileHash x, FileHash y) => !(x == y);

        public int CompareTo(FileHash other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is FileHash x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FileHash x, FileHash y) => x.CompareTo(y) <= 0;
        public static bool operator <(FileHash x, FileHash y) => x.CompareTo(y) < 0;
        public static bool operator >(FileHash x, FileHash y) => x.CompareTo(y) > 0;
        public static bool operator >=(FileHash x, FileHash y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FileHash.{_tag.GetType().Name}{_tag}";
    }
}