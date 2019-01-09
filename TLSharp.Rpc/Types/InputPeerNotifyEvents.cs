using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputPeerNotifyEvents : ITlType, IEquatable<InputPeerNotifyEvents>, IComparable<InputPeerNotifyEvents>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf03064d8;
            

            
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
            uint ITlTypeTag.TypeNumber => 0xe86a2c74;
            

            
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
        InputPeerNotifyEvents(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputPeerNotifyEvents(EmptyTag tag) => new InputPeerNotifyEvents(tag);
        public static explicit operator InputPeerNotifyEvents(AllTag tag) => new InputPeerNotifyEvents(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputPeerNotifyEvents Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xf03064d8: return (InputPeerNotifyEvents) EmptyTag.DeserializeTag(br);
                case 0xe86a2c74: return (InputPeerNotifyEvents) AllTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xf03064d8, 0xe86a2c74 });
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

        public bool Equals(InputPeerNotifyEvents other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputPeerNotifyEvents x && Equals(x);
        public static bool operator ==(InputPeerNotifyEvents a, InputPeerNotifyEvents b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputPeerNotifyEvents a, InputPeerNotifyEvents b) => !(a == b);

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

        public int CompareTo(InputPeerNotifyEvents other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputPeerNotifyEvents x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputPeerNotifyEvents a, InputPeerNotifyEvents b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputPeerNotifyEvents a, InputPeerNotifyEvents b) => a.CompareTo(b) < 0;
        public static bool operator >(InputPeerNotifyEvents a, InputPeerNotifyEvents b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputPeerNotifyEvents a, InputPeerNotifyEvents b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}