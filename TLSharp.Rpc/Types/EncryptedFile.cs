using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class EncryptedFile : ITlType, IEquatable<EncryptedFile>, IComparable<EncryptedFile>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xc21f497e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
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

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x4a70994c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long Id { get; }
            public long AccessHash { get; }
            public int Size { get; }
            public int DcId { get; }
            public int KeyFingerprint { get; }
            
            public Tag(
                long id,
                long accessHash,
                int size,
                int dcId,
                int keyFingerprint
            ) {
                Id = id;
                AccessHash = accessHash;
                Size = size;
                DcId = dcId;
                KeyFingerprint = keyFingerprint;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Size, bw, WriteInt);
                Write(DcId, bw, WriteInt);
                Write(KeyFingerprint, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var size = Read(br, ReadInt);
                var dcId = Read(br, ReadInt);
                var keyFingerprint = Read(br, ReadInt);
                return new Tag(id, accessHash, size, dcId, keyFingerprint);
            }
        }

        readonly ITlTypeTag _tag;
        EncryptedFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator EncryptedFile(EmptyTag tag) => new EncryptedFile(tag);
        public static explicit operator EncryptedFile(Tag tag) => new EncryptedFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static EncryptedFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (EncryptedFile) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (EncryptedFile) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(EncryptedFile other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is EncryptedFile x && Equals(x);
        public static bool operator ==(EncryptedFile a, EncryptedFile b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(EncryptedFile a, EncryptedFile b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(EncryptedFile other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EncryptedFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EncryptedFile a, EncryptedFile b) => a.CompareTo(b) <= 0;
        public static bool operator <(EncryptedFile a, EncryptedFile b) => a.CompareTo(b) < 0;
        public static bool operator >(EncryptedFile a, EncryptedFile b) => a.CompareTo(b) > 0;
        public static bool operator >=(EncryptedFile a, EncryptedFile b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}