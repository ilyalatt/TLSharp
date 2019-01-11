using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SecureFile : ITlType, IEquatable<SecureFile>, IComparable<SecureFile>, IComparable
    {
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0x64199744;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xe0277a62;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long Id;
            public readonly long AccessHash;
            public readonly int Size;
            public readonly int DcId;
            public readonly int Date;
            public readonly Arr<byte> FileHash;
            public readonly Arr<byte> Secret;
            
            public Tag(
                long id,
                long accessHash,
                int size,
                int dcId,
                int date,
                Some<Arr<byte>> fileHash,
                Some<Arr<byte>> secret
            ) {
                Id = id;
                AccessHash = accessHash;
                Size = size;
                DcId = dcId;
                Date = date;
                FileHash = fileHash;
                Secret = secret;
            }
            
            (long, long, int, int, int, Arr<byte>, Arr<byte>) CmpTuple =>
                (Id, AccessHash, Size, DcId, Date, FileHash, Secret);

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

            public override string ToString() => $"(Id: {Id}, AccessHash: {AccessHash}, Size: {Size}, DcId: {DcId}, Date: {Date}, FileHash: {FileHash}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteLong);
                Write(AccessHash, bw, WriteLong);
                Write(Size, bw, WriteInt);
                Write(DcId, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(FileHash, bw, WriteBytes);
                Write(Secret, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadLong);
                var accessHash = Read(br, ReadLong);
                var size = Read(br, ReadInt);
                var dcId = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var fileHash = Read(br, ReadBytes);
                var secret = Read(br, ReadBytes);
                return new Tag(id, accessHash, size, dcId, date, fileHash, secret);
            }
        }

        readonly ITlTypeTag _tag;
        SecureFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SecureFile(EmptyTag tag) => new SecureFile(tag);
        public static explicit operator SecureFile(Tag tag) => new SecureFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SecureFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case EmptyTag.TypeNumber: return (SecureFile) EmptyTag.DeserializeTag(br);
                case Tag.TypeNumber: return (SecureFile) Tag.DeserializeTag(br);
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

        public bool Equals(SecureFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is SecureFile x && Equals(x);
        public static bool operator ==(SecureFile x, SecureFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SecureFile x, SecureFile y) => !(x == y);

        public int CompareTo(SecureFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is SecureFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SecureFile x, SecureFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(SecureFile x, SecureFile y) => x.CompareTo(y) < 0;
        public static bool operator >(SecureFile x, SecureFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(SecureFile x, SecureFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SecureFile.{_tag.GetType().Name}{_tag}";
    }
}