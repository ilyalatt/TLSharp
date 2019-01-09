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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf52ff27f;
            
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

        public sealed class BigTag : Record<BigTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfa4f0bb5;
            
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
                case 0xf52ff27f: return (InputFile) Tag.DeserializeTag(br);
                case 0xfa4f0bb5: return (InputFile) BigTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xf52ff27f, 0xfa4f0bb5 });
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

        public bool Equals(InputFile other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputFile x && Equals(x);
        public static bool operator ==(InputFile a, InputFile b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputFile a, InputFile b) => !(a == b);

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

        public int CompareTo(InputFile other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputFile a, InputFile b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputFile a, InputFile b) => a.CompareTo(b) < 0;
        public static bool operator >(InputFile a, InputFile b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputFile a, InputFile b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}