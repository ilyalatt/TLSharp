using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class FavedStickers : ITlType, IEquatable<FavedStickers>, IComparable<FavedStickers>, IComparable
    {
        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0x9e8fa6d3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NotModifiedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NotModifiedTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is NotModifiedTag x && Equals(x);
            public static bool operator ==(NotModifiedTag x, NotModifiedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NotModifiedTag x, NotModifiedTag y) => !(x == y);

            public int CompareTo(NotModifiedTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is NotModifiedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NotModifiedTag x, NotModifiedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xf37f2f16;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Hash;
            public readonly Arr<T.StickerPack> Packs;
            public readonly Arr<T.Document> Stickers;
            
            public Tag(
                int hash,
                Some<Arr<T.StickerPack>> packs,
                Some<Arr<T.Document>> stickers
            ) {
                Hash = hash;
                Packs = packs;
                Stickers = stickers;
            }
            
            (int, Arr<T.StickerPack>, Arr<T.Document>) CmpTuple =>
                (Hash, Packs, Stickers);

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

            public override string ToString() => $"(Hash: {Hash}, Packs: {Packs}, Stickers: {Stickers})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteInt);
                Write(Packs, bw, WriteVector<T.StickerPack>(WriteSerializable));
                Write(Stickers, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadInt);
                var packs = Read(br, ReadVector(T.StickerPack.Deserialize));
                var stickers = Read(br, ReadVector(T.Document.Deserialize));
                return new Tag(hash, packs, stickers);
            }
        }

        readonly ITlTypeTag _tag;
        FavedStickers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FavedStickers(NotModifiedTag tag) => new FavedStickers(tag);
        public static explicit operator FavedStickers(Tag tag) => new FavedStickers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FavedStickers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NotModifiedTag.TypeNumber: return (FavedStickers) NotModifiedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (FavedStickers) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { NotModifiedTag.TypeNumber, Tag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<NotModifiedTag, T> notModifiedTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case NotModifiedTag x when notModifiedTag != null: return notModifiedTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<NotModifiedTag, T> notModifiedTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            notModifiedTag ?? throw new ArgumentNullException(nameof(notModifiedTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case NotModifiedTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(FavedStickers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is FavedStickers x && Equals(x);
        public static bool operator ==(FavedStickers x, FavedStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FavedStickers x, FavedStickers y) => !(x == y);

        public int CompareTo(FavedStickers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is FavedStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FavedStickers x, FavedStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(FavedStickers x, FavedStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(FavedStickers x, FavedStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(FavedStickers x, FavedStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FavedStickers.{_tag.GetType().Name}{_tag}";
    }
}