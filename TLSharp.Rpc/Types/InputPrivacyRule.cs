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
        public sealed class ValueAllowContactsTag : ITlTypeTag, IEquatable<ValueAllowContactsTag>, IComparable<ValueAllowContactsTag>, IComparable
        {
            internal const uint TypeNumber = 0x0d09e07b;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueAllowContactsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ValueAllowContactsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ValueAllowContactsTag x && Equals(x);
            public static bool operator ==(ValueAllowContactsTag x, ValueAllowContactsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ValueAllowContactsTag x, ValueAllowContactsTag y) => !(x == y);

            public int CompareTo(ValueAllowContactsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ValueAllowContactsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ValueAllowContactsTag x, ValueAllowContactsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ValueAllowContactsTag x, ValueAllowContactsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ValueAllowContactsTag x, ValueAllowContactsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ValueAllowContactsTag x, ValueAllowContactsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueAllowContactsTag DeserializeTag(BinaryReader br)
            {

                return new ValueAllowContactsTag();
            }
        }

        public sealed class ValueAllowAllTag : ITlTypeTag, IEquatable<ValueAllowAllTag>, IComparable<ValueAllowAllTag>, IComparable
        {
            internal const uint TypeNumber = 0x184b35ce;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueAllowAllTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ValueAllowAllTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ValueAllowAllTag x && Equals(x);
            public static bool operator ==(ValueAllowAllTag x, ValueAllowAllTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ValueAllowAllTag x, ValueAllowAllTag y) => !(x == y);

            public int CompareTo(ValueAllowAllTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ValueAllowAllTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ValueAllowAllTag x, ValueAllowAllTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ValueAllowAllTag x, ValueAllowAllTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ValueAllowAllTag x, ValueAllowAllTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ValueAllowAllTag x, ValueAllowAllTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueAllowAllTag DeserializeTag(BinaryReader br)
            {

                return new ValueAllowAllTag();
            }
        }

        public sealed class ValueAllowUsersTag : ITlTypeTag, IEquatable<ValueAllowUsersTag>, IComparable<ValueAllowUsersTag>, IComparable
        {
            internal const uint TypeNumber = 0x131cc67f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.InputUser> Users { get; }
            
            public ValueAllowUsersTag(
                Some<Arr<T.InputUser>> users
            ) {
                Users = users;
            }
            
            Arr<T.InputUser> CmpTuple =>
                Users;

            public bool Equals(ValueAllowUsersTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ValueAllowUsersTag x && Equals(x);
            public static bool operator ==(ValueAllowUsersTag x, ValueAllowUsersTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ValueAllowUsersTag x, ValueAllowUsersTag y) => !(x == y);

            public int CompareTo(ValueAllowUsersTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ValueAllowUsersTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ValueAllowUsersTag x, ValueAllowUsersTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ValueAllowUsersTag x, ValueAllowUsersTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ValueAllowUsersTag x, ValueAllowUsersTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ValueAllowUsersTag x, ValueAllowUsersTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Users: {Users})";
            
            
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

        public sealed class ValueDisallowContactsTag : ITlTypeTag, IEquatable<ValueDisallowContactsTag>, IComparable<ValueDisallowContactsTag>, IComparable
        {
            internal const uint TypeNumber = 0x0ba52007;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueDisallowContactsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ValueDisallowContactsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ValueDisallowContactsTag x && Equals(x);
            public static bool operator ==(ValueDisallowContactsTag x, ValueDisallowContactsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ValueDisallowContactsTag x, ValueDisallowContactsTag y) => !(x == y);

            public int CompareTo(ValueDisallowContactsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ValueDisallowContactsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ValueDisallowContactsTag x, ValueDisallowContactsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ValueDisallowContactsTag x, ValueDisallowContactsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ValueDisallowContactsTag x, ValueDisallowContactsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ValueDisallowContactsTag x, ValueDisallowContactsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueDisallowContactsTag DeserializeTag(BinaryReader br)
            {

                return new ValueDisallowContactsTag();
            }
        }

        public sealed class ValueDisallowAllTag : ITlTypeTag, IEquatable<ValueDisallowAllTag>, IComparable<ValueDisallowAllTag>, IComparable
        {
            internal const uint TypeNumber = 0xd66b66c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public ValueDisallowAllTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(ValueDisallowAllTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ValueDisallowAllTag x && Equals(x);
            public static bool operator ==(ValueDisallowAllTag x, ValueDisallowAllTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ValueDisallowAllTag x, ValueDisallowAllTag y) => !(x == y);

            public int CompareTo(ValueDisallowAllTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ValueDisallowAllTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ValueDisallowAllTag x, ValueDisallowAllTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ValueDisallowAllTag x, ValueDisallowAllTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ValueDisallowAllTag x, ValueDisallowAllTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ValueDisallowAllTag x, ValueDisallowAllTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static ValueDisallowAllTag DeserializeTag(BinaryReader br)
            {

                return new ValueDisallowAllTag();
            }
        }

        public sealed class ValueDisallowUsersTag : ITlTypeTag, IEquatable<ValueDisallowUsersTag>, IComparable<ValueDisallowUsersTag>, IComparable
        {
            internal const uint TypeNumber = 0x90110467;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.InputUser> Users { get; }
            
            public ValueDisallowUsersTag(
                Some<Arr<T.InputUser>> users
            ) {
                Users = users;
            }
            
            Arr<T.InputUser> CmpTuple =>
                Users;

            public bool Equals(ValueDisallowUsersTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is ValueDisallowUsersTag x && Equals(x);
            public static bool operator ==(ValueDisallowUsersTag x, ValueDisallowUsersTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(ValueDisallowUsersTag x, ValueDisallowUsersTag y) => !(x == y);

            public int CompareTo(ValueDisallowUsersTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is ValueDisallowUsersTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(ValueDisallowUsersTag x, ValueDisallowUsersTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(ValueDisallowUsersTag x, ValueDisallowUsersTag y) => x.CompareTo(y) < 0;
            public static bool operator >(ValueDisallowUsersTag x, ValueDisallowUsersTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(ValueDisallowUsersTag x, ValueDisallowUsersTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Users: {Users})";
            
            
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

        public bool Equals(InputPrivacyRule other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputPrivacyRule x && Equals(x);
        public static bool operator ==(InputPrivacyRule x, InputPrivacyRule y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputPrivacyRule x, InputPrivacyRule y) => !(x == y);

        public int CompareTo(InputPrivacyRule other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPrivacyRule x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPrivacyRule x, InputPrivacyRule y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputPrivacyRule x, InputPrivacyRule y) => x.CompareTo(y) < 0;
        public static bool operator >(InputPrivacyRule x, InputPrivacyRule y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputPrivacyRule x, InputPrivacyRule y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputPrivacyRule.{_tag.GetType().Name}{_tag}";
    }
}