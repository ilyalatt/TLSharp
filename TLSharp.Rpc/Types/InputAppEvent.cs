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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x770656a8;
            
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
                case 0x770656a8: return (InputAppEvent) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x770656a8 });
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

        public bool Equals(InputAppEvent other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is InputAppEvent x && Equals(x);
        public static bool operator ==(InputAppEvent a, InputAppEvent b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(InputAppEvent a, InputAppEvent b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(InputAppEvent other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is InputAppEvent x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InputAppEvent a, InputAppEvent b) => a.CompareTo(b) <= 0;
        public static bool operator <(InputAppEvent a, InputAppEvent b) => a.CompareTo(b) < 0;
        public static bool operator >(InputAppEvent a, InputAppEvent b) => a.CompareTo(b) > 0;
        public static bool operator >=(InputAppEvent a, InputAppEvent b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}