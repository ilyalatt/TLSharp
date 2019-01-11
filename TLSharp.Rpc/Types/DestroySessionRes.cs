using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class DestroySessionRes : ITlType, IEquatable<DestroySessionRes>, IComparable<DestroySessionRes>, IComparable
    {
        public sealed class OkTag : ITlTypeTag, IEquatable<OkTag>, IComparable<OkTag>, IComparable
        {
            internal const uint TypeNumber = 0xe22045fc;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long SessionId;
            
            public OkTag(
                long sessionId
            ) {
                SessionId = sessionId;
            }
            
            long CmpTuple =>
                SessionId;

            public bool Equals(OkTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is OkTag x && Equals(x);
            public static bool operator ==(OkTag x, OkTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(OkTag x, OkTag y) => !(x == y);

            public int CompareTo(OkTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is OkTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(OkTag x, OkTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(OkTag x, OkTag y) => x.CompareTo(y) < 0;
            public static bool operator >(OkTag x, OkTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(OkTag x, OkTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(SessionId: {SessionId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(SessionId, bw, WriteLong);
            }
            
            internal static OkTag DeserializeTag(BinaryReader br)
            {
                var sessionId = Read(br, ReadLong);
                return new OkTag(sessionId);
            }
        }

        public sealed class NoneTag : ITlTypeTag, IEquatable<NoneTag>, IComparable<NoneTag>, IComparable
        {
            internal const uint TypeNumber = 0x62d350c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly long SessionId;
            
            public NoneTag(
                long sessionId
            ) {
                SessionId = sessionId;
            }
            
            long CmpTuple =>
                SessionId;

            public bool Equals(NoneTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is NoneTag x && Equals(x);
            public static bool operator ==(NoneTag x, NoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoneTag x, NoneTag y) => !(x == y);

            public int CompareTo(NoneTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is NoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoneTag x, NoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoneTag x, NoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoneTag x, NoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoneTag x, NoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(SessionId: {SessionId})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(SessionId, bw, WriteLong);
            }
            
            internal static NoneTag DeserializeTag(BinaryReader br)
            {
                var sessionId = Read(br, ReadLong);
                return new NoneTag(sessionId);
            }
        }

        readonly ITlTypeTag _tag;
        DestroySessionRes(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DestroySessionRes(OkTag tag) => new DestroySessionRes(tag);
        public static explicit operator DestroySessionRes(NoneTag tag) => new DestroySessionRes(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DestroySessionRes Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case OkTag.TypeNumber: return (DestroySessionRes) OkTag.DeserializeTag(br);
                case NoneTag.TypeNumber: return (DestroySessionRes) NoneTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { OkTag.TypeNumber, NoneTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<OkTag, T> okTag = null,
            Func<NoneTag, T> noneTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case OkTag x when okTag != null: return okTag(x);
                case NoneTag x when noneTag != null: return noneTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<OkTag, T> okTag,
            Func<NoneTag, T> noneTag
        ) => Match(
            () => throw new Exception("WTF"),
            okTag ?? throw new ArgumentNullException(nameof(okTag)),
            noneTag ?? throw new ArgumentNullException(nameof(noneTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case OkTag _: return 0;
                case NoneTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(DestroySessionRes other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is DestroySessionRes x && Equals(x);
        public static bool operator ==(DestroySessionRes x, DestroySessionRes y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DestroySessionRes x, DestroySessionRes y) => !(x == y);

        public int CompareTo(DestroySessionRes other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is DestroySessionRes x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DestroySessionRes x, DestroySessionRes y) => x.CompareTo(y) <= 0;
        public static bool operator <(DestroySessionRes x, DestroySessionRes y) => x.CompareTo(y) < 0;
        public static bool operator >(DestroySessionRes x, DestroySessionRes y) => x.CompareTo(y) > 0;
        public static bool operator >=(DestroySessionRes x, DestroySessionRes y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"DestroySessionRes.{_tag.GetType().Name}{_tag}";
    }
}