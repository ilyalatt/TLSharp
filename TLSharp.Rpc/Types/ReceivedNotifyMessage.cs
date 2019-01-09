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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa384b779;
            
            public int Id { get; }
            public int Flags { get; }
            
            public Tag(
                int id,
                int flags
            ) {
                Id = id;
                Flags = flags;
            }
            
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
                case 0xa384b779: return (ReceivedNotifyMessage) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xa384b779 });
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

        public bool Equals(ReceivedNotifyMessage other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ReceivedNotifyMessage x && Equals(x);
        public static bool operator ==(ReceivedNotifyMessage a, ReceivedNotifyMessage b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ReceivedNotifyMessage a, ReceivedNotifyMessage b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ReceivedNotifyMessage other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReceivedNotifyMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReceivedNotifyMessage a, ReceivedNotifyMessage b) => a.CompareTo(b) <= 0;
        public static bool operator <(ReceivedNotifyMessage a, ReceivedNotifyMessage b) => a.CompareTo(b) < 0;
        public static bool operator >(ReceivedNotifyMessage a, ReceivedNotifyMessage b) => a.CompareTo(b) > 0;
        public static bool operator >=(ReceivedNotifyMessage a, ReceivedNotifyMessage b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}