using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Upload
{
    public sealed class CdnFile : ITlType, IEquatable<CdnFile>, IComparable<CdnFile>, IComparable
    {
        public sealed class ReuploadNeededTag : Record<ReuploadNeededTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xeea8e46e;
            
            public Arr<byte> RequestToken { get; }
            
            public ReuploadNeededTag(
                Some<Arr<byte>> requestToken
            ) {
                RequestToken = requestToken;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(RequestToken, bw, WriteBytes);
            }
            
            internal static ReuploadNeededTag DeserializeTag(BinaryReader br)
            {
                var requestToken = Read(br, ReadBytes);
                return new ReuploadNeededTag(requestToken);
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa99fca4f;
            
            public Arr<byte> Bytes { get; }
            
            public Tag(
                Some<Arr<byte>> bytes
            ) {
                Bytes = bytes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Bytes, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var bytes = Read(br, ReadBytes);
                return new Tag(bytes);
            }
        }

        readonly ITlTypeTag _tag;
        CdnFile(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator CdnFile(ReuploadNeededTag tag) => new CdnFile(tag);
        public static explicit operator CdnFile(Tag tag) => new CdnFile(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static CdnFile Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xeea8e46e: return (CdnFile) ReuploadNeededTag.DeserializeTag(br);
                case 0xa99fca4f: return (CdnFile) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xeea8e46e, 0xa99fca4f });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<ReuploadNeededTag, T> reuploadNeededTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case ReuploadNeededTag x when reuploadNeededTag != null: return reuploadNeededTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<ReuploadNeededTag, T> reuploadNeededTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            reuploadNeededTag ?? throw new ArgumentNullException(nameof(reuploadNeededTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(CdnFile other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is CdnFile x && Equals(x);
        public static bool operator ==(CdnFile a, CdnFile b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(CdnFile a, CdnFile b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case ReuploadNeededTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(CdnFile other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CdnFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CdnFile a, CdnFile b) => a.CompareTo(b) <= 0;
        public static bool operator <(CdnFile a, CdnFile b) => a.CompareTo(b) < 0;
        public static bool operator >(CdnFile a, CdnFile b) => a.CompareTo(b) > 0;
        public static bool operator >=(CdnFile a, CdnFile b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}