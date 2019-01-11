using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Channels
{
    public sealed class ChannelParticipants : ITlType, IEquatable<ChannelParticipants>, IComparable<ChannelParticipants>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xf56ee2a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Count;
            public readonly Arr<T.ChannelParticipant> Participants;
            public readonly Arr<T.User> Users;
            
            public Tag(
                int count,
                Some<Arr<T.ChannelParticipant>> participants,
                Some<Arr<T.User>> users
            ) {
                Count = count;
                Participants = participants;
                Users = users;
            }
            
            (int, Arr<T.ChannelParticipant>, Arr<T.User>) CmpTuple =>
                (Count, Participants, Users);

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

            public override string ToString() => $"(Count: {Count}, Participants: {Participants}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Count, bw, WriteInt);
                Write(Participants, bw, WriteVector<T.ChannelParticipant>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var count = Read(br, ReadInt);
                var participants = Read(br, ReadVector(T.ChannelParticipant.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(count, participants, users);
            }
        }

        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0xf0173fe9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NotModifiedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NotModifiedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is NotModifiedTag x && Equals(x);
            public static bool operator ==(NotModifiedTag x, NotModifiedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NotModifiedTag x, NotModifiedTag y) => !(x == y);

            public int CompareTo(NotModifiedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is NotModifiedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        readonly ITlTypeTag _tag;
        ChannelParticipants(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipants(Tag tag) => new ChannelParticipants(tag);
        public static explicit operator ChannelParticipants(NotModifiedTag tag) => new ChannelParticipants(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ChannelParticipants Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ChannelParticipants) Tag.DeserializeTag(br);
                case NotModifiedTag.TypeNumber: return (ChannelParticipants) NotModifiedTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, NotModifiedTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<NotModifiedTag, T> notModifiedTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<NotModifiedTag, T> notModifiedTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case NotModifiedTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(ChannelParticipants other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ChannelParticipants x && Equals(x);
        public static bool operator ==(ChannelParticipants x, ChannelParticipants y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChannelParticipants x, ChannelParticipants y) => !(x == y);

        public int CompareTo(ChannelParticipants other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ChannelParticipants x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipants x, ChannelParticipants y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChannelParticipants x, ChannelParticipants y) => x.CompareTo(y) < 0;
        public static bool operator >(ChannelParticipants x, ChannelParticipants y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChannelParticipants x, ChannelParticipants y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ChannelParticipants.{_tag.GetType().Name}{_tag}";
    }
}