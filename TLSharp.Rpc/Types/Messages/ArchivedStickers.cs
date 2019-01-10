using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class ArchivedStickers : ITlType, IEquatable<ArchivedStickers>, IComparable<ArchivedStickers>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x4fcba9c8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Count { get; }
            public Arr<T.StickerSetCovered> Sets { get; }
            
            public Tag(
                int count,
                Some<Arr<T.StickerSetCovered>> sets
            ) {
                Count = count;
                Sets = sets;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Count, bw, WriteInt);
                Write(Sets, bw, WriteVector<T.StickerSetCovered>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var count = Read(br, ReadInt);
                var sets = Read(br, ReadVector(T.StickerSetCovered.Deserialize));
                return new Tag(count, sets);
            }
        }

        readonly ITlTypeTag _tag;
        ArchivedStickers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ArchivedStickers(Tag tag) => new ArchivedStickers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ArchivedStickers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ArchivedStickers) Tag.DeserializeTag(br);
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

        public bool Equals(ArchivedStickers other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ArchivedStickers x && Equals(x);
        public static bool operator ==(ArchivedStickers a, ArchivedStickers b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ArchivedStickers a, ArchivedStickers b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ArchivedStickers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ArchivedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ArchivedStickers a, ArchivedStickers b) => a.CompareTo(b) <= 0;
        public static bool operator <(ArchivedStickers a, ArchivedStickers b) => a.CompareTo(b) < 0;
        public static bool operator >(ArchivedStickers a, ArchivedStickers b) => a.CompareTo(b) > 0;
        public static bool operator >=(ArchivedStickers a, ArchivedStickers b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}