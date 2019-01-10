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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x84d19185;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Pts { get; }
            public int PtsCount { get; }
            
            public Tag(
                int pts,
                int ptsCount
            ) {
                Pts = pts;
                PtsCount = ptsCount;
            }
            
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

        public bool Equals(AffectedMessages other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is AffectedMessages x && Equals(x);
        public static bool operator ==(AffectedMessages a, AffectedMessages b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(AffectedMessages a, AffectedMessages b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(AffectedMessages other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AffectedMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AffectedMessages a, AffectedMessages b) => a.CompareTo(b) <= 0;
        public static bool operator <(AffectedMessages a, AffectedMessages b) => a.CompareTo(b) < 0;
        public static bool operator >(AffectedMessages a, AffectedMessages b) => a.CompareTo(b) > 0;
        public static bool operator >=(AffectedMessages a, AffectedMessages b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}