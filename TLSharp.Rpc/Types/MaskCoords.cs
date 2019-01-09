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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xaed6dbb2;
            
            public int N { get; }
            public double X { get; }
            public double Y { get; }
            public double Zoom { get; }
            
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
                case 0xaed6dbb2: return (MaskCoords) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xaed6dbb2 });
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

        public bool Equals(MaskCoords other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MaskCoords x && Equals(x);
        public static bool operator ==(MaskCoords a, MaskCoords b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MaskCoords a, MaskCoords b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MaskCoords other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MaskCoords x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MaskCoords a, MaskCoords b) => a.CompareTo(b) <= 0;
        public static bool operator <(MaskCoords a, MaskCoords b) => a.CompareTo(b) < 0;
        public static bool operator >(MaskCoords a, MaskCoords b) => a.CompareTo(b) > 0;
        public static bool operator >=(MaskCoords a, MaskCoords b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}