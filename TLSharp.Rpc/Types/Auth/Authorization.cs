using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Auth
{
    public sealed class Authorization : ITlType, IEquatable<Authorization>, IComparable<Authorization>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xcd050916;
            
            public Option<int> TmpSessions { get; }
            public T.User User { get; }
            
            public Tag(
                Option<int> tmpSessions,
                Some<T.User> user
            ) {
                TmpSessions = tmpSessions;
                User = user;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(0, TmpSessions), bw, WriteInt);
                Write(TmpSessions, bw, WriteOption<int>(WriteInt));
                Write(User, bw, WriteSerializable);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var tmpSessions = Read(br, ReadOption(flags, 0, ReadInt));
                var user = Read(br, T.User.Deserialize);
                return new Tag(tmpSessions, user);
            }
        }

        readonly ITlTypeTag _tag;
        Authorization(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Authorization(Tag tag) => new Authorization(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Authorization Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xcd050916: return (Authorization) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xcd050916 });
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

        public bool Equals(Authorization other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Authorization x && Equals(x);
        public static bool operator ==(Authorization a, Authorization b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Authorization a, Authorization b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Authorization other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Authorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Authorization a, Authorization b) => a.CompareTo(b) <= 0;
        public static bool operator <(Authorization a, Authorization b) => a.CompareTo(b) < 0;
        public static bool operator >(Authorization a, Authorization b) => a.CompareTo(b) > 0;
        public static bool operator >=(Authorization a, Authorization b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}