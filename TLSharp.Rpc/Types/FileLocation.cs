using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class FileLocation : ITlType, IEquatable<FileLocation>, IComparable<FileLocation>, IComparable
    {
        public sealed class UnavailableTag : ITlTypeTag, IEquatable<UnavailableTag>, IComparable<UnavailableTag>, IComparable
        {
            internal const uint TypeNumber = 0x7c596b46;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long VolumeId;
            public readonly int LocalId;
            public readonly long Secret;
            
            public UnavailableTag(
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

            public bool Equals(UnavailableTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is UnavailableTag x && Equals(x);
            public static bool operator ==(UnavailableTag x, UnavailableTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(UnavailableTag x, UnavailableTag y) => !(x == y);

            public int CompareTo(UnavailableTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is UnavailableTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(UnavailableTag x, UnavailableTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(UnavailableTag x, UnavailableTag y) => x.CompareTo(y) < 0;
            public static bool operator >(UnavailableTag x, UnavailableTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(UnavailableTag x, UnavailableTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(VolumeId: {VolumeId}, LocalId: {LocalId}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(VolumeId, bw, WriteLong);
                Write(LocalId, bw, WriteInt);
                Write(Secret, bw, WriteLong);
            }
            
            internal static UnavailableTag DeserializeTag(BinaryReader br)
            {
                var volumeId = Read(br, ReadLong);
                var localId = Read(br, ReadInt);
                var secret = Read(br, ReadLong);
                return new UnavailableTag(volumeId, localId, secret);
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x53d69076;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int DcId;
            public readonly long VolumeId;
            public readonly int LocalId;
            public readonly long Secret;
            
            public Tag(
                int dcId,
                long volumeId,
                int localId,
                long secret
            ) {
                DcId = dcId;
                VolumeId = volumeId;
                LocalId = localId;
                Secret = secret;
            }
            
            (int, long, int, long) CmpTuple =>
                (DcId, VolumeId, LocalId, Secret);

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

            public override string ToString() => $"(DcId: {DcId}, VolumeId: {VolumeId}, LocalId: {LocalId}, Secret: {Secret})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(DcId, bw, WriteInt);
                Write(VolumeId, bw, WriteLong);
                Write(LocalId, bw, WriteInt);
                Write(Secret, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var dcId = Read(br, ReadInt);
                var volumeId = Read(br, ReadLong);
                var localId = Read(br, ReadInt);
                var secret = Read(br, ReadLong);
                return new Tag(dcId, volumeId, localId, secret);
            }
        }

        readonly ITlTypeTag _tag;
        FileLocation(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FileLocation(UnavailableTag tag) => new FileLocation(tag);
        public static explicit operator FileLocation(Tag tag) => new FileLocation(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FileLocation Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case UnavailableTag.TypeNumber: return (FileLocation) UnavailableTag.DeserializeTag(br);
                case Tag.TypeNumber: return (FileLocation) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { UnavailableTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<UnavailableTag, T> unavailableTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case UnavailableTag x when unavailableTag != null: return unavailableTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<UnavailableTag, T> unavailableTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            unavailableTag ?? throw new ArgumentNullException(nameof(unavailableTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case UnavailableTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(FileLocation other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is FileLocation x && Equals(x);
        public static bool operator ==(FileLocation x, FileLocation y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FileLocation x, FileLocation y) => !(x == y);

        public int CompareTo(FileLocation other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is FileLocation x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FileLocation x, FileLocation y) => x.CompareTo(y) <= 0;
        public static bool operator <(FileLocation x, FileLocation y) => x.CompareTo(y) < 0;
        public static bool operator >(FileLocation x, FileLocation y) => x.CompareTo(y) > 0;
        public static bool operator >=(FileLocation x, FileLocation y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FileLocation.{_tag.GetType().Name}{_tag}";
    }
}