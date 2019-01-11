using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class DestroyAuthKeyRes : ITlType, IEquatable<DestroyAuthKeyRes>, IComparable<DestroyAuthKeyRes>, IComparable
    {
        public sealed class OkTag : ITlTypeTag, IEquatable<OkTag>, IComparable<OkTag>, IComparable
        {
            internal const uint TypeNumber = 0xf660e1d4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public OkTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(OkTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is OkTag x && Equals(x);
            public static bool operator ==(OkTag x, OkTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(OkTag x, OkTag y) => !(x == y);

            public int CompareTo(OkTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is OkTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(OkTag x, OkTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(OkTag x, OkTag y) => x.CompareTo(y) < 0;
            public static bool operator >(OkTag x, OkTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(OkTag x, OkTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static OkTag DeserializeTag(BinaryReader br)
            {

                return new OkTag();
            }
        }

        public sealed class NoneTag : ITlTypeTag, IEquatable<NoneTag>, IComparable<NoneTag>, IComparable
        {
            internal const uint TypeNumber = 0x0a9f2259;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public NoneTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(NoneTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is NoneTag x && Equals(x);
            public static bool operator ==(NoneTag x, NoneTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(NoneTag x, NoneTag y) => !(x == y);

            public int CompareTo(NoneTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is NoneTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(NoneTag x, NoneTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(NoneTag x, NoneTag y) => x.CompareTo(y) < 0;
            public static bool operator >(NoneTag x, NoneTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(NoneTag x, NoneTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NoneTag DeserializeTag(BinaryReader br)
            {

                return new NoneTag();
            }
        }

        public sealed class FailTag : ITlTypeTag, IEquatable<FailTag>, IComparable<FailTag>, IComparable
        {
            internal const uint TypeNumber = 0xea109b13;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public FailTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(FailTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is FailTag x && Equals(x);
            public static bool operator ==(FailTag x, FailTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FailTag x, FailTag y) => !(x == y);

            public int CompareTo(FailTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is FailTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FailTag x, FailTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FailTag x, FailTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FailTag x, FailTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FailTag x, FailTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static FailTag DeserializeTag(BinaryReader br)
            {

                return new FailTag();
            }
        }

        readonly ITlTypeTag _tag;
        DestroyAuthKeyRes(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator DestroyAuthKeyRes(OkTag tag) => new DestroyAuthKeyRes(tag);
        public static explicit operator DestroyAuthKeyRes(NoneTag tag) => new DestroyAuthKeyRes(tag);
        public static explicit operator DestroyAuthKeyRes(FailTag tag) => new DestroyAuthKeyRes(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static DestroyAuthKeyRes Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case OkTag.TypeNumber: return (DestroyAuthKeyRes) OkTag.DeserializeTag(br);
                case NoneTag.TypeNumber: return (DestroyAuthKeyRes) NoneTag.DeserializeTag(br);
                case FailTag.TypeNumber: return (DestroyAuthKeyRes) FailTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { OkTag.TypeNumber, NoneTag.TypeNumber, FailTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<OkTag, T> okTag = null,
            Func<NoneTag, T> noneTag = null,
            Func<FailTag, T> failTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case OkTag x when okTag != null: return okTag(x);
                case NoneTag x when noneTag != null: return noneTag(x);
                case FailTag x when failTag != null: return failTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<OkTag, T> okTag,
            Func<NoneTag, T> noneTag,
            Func<FailTag, T> failTag
        ) => Match(
            () => throw new Exception("WTF"),
            okTag ?? throw new ArgumentNullException(nameof(okTag)),
            noneTag ?? throw new ArgumentNullException(nameof(noneTag)),
            failTag ?? throw new ArgumentNullException(nameof(failTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case OkTag _: return 0;
                case NoneTag _: return 1;
                case FailTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(DestroyAuthKeyRes other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is DestroyAuthKeyRes x && Equals(x);
        public static bool operator ==(DestroyAuthKeyRes x, DestroyAuthKeyRes y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DestroyAuthKeyRes x, DestroyAuthKeyRes y) => !(x == y);

        public int CompareTo(DestroyAuthKeyRes other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DestroyAuthKeyRes x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DestroyAuthKeyRes x, DestroyAuthKeyRes y) => x.CompareTo(y) <= 0;
        public static bool operator <(DestroyAuthKeyRes x, DestroyAuthKeyRes y) => x.CompareTo(y) < 0;
        public static bool operator >(DestroyAuthKeyRes x, DestroyAuthKeyRes y) => x.CompareTo(y) > 0;
        public static bool operator >=(DestroyAuthKeyRes x, DestroyAuthKeyRes y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"DestroyAuthKeyRes.{_tag.GetType().Name}{_tag}";
    }
}