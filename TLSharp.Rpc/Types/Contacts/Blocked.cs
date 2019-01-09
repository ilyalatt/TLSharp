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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x1c138d15;
            
            public Arr<T.ContactBlocked> Blocked { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.ContactBlocked>> blocked,
                Some<Arr<T.User>> users
            ) {
                Blocked = blocked;
                Users = users;
            }
            
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

        public sealed class SliceTag : Record<SliceTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x900802a1;
            
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
                case 0x1c138d15: return (Blocked) Tag.DeserializeTag(br);
                case 0x900802a1: return (Blocked) SliceTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x1c138d15, 0x900802a1 });
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

        public bool Equals(Blocked other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Blocked x && Equals(x);
        public static bool operator ==(Blocked a, Blocked b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Blocked a, Blocked b) => !(a == b);

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

        public int CompareTo(Blocked other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Blocked x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Blocked a, Blocked b) => a.CompareTo(b) <= 0;
        public static bool operator <(Blocked a, Blocked b) => a.CompareTo(b) < 0;
        public static bool operator >(Blocked a, Blocked b) => a.CompareTo(b) > 0;
        public static bool operator >=(Blocked a, Blocked b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}