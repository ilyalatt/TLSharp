using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputFileLocation : ITlType, IEquatable<InputFileLocation>, IComparable<InputFileLocation>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x14637196;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long VolumeId { get; }
            public int LocalId { get; }
            public long Secret { get; }
            
            public Tag(
                long volumeId,
                int localId,
                long secret
            ) {
                VolumeId = volumeId;
                LocalId = localId;
                Secret = secret;
            }
            
            (long, int, long) CmpTuple =>
                (VolumeId, LocalId, Secret);

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

            public override string ToString() => $"(VolumeId: {VolumeId}, LocalId: {LocalId}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(VolumeId, bw, WriteLong);
                Write(LocalId, bw, WriteInt);
                Write(Secret, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var volumeId = Read(br, ReadLong);
                var localId = Read(br, ReadInt);
                var secret = Read(br, ReadLong);
                return new Tag(volumeId, localId, secret);
            }
        }

        public sealed class EncryptedTag : ITlTypeTag, IEquatable<EncryptedTag>, IComparable<EncryptedTag>, IComparable
        {
            internal const uint TypeNumber = 0xf5235d55;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            
            public EncryptedTag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            (long, long) CmpTuple =>
                (Id, AccessHash);

            public bool Equals(EncryptedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is EncryptedTag x && Equals(x);
            public static bool operator ==(EncryptedTag x, EncryptedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EncryptedTag x, EncryptedTag y) => !(x == y);

            public int CompareTo(EncryptedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is EncryptedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EncryptedTag x, EncryptedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EncryptedTag x, EncryptedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EncryptedTag x, EncryptedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EncryptedTag x, EncryptedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static EncryptedTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                return new EncryptedTag(id, accessHash);
            }
        }

        public sealed class DocumentTag : ITlTypeTag, IEquatable<DocumentTag>, IComparable<DocumentTag>, IComparable
        {
            internal const uint TypeNumber = 0x430f0724;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Version { get; }
            
            public DocumentTag(
                long id,
                long accessHash,
                int version
            ) {
                Id = id;
                AccessHash = accessHash;
                Version = version;
            }
            
            (long, long, int) CmpTuple =>
                (Id, AccessHash, Version);

            public bool Equals(DocumentTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DocumentTag x && Equals(x);
            public static bool operator ==(DocumentTag x, DocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentTag x, DocumentTag y) => !(x == y);

            public int CompareTo(DocumentTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DocumentTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DocumentTag x, DocumentTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DocumentTag x, DocumentTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DocumentTag x, DocumentTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DocumentTag x, DocumentTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Version: {Version})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Version, bw, WriteInt);
            }
            
            internal static DocumentTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var version = Read(br, ReadInt);
                return new DocumentTag(id, accessHash, version);
            }
        }

        readonly ITlTypeTag _tag;
        InputFileLocation(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputFileLocation(Tag tag) => new InputFileLocation(tag);
        public static explicit operator InputFileLocation(EncryptedTag tag) => new InputFileLocation(tag);
        public static explicit operator InputFileLocation(DocumentTag tag) => new InputFileLocation(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputFileLocation Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputFileLocation) Tag.DeserializeTag(br);
                case EncryptedTag.TypeNumber: return (InputFileLocation) EncryptedTag.DeserializeTag(br);
                case DocumentTag.TypeNumber: return (InputFileLocation) DocumentTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, EncryptedTag.TypeNumber, DocumentTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<EncryptedTag, T> encryptedTag = null,
            Func<DocumentTag, T> documentTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case EncryptedTag x when encryptedTag != null: return encryptedTag(x);
                case DocumentTag x when documentTag != null: return documentTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<EncryptedTag, T> encryptedTag,
            Func<DocumentTag, T> documentTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            encryptedTag ?? throw new ArgumentNullException(nameof(encryptedTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case EncryptedTag _: return 1;
                case DocumentTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputFileLocation other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputFileLocation x && Equals(x);
        public static bool operator ==(InputFileLocation x, InputFileLocation y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputFileLocation x, InputFileLocation y) => !(x == y);

        public int CompareTo(InputFileLocation other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputFileLocation x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) < 0;
        public static bool operator >(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputFileLocation.{_tag.GetType().Name}{_tag}";
    }
}