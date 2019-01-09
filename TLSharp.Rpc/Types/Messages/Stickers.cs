using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class Stickers : ITlType, IEquatable<Stickers>, IComparable<Stickers>, IComparable
    {
        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf1749a22;
            

            
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
            uint ITlTypeTag.TypeNumber => 0x8a8ecd32;
            
            public string Hash { get; }
            public Arr<T.Document> Stickers { get; }
            
            public Tag(
                Some<string> hash,
                Some<Arr<T.Document>> stickers
            ) {
                Hash = hash;
                Stickers = stickers;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteString);
                Write(Stickers, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadString);
                var stickers = Read(br, ReadVector(T.Document.Deserialize));
                return new Tag(hash, stickers);
            }
        }

        readonly ITlTypeTag _tag;
        Stickers(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Stickers(NotModifiedTag tag) => new Stickers(tag);
        public static explicit operator Stickers(Tag tag) => new Stickers(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Stickers Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xf1749a22: return (Stickers) NotModifiedTag.DeserializeTag(br);
                case 0x8a8ecd32: return (Stickers) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xf1749a22, 0x8a8ecd32 });
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

        public bool Equals(Stickers other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Stickers x && Equals(x);
        public static bool operator ==(Stickers a, Stickers b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Stickers a, Stickers b) => !(a == b);

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

        public int CompareTo(Stickers other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Stickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Stickers a, Stickers b) => a.CompareTo(b) <= 0;
        public static bool operator <(Stickers a, Stickers b) => a.CompareTo(b) < 0;
        public static bool operator >(Stickers a, Stickers b) => a.CompareTo(b) > 0;
        public static bool operator >=(Stickers a, Stickers b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}