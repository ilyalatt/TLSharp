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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x9299359f;
            
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
                case 0x9299359f: return (HttpWait) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x9299359f });
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

        public bool Equals(HttpWait other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is HttpWait x && Equals(x);
        public static bool operator ==(HttpWait a, HttpWait b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(HttpWait a, HttpWait b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(HttpWait other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is HttpWait x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(HttpWait a, HttpWait b) => a.CompareTo(b) <= 0;
        public static bool operator <(HttpWait a, HttpWait b) => a.CompareTo(b) < 0;
        public static bool operator >(HttpWait a, HttpWait b) => a.CompareTo(b) > 0;
        public static bool operator >=(HttpWait a, HttpWait b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}