using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types.Auth
{
    public sealed class SentCodeType : ITlType, IEquatable<SentCodeType>, IComparable<SentCodeType>, IComparable
    {
        public sealed class AppTag : Record<AppTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3dbb5986;
            
            public int Length { get; }
            
            public AppTag(
                int length
            ) {
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Length, bw, WriteInt);
            }
            
            internal static AppTag DeserializeTag(BinaryReader br)
            {
                var length = Read(br, ReadInt);
                return new AppTag(length);
            }
        }

        public sealed class SmsTag : Record<SmsTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xc000bba2;
            
            public int Length { get; }
            
            public SmsTag(
                int length
            ) {
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Length, bw, WriteInt);
            }
            
            internal static SmsTag DeserializeTag(BinaryReader br)
            {
                var length = Read(br, ReadInt);
                return new SmsTag(length);
            }
        }

        public sealed class CallTag : Record<CallTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x5353e5a7;
            
            public int Length { get; }
            
            public CallTag(
                int length
            ) {
                Length = length;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Length, bw, WriteInt);
            }
            
            internal static CallTag DeserializeTag(BinaryReader br)
            {
                var length = Read(br, ReadInt);
                return new CallTag(length);
            }
        }

        public sealed class FlashCallTag : Record<FlashCallTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xab03c6d9;
            
            public string Pattern { get; }
            
            public FlashCallTag(
                Some<string> pattern
            ) {
                Pattern = pattern;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pattern, bw, WriteString);
            }
            
            internal static FlashCallTag DeserializeTag(BinaryReader br)
            {
                var pattern = Read(br, ReadString);
                return new FlashCallTag(pattern);
            }
        }

        readonly ITlTypeTag _tag;
        SentCodeType(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SentCodeType(AppTag tag) => new SentCodeType(tag);
        public static explicit operator SentCodeType(SmsTag tag) => new SentCodeType(tag);
        public static explicit operator SentCodeType(CallTag tag) => new SentCodeType(tag);
        public static explicit operator SentCodeType(FlashCallTag tag) => new SentCodeType(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SentCodeType Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x3dbb5986: return (SentCodeType) AppTag.DeserializeTag(br);
                case 0xc000bba2: return (SentCodeType) SmsTag.DeserializeTag(br);
                case 0x5353e5a7: return (SentCodeType) CallTag.DeserializeTag(br);
                case 0xab03c6d9: return (SentCodeType) FlashCallTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x3dbb5986, 0xc000bba2, 0x5353e5a7, 0xab03c6d9 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<AppTag, T> appTag = null,
            Func<SmsTag, T> smsTag = null,
            Func<CallTag, T> callTag = null,
            Func<FlashCallTag, T> flashCallTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case AppTag x when appTag != null: return appTag(x);
                case SmsTag x when smsTag != null: return smsTag(x);
                case CallTag x when callTag != null: return callTag(x);
                case FlashCallTag x when flashCallTag != null: return flashCallTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<AppTag, T> appTag,
            Func<SmsTag, T> smsTag,
            Func<CallTag, T> callTag,
            Func<FlashCallTag, T> flashCallTag
        ) => Match(
            () => throw new Exception("WTF"),
            appTag ?? throw new ArgumentNullException(nameof(appTag)),
            smsTag ?? throw new ArgumentNullException(nameof(smsTag)),
            callTag ?? throw new ArgumentNullException(nameof(callTag)),
            flashCallTag ?? throw new ArgumentNullException(nameof(flashCallTag))
        );

        public bool Equals(SentCodeType other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is SentCodeType x && Equals(x);
        public static bool operator ==(SentCodeType a, SentCodeType b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(SentCodeType a, SentCodeType b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case AppTag _: return 0;
                case SmsTag _: return 1;
                case CallTag _: return 2;
                case FlashCallTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(SentCodeType other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SentCodeType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SentCodeType a, SentCodeType b) => a.CompareTo(b) <= 0;
        public static bool operator <(SentCodeType a, SentCodeType b) => a.CompareTo(b) < 0;
        public static bool operator >(SentCodeType a, SentCodeType b) => a.CompareTo(b) > 0;
        public static bool operator >=(SentCodeType a, SentCodeType b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}