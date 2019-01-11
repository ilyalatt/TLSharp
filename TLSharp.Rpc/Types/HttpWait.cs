using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class HttpWait : ITlType, IEquatable<HttpWait>, IComparable<HttpWait>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x9299359f;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public int MaxDelay { get; }
            public int WaitAfter { get; }
            public int MaxWait { get; }
            
            public Tag(
                int maxDelay,
                int waitAfter,
                int maxWait
            ) {
                MaxDelay = maxDelay;
                WaitAfter = waitAfter;
                MaxWait = maxWait;
            }
            
            (int, int, int) CmpTuple =>
                (MaxDelay, WaitAfter, MaxWait);

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

            public override string ToString() => $"(MaxDelay: {MaxDelay}, WaitAfter: {WaitAfter}, MaxWait: {MaxWait})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaxDelay, bw, WriteInt);
                Write(WaitAfter, bw, WriteInt);
                Write(MaxWait, bw, WriteInt);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var maxDelay = Read(br, ReadInt);
                var waitAfter = Read(br, ReadInt);
                var maxWait = Read(br, ReadInt);
                return new Tag(maxDelay, waitAfter, maxWait);
            }
        }

        readonly ITlTypeTag _tag;
        HttpWait(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator HttpWait(Tag tag) => new HttpWait(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static HttpWait Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (HttpWait) Tag.DeserializeTag(br);
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

        public bool Equals(HttpWait other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is HttpWait x && Equals(x);
        public static bool operator ==(HttpWait x, HttpWait y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(HttpWait x, HttpWait y) => !(x == y);

        public int CompareTo(HttpWait other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is HttpWait x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(HttpWait x, HttpWait y) => x.CompareTo(y) <= 0;
        public static bool operator <(HttpWait x, HttpWait y) => x.CompareTo(y) < 0;
        public static bool operator >(HttpWait x, HttpWait y) => x.CompareTo(y) > 0;
        public static bool operator >=(HttpWait x, HttpWait y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"HttpWait.{_tag.GetType().Name}{_tag}";
    }
}