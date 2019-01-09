using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class SavedGifs : ITlType, IEquatable<SavedGifs>, IComparable<SavedGifs>, IComparable
    {
        public sealed class NotModifiedTag : Record<NotModifiedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe8025ca2;
            

            
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
            uint ITlTypeTag.TypeNumber => 0x2e0709a5;
            
            public int Hash { get; }
            public Arr<T.Document> Gifs { get; }
            
            public Tag(
                int hash,
                Some<Arr<T.Document>> gifs
            ) {
                Hash = hash;
                Gifs = gifs;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Hash, bw, WriteInt);
                Write(Gifs, bw, WriteVector<T.Document>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var hash = Read(br, ReadInt);
                var gifs = Read(br, ReadVector(T.Document.Deserialize));
                return new Tag(hash, gifs);
            }
        }

        readonly ITlTypeTag _tag;
        SavedGifs(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SavedGifs(NotModifiedTag tag) => new SavedGifs(tag);
        public static explicit operator SavedGifs(Tag tag) => new SavedGifs(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SavedGifs Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xe8025ca2: return (SavedGifs) NotModifiedTag.DeserializeTag(br);
                case 0x2e0709a5: return (SavedGifs) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xe8025ca2, 0x2e0709a5 });
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

        public bool Equals(SavedGifs other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is SavedGifs x && Equals(x);
        public static bool operator ==(SavedGifs a, SavedGifs b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(SavedGifs a, SavedGifs b) => !(a == b);

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

        public int CompareTo(SavedGifs other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SavedGifs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SavedGifs a, SavedGifs b) => a.CompareTo(b) <= 0;
        public static bool operator <(SavedGifs a, SavedGifs b) => a.CompareTo(b) < 0;
        public static bool operator >(SavedGifs a, SavedGifs b) => a.CompareTo(b) > 0;
        public static bool operator >=(SavedGifs a, SavedGifs b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}