using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputPrivacyRule : ITlType, IEquatable<InputPrivacyRule>, IComparable<InputPrivacyRule>, IComparable
    {
        public sealed class ValueAllowContactsTag : Record<ValueAllowContactsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x0d09e07b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueAllowContactsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueAllowContactsTag DeserializeTag(BinaryReader br)
            {

                return new ValueAllowContactsTag();
            }
        }

        public sealed class ValueAllowAllTag : Record<ValueAllowAllTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x184b35ce;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueAllowAllTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueAllowAllTag DeserializeTag(BinaryReader br)
            {

                return new ValueAllowAllTag();
            }
        }

        public sealed class ValueAllowUsersTag : Record<ValueAllowUsersTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x131cc67f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.InputUser> Users { get; }
            
            public ValueAllowUsersTag(
                Some<Arr<T.InputUser>> users
            ) {
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Users, bw, WriteVector<T.InputUser>(WriteSerializable));
            }
            
            internal static ValueAllowUsersTag DeserializeTag(BinaryReader br)
            {
                var users = Read(br, ReadVector(T.InputUser.Deserialize));
                return new ValueAllowUsersTag(users);
            }
        }

        public sealed class ValueDisallowContactsTag : Record<ValueDisallowContactsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x0ba52007;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueDisallowContactsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueDisallowContactsTag DeserializeTag(BinaryReader br)
            {

                return new ValueDisallowContactsTag();
            }
        }

        public sealed class ValueDisallowAllTag : Record<ValueDisallowAllTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xd66b66c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueDisallowAllTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueDisallowAllTag DeserializeTag(BinaryReader br)
            {

                return new ValueDisallowAllTag();
            }
        }

        public sealed class ValueDisallowUsersTag : Record<ValueDisallowUsersTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x90110467;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.InputUser> Users { get; }
            
            public ValueDisallowUsersTag(
                Some<Arr<T.InputUser>> users
            ) {
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Users, bw, WriteVector<T.InputUser>(WriteSerializable));
            }
            
            internal static ValueDisallowUsersTag DeserializeTag(BinaryReader br)
            {
                var users = Read(br, ReadVector(T.InputUser.Deserialize));
                return new ValueDisallowUsersTag(users);
            }
        }

        readonly ITlTypeTag _tag;
        InputPrivacyRule(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPrivacyRule(ValueAllowContactsTag tag) => new InputPrivacyRule(tag);
        public static explicit operator InputPrivacyRule(ValueAllowAllTag tag) => new InputPrivacyRule(tag);
        public static explicit operator InputPrivacyRule(ValueAllowUsersTag tag) => new InputPrivacyRule(tag);
        public static explicit operator InputPrivacyRule(ValueDisallowContactsTag tag) => new InputPrivacyRule(tag);
        public static explicit operator InputPrivacyRule(ValueDisallowAllTag tag) => new InputPrivacyRule(tag);
        public static explicit operator InputPrivacyRule(ValueDisallowUsersTag tag) => new InputPrivacyRule(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputPrivacyRule Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case ValueAllowContactsTag.TypeNumber: return (InputPrivacyRule) ValueAllowContactsTag.DeserializeTag(br);
                case ValueAllowAllTag.TypeNumber: return (InputPrivacyRule) ValueAllowAllTag.DeserializeTag(br);
                case ValueAllowUsersTag.TypeNumber: return (InputPrivacyRule) ValueAllowUsersTag.DeserializeTag(br);
                case ValueDisallowContactsTag.TypeNumber: return (InputPrivacyRule) ValueDisallowContactsTag.DeserializeTag(br);
                case ValueDisallowAllTag.TypeNumber: return (InputPrivacyRule) ValueDisallowAllTag.DeserializeTag(br);
                case ValueDisallowUsersTag.TypeNumber: return (InputPrivacyRule) ValueDisallowUsersTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { ValueAllowContactsTag.TypeNumber, ValueAllowAllTag.TypeNumber, ValueAllowUsersTag.TypeNumber, ValueDisallowContactsTag.TypeNumber, ValueDisallowAllTag.TypeNumber, ValueDisallowUsersTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<ValueAllowContactsTag, T> valueAllowContactsTag = null,
            Func<ValueAllowAllTag, T> valueAllowAllTag = null,
            Func<ValueAllowUsersTag, T> valueAllowUsersTag = null,
            Func<ValueDisallowContactsTag, T> valueDisallowContactsTag = null,
            Func<ValueDisallowAllTag, T> valueDisallowAllTag = null,
            Func<ValueDisallowUsersTag, T> valueDisallowUsersTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case ValueAllowContactsTag x when valueAllowContactsTag != null: return valueAllowContactsTag(x);
                case ValueAllowAllTag x when valueAllowAllTag != null: return valueAllowAllTag(x);
                case ValueAllowUsersTag x when valueAllowUsersTag != null: return valueAllowUsersTag(x);
                case ValueDisallowContactsTag x when valueDisallowContactsTag != null: return valueDisallowContactsTag(x);
                case ValueDisallowAllTag x when valueDisallowAllTag != null: return valueDisallowAllTag(x);
                case ValueDisallowUsersTag x when valueDisallowUsersTag != null: return valueDisallowUsersTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<ValueAllowContactsTag, T> valueAllowContactsTag,
            Func<ValueAllowAllTag, T> valueAllowAllTag,
            Func<ValueAllowUsersTag, T> valueAllowUsersTag,
            Func<ValueDisallowContactsTag, T> valueDisallowContactsTag,
            Func<ValueDisallowAllTag, T> valueDisallowAllTag,
            Func<ValueDisallowUsersTag, T> valueDisallowUsersTag
        ) => Match(
            () => throw new Exception("WTF"),
            valueAllowContactsTag ?? throw new ArgumentNullException(nameof(valueAllowContactsTag)),
            valueAllowAllTag ?? throw new ArgumentNullException(nameof(valueAllowAllTag)),
            valueAllowUsersTag ?? throw new ArgumentNullException(nameof(valueAllowUsersTag)),
            valueDisallowContactsTag ?? throw new ArgumentNullException(nameof(valueDisallowContactsTag)),
            valueDisallowAllTag ?? throw new ArgumentNullException(nameof(valueDisallowAllTag)),
            valueDisallowUsersTag ?? throw new ArgumentNullException(nameof(valueDisallowUsersTag))
        );

        public bool Equals(InputPrivacyRule other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputPrivacyRule x && Equals(x);
        public static bool operator ==(InputPrivacyRule a, InputPrivacyRule b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputPrivacyRule a, InputPrivacyRule b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case ValueAllowContactsTag _: return 0;
                case ValueAllowAllTag _: return 1;
                case ValueAllowUsersTag _: return 2;
                case ValueDisallowContactsTag _: return 3;
                case ValueDisallowAllTag _: return 4;
                case ValueDisallowUsersTag _: return 5;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputPrivacyRule other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPrivacyRule x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPrivacyRule a, InputPrivacyRule b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputPrivacyRule a, InputPrivacyRule b) => a.CompareTo(b) < 0;
        public static bool operator >(InputPrivacyRule a, InputPrivacyRule b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputPrivacyRule a, InputPrivacyRule b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}