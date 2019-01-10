using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class FutureSalts : ITlType, IEquatable<FutureSalts>, IComparable<FutureSalts>, IComparable
    {
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0xae500895;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public long ReqMsgId { get; }
            public int Now { get; }
            public Arr<T.FutureSalt> Salts { get; }
            
            public Tag(
                long reqMsgId,
                int now,
                Some<Arr<T.FutureSalt>> salts
            ) {
                ReqMsgId = reqMsgId;
                Now = now;
                Salts = salts;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(ReqMsgId, bw, WriteLong);
                Write(Now, bw, WriteInt);
                Write(Salts, bw, WriteVector<T.FutureSalt>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var reqMsgId = Read(br, ReadLong);
                var now = Read(br, ReadInt);
                var salts = Read(br, ReadVector(T.FutureSalt.Deserialize));
                return new Tag(reqMsgId, now, salts);
            }
        }

        readonly ITlTypeTag _tag;
        FutureSalts(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator FutureSalts(Tag tag) => new FutureSalts(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static FutureSalts Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (FutureSalts) Tag.DeserializeTag(br);
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

        public bool Equals(FutureSalts other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is FutureSalts x && Equals(x);
        public static bool operator ==(FutureSalts a, FutureSalts b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(FutureSalts a, FutureSalts b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(FutureSalts other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is FutureSalts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FutureSalts a, FutureSalts b) => a.CompareTo(b) <= 0;
        public static bool operator <(FutureSalts a, FutureSalts b) => a.CompareTo(b) < 0;
        public static bool operator >(FutureSalts a, FutureSalts b) => a.CompareTo(b) > 0;
        public static bool operator >=(FutureSalts a, FutureSalts b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}