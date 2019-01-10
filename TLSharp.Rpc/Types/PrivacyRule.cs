using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PrivacyRule : ITlType, IEquatable<PrivacyRule>, IComparable<PrivacyRule>, IComparable
    {
        public sealed class ValueAllowContactsTag : Record<ValueAllowContactsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xfffe1bac;
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
            internal const uint TypeNumber = 0x65427b82;
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
            internal const uint TypeNumber = 0x4d5bbe0c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Users { get; }
            
            public ValueAllowUsersTag(
                Some<Arr<int>> users
            ) {
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Users, bw, WriteVector<int>(WriteInt));
            }
            
            internal static ValueAllowUsersTag DeserializeTag(BinaryReader br)
            {
                var users = Read(br, ReadVector(ReadInt));
                return new ValueAllowUsersTag(users);
            }
        }

        public sealed class ValueDisallowContactsTag : Record<ValueDisallowContactsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf888fa1a;
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
            internal const uint TypeNumber = 0x8b73e763;
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
            internal const uint TypeNumber = 0x0c7f49b7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Users { get; }
            
            public ValueDisallowUsersTag(
                Some<Arr<int>> users
            ) {
                Users = users;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Users, bw, WriteVector<int>(WriteInt));
            }
            
            internal static ValueDisallowUsersTag DeserializeTag(BinaryReader br)
            {
                var users = Read(br, ReadVector(ReadInt));
                return new ValueDisallowUsersTag(users);
            }
        }

        readonly ITlTypeTag _tag;
        PrivacyRule(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PrivacyRule(ValueAllowContactsTag tag) => new PrivacyRule(tag);
        public static explicit operator PrivacyRule(ValueAllowAllTag tag) => new PrivacyRule(tag);
        public static explicit operator PrivacyRule(ValueAllowUsersTag tag) => new PrivacyRule(tag);
        public static explicit operator PrivacyRule(ValueDisallowContactsTag tag) => new PrivacyRule(tag);
        public static explicit operator PrivacyRule(ValueDisallowAllTag tag) => new PrivacyRule(tag);
        public static explicit operator PrivacyRule(ValueDisallowUsersTag tag) => new PrivacyRule(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PrivacyRule Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case ValueAllowContactsTag.TypeNumber: return (PrivacyRule) ValueAllowContactsTag.DeserializeTag(br);
                case ValueAllowAllTag.TypeNumber: return (PrivacyRule) ValueAllowAllTag.DeserializeTag(br);
                case ValueAllowUsersTag.TypeNumber: return (PrivacyRule) ValueAllowUsersTag.DeserializeTag(br);
                case ValueDisallowContactsTag.TypeNumber: return (PrivacyRule) ValueDisallowContactsTag.DeserializeTag(br);
                case ValueDisallowAllTag.TypeNumber: return (PrivacyRule) ValueDisallowAllTag.DeserializeTag(br);
                case ValueDisallowUsersTag.TypeNumber: return (PrivacyRule) ValueDisallowUsersTag.DeserializeTag(br);
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

        public bool Equals(PrivacyRule other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PrivacyRule x && Equals(x);
        public static bool operator ==(PrivacyRule a, PrivacyRule b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PrivacyRule a, PrivacyRule b) => !(a == b);

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

        public int CompareTo(PrivacyRule other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PrivacyRule x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PrivacyRule a, PrivacyRule b) => a.CompareTo(b) <= 0;
        public static bool operator <(PrivacyRule a, PrivacyRule b) => a.CompareTo(b) < 0;
        public static bool operator >(PrivacyRule a, PrivacyRule b) => a.CompareTo(b) > 0;
        public static bool operator >=(PrivacyRule a, PrivacyRule b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}