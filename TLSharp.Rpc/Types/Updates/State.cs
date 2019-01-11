using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Updates
{
    public sealed class State : ITlType, IEquatable<State>, IComparable<State>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xa56c2a3e;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Pts { get; }
            public int Qts { get; }
            public int Date { get; }
            public int Seq { get; }
            public int UnreadCount { get; }
            
            public Tag(
                int pts,
                int qts,
                int date,
                int seq,
                int unreadCount
            ) {
                Pts = pts;
                Qts = qts;
                Date = date;
                Seq = seq;
                UnreadCount = unreadCount;
            }
            
            (int, int, int, int, int) CmpTuple =>
                (Pts, Qts, Date, Seq, UnreadCount);

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

            public override string ToString() => $"(Pts: {Pts}, Qts: {Qts}, Date: {Date}, Seq: {Seq}, UnreadCount: {UnreadCount})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pts, bw, WriteInt);
                Write(Qts, bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Seq, bw, WriteInt);
                Write(UnreadCount, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var pts = Read(br, ReadInt);
                var qts = Read(br, ReadInt);
                var date = Read(br, ReadInt);
                var seq = Read(br, ReadInt);
                var unreadCount = Read(br, ReadInt);
                return new Tag(pts, qts, date, seq, unreadCount);
            }
        }

        readonly ITlTypeTag _tag;
        State(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator State(Tag tag) => new State(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static State Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (State) Tag.DeserializeTag(br);
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

        public bool Equals(State other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is State x && Equals(x);
        public static bool operator ==(State x, State y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(State x, State y) => !(x == y);

        public int CompareTo(State other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is State x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(State x, State y) => x.CompareTo(y) <= 0;
        public static bool operator <(State x, State y) => x.CompareTo(y) < 0;
        public static bool operator >(State x, State y) => x.CompareTo(y) > 0;
        public static bool operator >=(State x, State y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"State.{_tag.GetType().Name}{_tag}";
    }
}