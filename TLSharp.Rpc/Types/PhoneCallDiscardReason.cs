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
        public sealed class MissedTag : Record<MissedTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x85e42301;
            

            
            public MissedTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static MissedTag DeserializeTag(BinaryReader br)
            {

                return new MissedTag();
            }
        }

        public sealed class DisconnectTag : Record<DisconnectTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe095c1a0;
            

            
            public DisconnectTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static DisconnectTag DeserializeTag(BinaryReader br)
            {

                return new DisconnectTag();
            }
        }

        public sealed class HangupTag : Record<HangupTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x57adc690;
            

            
            public HangupTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static HangupTag DeserializeTag(BinaryReader br)
            {

                return new HangupTag();
            }
        }

        public sealed class BusyTag : Record<BusyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xfaf7e8c9;
            

            
            public BusyTag(

            ) {

            }
            
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
                case 0x85e42301: return (PhoneCallDiscardReason) MissedTag.DeserializeTag(br);
                case 0xe095c1a0: return (PhoneCallDiscardReason) DisconnectTag.DeserializeTag(br);
                case 0x57adc690: return (PhoneCallDiscardReason) HangupTag.DeserializeTag(br);
                case 0xfaf7e8c9: return (PhoneCallDiscardReason) BusyTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x85e42301, 0xe095c1a0, 0x57adc690, 0xfaf7e8c9 });
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

        public bool Equals(PhoneCallDiscardReason other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PhoneCallDiscardReason x && Equals(x);
        public static bool operator ==(PhoneCallDiscardReason a, PhoneCallDiscardReason b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PhoneCallDiscardReason a, PhoneCallDiscardReason b) => !(a == b);

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

        public int CompareTo(PhoneCallDiscardReason other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PhoneCallDiscardReason x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PhoneCallDiscardReason a, PhoneCallDiscardReason b) => a.CompareTo(b) <= 0;
        public static bool operator <(PhoneCallDiscardReason a, PhoneCallDiscardReason b) => a.CompareTo(b) < 0;
        public static bool operator >(PhoneCallDiscardReason a, PhoneCallDiscardReason b) => a.CompareTo(b) > 0;
        public static bool operator >=(PhoneCallDiscardReason a, PhoneCallDiscardReason b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}