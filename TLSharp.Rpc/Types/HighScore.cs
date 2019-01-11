using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class HighScore : ITlType, IEquatable<HighScore>, IComparable<HighScore>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x58fffcd0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Pos;
            public readonly int UserId;
            public readonly int Score;
            
            public Tag(
                int pos,
                int userId,
                int score
            ) {
                Pos = pos;
                UserId = userId;
                Score = score;
            }
            
            (int, int, int) CmpTuple =>
                (Pos, UserId, Score);

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

            public override string ToString() => $"(Pos: {Pos}, UserId: {UserId}, Score: {Score})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pos, bw, WriteInt);
                Write(UserId, bw, WriteInt);
                Write(Score, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var pos = Read(br, ReadInt);
                var userId = Read(br, ReadInt);
                var score = Read(br, ReadInt);
                return new Tag(pos, userId, score);
            }
        }

        readonly ITlTypeTag _tag;
        HighScore(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator HighScore(Tag tag) => new HighScore(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static HighScore Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (HighScore) Tag.DeserializeTag(br);
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

        public bool Equals(HighScore other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is HighScore x && Equals(x);
        public static bool operator ==(HighScore x, HighScore y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(HighScore x, HighScore y) => !(x == y);

        public int CompareTo(HighScore other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is HighScore x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(HighScore x, HighScore y) => x.CompareTo(y) <= 0;
        public static bool operator <(HighScore x, HighScore y) => x.CompareTo(y) < 0;
        public static bool operator >(HighScore x, HighScore y) => x.CompareTo(y) > 0;
        public static bool operator >=(HighScore x, HighScore y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"HighScore.{_tag.GetType().Name}{_tag}";
    }
}