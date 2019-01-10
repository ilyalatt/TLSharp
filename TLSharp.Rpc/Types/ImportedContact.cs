using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ImportedContact : ITlType, IEquatable<ImportedContact>, IComparable<ImportedContact>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd0028438;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int UserId { get; }
            public long ClientId { get; }
            
            public Tag(
                int userId,
                long clientId
            ) {
                UserId = userId;
                ClientId = clientId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(UserId, bw, WriteInt);
                Write(ClientId, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var userId = Read(br, ReadInt);
                var clientId = Read(br, ReadLong);
                return new Tag(userId, clientId);
            }
        }

        readonly ITlTypeTag _tag;
        ImportedContact(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ImportedContact(Tag tag) => new ImportedContact(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ImportedContact Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ImportedContact) Tag.DeserializeTag(br);
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

        public bool Equals(ImportedContact other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ImportedContact x && Equals(x);
        public static bool operator ==(ImportedContact a, ImportedContact b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ImportedContact a, ImportedContact b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ImportedContact other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ImportedContact x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportedContact a, ImportedContact b) => a.CompareTo(b) <= 0;
        public static bool operator <(ImportedContact a, ImportedContact b) => a.CompareTo(b) < 0;
        public static bool operator >(ImportedContact a, ImportedContact b) => a.CompareTo(b) > 0;
        public static bool operator >=(ImportedContact a, ImportedContact b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}