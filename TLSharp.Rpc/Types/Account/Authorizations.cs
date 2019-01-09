using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class Authorizations : ITlType, IEquatable<Authorizations>, IComparable<Authorizations>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1250abde;
            
            public Arr<T.Authorization> Authorizations { get; }
            
            public Tag(
                Some<Arr<T.Authorization>> authorizations
            ) {
                Authorizations = authorizations;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Authorizations, bw, WriteVector<T.Authorization>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var authorizations = Read(br, ReadVector(T.Authorization.Deserialize));
                return new Tag(authorizations);
            }
        }

        readonly ITlTypeTag _tag;
        Authorizations(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Authorizations(Tag tag) => new Authorizations(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Authorizations Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x1250abde: return (Authorizations) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x1250abde });
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

        public bool Equals(Authorizations other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Authorizations x && Equals(x);
        public static bool operator ==(Authorizations a, Authorizations b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Authorizations a, Authorizations b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Authorizations other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Authorizations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Authorizations a, Authorizations b) => a.CompareTo(b) <= 0;
        public static bool operator <(Authorizations a, Authorizations b) => a.CompareTo(b) < 0;
        public static bool operator >(Authorizations a, Authorizations b) => a.CompareTo(b) > 0;
        public static bool operator >=(Authorizations a, Authorizations b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}