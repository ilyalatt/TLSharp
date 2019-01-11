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
            
            public readonly long VolumeId;
            public readonly int LocalId;
            public readonly long Secret;
            
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
            
            public readonly long Id;
            public readonly long AccessHash;
            
            public EncryptedTag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            (long, long) CmpTuple =>
                (Id, AccessHash);

            public bool Equals(EncryptedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EncryptedTag x && Equals(x);
            public static bool operator ==(EncryptedTag x, EncryptedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EncryptedTag x, EncryptedTag y) => !(x == y);

            public int CompareTo(EncryptedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Version;
            
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

            public bool Equals(DocumentTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DocumentTag x && Equals(x);
            public static bool operator ==(DocumentTag x, DocumentTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DocumentTag x, DocumentTag y) => !(x == y);

            public int CompareTo(DocumentTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
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

        public sealed class SecureTag : ITlTypeTag, IEquatable<SecureTag>, IComparable<SecureTag>, IComparable
        {
            internal const uint TypeNumber = 0xcbc7ee28;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            
            public SecureTag(
                long id,
                long accessHash
            ) {
                Id = id;
                AccessHash = accessHash;
            }
            
            (long, long) CmpTuple =>
                (Id, AccessHash);

            public bool Equals(SecureTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SecureTag x && Equals(x);
            public static bool operator ==(SecureTag x, SecureTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SecureTag x, SecureTag y) => !(x == y);

            public int CompareTo(SecureTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SecureTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SecureTag x, SecureTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SecureTag x, SecureTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SecureTag x, SecureTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SecureTag x, SecureTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
            }
            
            internal static SecureTag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                return new SecureTag(id, accessHash);
            }
        }

        public sealed class TakeoutTag : ITlTypeTag, IEquatable<TakeoutTag>, IComparable<TakeoutTag>, IComparable
        {
            internal const uint TypeNumber = 0x29be5899;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public TakeoutTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(TakeoutTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TakeoutTag x && Equals(x);
            public static bool operator ==(TakeoutTag x, TakeoutTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TakeoutTag x, TakeoutTag y) => !(x == y);

            public int CompareTo(TakeoutTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TakeoutTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TakeoutTag x, TakeoutTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TakeoutTag x, TakeoutTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TakeoutTag x, TakeoutTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TakeoutTag x, TakeoutTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static TakeoutTag DeserializeTag(BinaryReader br)
            {

                return new TakeoutTag();
            }
        }

        readonly ITlTypeTag _tag;
        InputFileLocation(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputFileLocation(Tag tag) => new InputFileLocation(tag);
        public static explicit operator InputFileLocation(EncryptedTag tag) => new InputFileLocation(tag);
        public static explicit operator InputFileLocation(DocumentTag tag) => new InputFileLocation(tag);
        public static explicit operator InputFileLocation(SecureTag tag) => new InputFileLocation(tag);
        public static explicit operator InputFileLocation(TakeoutTag tag) => new InputFileLocation(tag);

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
                case SecureTag.TypeNumber: return (InputFileLocation) SecureTag.DeserializeTag(br);
                case TakeoutTag.TypeNumber: return (InputFileLocation) TakeoutTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, EncryptedTag.TypeNumber, DocumentTag.TypeNumber, SecureTag.TypeNumber, TakeoutTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<EncryptedTag, T> encryptedTag = null,
            Func<DocumentTag, T> documentTag = null,
            Func<SecureTag, T> secureTag = null,
            Func<TakeoutTag, T> takeoutTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case EncryptedTag x when encryptedTag != null: return encryptedTag(x);
                case DocumentTag x when documentTag != null: return documentTag(x);
                case SecureTag x when secureTag != null: return secureTag(x);
                case TakeoutTag x when takeoutTag != null: return takeoutTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<EncryptedTag, T> encryptedTag,
            Func<DocumentTag, T> documentTag,
            Func<SecureTag, T> secureTag,
            Func<TakeoutTag, T> takeoutTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            encryptedTag ?? throw new ArgumentNullException(nameof(encryptedTag)),
            documentTag ?? throw new ArgumentNullException(nameof(documentTag)),
            secureTag ?? throw new ArgumentNullException(nameof(secureTag)),
            takeoutTag ?? throw new ArgumentNullException(nameof(takeoutTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case EncryptedTag _: return 1;
                case DocumentTag _: return 2;
                case SecureTag _: return 3;
                case TakeoutTag _: return 4;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputFileLocation other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is InputFileLocation x && Equals(x);
        public static bool operator ==(InputFileLocation x, InputFileLocation y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputFileLocation x, InputFileLocation y) => !(x == y);

        public int CompareTo(InputFileLocation other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is InputFileLocation x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) < 0;
        public static bool operator >(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputFileLocation x, InputFileLocation y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputFileLocation.{_tag.GetType().Name}{_tag}";
    }
}