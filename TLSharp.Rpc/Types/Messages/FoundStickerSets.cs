using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class FoundStickerSets : ITlType, IEquatable<FoundStickerSets>, IComparable<FoundStickerSets>, IComparable
    {
        public sealed class NotModifiedTag : ITlTypeTag, IEquatable<NotModifiedTag>, IComparable<NotModifiedTag>, IComparable
        {
            internal const uint TypeNumber = 0x0d54b65d;
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
            internal const uint TypeNumber = 0x5108d648;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Hash;
            public readonly Arr<T.StickerSetCovered> Sets;
            
            public Tag(
                int hash,
                Some<Arr<T.StickerSetCovered>> sets
            ) {
                Hash = hash;
                Sets = sets;
            }
            
            (int, Arr<T.StickerSetCovered>) CmpTuple =>
                (Hash, Sets);

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

            public override string ToString() => $"(Hash: {Hash}, Sets: {Sets})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteInt);
                Write(Sets, bw, WriteVector<T.StickerSetCovered>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadInt);
                var sets = Read(br, ReadVector(T.StickerSetCovered.Deserialize));
                return new Tag(hash, sets);
            }
        }

        readonly ITlTypeTag _tag;
        FoundStickerSets(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FoundStickerSets(NotModifiedTag tag) => new FoundStickerSets(tag);
        public static explicit operator FoundStickerSets(Tag tag) => new FoundStickerSets(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FoundStickerSets Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case NotModifiedTag.TypeNumber: return (FoundStickerSets) NotModifiedTag.DeserializeTag(br);
                case Tag.TypeNumber: return (FoundStickerSets) Tag.DeserializeTag(br);
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

        public bool Equals(FoundStickerSets other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is FoundStickerSets x && Equals(x);
        public static bool operator ==(FoundStickerSets x, FoundStickerSets y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FoundStickerSets x, FoundStickerSets y) => !(x == y);

        public int CompareTo(FoundStickerSets other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is FoundStickerSets x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FoundStickerSets x, FoundStickerSets y) => x.CompareTo(y) <= 0;
        public static bool operator <(FoundStickerSets x, FoundStickerSets y) => x.CompareTo(y) < 0;
        public static bool operator >(FoundStickerSets x, FoundStickerSets y) => x.CompareTo(y) > 0;
        public static bool operator >=(FoundStickerSets x, FoundStickerSets y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FoundStickerSets.{_tag.GetType().Name}{_tag}";
    }
}