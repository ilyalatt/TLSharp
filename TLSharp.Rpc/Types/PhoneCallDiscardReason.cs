using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PhoneCallDiscardReason : ITlType, IEquatable<PhoneCallDiscardReason>, IComparable<PhoneCallDiscardReason>, IComparable
    {
        public sealed class MissedTag : ITlTypeTag, IEquatable<MissedTag>, IComparable<MissedTag>, IComparable
        {
            internal const uint TypeNumber = 0x85e42301;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public MissedTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(MissedTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is MissedTag x && Equals(x);
            public static bool operator ==(MissedTag x, MissedTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(MissedTag x, MissedTag y) => !(x == y);

            public int CompareTo(MissedTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is MissedTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(MissedTag x, MissedTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(MissedTag x, MissedTag y) => x.CompareTo(y) < 0;
            public static bool operator >(MissedTag x, MissedTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(MissedTag x, MissedTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static MissedTag DeserializeTag(BinaryReader br)
            {

                return new MissedTag();
            }
        }

        public sealed class DisconnectTag : ITlTypeTag, IEquatable<DisconnectTag>, IComparable<DisconnectTag>, IComparable
        {
            internal const uint TypeNumber = 0xe095c1a0;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public DisconnectTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(DisconnectTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DisconnectTag x && Equals(x);
            public static bool operator ==(DisconnectTag x, DisconnectTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DisconnectTag x, DisconnectTag y) => !(x == y);

            public int CompareTo(DisconnectTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DisconnectTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DisconnectTag x, DisconnectTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DisconnectTag x, DisconnectTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DisconnectTag x, DisconnectTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DisconnectTag x, DisconnectTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static DisconnectTag DeserializeTag(BinaryReader br)
            {

                return new DisconnectTag();
            }
        }

        public sealed class HangupTag : ITlTypeTag, IEquatable<HangupTag>, IComparable<HangupTag>, IComparable
        {
            internal const uint TypeNumber = 0x57adc690;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public HangupTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(HangupTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is HangupTag x && Equals(x);
            public static bool operator ==(HangupTag x, HangupTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(HangupTag x, HangupTag y) => !(x == y);

            public int CompareTo(HangupTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is HangupTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(HangupTag x, HangupTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(HangupTag x, HangupTag y) => x.CompareTo(y) < 0;
            public static bool operator >(HangupTag x, HangupTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(HangupTag x, HangupTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HangupTag DeserializeTag(BinaryReader br)
            {

                return new HangupTag();
            }
        }

        public sealed class BusyTag : ITlTypeTag, IEquatable<BusyTag>, IComparable<BusyTag>, IComparable
        {
            internal const uint TypeNumber = 0xfaf7e8c9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public BusyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(BusyTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is BusyTag x && Equals(x);
            public static bool operator ==(BusyTag x, BusyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(BusyTag x, BusyTag y) => !(x == y);

            public int CompareTo(BusyTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is BusyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(BusyTag x, BusyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(BusyTag x, BusyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(BusyTag x, BusyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(BusyTag x, BusyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static BusyTag DeserializeTag(BinaryReader br)
            {

                return new BusyTag();
            }
        }

        readonly ITlTypeTag _tag;
        PhoneCallDiscardReason(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PhoneCallDiscardReason(MissedTag tag) => new PhoneCallDiscardReason(tag);
        public static explicit operator PhoneCallDiscardReason(DisconnectTag tag) => new PhoneCallDiscardReason(tag);
        public static explicit operator PhoneCallDiscardReason(HangupTag tag) => new PhoneCallDiscardReason(tag);
        public static explicit operator PhoneCallDiscardReason(BusyTag tag) => new PhoneCallDiscardReason(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PhoneCallDiscardReason Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case MissedTag.TypeNumber: return (PhoneCallDiscardReason) MissedTag.DeserializeTag(br);
                case DisconnectTag.TypeNumber: return (PhoneCallDiscardReason) DisconnectTag.DeserializeTag(br);
                case HangupTag.TypeNumber: return (PhoneCallDiscardReason) HangupTag.DeserializeTag(br);
                case BusyTag.TypeNumber: return (PhoneCallDiscardReason) BusyTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { MissedTag.TypeNumber, DisconnectTag.TypeNumber, HangupTag.TypeNumber, BusyTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<MissedTag, T> missedTag = null,
            Func<DisconnectTag, T> disconnectTag = null,
            Func<HangupTag, T> hangupTag = null,
            Func<BusyTag, T> busyTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case MissedTag x when missedTag != null: return missedTag(x);
                case DisconnectTag x when disconnectTag != null: return disconnectTag(x);
                case HangupTag x when hangupTag != null: return hangupTag(x);
                case BusyTag x when busyTag != null: return busyTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<MissedTag, T> missedTag,
            Func<DisconnectTag, T> disconnectTag,
            Func<HangupTag, T> hangupTag,
            Func<BusyTag, T> busyTag
        ) => Match(
            () => throw new Exception("WTF"),
            missedTag ?? throw new ArgumentNullException(nameof(missedTag)),
            disconnectTag ?? throw new ArgumentNullException(nameof(disconnectTag)),
            hangupTag ?? throw new ArgumentNullException(nameof(hangupTag)),
            busyTag ?? throw new ArgumentNullException(nameof(busyTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case MissedTag _: return 0;
                case DisconnectTag _: return 1;
                case HangupTag _: return 2;
                case BusyTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(PhoneCallDiscardReason other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PhoneCallDiscardReason x && Equals(x);
        public static bool operator ==(PhoneCallDiscardReason x, PhoneCallDiscardReason y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PhoneCallDiscardReason x, PhoneCallDiscardReason y) => !(x == y);

        public int CompareTo(PhoneCallDiscardReason other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhoneCallDiscardReason x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneCallDiscardReason x, PhoneCallDiscardReason y) => x.CompareTo(y) <= 0;
        public static bool operator <(PhoneCallDiscardReason x, PhoneCallDiscardReason y) => x.CompareTo(y) < 0;
        public static bool operator >(PhoneCallDiscardReason x, PhoneCallDiscardReason y) => x.CompareTo(y) > 0;
        public static bool operator >=(PhoneCallDiscardReason x, PhoneCallDiscardReason y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PhoneCallDiscardReason.{_tag.GetType().Name}{_tag}";
    }
}