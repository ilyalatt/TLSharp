using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class MsgResendReq : ITlType, IEquatable<MsgResendReq>, IComparable<MsgResendReq>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x7d861a08;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<long> MsgIds { get; }
            
            public Tag(
                Some<Arr<long>> msgIds
            ) {
                MsgIds = msgIds;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MsgIds, bw, WriteVector<long>(WriteLong));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var msgIds = Read(br, ReadVector(ReadLong));
                return new Tag(msgIds);
            }
        }

        readonly ITlTypeTag _tag;
        MsgResendReq(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator MsgResendReq(Tag tag) => new MsgResendReq(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static MsgResendReq Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (MsgResendReq) Tag.DeserializeTag(br);
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

        public bool Equals(MsgResendReq other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is MsgResendReq x && Equals(x);
        public static bool operator ==(MsgResendReq a, MsgResendReq b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(MsgResendReq a, MsgResendReq b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(MsgResendReq other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is MsgResendReq x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MsgResendReq a, MsgResendReq b) => a.CompareTo(b) <= 0;
        public static bool operator <(MsgResendReq a, MsgResendReq b) => a.CompareTo(b) < 0;
        public static bool operator >(MsgResendReq a, MsgResendReq b) => a.CompareTo(b) > 0;
        public static bool operator >=(MsgResendReq a, MsgResendReq b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}