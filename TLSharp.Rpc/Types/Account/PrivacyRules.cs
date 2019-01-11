using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Account
{
    public sealed class PrivacyRules : ITlType, IEquatable<PrivacyRules>, IComparable<PrivacyRules>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x554abb6f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.PrivacyRule> Rules { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.PrivacyRule>> rules,
                Some<Arr<T.User>> users
            ) {
                Rules = rules;
                Users = users;
            }
            
            (Arr<T.PrivacyRule>, Arr<T.User>) CmpTuple =>
                (Rules, Users);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Rules: {Rules}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Rules, bw, WriteVector<T.PrivacyRule>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var rules = Read(br, ReadVector(T.PrivacyRule.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(rules, users);
            }
        }

        readonly ITlTypeTag _tag;
        PrivacyRules(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PrivacyRules(Tag tag) => new PrivacyRules(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PrivacyRules Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PrivacyRules) Tag.DeserializeTag(br);
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

        public bool Equals(PrivacyRules other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PrivacyRules x && Equals(x);
        public static bool operator ==(PrivacyRules x, PrivacyRules y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PrivacyRules x, PrivacyRules y) => !(x == y);

        public int CompareTo(PrivacyRules other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PrivacyRules x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PrivacyRules x, PrivacyRules y) => x.CompareTo(y) <= 0;
        public static bool operator <(PrivacyRules x, PrivacyRules y) => x.CompareTo(y) < 0;
        public static bool operator >(PrivacyRules x, PrivacyRules y) => x.CompareTo(y) > 0;
        public static bool operator >=(PrivacyRules x, PrivacyRules y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PrivacyRules.{_tag.GetType().Name}{_tag}";
    }
}