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
        public sealed class EmptyTag : ITlTypeTag, IEquatable<EmptyTag>, IComparable<EmptyTag>, IComparable
        {
            internal const uint TypeNumber = 0xadd53cb3;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public EmptyTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(EmptyTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is EmptyTag x && Equals(x);
            public static bool operator ==(EmptyTag x, EmptyTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(EmptyTag x, EmptyTag y) => !(x == y);

            public int CompareTo(EmptyTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is EmptyTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(EmptyTag x, EmptyTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(EmptyTag x, EmptyTag y) => x.CompareTo(y) < 0;
            public static bool operator >(EmptyTag x, EmptyTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(EmptyTag x, EmptyTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {

            }
            
            internal static EmptyTag DeserializeTag(BinaryReader br)
            {

                return new EmptyTag();
            }
        }

        public sealed class AllTag : ITlTypeTag, IEquatable<AllTag>, IComparable<AllTag>, IComparable
        {
            internal const uint TypeNumber = 0x6d1ded88;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            

            
            public AllTag(

            ) {

            }
            
            Unit CmpTuple =>
                Unit.Default;

            public bool Equals(AllTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is AllTag x && Equals(x);
            public static bool operator ==(AllTag x, AllTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(AllTag x, AllTag y) => !(x == y);

            public int CompareTo(AllTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is AllTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(AllTag x, AllTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(AllTag x, AllTag y) => x.CompareTo(y) < 0;
            public static bool operator >(AllTag x, AllTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(AllTag x, AllTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"()";
            
            
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
                case EmptyTag.TypeNumber: return (PeerNotifyEvents) EmptyTag.DeserializeTag(br);
                case AllTag.TypeNumber: return (PeerNotifyEvents) AllTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { EmptyTag.TypeNumber, AllTag.TypeNumber });
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

        public bool Equals(PeerNotifyEvents other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PeerNotifyEvents x && Equals(x);
        public static bool operator ==(PeerNotifyEvents x, PeerNotifyEvents y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PeerNotifyEvents x, PeerNotifyEvents y) => !(x == y);

        public int CompareTo(PeerNotifyEvents other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PeerNotifyEvents x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PeerNotifyEvents x, PeerNotifyEvents y) => x.CompareTo(y) <= 0;
        public static bool operator <(PeerNotifyEvents x, PeerNotifyEvents y) => x.CompareTo(y) < 0;
        public static bool operator >(PeerNotifyEvents x, PeerNotifyEvents y) => x.CompareTo(y) > 0;
        public static bool operator >=(PeerNotifyEvents x, PeerNotifyEvents y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PeerNotifyEvents.{_tag.GetType().Name}{_tag}";
    }
}