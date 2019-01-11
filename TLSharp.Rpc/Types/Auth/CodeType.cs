using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Auth
{
    public sealed class CodeType : ITlType, IEquatable<CodeType>, IComparable<CodeType>, IComparable
    {
        public sealed class SmsTag : ITlTypeTag, IEquatable<SmsTag>, IComparable<SmsTag>, IComparable
        {
            internal const uint TypeNumber = 0x72a3158c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SmsTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(SmsTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is SmsTag x && Equals(x);
            public static bool operator ==(SmsTag x, SmsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SmsTag x, SmsTag y) => !(x == y);

            public int CompareTo(SmsTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is SmsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SmsTag x, SmsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SmsTag x, SmsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SmsTag x, SmsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SmsTag x, SmsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SmsTag DeserializeTag(BinaryReader br)
            {

                return new SmsTag();
            }
        }

        public sealed class CallTag : ITlTypeTag, IEquatable<CallTag>, IComparable<CallTag>, IComparable
        {
            internal const uint TypeNumber = 0x741cd3e3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public CallTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(CallTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is CallTag x && Equals(x);
            public static bool operator ==(CallTag x, CallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CallTag x, CallTag y) => !(x == y);

            public int CompareTo(CallTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is CallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CallTag x, CallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CallTag x, CallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CallTag x, CallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CallTag x, CallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static CallTag DeserializeTag(BinaryReader br)
            {

                return new CallTag();
            }
        }

        public sealed class FlashCallTag : ITlTypeTag, IEquatable<FlashCallTag>, IComparable<FlashCallTag>, IComparable
        {
            internal const uint TypeNumber = 0x226ccefb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public FlashCallTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(FlashCallTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is FlashCallTag x && Equals(x);
            public static bool operator ==(FlashCallTag x, FlashCallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FlashCallTag x, FlashCallTag y) => !(x == y);

            public int CompareTo(FlashCallTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is FlashCallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static FlashCallTag DeserializeTag(BinaryReader br)
            {

                return new FlashCallTag();
            }
        }

        readonly ITlTypeTag _tag;
        CodeType(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator CodeType(SmsTag tag) => new CodeType(tag);
        public static explicit operator CodeType(CallTag tag) => new CodeType(tag);
        public static explicit operator CodeType(FlashCallTag tag) => new CodeType(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static CodeType Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case SmsTag.TypeNumber: return (CodeType) SmsTag.DeserializeTag(br);
                case CallTag.TypeNumber: return (CodeType) CallTag.DeserializeTag(br);
                case FlashCallTag.TypeNumber: return (CodeType) FlashCallTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { SmsTag.TypeNumber, CallTag.TypeNumber, FlashCallTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<SmsTag, T> smsTag = null,
            Func<CallTag, T> callTag = null,
            Func<FlashCallTag, T> flashCallTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case SmsTag x when smsTag != null: return smsTag(x);
                case CallTag x when callTag != null: return callTag(x);
                case FlashCallTag x when flashCallTag != null: return flashCallTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<SmsTag, T> smsTag,
            Func<CallTag, T> callTag,
            Func<FlashCallTag, T> flashCallTag
        ) => Match(
            () => throw new Exception("WTF"),
            smsTag ?? throw new ArgumentNullException(nameof(smsTag)),
            callTag ?? throw new ArgumentNullException(nameof(callTag)),
            flashCallTag ?? throw new ArgumentNullException(nameof(flashCallTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case SmsTag _: return 0;
                case CallTag _: return 1;
                case FlashCallTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(CodeType other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is CodeType x && Equals(x);
        public static bool operator ==(CodeType x, CodeType y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CodeType x, CodeType y) => !(x == y);

        public int CompareTo(CodeType other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is CodeType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CodeType x, CodeType y) => x.CompareTo(y) <= 0;
        public static bool operator <(CodeType x, CodeType y) => x.CompareTo(y) < 0;
        public static bool operator >(CodeType x, CodeType y) => x.CompareTo(y) > 0;
        public static bool operator >=(CodeType x, CodeType y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"CodeType.{_tag.GetType().Name}{_tag}";
    }
}