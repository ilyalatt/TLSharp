using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class AllStickers : ITlType, IEquatable<AllStickers>, IComparable<AllStickers>, IComparable
    {
        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe86602c3;
            

            
            public NotModifiedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NotModifiedTag DeserializeTag(BinaryReader br)
            {

                return new NotModifiedTag();
            }
        }

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xedfd405f;
            
            public int Hash { get; }
            public Arr<T.StickerSet> Sets { get; }
            
            public Tag(
                int hash,
                Some<Arr<T.StickerSet>> sets
            ) {
                Hash = hash;
                Sets = sets;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteInt);
                Write(Sets, bw, WriteVector<T.StickerSet>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadInt);
                var sets = Read(br, ReadVector(T.StickerSet.Deserialize));
                return new Tag(hash, sets);
            }
        }

        readonly ITlTypeTag _tag;
        AllStickers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator AllStickers(NotModifiedTag tag) => new AllStickers(tag);
        public static explicit operator AllStickers(Tag tag) => new AllStickers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static AllStickers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xe86602c3: return (AllStickers) NotModifiedTag.DeserializeTag(br);
                case 0xedfd405f: return (AllStickers) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xe86602c3, 0xedfd405f });
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

        public bool Equals(AllStickers other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is AllStickers x && Equals(x);
        public static bool operator ==(AllStickers a, AllStickers b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(AllStickers a, AllStickers b) => !(a == b);

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

        public int CompareTo(AllStickers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AllStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AllStickers a, AllStickers b) => a.CompareTo(b) <= 0;
        public static bool operator <(AllStickers a, AllStickers b) => a.CompareTo(b) < 0;
        public static bool operator >(AllStickers a, AllStickers b) => a.CompareTo(b) > 0;
        public static bool operator >=(AllStickers a, AllStickers b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}