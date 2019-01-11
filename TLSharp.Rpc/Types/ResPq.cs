using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class ResPq : ITlType, IEquatable<ResPq>, IComparable<ResPq>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0x05162463;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly Int128 Nonce;
            public readonly Int128 ServerNonce;
            public readonly Arr<byte> Pq;
            public readonly Arr<long> ServerPublicKeyFingerprints;
            
            public Tag(
                Int128 nonce,
                Int128 serverNonce,
                Some<Arr<byte>> pq,
                Some<Arr<long>> serverPublicKeyFingerprints
            ) {
                Nonce = nonce;
                ServerNonce = serverNonce;
                Pq = pq;
                ServerPublicKeyFingerprints = serverPublicKeyFingerprints;
            }
            
            (Int128, Int128, Arr<byte>, Arr<long>) CmpTuple =>
                (Nonce, ServerNonce, Pq, ServerPublicKeyFingerprints);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, Pq: {Pq}, ServerPublicKeyFingerprints: {ServerPublicKeyFingerprints})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(Pq, bw, WriteBytes);
                Write(ServerPublicKeyFingerprints, bw, WriteVector<long>(WriteLong));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var pq = Read(br, ReadBytes);
                var serverPublicKeyFingerprints = Read(br, ReadVector(ReadLong));
                return new Tag(nonce, serverNonce, pq, serverPublicKeyFingerprints);
            }
        }

        readonly ITlTypeTag _tag;
        ResPq(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator ResPq(Tag tag) => new ResPq(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static ResPq Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (ResPq) Tag.DeserializeTag(br);
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

        public bool Equals(ResPq other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is ResPq x && Equals(x);
        public static bool operator ==(ResPq x, ResPq y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResPq x, ResPq y) => !(x == y);

        public int CompareTo(ResPq other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is ResPq x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResPq x, ResPq y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResPq x, ResPq y) => x.CompareTo(y) < 0;
        public static bool operator >(ResPq x, ResPq y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResPq x, ResPq y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"ResPq.{_tag.GetType().Name}{_tag}";
    }
}