using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputFile : ITlType, IEquatable<InputFile>, IComparable<InputFile>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xf52ff27f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public int Parts { get; }
            public string Name { get; }
            public string Md5Checksum { get; }
            
            public Tag(
                long id,
                int parts,
                Some<string> name,
                Some<string> md5Checksum
            ) {
                Id = id;
                Parts = parts;
                Name = name;
                Md5Checksum = md5Checksum;
            }
            
            (long, int, string, string) CmpTuple =>
                (Id, Parts, Name, Md5Checksum);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Parts: {Parts}, Name: {Name}, Md5Checksum: {Md5Checksum})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Parts, bw, WriteInt);
                Write(Name, bw, WriteString);
                Write(Md5Checksum, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var parts = Read(br, ReadInt);
                var name = Read(br, ReadString);
                var md5Checksum = Read(br, ReadString);
                return new Tag(id, parts, name, md5Checksum);
            }
        }

        public sealed class BigTag : ITlTypeTag, IEquatable<BigTag>, IComparable<BigTag>, IComparable
        {
            internal const uint TypeNumber = 0xfa4f0bb5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public int Parts { get; }
            public string Name { get; }
            
            public BigTag(
                long id,
                int parts,
                Some<string> name
            ) {
                Id = id;
                Parts = parts;
                Name = name;
            }
            
            (long, int, string) CmpTuple =>
                (Id, Parts, Name);

            public bool Equals(BigTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BigTag x && Equals(x);
            public static bool operator ==(BigTag x, BigTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BigTag x, BigTag y) => !(x == y);

            public int CompareTo(BigTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BigTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BigTag x, BigTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BigTag x, BigTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BigTag x, BigTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BigTag x, BigTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Parts: {Parts}, Name: {Name})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Parts, bw, WriteInt);
                Write(Name, bw, WriteString);
            }
            
            internal static BigTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var parts = Read(br, ReadInt);
                var name = Read(br, ReadString);
                return new BigTag(id, parts, name);
            }
        }

        readonly ITlTypeTag _tag;
        InputFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputFile(Tag tag) => new InputFile(tag);
        public static explicit operator InputFile(BigTag tag) => new InputFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputFile) Tag.DeserializeTag(br);
                case BigTag.TypeNumber: return (InputFile) BigTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, BigTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<BigTag, T> bigTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case BigTag x when bigTag != null: return bigTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<BigTag, T> bigTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            bigTag ?? throw new ArgumentNullException(nameof(bigTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case BigTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputFile other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputFile x && Equals(x);
        public static bool operator ==(InputFile x, InputFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputFile x, InputFile y) => !(x == y);

        public int CompareTo(InputFile other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputFile x, InputFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputFile x, InputFile y) => x.CompareTo(y) < 0;
        public static bool operator >(InputFile x, InputFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputFile x, InputFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputFile.{_tag.GetType().Name}{_tag}";
    }
}