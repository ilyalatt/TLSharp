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
        public sealed class AppTag : ITlTypeTag, IEquatable<AppTag>, IComparable<AppTag>, IComparable
        {
            internal const uint TypeNumber = 0x3dbb5986;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Length { get; }
            
            public AppTag(
                int length
            ) {
                Length = length;
            }
            
            int CmpTuple =>
                Length;

            public bool Equals(AppTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is AppTag x && Equals(x);
            public static bool operator ==(AppTag x, AppTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AppTag x, AppTag y) => !(x == y);

            public int CompareTo(AppTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is AppTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AppTag x, AppTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AppTag x, AppTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AppTag x, AppTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AppTag x, AppTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Length: {Length})";
            
            
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

        public sealed class SmsTag : ITlTypeTag, IEquatable<SmsTag>, IComparable<SmsTag>, IComparable
        {
            internal const uint TypeNumber = 0xc000bba2;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Length { get; }
            
            public SmsTag(
                int length
            ) {
                Length = length;
            }
            
            int CmpTuple =>
                Length;

            public bool Equals(SmsTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is SmsTag x && Equals(x);
            public static bool operator ==(SmsTag x, SmsTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(SmsTag x, SmsTag y) => !(x == y);

            public int CompareTo(SmsTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is SmsTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(SmsTag x, SmsTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(SmsTag x, SmsTag y) => x.CompareTo(y) < 0;
            public static bool operator >(SmsTag x, SmsTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(SmsTag x, SmsTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Length: {Length})";
            
            
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

        public sealed class CallTag : ITlTypeTag, IEquatable<CallTag>, IComparable<CallTag>, IComparable
        {
            internal const uint TypeNumber = 0x5353e5a7;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int Length { get; }
            
            public CallTag(
                int length
            ) {
                Length = length;
            }
            
            int CmpTuple =>
                Length;

            public bool Equals(CallTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is CallTag x && Equals(x);
            public static bool operator ==(CallTag x, CallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(CallTag x, CallTag y) => !(x == y);

            public int CompareTo(CallTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is CallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(CallTag x, CallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(CallTag x, CallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(CallTag x, CallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(CallTag x, CallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Length: {Length})";
            
            
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

        public sealed class FlashCallTag : ITlTypeTag, IEquatable<FlashCallTag>, IComparable<FlashCallTag>, IComparable
        {
            internal const uint TypeNumber = 0xab03c6d9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public string Pattern { get; }
            
            public FlashCallTag(
                Some<string> pattern
            ) {
                Pattern = pattern;
            }
            
            string CmpTuple =>
                Pattern;

            public bool Equals(FlashCallTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is FlashCallTag x && Equals(x);
            public static bool operator ==(FlashCallTag x, FlashCallTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(FlashCallTag x, FlashCallTag y) => !(x == y);

            public int CompareTo(FlashCallTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is FlashCallTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) < 0;
            public static bool operator >(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(FlashCallTag x, FlashCallTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Pattern: {Pattern})";
            
            
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
                case AppTag.TypeNumber: return (SentCodeType) AppTag.DeserializeTag(br);
                case SmsTag.TypeNumber: return (SentCodeType) SmsTag.DeserializeTag(br);
                case CallTag.TypeNumber: return (SentCodeType) CallTag.DeserializeTag(br);
                case FlashCallTag.TypeNumber: return (SentCodeType) FlashCallTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { AppTag.TypeNumber, SmsTag.TypeNumber, CallTag.TypeNumber, FlashCallTag.TypeNumber });
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

        public bool Equals(SentCodeType other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is SentCodeType x && Equals(x);
        public static bool operator ==(SentCodeType x, SentCodeType y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SentCodeType x, SentCodeType y) => !(x == y);

        public int CompareTo(SentCodeType other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SentCodeType x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SentCodeType x, SentCodeType y) => x.CompareTo(y) <= 0;
        public static bool operator <(SentCodeType x, SentCodeType y) => x.CompareTo(y) < 0;
        public static bool operator >(SentCodeType x, SentCodeType y) => x.CompareTo(y) > 0;
        public static bool operator >=(SentCodeType x, SentCodeType y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SentCodeType.{_tag.GetType().Name}{_tag}";
    }
}