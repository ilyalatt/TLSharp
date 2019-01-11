using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Channels
{
    public sealed class ChannelParticipant : ITlType, IEquatable<ChannelParticipant>, IComparable<ChannelParticipant>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xd0d9b163;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public T.ChannelParticipant Participant { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<T.ChannelParticipant> participant,
                Some<Arr<T.User>> users
            ) {
                Participant = participant;
                Users = users;
            }
            
            (T.ChannelParticipant, Arr<T.User>) CmpTuple =>
                (Participant, Users);

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

            public override string ToString() => $"(Participant: {Participant}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Participant, bw, WriteSerializable);
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var participant = Read(br, T.ChannelParticipant.Deserialize);
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(participant, users);
            }
        }

        readonly ITlTypeTag _tag;
        ChannelParticipant(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipant(Tag tag) => new ChannelParticipant(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelParticipant Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelParticipant) Tag.DeserializeTag(br);
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

        public bool Equals(ChannelParticipant other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is ChannelParticipant x && Equals(x);
        public static bool operator ==(ChannelParticipant x, ChannelParticipant y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelParticipant x, ChannelParticipant y) => !(x == y);

        public int CompareTo(ChannelParticipant other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelParticipant x, ChannelParticipant y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelParticipant.{_tag.GetType().Name}{_tag}";
    }
}