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
        public sealed class Tag : Record<Tag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x05162463;
            
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public Arr<byte> Pq { get; }
            public Arr<long> ServerPublicKeyFingerprints { get; }
            
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
                case 0x05162463: return (ResPq) Tag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x05162463 });
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

        public bool Equals(ResPq other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is ResPq x && Equals(x);
        public static bool operator ==(ResPq a, ResPq b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(ResPq a, ResPq b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(ResPq other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ResPq x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResPq a, ResPq b) => a.CompareTo(b) <= 0;
        public static bool operator <(ResPq a, ResPq b) => a.CompareTo(b) < 0;
        public static bool operator >(ResPq a, ResPq b) => a.CompareTo(b) > 0;
        public static bool operator >=(ResPq a, ResPq b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}