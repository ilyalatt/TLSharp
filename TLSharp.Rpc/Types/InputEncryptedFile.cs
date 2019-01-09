using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputEncryptedFile : ITlType, IEquatable<InputEncryptedFile>, IComparable<InputEncryptedFile>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1837c364;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class UploadedTag : Record<UploadedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x64bd0306;
            
            public long Id { get; }
            public int Parts { get; }
            public string Md5Checksum { get; }
            public int KeyFingerprint { get; }
            
            public UploadedTag(
                long id,
                int parts,
                Some<string> md5Checksum,
                int keyFingerprint
            ) {
                Id = id;
                Parts = parts;
                Md5Checksum = md5Checksum;
                KeyFingerprint = keyFingerprint;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Parts, bw, WriteInt);
                Write(Md5Checksum, bw, WriteString);
                Write(KeyFingerprint, bw, WriteInt);
            }
            
            internal static UploadedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var parts = Read(br, ReadInt);
                var md5Checksum = Read(br, ReadString);
                var keyFingerprint = Read(br, ReadInt);
                return new UploadedTag(id, parts, md5Checksum, keyFingerprint);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x5a17b5e5;
            
            public long Id { get; }
            public long AccessHash { get; }
            
            public Tag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
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

        public sealed class BigUploadedTag : Record<BigUploadedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x2dc173c8;
            
            public long Id { get; }
            public int Parts { get; }
            public int KeyFingerprint { get; }
            
            public BigUploadedTag(
                long id,
                int parts,
                int keyFingerprint
            ) {
                Id = id;
                Parts = parts;
                KeyFingerprint = keyFingerprint;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(Parts, bw, WriteInt);
                Write(KeyFingerprint, bw, WriteInt);
            }
            
            internal static BigUploadedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var parts = Read(br, ReadInt);
                var keyFingerprint = Read(br, ReadInt);
                return new BigUploadedTag(id, parts, keyFingerprint);
            }
        }

        readonly ITlTypeTag _tag;
        InputEncryptedFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputEncryptedFile(EmptyTag tag) => new InputEncryptedFile(tag);
        public static explicit operator InputEncryptedFile(UploadedTag tag) => new InputEncryptedFile(tag);
        public static explicit operator InputEncryptedFile(Tag tag) => new InputEncryptedFile(tag);
        public static explicit operator InputEncryptedFile(BigUploadedTag tag) => new InputEncryptedFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputEncryptedFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x1837c364: return (InputEncryptedFile) EmptyTag.DeserializeTag(br);
                case 0x64bd0306: return (InputEncryptedFile) UploadedTag.DeserializeTag(br);
                case 0x5a17b5e5: return (InputEncryptedFile) Tag.DeserializeTag(br);
                case 0x2dc173c8: return (InputEncryptedFile) BigUploadedTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x1837c364, 0x64bd0306, 0x5a17b5e5, 0x2dc173c8 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<UploadedTag, T> uploadedTag = null,
            Func<Tag, T> tag = null,
            Func<BigUploadedTag, T> bigUploadedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case UploadedTag x when uploadedTag != null: return uploadedTag(x);
                case Tag x when tag != null: return tag(x);
                case BigUploadedTag x when bigUploadedTag != null: return bigUploadedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<UploadedTag, T> uploadedTag,
            Func<Tag, T> tag,
            Func<BigUploadedTag, T> bigUploadedTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            uploadedTag ?? throw new ArgumentNullException(nameof(uploadedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            bigUploadedTag ?? throw new ArgumentNullException(nameof(bigUploadedTag))
        );

        public bool Equals(InputEncryptedFile other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputEncryptedFile x && Equals(x);
        public static bool operator ==(InputEncryptedFile a, InputEncryptedFile b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputEncryptedFile a, InputEncryptedFile b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case UploadedTag _: return 1;
                case Tag _: return 2;
                case BigUploadedTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputEncryptedFile other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputEncryptedFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputEncryptedFile a, InputEncryptedFile b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputEncryptedFile a, InputEncryptedFile b) => a.CompareTo(b) < 0;
        public static bool operator >(InputEncryptedFile a, InputEncryptedFile b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputEncryptedFile a, InputEncryptedFile b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}