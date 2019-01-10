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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xf56ee2a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Count { get; }
            public Arr<T.ChannelParticipant> Participants { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                int count,
                Some<Arr<T.ChannelParticipant>> participants,
                Some<Arr<T.User>> users
            ) {
                Count = count;
                Participants = participants;
                Users = users;
            }
            
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

        readonly ITlTypeTag _tag;
        ChannelParticipants(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ChannelParticipants(Tag tag) => new ChannelParticipants(tag);

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

        public bool Equals(ChannelParticipants other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChannelParticipants x && Equals(x);
        public static bool operator ==(ChannelParticipants a, ChannelParticipants b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChannelParticipants a, ChannelParticipants b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChannelParticipants other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipants x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipants a, ChannelParticipants b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChannelParticipants a, ChannelParticipants b) => a.CompareTo(b) < 0;
        public static bool operator >(ChannelParticipants a, ChannelParticipants b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChannelParticipants a, ChannelParticipants b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}