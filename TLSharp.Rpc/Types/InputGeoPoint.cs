using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputGeoPoint : ITlType, IEquatable<InputGeoPoint>, IComparable<InputGeoPoint>, IComparable
    {
        public sealed class EmptyTag : Record<EmptyTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xe4c123d6;
            

            
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

        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xf3b7acc9;
            
            public double Lat { get; }
            public double Long { get; }
            
            public Tag(
                double lat,
                double @long
            ) {
                Lat = lat;
                Long = @long;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Lat, bw, WriteDouble);
                Write(Long, bw, WriteDouble);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var lat = Read(br, ReadDouble);
                var @long = Read(br, ReadDouble);
                return new Tag(lat, @long);
            }
        }

        readonly ITlTypeTag _tag;
        InputGeoPoint(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputGeoPoint(EmptyTag tag) => new InputGeoPoint(tag);
        public static explicit operator InputGeoPoint(Tag tag) => new InputGeoPoint(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputGeoPoint Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0xe4c123d6: return (InputGeoPoint) EmptyTag.DeserializeTag(br);
                case 0xf3b7acc9: return (InputGeoPoint) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0xe4c123d6, 0xf3b7acc9 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<EmptyTag, T> emptyTag = null,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case EmptyTag x when emptyTag != null: return emptyTag(x);
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<EmptyTag, T> emptyTag,
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            emptyTag ?? throw new ArgumentNullException(nameof(emptyTag)),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        public bool Equals(InputGeoPoint other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputGeoPoint x && Equals(x);
        public static bool operator ==(InputGeoPoint a, InputGeoPoint b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputGeoPoint a, InputGeoPoint b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case EmptyTag _: return 0;
                case Tag _: return 1;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputGeoPoint other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputGeoPoint x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputGeoPoint a, InputGeoPoint b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputGeoPoint a, InputGeoPoint b) => a.CompareTo(b) < 0;
        public static bool operator >(InputGeoPoint a, InputGeoPoint b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputGeoPoint a, InputGeoPoint b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}