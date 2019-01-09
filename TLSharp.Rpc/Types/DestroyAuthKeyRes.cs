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
        public sealed class OkTag : Record<OkTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf660e1d4;
            

            
            public OkTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static OkTag DeserializeTag(BinaryReader br)
            {

                return new OkTag();
            }
        }

        public sealed class NoneTag : Record<NoneTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x0a9f2259;
            

            
            public NoneTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static NoneTag DeserializeTag(BinaryReader br)
            {

                return new NoneTag();
            }
        }

        public sealed class FailTag : Record<FailTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xea109b13;
            

            
            public FailTag(

            ) {

            }
            
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
                case 0xf660e1d4: return (DestroyAuthKeyRes) OkTag.DeserializeTag(br);
                case 0x0a9f2259: return (DestroyAuthKeyRes) NoneTag.DeserializeTag(br);
                case 0xea109b13: return (DestroyAuthKeyRes) FailTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xf660e1d4, 0x0a9f2259, 0xea109b13 });
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

        public bool Equals(DestroyAuthKeyRes other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is DestroyAuthKeyRes x && Equals(x);
        public static bool operator ==(DestroyAuthKeyRes a, DestroyAuthKeyRes b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(DestroyAuthKeyRes a, DestroyAuthKeyRes b) => !(a == b);

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

        public int CompareTo(DestroyAuthKeyRes other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DestroyAuthKeyRes x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DestroyAuthKeyRes a, DestroyAuthKeyRes b) => a.CompareTo(b) <= 0;
        public static bool operator <(DestroyAuthKeyRes a, DestroyAuthKeyRes b) => a.CompareTo(b) < 0;
        public static bool operator >(DestroyAuthKeyRes a, DestroyAuthKeyRes b) => a.CompareTo(b) > 0;
        public static bool operator >=(DestroyAuthKeyRes a, DestroyAuthKeyRes b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}