using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputSecureFile : ITlType, IEquatable<InputSecureFile>, IComparable<InputSecureFile>, IComparable
    {
        public sealed class UploadedTag : ITlTypeTag, IEquatable<UploadedTag>, IComparable<UploadedTag>, IComparable
        {
            internal const uint TypeNumber = 0x3334b0f0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly int Parts;
            public readonly string Md5Checksum;
            public readonly Arr<byte> FileHash;
            public readonly Arr<byte> Secret;
            
            public UploadedTag(
                long id,
                int parts,
                Some<string> md5Checksum,
                Some<Arr<byte>> fileHash,
                Some<Arr<byte>> secret
            ) {
                Id = id;
                Parts = parts;
                Md5Checksum = md5Checksum;
                FileHash = fileHash;
                Secret = secret;
            }
            
            (long, int, string, Arr<byte>, Arr<byte>) CmpTuple =>
                (Id, Parts, Md5Checksum, FileHash, Secret);

            public bool Equals(UploadedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UploadedTag x && Equals(x);
            public static bool operator ==(UploadedTag x, UploadedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UploadedTag x, UploadedTag y) => !(x == y);

            public int CompareTo(UploadedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UploadedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UploadedTag x, UploadedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UploadedTag x, UploadedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UploadedTag x, UploadedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UploadedTag x, UploadedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, Parts: {Parts}, Md5Checksum: {Md5Checksum}, FileHash: {FileHash}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Parts, bw, WriteInt);
                Write(Md5Checksum, bw, WriteString);
                Write(FileHash, bw, WriteBytes);
                Write(Secret, bw, WriteBytes);
            }
            
            internal static UploadedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var parts = Read(br, ReadInt);
                var md5Checksum = Read(br, ReadString);
                var fileHash = Read(br, ReadBytes);
                var secret = Read(br, ReadBytes);
                return new UploadedTag(id, parts, md5Checksum, fileHash, secret);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x5367e5be;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            
            public Tag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            (long, long) CmpTuple =>
                (Id, AccessHash);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                return new Tag(id, accessHash);
            }
        }

        readonly ITlTypeTag _tag;
        InputSecureFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputSecureFile(UploadedTag tag) => new InputSecureFile(tag);
        public static explicit operator InputSecureFile(Tag tag) => new InputSecureFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputSecureFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case UploadedTag.TypeNumber: return (InputSecureFile) UploadedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (InputSecureFile) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UploadedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UploadedTag, T> uploadedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UploadedTag x when uploadedTag != null: return uploadedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UploadedTag, T> uploadedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            uploadedTag ?? throw new ArgumentNullException(nameof(uploadedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UploadedTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputSecureFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputSecureFile x && Equals(x);
        public static bool operator ==(InputSecureFile x, InputSecureFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputSecureFile x, InputSecureFile y) => !(x == y);

        public int CompareTo(InputSecureFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputSecureFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputSecureFile x, InputSecureFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputSecureFile x, InputSecureFile y) => x.CompareTo(y) < 0;
        public static bool operator >(InputSecureFile x, InputSecureFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputSecureFile x, InputSecureFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputSecureFile.{_tag.GetType().Name}{_tag}";
    }
}