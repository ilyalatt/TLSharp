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
        public sealed class DhGenOkTag : ITlTypeTag, IEquatable<DhGenOkTag>, IComparable<DhGenOkTag>, IComparable
        {
            internal const uint TypeNumber = 0x3bcbf734;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (Int128, Int128, Int128) CmpTuple =>
                (Nonce, ServerNonce, NewNonceHash1);

            public bool Equals(DhGenOkTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DhGenOkTag x && Equals(x);
            public static bool operator ==(DhGenOkTag x, DhGenOkTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DhGenOkTag x, DhGenOkTag y) => !(x == y);

            public int CompareTo(DhGenOkTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DhGenOkTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DhGenOkTag x, DhGenOkTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DhGenOkTag x, DhGenOkTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DhGenOkTag x, DhGenOkTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DhGenOkTag x, DhGenOkTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonceHash1: {NewNonceHash1})";
            
            
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

        public sealed class DhGenRetryTag : ITlTypeTag, IEquatable<DhGenRetryTag>, IComparable<DhGenRetryTag>, IComparable
        {
            internal const uint TypeNumber = 0x46dc1fb9;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (Int128, Int128, Int128) CmpTuple =>
                (Nonce, ServerNonce, NewNonceHash2);

            public bool Equals(DhGenRetryTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DhGenRetryTag x && Equals(x);
            public static bool operator ==(DhGenRetryTag x, DhGenRetryTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DhGenRetryTag x, DhGenRetryTag y) => !(x == y);

            public int CompareTo(DhGenRetryTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DhGenRetryTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DhGenRetryTag x, DhGenRetryTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DhGenRetryTag x, DhGenRetryTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DhGenRetryTag x, DhGenRetryTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DhGenRetryTag x, DhGenRetryTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonceHash2: {NewNonceHash2})";
            
            
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

        public sealed class DhGenFailTag : ITlTypeTag, IEquatable<DhGenFailTag>, IComparable<DhGenFailTag>, IComparable
        {
            internal const uint TypeNumber = 0xa69dae02;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
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
            
            (Int128, Int128, Int128) CmpTuple =>
                (Nonce, ServerNonce, NewNonceHash3);

            public bool Equals(DhGenFailTag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is DhGenFailTag x && Equals(x);
            public static bool operator ==(DhGenFailTag x, DhGenFailTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DhGenFailTag x, DhGenFailTag y) => !(x == y);

            public int CompareTo(DhGenFailTag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is DhGenFailTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DhGenFailTag x, DhGenFailTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DhGenFailTag x, DhGenFailTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DhGenFailTag x, DhGenFailTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DhGenFailTag x, DhGenFailTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonceHash3: {NewNonceHash3})";
            
            
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
                case DhGenOkTag.TypeNumber: return (SetClientDhParamsAnswer) DhGenOkTag.DeserializeTag(br);
                case DhGenRetryTag.TypeNumber: return (SetClientDhParamsAnswer) DhGenRetryTag.DeserializeTag(br);
                case DhGenFailTag.TypeNumber: return (SetClientDhParamsAnswer) DhGenFailTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { DhGenOkTag.TypeNumber, DhGenRetryTag.TypeNumber, DhGenFailTag.TypeNumber });
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

        public bool Equals(SetClientDhParamsAnswer other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is SetClientDhParamsAnswer x && Equals(x);
        public static bool operator ==(SetClientDhParamsAnswer x, SetClientDhParamsAnswer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetClientDhParamsAnswer x, SetClientDhParamsAnswer y) => !(x == y);

        public int CompareTo(SetClientDhParamsAnswer other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetClientDhParamsAnswer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetClientDhParamsAnswer x, SetClientDhParamsAnswer y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetClientDhParamsAnswer x, SetClientDhParamsAnswer y) => x.CompareTo(y) < 0;
        public static bool operator >(SetClientDhParamsAnswer x, SetClientDhParamsAnswer y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetClientDhParamsAnswer x, SetClientDhParamsAnswer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"SetClientDhParamsAnswer.{_tag.GetType().Name}{_tag}";
    }
}