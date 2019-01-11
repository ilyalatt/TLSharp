using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MaskCoords : ITlType, IEquatable<MaskCoords>, IComparable<MaskCoords>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xaed6dbb2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int N;
            public readonly double X;
            public readonly double Y;
            public readonly double Zoom;
            
            public Tag(
                int n,
                double x,
                double y,
                double zoom
            ) {
                N = n;
                X = x;
                Y = y;
                Zoom = zoom;
            }
            
            (int, double, double, double) CmpTuple =>
                (N, X, Y, Zoom);

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

            public override string ToString() => $"(N: {N}, X: {X}, Y: {Y}, Zoom: {Zoom})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(N, bw, WriteInt);
                Write(X, bw, WriteDouble);
                Write(Y, bw, WriteDouble);
                Write(Zoom, bw, WriteDouble);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var n = Read(br, ReadInt);
                var x = Read(br, ReadDouble);
                var y = Read(br, ReadDouble);
                var zoom = Read(br, ReadDouble);
                return new Tag(n, x, y, zoom);
            }
        }

        readonly ITlTypeTag _tag;
        MaskCoords(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MaskCoords(Tag tag) => new MaskCoords(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MaskCoords Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (MaskCoords) Tag.DeserializeTag(br);
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

        public bool Equals(MaskCoords other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is MaskCoords x && Equals(x);
        public static bool operator ==(MaskCoords x, MaskCoords y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MaskCoords x, MaskCoords y) => !(x == y);

        public int CompareTo(MaskCoords other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is MaskCoords x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MaskCoords x, MaskCoords y) => x.CompareTo(y) <= 0;
        public static bool operator <(MaskCoords x, MaskCoords y) => x.CompareTo(y) < 0;
        public static bool operator >(MaskCoords x, MaskCoords y) => x.CompareTo(y) > 0;
        public static bool operator >=(MaskCoords x, MaskCoords y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"MaskCoords.{_tag.GetType().Name}{_tag}";
    }
}