using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Contacts
{
    public sealed class Blocked : ITlType, IEquatable<Blocked>, IComparable<Blocked>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x1c138d15;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.ContactBlocked> Blocked { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.ContactBlocked>> blocked,
                Some<Arr<T.User>> users
            ) {
                Blocked = blocked;
                Users = users;
            }
            
            (Arr<T.ContactBlocked>, Arr<T.User>) CmpTuple =>
                (Blocked, Users);

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

            public override string ToString() => $"(Blocked: {Blocked}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Blocked, bw, WriteVector<T.ContactBlocked>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var blocked = Read(br, ReadVector(T.ContactBlocked.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(blocked, users);
            }
        }

        public sealed class SliceTag : ITlTypeTag, IEquatable<SliceTag>, IComparable<SliceTag>, IComparable
        {
            internal const uint TypeNumber = 0x900802a1;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Count { get; }
            public Arr<T.ContactBlocked> Blocked { get; }
            public Arr<T.User> Users { get; }
            
            public SliceTag(
                int count,
                Some<Arr<T.ContactBlocked>> blocked,
                Some<Arr<T.User>> users
            ) {
                Count = count;
                Blocked = blocked;
                Users = users;
            }
            
            (int, Arr<T.ContactBlocked>, Arr<T.User>) CmpTuple =>
                (Count, Blocked, Users);

            public bool Equals(SliceTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SliceTag x && Equals(x);
            public static bool operator ==(SliceTag x, SliceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SliceTag x, SliceTag y) => !(x == y);

            public int CompareTo(SliceTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SliceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SliceTag x, SliceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SliceTag x, SliceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SliceTag x, SliceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SliceTag x, SliceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Count: {Count}, Blocked: {Blocked}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Count, bw, WriteInt);
                Write(Blocked, bw, WriteVector<T.ContactBlocked>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static SliceTag DeserializeTag(BinaryReader br)
            {
                var count = Read(br, ReadInt);
                var blocked = Read(br, ReadVector(T.ContactBlocked.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new SliceTag(count, blocked, users);
            }
        }

        readonly ITlTypeTag _tag;
        Blocked(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Blocked(Tag tag) => new Blocked(tag);
        public static explicit operator Blocked(SliceTag tag) => new Blocked(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Blocked Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Blocked) Tag.DeserializeTag(br);
                case SliceTag.TypeNumber: return (Blocked) SliceTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, SliceTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SliceTag, T> sliceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SliceTag x when sliceTag != null: return sliceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SliceTag, T> sliceTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            sliceTag ?? throw new ArgumentNullException(nameof(sliceTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SliceTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Blocked other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Blocked x && Equals(x);
        public static bool operator ==(Blocked x, Blocked y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Blocked x, Blocked y) => !(x == y);

        public int CompareTo(Blocked other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Blocked x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Blocked x, Blocked y) => x.CompareTo(y) <= 0;
        public static bool operator <(Blocked x, Blocked y) => x.CompareTo(y) < 0;
        public static bool operator >(Blocked x, Blocked y) => x.CompareTo(y) > 0;
        public static bool operator >=(Blocked x, Blocked y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Blocked.{_tag.GetType().Name}{_tag}";
    }
}