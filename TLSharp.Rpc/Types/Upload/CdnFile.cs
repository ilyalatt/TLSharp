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
        public sealed class ReuploadNeededTag : ITlTypeTag, IEquatable<ReuploadNeededTag>, IComparable<ReuploadNeededTag>, IComparable
        {
            internal const uint TypeNumber = 0xeea8e46e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<byte> RequestToken;
            
            public ReuploadNeededTag(
                Some<Arr<byte>> requestToken
            ) {
                RequestToken = requestToken;
            }
            
            Arr<byte> CmpTuple =>
                RequestToken;

            public bool Equals(ReuploadNeededTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is ReuploadNeededTag x && Equals(x);
            public static bool operator ==(ReuploadNeededTag x, ReuploadNeededTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ReuploadNeededTag x, ReuploadNeededTag y) => !(x == y);

            public int CompareTo(ReuploadNeededTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is ReuploadNeededTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ReuploadNeededTag x, ReuploadNeededTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ReuploadNeededTag x, ReuploadNeededTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ReuploadNeededTag x, ReuploadNeededTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ReuploadNeededTag x, ReuploadNeededTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(RequestToken: {RequestToken})";
            
            
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

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xa99fca4f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<byte> Bytes;
            
            public Tag(
                Some<Arr<byte>> bytes
            ) {
                Bytes = bytes;
            }
            
            Arr<byte> CmpTuple =>
                Bytes;

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

            public override string ToString() => $"(Bytes: {Bytes})";
            
            
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
                case ReuploadNeededTag.TypeNumber: return (CdnFile) ReuploadNeededTag.DeserializeTag(br);
                case Tag.TypeNumber: return (CdnFile) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ReuploadNeededTag.TypeNumber, Tag.TypeNumber });
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

        public bool Equals(CdnFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is CdnFile x && Equals(x);
        public static bool operator ==(CdnFile x, CdnFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CdnFile x, CdnFile y) => !(x == y);

        public int CompareTo(CdnFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is CdnFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CdnFile x, CdnFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(CdnFile x, CdnFile y) => x.CompareTo(y) < 0;
        public static bool operator >(CdnFile x, CdnFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(CdnFile x, CdnFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"CdnFile.{_tag.GetType().Name}{_tag}";
    }
}