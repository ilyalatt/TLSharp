using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class AuthorizationForm : ITlType, IEquatable<AuthorizationForm>, IComparable<AuthorizationForm>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xcb976d53;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool SelfieRequired;
            public readonly Arr<T.SecureValueType> RequiredTypes;
            public readonly Arr<T.SecureValue> Values;
            public readonly Arr<T.SecureValueError> Errors;
            public readonly Arr<T.User> Users;
            public readonly Option<string> PrivacyPolicyUrl;
            
            public Tag(
                bool selfieRequired,
                Some<Arr<T.SecureValueType>> requiredTypes,
                Some<Arr<T.SecureValue>> values,
                Some<Arr<T.SecureValueError>> errors,
                Some<Arr<T.User>> users,
                Option<string> privacyPolicyUrl
            ) {
                SelfieRequired = selfieRequired;
                RequiredTypes = requiredTypes;
                Values = values;
                Errors = errors;
                Users = users;
                PrivacyPolicyUrl = privacyPolicyUrl;
            }
            
            (bool, Arr<T.SecureValueType>, Arr<T.SecureValue>, Arr<T.SecureValueError>, Arr<T.User>, Option<string>) CmpTuple =>
                (SelfieRequired, RequiredTypes, Values, Errors, Users, PrivacyPolicyUrl);

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

            public override string ToString() => $"(SelfieRequired: {SelfieRequired}, RequiredTypes: {RequiredTypes}, Values: {Values}, Errors: {Errors}, Users: {Users}, PrivacyPolicyUrl: {PrivacyPolicyUrl})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, SelfieRequired) | MaskBit(0, PrivacyPolicyUrl), bw, WriteInt);
                Write(RequiredTypes, bw, WriteVector<T.SecureValueType>(WriteSerializable));
                Write(Values, bw, WriteVector<T.SecureValue>(WriteSerializable));
                Write(Errors, bw, WriteVector<T.SecureValueError>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
                Write(PrivacyPolicyUrl, bw, WriteOption<string>(WriteString));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var selfieRequired = Read(br, ReadOption(flags, 1));
                var requiredTypes = Read(br, ReadVector(T.SecureValueType.Deserialize));
                var values = Read(br, ReadVector(T.SecureValue.Deserialize));
                var errors = Read(br, ReadVector(T.SecureValueError.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                var privacyPolicyUrl = Read(br, ReadOption(flags, 0, ReadString));
                return new Tag(selfieRequired, requiredTypes, values, errors, users, privacyPolicyUrl);
            }
        }

        readonly ITlTypeTag _tag;
        AuthorizationForm(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator AuthorizationForm(Tag tag) => new AuthorizationForm(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static AuthorizationForm Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (AuthorizationForm) Tag.DeserializeTag(br);
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

        public bool Equals(AuthorizationForm other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is AuthorizationForm x && Equals(x);
        public static bool operator ==(AuthorizationForm x, AuthorizationForm y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AuthorizationForm x, AuthorizationForm y) => !(x == y);

        public int CompareTo(AuthorizationForm other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is AuthorizationForm x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AuthorizationForm x, AuthorizationForm y) => x.CompareTo(y) <= 0;
        public static bool operator <(AuthorizationForm x, AuthorizationForm y) => x.CompareTo(y) < 0;
        public static bool operator >(AuthorizationForm x, AuthorizationForm y) => x.CompareTo(y) > 0;
        public static bool operator >=(AuthorizationForm x, AuthorizationForm y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"AuthorizationForm.{_tag.GetType().Name}{_tag}";
    }
}