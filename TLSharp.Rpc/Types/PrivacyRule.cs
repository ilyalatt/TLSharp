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
        public sealed class ValueAllowContactsTag : ITlTypeTag, IEquatable<ValueAllowContactsTag>, IComparable<ValueAllowContactsTag>, IComparable
        {
            internal const uint TypeNumber = 0xfffe1bac;
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
            internal const uint TypeNumber = 0x65427b82;
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
            internal const uint TypeNumber = 0x4d5bbe0c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Users { get; }
            
            public ValueAllowUsersTag(
                Some<Arr<int>> users
            ) {
                Users = users;
            }
            
            Arr<int> CmpTuple =>
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
                Write(Users, bw, WriteVector<int>(WriteInt));
            }
            
            internal static ValueAllowUsersTag DeserializeTag(BinaryReader br)
            {
                var users = Read(br, ReadVector(ReadInt));
                return new ValueAllowUsersTag(users);
            }
        }

        public sealed class ValueDisallowContactsTag : ITlTypeTag, IEquatable<ValueDisallowContactsTag>, IComparable<ValueDisallowContactsTag>, IComparable
        {
            internal const uint TypeNumber = 0xf888fa1a;
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
            internal const uint TypeNumber = 0x8b73e763;
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
            internal const uint TypeNumber = 0x0c7f49b7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<int> Users { get; }
            
            public ValueDisallowUsersTag(
                Some<Arr<int>> users
            ) {
                Users = users;
            }
            
            Arr<int> CmpTuple =>
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

        public bool Equals(PrivacyRule other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PrivacyRule x && Equals(x);
        public static bool operator ==(PrivacyRule x, PrivacyRule y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PrivacyRule x, PrivacyRule y) => !(x == y);

        public int CompareTo(PrivacyRule other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PrivacyRule x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PrivacyRule x, PrivacyRule y) => x.CompareTo(y) <= 0;
        public static bool operator <(PrivacyRule x, PrivacyRule y) => x.CompareTo(y) < 0;
        public static bool operator >(PrivacyRule x, PrivacyRule y) => x.CompareTo(y) > 0;
        public static bool operator >=(PrivacyRule x, PrivacyRule y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PrivacyRule.{_tag.GetType().Name}{_tag}";
    }
}