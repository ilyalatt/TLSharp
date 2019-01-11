using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class PqInnerData : ITlType, IEquatable<PqInnerData>, IComparable<PqInnerData>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x83c95aec;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public Arr<byte> Pq { get; }
            public Arr<byte> P { get; }
            public Arr<byte> Q { get; }
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public Int256 NewNonce { get; }
            
            public Tag(
                Some<Arr<byte>> pq,
                Some<Arr<byte>> p,
                Some<Arr<byte>> q,
                Int128 nonce,
                Int128 serverNonce,
                Int256 newNonce
            ) {
                Pq = pq;
                P = p;
                Q = q;
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonce = newNonce;
            }
            
            (Arr<byte>, Arr<byte>, Arr<byte>, Int128, Int128, Int256) CmpTuple =>
                (Pq, P, Q, Nonce, ServerNonce, NewNonce);

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

            public override string ToString() => $"(Pq: {Pq}, P: {P}, Q: {Q}, Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonce: {NewNonce})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pq, bw, WriteBytes);
                Write(P, bw, WriteBytes);
                Write(Q, bw, WriteBytes);
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonce, bw, WriteInt256);
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var pq = Read(br, ReadBytes);
                var p = Read(br, ReadBytes);
                var q = Read(br, ReadBytes);
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonce = Read(br, ReadInt256);
                return new Tag(pq, p, q, nonce, serverNonce, newNonce);
            }
        }

        readonly ITlTypeTag _tag;
        PqInnerData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PqInnerData(Tag tag) => new PqInnerData(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static PqInnerData Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (PqInnerData) Tag.DeserializeTag(br);
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

        public bool Equals(PqInnerData other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is PqInnerData x && Equals(x);
        public static bool operator ==(PqInnerData x, PqInnerData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PqInnerData x, PqInnerData y) => !(x == y);

        public int CompareTo(PqInnerData other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is PqInnerData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PqInnerData x, PqInnerData y) => x.CompareTo(y) <= 0;
        public static bool operator <(PqInnerData x, PqInnerData y) => x.CompareTo(y) < 0;
        public static bool operator >(PqInnerData x, PqInnerData y) => x.CompareTo(y) > 0;
        public static bool operator >=(PqInnerData x, PqInnerData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PqInnerData.{_tag.GetType().Name}{_tag}";
    }
}