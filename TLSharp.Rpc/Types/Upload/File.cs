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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x096a18d5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (T.Storage.FileType, int, Arr<byte>) CmpTuple =>
                (Type, Mtime, Bytes);

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

            public override string ToString() => $"(Type: {Type}, Mtime: {Mtime}, Bytes: {Bytes})";
            
            
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

        public sealed class CdnRedirectTag : ITlTypeTag, IEquatable<CdnRedirectTag>, IComparable<CdnRedirectTag>, IComparable
        {
            internal const uint TypeNumber = 0x1508485a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (int, Arr<byte>, Arr<byte>, Arr<byte>) CmpTuple =>
                (DcId, FileToken, EncryptionKey, EncryptionIv);

            public bool Equals(CdnRedirectTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CdnRedirectTag x && Equals(x);
            public static bool operator ==(CdnRedirectTag x, CdnRedirectTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CdnRedirectTag x, CdnRedirectTag y) => !(x == y);

            public int CompareTo(CdnRedirectTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is CdnRedirectTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CdnRedirectTag x, CdnRedirectTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CdnRedirectTag x, CdnRedirectTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CdnRedirectTag x, CdnRedirectTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CdnRedirectTag x, CdnRedirectTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(DcId: {DcId}, FileToken: {FileToken}, EncryptionKey: {EncryptionKey}, EncryptionIv: {EncryptionIv})";
            
            
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
                case Tag.TypeNumber: return (File) Tag.DeserializeTag(br);
                case CdnRedirectTag.TypeNumber: return (File) CdnRedirectTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, CdnRedirectTag.TypeNumber });
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

        public bool Equals(File other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is File x && Equals(x);
        public static bool operator ==(File x, File y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(File x, File y) => !(x == y);

        public int CompareTo(File other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is File x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(File x, File y) => x.CompareTo(y) <= 0;
        public static bool operator <(File x, File y) => x.CompareTo(y) < 0;
        public static bool operator >(File x, File y) => x.CompareTo(y) > 0;
        public static bool operator >=(File x, File y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"File.{_tag.GetType().Name}{_tag}";
    }
}