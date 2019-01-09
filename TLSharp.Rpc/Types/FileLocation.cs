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
        public sealed class UnavailableTag : Record<UnavailableTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x7c596b46;
            
            public long VolumeId { get; }
            public int LocalId { get; }
            public long Secret { get; }
            
            public UnavailableTag(
                long volumeId,
                int localId,
                long secret
            ) {
                VolumeId = volumeId;
                LocalId = localId;
                Secret = secret;
            }
            
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

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x53d69076;
            
            public int DcId { get; }
            public long VolumeId { get; }
            public int LocalId { get; }
            public long Secret { get; }
            
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
                case 0x7c596b46: return (FileLocation) UnavailableTag.DeserializeTag(br);
                case 0x53d69076: return (FileLocation) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x7c596b46, 0x53d69076 });
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

        public bool Equals(FileLocation other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is FileLocation x && Equals(x);
        public static bool operator ==(FileLocation a, FileLocation b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(FileLocation a, FileLocation b) => !(a == b);

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

        public int CompareTo(FileLocation other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FileLocation x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FileLocation a, FileLocation b) => a.CompareTo(b) <= 0;
        public static bool operator <(FileLocation a, FileLocation b) => a.CompareTo(b) < 0;
        public static bool operator >(FileLocation a, FileLocation b) => a.CompareTo(b) > 0;
        public static bool operator >=(FileLocation a, FileLocation b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}