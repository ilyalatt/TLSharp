using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class InputAppEvent : ITlType, IEquatable<InputAppEvent>, IComparable<InputAppEvent>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x770656a8;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public double Time { get; }
            public string Type { get; }
            public long Peer { get; }
            public string Data { get; }
            
            public Tag(
                double time,
                Some<string> type,
                long peer,
                Some<string> data
            ) {
                Time = time;
                Type = type;
                Peer = peer;
                Data = data;
            }
            
            (double, string, long, string) CmpTuple =>
                (Time, Type, Peer, Data);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Time: {Time}, Type: {Type}, Peer: {Peer}, Data: {Data})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Time, bw, WriteDouble);
                Write(Type, bw, WriteString);
                Write(Peer, bw, WriteLong);
                Write(Data, bw, WriteString);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var time = Read(br, ReadDouble);
                var type = Read(br, ReadString);
                var peer = Read(br, ReadLong);
                var data = Read(br, ReadString);
                return new Tag(time, type, peer, data);
            }
        }

        readonly ITlTypeTag _tag;
        InputAppEvent(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator InputAppEvent(Tag tag) => new InputAppEvent(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static InputAppEvent Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (InputAppEvent) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(InputAppEvent other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is InputAppEvent x && Equals(x);
        public static bool operator ==(InputAppEvent x, InputAppEvent y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InputAppEvent x, InputAppEvent y) => !(x == y);

        public int CompareTo(InputAppEvent other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputAppEvent x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputAppEvent x, InputAppEvent y) => x.CompareTo(y) <= 0;
        public static bool operator <(InputAppEvent x, InputAppEvent y) => x.CompareTo(y) < 0;
        public static bool operator >(InputAppEvent x, InputAppEvent y) => x.CompareTo(y) > 0;
        public static bool operator >=(InputAppEvent x, InputAppEvent y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"InputAppEvent.{_tag.GetType().Name}{_tag}";
    }
}