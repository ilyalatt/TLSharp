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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xd0d9b163;
            
            public T.ChannelParticipant Participant { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<T.ChannelParticipant> participant,
                Some<Arr<T.User>> users
            ) {
                Participant = participant;
                Users = users;
            }
            
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
                case 0xd0d9b163: return (ChannelParticipant) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xd0d9b163 });
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

        public bool Equals(ChannelParticipant other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ChannelParticipant x && Equals(x);
        public static bool operator ==(ChannelParticipant a, ChannelParticipant b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ChannelParticipant a, ChannelParticipant b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ChannelParticipant other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChannelParticipant x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) <= 0;
        public static bool operator <(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) < 0;
        public static bool operator >(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) > 0;
        public static bool operator >=(ChannelParticipant a, ChannelParticipant b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}