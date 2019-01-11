using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class AffectedMessages : ITlType, IEquatable<AffectedMessages>, IComparable<AffectedMessages>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x84d19185;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Pts;
            public readonly int PtsCount;
            
            public Tag(
                int pts,
                int ptsCount
            ) {
                Pts = pts;
                PtsCount = ptsCount;
            }
            
            (int, int) CmpTuple =>
                (Pts, PtsCount);

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

            public override string ToString() => $"(Pts: {Pts}, PtsCount: {PtsCount})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pts, bw, WriteInt);
                Write(PtsCount, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var pts = Read(br, ReadInt);
                var ptsCount = Read(br, ReadInt);
                return new Tag(pts, ptsCount);
            }
        }

        readonly ITlTypeTag _tag;
        AffectedMessages(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator AffectedMessages(Tag tag) => new AffectedMessages(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static AffectedMessages Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (AffectedMessages) Tag.DeserializeTag(br);
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

        public bool Equals(AffectedMessages other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is AffectedMessages x && Equals(x);
        public static bool operator ==(AffectedMessages x, AffectedMessages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AffectedMessages x, AffectedMessages y) => !(x == y);

        public int CompareTo(AffectedMessages other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is AffectedMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AffectedMessages x, AffectedMessages y) => x.CompareTo(y) <= 0;
        public static bool operator <(AffectedMessages x, AffectedMessages y) => x.CompareTo(y) < 0;
        public static bool operator >(AffectedMessages x, AffectedMessages y) => x.CompareTo(y) > 0;
        public static bool operator >=(AffectedMessages x, AffectedMessages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"AffectedMessages.{_tag.GetType().Name}{_tag}";
    }
}