using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Pong : ITlType, IEquatable<Pong>, IComparable<Pong>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x347773c5;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long MsgId { get; }
            public long PingId { get; }
            
            public Tag(
                long msgId,
                long pingId
            ) {
                MsgId = msgId;
                PingId = pingId;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MsgId, bw, WriteLong);
                Write(PingId, bw, WriteLong);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var msgId = Read(br, ReadLong);
                var pingId = Read(br, ReadLong);
                return new Tag(msgId, pingId);
            }
        }

        readonly ITlTypeTag _tag;
        Pong(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Pong(Tag tag) => new Pong(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Pong Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Pong) Tag.DeserializeTag(br);
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

        public bool Equals(Pong other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is Pong x && Equals(x);
        public static bool operator ==(Pong a, Pong b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(Pong a, Pong b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(Pong other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Pong x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Pong a, Pong b) => a.CompareTo(b) <= 0;
        public static bool operator <(Pong a, Pong b) => a.CompareTo(b) < 0;
        public static bool operator >(Pong a, Pong b) => a.CompareTo(b) > 0;
        public static bool operator >=(Pong a, Pong b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}