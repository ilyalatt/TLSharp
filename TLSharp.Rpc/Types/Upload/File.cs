using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Upload
{
    public sealed class File : ITlType, IEquatable<File>, IComparable<File>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x096a18d5;
            
            public T.Storage.FileType Type { get; }
            public int Mtime { get; }
            public Arr<byte> Bytes { get; }
            
            public Tag(
                Some<T.Storage.FileType> type,
                int mtime,
                Some<Arr<byte>> bytes
            ) {
                Type = type;
                Mtime = mtime;
                Bytes = bytes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Type, bw, WriteSerializable);
                Write(Mtime, bw, WriteInt);
                Write(Bytes, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var type = Read(br, T.Storage.FileType.Deserialize);
                var mtime = Read(br, ReadInt);
                var bytes = Read(br, ReadBytes);
                return new Tag(type, mtime, bytes);
            }
        }

        public sealed class CdnRedirectTag : Record<CdnRedirectTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1508485a;
            
            public int DcId { get; }
            public Arr<byte> FileToken { get; }
            public Arr<byte> EncryptionKey { get; }
            public Arr<byte> EncryptionIv { get; }
            
            public CdnRedirectTag(
                int dcId,
                Some<Arr<byte>> fileToken,
                Some<Arr<byte>> encryptionKey,
                Some<Arr<byte>> encryptionIv
            ) {
                DcId = dcId;
                FileToken = fileToken;
                EncryptionKey = encryptionKey;
                EncryptionIv = encryptionIv;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(DcId, bw, WriteInt);
                Write(FileToken, bw, WriteBytes);
                Write(EncryptionKey, bw, WriteBytes);
                Write(EncryptionIv, bw, WriteBytes);
            }
            
            internal static CdnRedirectTag DeserializeTag(BinaryReader br)
            {
                var dcId = Read(br, ReadInt);
                var fileToken = Read(br, ReadBytes);
                var encryptionKey = Read(br, ReadBytes);
                var encryptionIv = Read(br, ReadBytes);
                return new CdnRedirectTag(dcId, fileToken, encryptionKey, encryptionIv);
            }
        }

        readonly ITlTypeTag _tag;
        File(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator File(Tag tag) => new File(tag);
        public static explicit operator File(CdnRedirectTag tag) => new File(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static File Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x096a18d5: return (File) Tag.DeserializeTag(br);
                case 0x1508485a: return (File) CdnRedirectTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x096a18d5, 0x1508485a });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<CdnRedirectTag, T> cdnRedirectTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case CdnRedirectTag x when cdnRedirectTag != null: return cdnRedirectTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<CdnRedirectTag, T> cdnRedirectTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            cdnRedirectTag ?? throw new ArgumentNullException(nameof(cdnRedirectTag))
        );

        public bool Equals(File other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is File x && Equals(x);
        public static bool operator ==(File a, File b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(File a, File b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case CdnRedirectTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(File other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is File x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(File a, File b) => a.CompareTo(b) <= 0;
        public static bool operator <(File a, File b) => a.CompareTo(b) < 0;
        public static bool operator >(File a, File b) => a.CompareTo(b) > 0;
        public static bool operator >=(File a, File b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}