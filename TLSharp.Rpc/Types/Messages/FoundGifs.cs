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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x450a1c0a;
            
            public int NextOffset { get; }
            public Arr<T.FoundGif> Results { get; }
            
            public Tag(
                int nextOffset,
                Some<Arr<T.FoundGif>> results
            ) {
                NextOffset = nextOffset;
                Results = results;
            }
            
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
                case 0x450a1c0a: return (FoundGifs) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x450a1c0a });
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

        public bool Equals(FoundGifs other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is FoundGifs x && Equals(x);
        public static bool operator ==(FoundGifs a, FoundGifs b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(FoundGifs a, FoundGifs b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(FoundGifs other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FoundGifs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FoundGifs a, FoundGifs b) => a.CompareTo(b) <= 0;
        public static bool operator <(FoundGifs a, FoundGifs b) => a.CompareTo(b) < 0;
        public static bool operator >(FoundGifs a, FoundGifs b) => a.CompareTo(b) > 0;
        public static bool operator >=(FoundGifs a, FoundGifs b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}