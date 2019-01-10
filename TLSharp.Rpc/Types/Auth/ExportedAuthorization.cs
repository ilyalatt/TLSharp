using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Auth
{
    public sealed class ExportedAuthorization : ITlType, IEquatable<ExportedAuthorization>, IComparable<ExportedAuthorization>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xdf969c2d;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Id { get; }
            public Arr<byte> Bytes { get; }
            
            public Tag(
                int id,
                Some<Arr<byte>> bytes
            ) {
                Id = id;
                Bytes = bytes;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(Bytes, bw, WriteBytes);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var bytes = Read(br, ReadBytes);
                return new Tag(id, bytes);
            }
        }

        readonly ITlTypeTag _tag;
        ExportedAuthorization(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ExportedAuthorization(Tag tag) => new ExportedAuthorization(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ExportedAuthorization Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ExportedAuthorization) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(ExportedAuthorization other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ExportedAuthorization x && Equals(x);
        public static bool operator ==(ExportedAuthorization a, ExportedAuthorization b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ExportedAuthorization a, ExportedAuthorization b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ExportedAuthorization other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ExportedAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportedAuthorization a, ExportedAuthorization b) => a.CompareTo(b) <= 0;
        public static bool operator <(ExportedAuthorization a, ExportedAuthorization b) => a.CompareTo(b) < 0;
        public static bool operator >(ExportedAuthorization a, ExportedAuthorization b) => a.CompareTo(b) > 0;
        public static bool operator >=(ExportedAuthorization a, ExportedAuthorization b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}