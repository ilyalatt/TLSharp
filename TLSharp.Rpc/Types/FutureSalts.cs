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
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xae500895;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long ReqMsgId;
            public readonly int Now;
            public readonly Arr<T.FutureSalt> Salts;
            
            public Tag(
                long reqMsgId,
                int now,
                Some<Arr<T.FutureSalt>> salts
            ) {
                ReqMsgId = reqMsgId;
                Now = now;
                Salts = salts;
            }
            
            (long, int, Arr<T.FutureSalt>) CmpTuple =>
                (ReqMsgId, Now, Salts);

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

            public override string ToString() => $"(ReqMsgId: {ReqMsgId}, Now: {Now}, Salts: {Salts})";
            
            
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

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(FutureSalts other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is FutureSalts x && Equals(x);
        public static bool operator ==(FutureSalts x, FutureSalts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FutureSalts x, FutureSalts y) => !(x == y);

        public int CompareTo(FutureSalts other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is FutureSalts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FutureSalts x, FutureSalts y) => x.CompareTo(y) <= 0;
        public static bool operator <(FutureSalts x, FutureSalts y) => x.CompareTo(y) < 0;
        public static bool operator >(FutureSalts x, FutureSalts y) => x.CompareTo(y) > 0;
        public static bool operator >=(FutureSalts x, FutureSalts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"FutureSalts.{_tag.GetType().Name}{_tag}";
    }
}