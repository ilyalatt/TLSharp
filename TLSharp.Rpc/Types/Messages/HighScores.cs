using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class HighScores : ITlType, IEquatable<HighScores>, IComparable<HighScores>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9a3bfd99;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<T.HighScore> Scores { get; }
            public Arr<T.User> Users { get; }
            
            public Tag(
                Some<Arr<T.HighScore>> scores,
                Some<Arr<T.User>> users
            ) {
                Scores = scores;
                Users = users;
            }
            
            (Arr<T.HighScore>, Arr<T.User>) CmpTuple =>
                (Scores, Users);

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

            public override string ToString() => $"(Scores: {Scores}, Users: {Users})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Scores, bw, WriteVector<T.HighScore>(WriteSerializable));
                Write(Users, bw, WriteVector<T.User>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var scores = Read(br, ReadVector(T.HighScore.Deserialize));
                var users = Read(br, ReadVector(T.User.Deserialize));
                return new Tag(scores, users);
            }
        }

        readonly ITlTypeTag _tag;
        HighScores(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator HighScores(Tag tag) => new HighScores(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static HighScores Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (HighScores) Tag.DeserializeTag(br);
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

        public bool Equals(HighScores other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is HighScores x && Equals(x);
        public static bool operator ==(HighScores x, HighScores y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(HighScores x, HighScores y) => !(x == y);

        public int CompareTo(HighScores other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is HighScores x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(HighScores x, HighScores y) => x.CompareTo(y) <= 0;
        public static bool operator <(HighScores x, HighScores y) => x.CompareTo(y) < 0;
        public static bool operator >(HighScores x, HighScores y) => x.CompareTo(y) > 0;
        public static bool operator >=(HighScores x, HighScores y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"HighScores.{_tag.GetType().Name}{_tag}";
    }
}