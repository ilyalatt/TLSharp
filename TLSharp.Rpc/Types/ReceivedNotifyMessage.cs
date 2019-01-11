using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ReceivedNotifyMessage : ITlType, IEquatable<ReceivedNotifyMessage>, IComparable<ReceivedNotifyMessage>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xa384b779;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly int Id;
            public readonly int Flags;
            
            public Tag(
                int id,
                int flags
            ) {
                Id = id;
                Flags = flags;
            }
            
            (int, int) CmpTuple =>
                (Id, Flags);

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

            public override string ToString() => $"(Id: {Id}, Flags: {Flags})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Id, bw, WriteInt);
                Write(Flags, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var id = Read(br, ReadInt);
                var flags = Read(br, ReadInt);
                return new Tag(id, flags);
            }
        }

        readonly ITlTypeTag _tag;
        ReceivedNotifyMessage(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ReceivedNotifyMessage(Tag tag) => new ReceivedNotifyMessage(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ReceivedNotifyMessage Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ReceivedNotifyMessage) Tag.DeserializeTag(br);
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

        public bool Equals(ReceivedNotifyMessage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ReceivedNotifyMessage x && Equals(x);
        public static bool operator ==(ReceivedNotifyMessage x, ReceivedNotifyMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReceivedNotifyMessage x, ReceivedNotifyMessage y) => !(x == y);

        public int CompareTo(ReceivedNotifyMessage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ReceivedNotifyMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReceivedNotifyMessage x, ReceivedNotifyMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReceivedNotifyMessage x, ReceivedNotifyMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(ReceivedNotifyMessage x, ReceivedNotifyMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReceivedNotifyMessage x, ReceivedNotifyMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ReceivedNotifyMessage.{_tag.GetType().Name}{_tag}";
    }
}