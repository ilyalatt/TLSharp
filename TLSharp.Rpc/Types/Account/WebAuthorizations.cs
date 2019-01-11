using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class WebAuthorizations : ITlType, IEquatable<WebAuthorizations>, IComparable<WebAuthorizations>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xed56c9fc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.WebAuthorization> Authorizations;
            public readonly Arr<T.User> Users;
            
            public Tag(
                Some<Arr<T.WebAuthorization>> authorizations,
                Some<Arr<T.User>> users
            ) {
                Authorizations = authorizations;
                Users = users;
            }
            
            (Arr<T.WebAuthorization>, Arr<T.User>) CmpTuple =>
                (Authorizations, Users);

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

            public override string ToString() => $"(Authorizations: {Authorizations}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Authorizations, bw, WriteVector<T.WebAuthorization>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var authorizations = Read(br, ReadVector(T.WebAuthorization.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(authorizations, users);
            }
        }

        readonly ITlTypeTag _tag;
        WebAuthorizations(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator WebAuthorizations(Tag tag) => new WebAuthorizations(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static WebAuthorizations Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (WebAuthorizations) Tag.DeserializeTag(br);
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(WebAuthorizations other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is WebAuthorizations x && Equals(x);
        public static bool operator ==(WebAuthorizations x, WebAuthorizations y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(WebAuthorizations x, WebAuthorizations y) => !(x == y);

        public int CompareTo(WebAuthorizations other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is WebAuthorizations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(WebAuthorizations x, WebAuthorizations y) => x.CompareTo(y) <= 0;
        public static bool operator <(WebAuthorizations x, WebAuthorizations y) => x.CompareTo(y) < 0;
        public static bool operator >(WebAuthorizations x, WebAuthorizations y) => x.CompareTo(y) > 0;
        public static bool operator >=(WebAuthorizations x, WebAuthorizations y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"WebAuthorizations.{_tag.GetType().Name}{_tag}";
    }
}