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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x58fffcd0;
            
            public int Pos { get; }
            public int UserId { get; }
            public int Score { get; }
            
            public Tag(
                int pos,
                int userId,
                int score
            ) {
                Pos = pos;
                UserId = userId;
                Score = score;
            }
            
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
                case 0x58fffcd0: return (HighScore) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x58fffcd0 });
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

        public bool Equals(HighScore other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is HighScore x && Equals(x);
        public static bool operator ==(HighScore a, HighScore b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(HighScore a, HighScore b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(HighScore other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is HighScore x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(HighScore a, HighScore b) => a.CompareTo(b) <= 0;
        public static bool operator <(HighScore a, HighScore b) => a.CompareTo(b) < 0;
        public static bool operator >(HighScore a, HighScore b) => a.CompareTo(b) > 0;
        public static bool operator >=(HighScore a, HighScore b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}