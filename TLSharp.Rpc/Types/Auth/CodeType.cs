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
        public sealed class SmsTag : Record<SmsTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x72a3158c;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public SmsTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static SmsTag DeserializeTag(BinaryReader br)
            {

                return new SmsTag();
            }
        }

        public sealed class CallTag : Record<CallTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x741cd3e3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public CallTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static CallTag DeserializeTag(BinaryReader br)
            {

                return new CallTag();
            }
        }

        public sealed class FlashCallTag : Record<FlashCallTag>, ITlTypeTag
        {
            internal const uint TypeNumber = 0x226ccefb;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public FlashCallTag(

            ) {

            }
            
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

        public bool Equals(CodeType other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is CodeType x && Equals(x);
        public static bool operator ==(CodeType a, CodeType b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(CodeType a, CodeType b) => !(a == b);

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

        public int CompareTo(CodeType other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CodeType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CodeType a, CodeType b) => a.CompareTo(b) <= 0;
        public static bool operator <(CodeType a, CodeType b) => a.CompareTo(b) < 0;
        public static bool operator >(CodeType a, CodeType b) => a.CompareTo(b) > 0;
        public static bool operator >=(CodeType a, CodeType b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}