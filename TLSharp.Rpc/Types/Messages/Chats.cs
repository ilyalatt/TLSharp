using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Messages
{
    public sealed class Chats : ITlType, IEquatable<Chats>, IComparable<Chats>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x64ff9fd5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Arr<T.Chat> Chats;
            
            public Tag(
                Some<Arr<T.Chat>> chats
            ) {
                Chats = chats;
            }
            
            Arr<T.Chat> CmpTuple =>
                Chats;

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

            public override string ToString() => $"(Chats: {Chats})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                return new Tag(chats);
            }
        }

        public sealed class SliceTag : ITlTypeTag, IEquatable<SliceTag>, IComparable<SliceTag>, IComparable
        {
            internal const uint TypeNumber = 0x9cd81144;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Count;
            public readonly Arr<T.Chat> Chats;
            
            public SliceTag(
                int count,
                Some<Arr<T.Chat>> chats
            ) {
                Count = count;
                Chats = chats;
            }
            
            (int, Arr<T.Chat>) CmpTuple =>
                (Count, Chats);

            public bool Equals(SliceTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SliceTag x && Equals(x);
            public static bool operator ==(SliceTag x, SliceTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SliceTag x, SliceTag y) => !(x == y);

            public int CompareTo(SliceTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SliceTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SliceTag x, SliceTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SliceTag x, SliceTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SliceTag x, SliceTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SliceTag x, SliceTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Count: {Count}, Chats: {Chats})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Count, bw, WriteInt);
                Write(Chats, bw, WriteVector<T.Chat>(WriteSerializable));
            }
            
            internal static SliceTag DeserializeTag(BinaryReader br)
            {
                var count = Read(br, ReadInt);
                var chats = Read(br, ReadVector(T.Chat.Deserialize));
                return new SliceTag(count, chats);
            }
        }

        readonly ITlTypeTag _tag;
        Chats(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Chats(Tag tag) => new Chats(tag);
        public static explicit operator Chats(SliceTag tag) => new Chats(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Chats Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Chats) Tag.DeserializeTag(br);
                case SliceTag.TypeNumber: return (Chats) SliceTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, SliceTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<SliceTag, T> sliceTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case SliceTag x when sliceTag != null: return sliceTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<SliceTag, T> sliceTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            sliceTag ?? throw new ArgumentNullException(nameof(sliceTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case SliceTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Chats other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Chats x && Equals(x);
        public static bool operator ==(Chats x, Chats y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Chats x, Chats y) => !(x == y);

        public int CompareTo(Chats other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Chats x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Chats x, Chats y) => x.CompareTo(y) <= 0;
        public static bool operator <(Chats x, Chats y) => x.CompareTo(y) < 0;
        public static bool operator >(Chats x, Chats y) => x.CompareTo(y) > 0;
        public static bool operator >=(Chats x, Chats y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Chats.{_tag.GetType().Name}{_tag}";
    }
}