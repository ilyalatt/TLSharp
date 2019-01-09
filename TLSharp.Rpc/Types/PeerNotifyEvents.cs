using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PeerNotifyEvents : ITlType, IEquatable<PeerNotifyEvents>, IComparable<PeerNotifyEvents>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xadd53cb3;
            

            
            public EmptyTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class AllTag : Record<AllTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x6d1ded88;
            

            
            public AllTag(

            ) {

            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static AllTag DeserializeTag(BinaryReader br)
            {

                return new AllTag();
            }
        }

        readonly ITlTypeTag _tag;
        PeerNotifyEvents(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PeerNotifyEvents(EmptyTag tag) => new PeerNotifyEvents(tag);
        public static explicit operator PeerNotifyEvents(AllTag tag) => new PeerNotifyEvents(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PeerNotifyEvents Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xadd53cb3: return (PeerNotifyEvents) EmptyTag.DeserializeTag(br);
                case 0x6d1ded88: return (PeerNotifyEvents) AllTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xadd53cb3, 0x6d1ded88 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<AllTag, T> allTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case AllTag x when allTag != null: return allTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<AllTag, T> allTag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            allTag ?? throw new ArgumentNullException(nameof(allTag))
        );

        public bool Equals(PeerNotifyEvents other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is PeerNotifyEvents x && Equals(x);
        public static bool operator ==(PeerNotifyEvents a, PeerNotifyEvents b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(PeerNotifyEvents a, PeerNotifyEvents b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case AllTag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(PeerNotifyEvents other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PeerNotifyEvents x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PeerNotifyEvents a, PeerNotifyEvents b) => a.CompareTo(b) <= 0;
        public static bool operator <(PeerNotifyEvents a, PeerNotifyEvents b) => a.CompareTo(b) < 0;
        public static bool operator >(PeerNotifyEvents a, PeerNotifyEvents b) => a.CompareTo(b) > 0;
        public static bool operator >=(PeerNotifyEvents a, PeerNotifyEvents b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}