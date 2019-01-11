using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class FoundGifs : ITlType, IEquatable<FoundGifs>, IComparable<FoundGifs>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x450a1c0a;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int NextOffset;
            public readonly Arr<T.FoundGif> Results;
            
            public Tag(
                int nextOffset,
                Some<Arr<T.FoundGif>> results
            ) {
                NextOffset = nextOffset;
                Results = results;
            }
            
            (int, Arr<T.FoundGif>) CmpTuple =>
                (NextOffset, Results);

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

            public override string ToString() => $"(NextOffset: {NextOffset}, Results: {Results})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(NextOffset, bw, WriteInt);
                Write(Results, bw, WriteVector<T.FoundGif>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var nextOffset = Read(br, ReadInt);
                var results = Read(br, ReadVector(T.FoundGif.Deserialize));
                return new Tag(nextOffset, results);
            }
        }

        readonly ITlTypeTag _tag;
        FoundGifs(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FoundGifs(Tag tag) => new FoundGifs(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FoundGifs Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (FoundGifs) Tag.DeserializeTag(br);
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

        public bool Equals(FoundGifs other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is FoundGifs x && Equals(x);
        public static bool operator ==(FoundGifs x, FoundGifs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FoundGifs x, FoundGifs y) => !(x == y);

        public int CompareTo(FoundGifs other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is FoundGifs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FoundGifs x, FoundGifs y) => x.CompareTo(y) <= 0;
        public static bool operator <(FoundGifs x, FoundGifs y) => x.CompareTo(y) < 0;
        public static bool operator >(FoundGifs x, FoundGifs y) => x.CompareTo(y) > 0;
        public static bool operator >=(FoundGifs x, FoundGifs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FoundGifs.{_tag.GetType().Name}{_tag}";
    }
}