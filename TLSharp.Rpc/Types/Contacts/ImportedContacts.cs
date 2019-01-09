using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Contacts
{
    public sealed class ImportedContacts : ITlType, IEquatable<ImportedContacts>, IComparable<ImportedContacts>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xad524315;
            
            public Arr<T.ImportedContact> Imported { get; }
            public Arr<long> RetryContacts { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.ImportedContact>> imported,
                Some<Arr<long>> retryContacts,
                Some<Arr<T.User>> users
            ) {
                Imported = imported;
                RetryContacts = retryContacts;
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Imported, bw, WriteVector<T.ImportedContact>(WriteSerializable));
                Write(RetryContacts, bw, WriteVector<long>(WriteLong));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var imported = Read(br, ReadVector(T.ImportedContact.Deserialize));
                var retryContacts = Read(br, ReadVector(ReadLong));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(imported, retryContacts, users);
            }
        }

        readonly ITlTypeTag _tag;
        ImportedContacts(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ImportedContacts(Tag tag) => new ImportedContacts(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ImportedContacts Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xad524315: return (ImportedContacts) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xad524315 });
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

        public bool Equals(ImportedContacts other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ImportedContacts x && Equals(x);
        public static bool operator ==(ImportedContacts a, ImportedContacts b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ImportedContacts a, ImportedContacts b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ImportedContacts other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ImportedContacts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportedContacts a, ImportedContacts b) => a.CompareTo(b) <= 0;
        public static bool operator <(ImportedContacts a, ImportedContacts b) => a.CompareTo(b) < 0;
        public static bool operator >(ImportedContacts a, ImportedContacts b) => a.CompareTo(b) > 0;
        public static bool operator >=(ImportedContacts a, ImportedContacts b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}