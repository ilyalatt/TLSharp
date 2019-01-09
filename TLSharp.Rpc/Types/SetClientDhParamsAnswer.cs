using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class SetClientDhParamsAnswer : ITlType, IEquatable<SetClientDhParamsAnswer>, IComparable<SetClientDhParamsAnswer>, IComparable
    {
        public sealed class DhGenOkTag : Record<DhGenOkTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x3bcbf734;
            
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public Int128 NewNonceHash1 { get; }
            
            public DhGenOkTag(
                Int128 nonce,
                Int128 serverNonce,
                Int128 newNonceHash1
            ) {
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonceHash1 = newNonceHash1;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonceHash1, bw, WriteInt128);
            }
            
            internal static DhGenOkTag DeserializeTag(BinaryReader br)
            {
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonceHash1 = Read(br, ReadInt128);
                return new DhGenOkTag(nonce, serverNonce, newNonceHash1);
            }
        }

        public sealed class DhGenRetryTag : Record<DhGenRetryTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0x46dc1fb9;
            
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public Int128 NewNonceHash2 { get; }
            
            public DhGenRetryTag(
                Int128 nonce,
                Int128 serverNonce,
                Int128 newNonceHash2
            ) {
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonceHash2 = newNonceHash2;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonceHash2, bw, WriteInt128);
            }
            
            internal static DhGenRetryTag DeserializeTag(BinaryReader br)
            {
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonceHash2 = Read(br, ReadInt128);
                return new DhGenRetryTag(nonce, serverNonce, newNonceHash2);
            }
        }

        public sealed class DhGenFailTag : Record<DhGenFailTag>, ITlTypeTag
        {
            uint ITlTypeTag.TypeNumber => 0xa69dae02;
            
            public Int128 Nonce { get; }
            public Int128 ServerNonce { get; }
            public Int128 NewNonceHash3 { get; }
            
            public DhGenFailTag(
                Int128 nonce,
                Int128 serverNonce,
                Int128 newNonceHash3
            ) {
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonceHash3 = newNonceHash3;
            }
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonceHash3, bw, WriteInt128);
            }
            
            internal static DhGenFailTag DeserializeTag(BinaryReader br)
            {
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonceHash3 = Read(br, ReadInt128);
                return new DhGenFailTag(nonce, serverNonce, newNonceHash3);
            }
        }

        readonly ITlTypeTag _tag;
        SetClientDhParamsAnswer(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator SetClientDhParamsAnswer(DhGenOkTag tag) => new SetClientDhParamsAnswer(tag);
        public static explicit operator SetClientDhParamsAnswer(DhGenRetryTag tag) => new SetClientDhParamsAnswer(tag);
        public static explicit operator SetClientDhParamsAnswer(DhGenFailTag tag) => new SetClientDhParamsAnswer(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static SetClientDhParamsAnswer Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case 0x3bcbf734: return (SetClientDhParamsAnswer) DhGenOkTag.DeserializeTag(br);
                case 0x46dc1fb9: return (SetClientDhParamsAnswer) DhGenRetryTag.DeserializeTag(br);
                case 0xa69dae02: return (SetClientDhParamsAnswer) DhGenFailTag.DeserializeTag(br);
                default: throw TlTransportException.UnexpectedTypeNumber(actual: typeNumber, expected: new uint[] { 0x3bcbf734, 0x46dc1fb9, 0xa69dae02 });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<DhGenOkTag, T> dhGenOkTag = null,
            Func<DhGenRetryTag, T> dhGenRetryTag = null,
            Func<DhGenFailTag, T> dhGenFailTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case DhGenOkTag x when dhGenOkTag != null: return dhGenOkTag(x);
                case DhGenRetryTag x when dhGenRetryTag != null: return dhGenRetryTag(x);
                case DhGenFailTag x when dhGenFailTag != null: return dhGenFailTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<DhGenOkTag, T> dhGenOkTag,
            Func<DhGenRetryTag, T> dhGenRetryTag,
            Func<DhGenFailTag, T> dhGenFailTag
        ) => Match(
            () => throw new Exception("WTF"),
            dhGenOkTag ?? throw new ArgumentNullException(nameof(dhGenOkTag)),
            dhGenRetryTag ?? throw new ArgumentNullException(nameof(dhGenRetryTag)),
            dhGenFailTag ?? throw new ArgumentNullException(nameof(dhGenFailTag))
        );

        public bool Equals(SetClientDhParamsAnswer other) => !ReferenceEquals(other, null) && _tag.Equals(other._tag);
        public override bool Equals(object obj) => obj is SetClientDhParamsAnswer x && Equals(x);
        public static bool operator ==(SetClientDhParamsAnswer a, SetClientDhParamsAnswer b) => a?.Equals(b) ?? ReferenceEquals(b, null);
        public static bool operator !=(SetClientDhParamsAnswer a, SetClientDhParamsAnswer b) => !(a == b);

        int GetTagOrder()
        {
            switch (_tag)
            {
                case DhGenOkTag _: return 0;
                case DhGenRetryTag _: return 1;
                case DhGenFailTag _: return 2;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public int CompareTo(SetClientDhParamsAnswer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetClientDhParamsAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetClientDhParamsAnswer a, SetClientDhParamsAnswer b) => a.CompareTo(b) <= 0;
        public static bool operator <(SetClientDhParamsAnswer a, SetClientDhParamsAnswer b) => a.CompareTo(b) < 0;
        public static bool operator >(SetClientDhParamsAnswer a, SetClientDhParamsAnswer b) => a.CompareTo(b) > 0;
        public static bool operator >=(SetClientDhParamsAnswer a, SetClientDhParamsAnswer b) => a.CompareTo(b) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();
    }
}