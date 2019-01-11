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
            
            public readonly Arr<byte> Pq;
            public readonly Arr<byte> P;
            public readonly Arr<byte> Q;
            public readonly Int128 Nonce;
            public readonly Int128 ServerNonce;
            public readonly Int256 NewNonce;
            
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

        public sealed class DcTag : ITlTypeTag, IEquatable<DcTag>, IComparable<DcTag>, IComparable
        {
            internal const uint TypeNumber = 0xa9f55f95;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Pq;
            public readonly string P;
            public readonly string Q;
            public readonly Int128 Nonce;
            public readonly Int128 ServerNonce;
            public readonly Int256 NewNonce;
            public readonly int Dc;
            
            public DcTag(
                Some<string> pq,
                Some<string> p,
                Some<string> q,
                Int128 nonce,
                Int128 serverNonce,
                Int256 newNonce,
                int dc
            ) {
                Pq = pq;
                P = p;
                Q = q;
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonce = newNonce;
                Dc = dc;
            }
            
            (string, string, string, Int128, Int128, Int256, int) CmpTuple =>
                (Pq, P, Q, Nonce, ServerNonce, NewNonce, Dc);

            public bool Equals(DcTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is DcTag x && Equals(x);
            public static bool operator ==(DcTag x, DcTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(DcTag x, DcTag y) => !(x == y);

            public int CompareTo(DcTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is DcTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(DcTag x, DcTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(DcTag x, DcTag y) => x.CompareTo(y) < 0;
            public static bool operator >(DcTag x, DcTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(DcTag x, DcTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Pq: {Pq}, P: {P}, Q: {Q}, Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonce: {NewNonce}, Dc: {Dc})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pq, bw, WriteString);
                Write(P, bw, WriteString);
                Write(Q, bw, WriteString);
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonce, bw, WriteInt256);
                Write(Dc, bw, WriteInt);
            }
            
            internal static DcTag DeserializeTag(BinaryReader br)
            {
                var pq = Read(br, ReadString);
                var p = Read(br, ReadString);
                var q = Read(br, ReadString);
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonce = Read(br, ReadInt256);
                var dc = Read(br, ReadInt);
                return new DcTag(pq, p, q, nonce, serverNonce, newNonce, dc);
            }
        }

        public sealed class TempTag : ITlTypeTag, IEquatable<TempTag>, IComparable<TempTag>, IComparable
        {
            internal const uint TypeNumber = 0x3c6a84d4;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Pq;
            public readonly string P;
            public readonly string Q;
            public readonly Int128 Nonce;
            public readonly Int128 ServerNonce;
            public readonly Int256 NewNonce;
            public readonly int ExpiresIn;
            
            public TempTag(
                Some<string> pq,
                Some<string> p,
                Some<string> q,
                Int128 nonce,
                Int128 serverNonce,
                Int256 newNonce,
                int expiresIn
            ) {
                Pq = pq;
                P = p;
                Q = q;
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonce = newNonce;
                ExpiresIn = expiresIn;
            }
            
            (string, string, string, Int128, Int128, Int256, int) CmpTuple =>
                (Pq, P, Q, Nonce, ServerNonce, NewNonce, ExpiresIn);

            public bool Equals(TempTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TempTag x && Equals(x);
            public static bool operator ==(TempTag x, TempTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TempTag x, TempTag y) => !(x == y);

            public int CompareTo(TempTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TempTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TempTag x, TempTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TempTag x, TempTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TempTag x, TempTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TempTag x, TempTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Pq: {Pq}, P: {P}, Q: {Q}, Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonce: {NewNonce}, ExpiresIn: {ExpiresIn})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pq, bw, WriteString);
                Write(P, bw, WriteString);
                Write(Q, bw, WriteString);
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonce, bw, WriteInt256);
                Write(ExpiresIn, bw, WriteInt);
            }
            
            internal static TempTag DeserializeTag(BinaryReader br)
            {
                var pq = Read(br, ReadString);
                var p = Read(br, ReadString);
                var q = Read(br, ReadString);
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonce = Read(br, ReadInt256);
                var expiresIn = Read(br, ReadInt);
                return new TempTag(pq, p, q, nonce, serverNonce, newNonce, expiresIn);
            }
        }

        public sealed class TempDcTag : ITlTypeTag, IEquatable<TempDcTag>, IComparable<TempDcTag>, IComparable
        {
            internal const uint TypeNumber = 0x56fddf88;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly string Pq;
            public readonly string P;
            public readonly string Q;
            public readonly Int128 Nonce;
            public readonly Int128 ServerNonce;
            public readonly Int256 NewNonce;
            public readonly int Dc;
            public readonly int ExpiresIn;
            
            public TempDcTag(
                Some<string> pq,
                Some<string> p,
                Some<string> q,
                Int128 nonce,
                Int128 serverNonce,
                Int256 newNonce,
                int dc,
                int expiresIn
            ) {
                Pq = pq;
                P = p;
                Q = q;
                Nonce = nonce;
                ServerNonce = serverNonce;
                NewNonce = newNonce;
                Dc = dc;
                ExpiresIn = expiresIn;
            }
            
            (string, string, string, Int128, Int128, Int256, int, int) CmpTuple =>
                (Pq, P, Q, Nonce, ServerNonce, NewNonce, Dc, ExpiresIn);

            public bool Equals(TempDcTag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is TempDcTag x && Equals(x);
            public static bool operator ==(TempDcTag x, TempDcTag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(TempDcTag x, TempDcTag y) => !(x == y);

            public int CompareTo(TempDcTag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is TempDcTag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(TempDcTag x, TempDcTag y) => x.CompareTo(y) <= 0;
            public static bool operator <(TempDcTag x, TempDcTag y) => x.CompareTo(y) < 0;
            public static bool operator >(TempDcTag x, TempDcTag y) => x.CompareTo(y) > 0;
            public static bool operator >=(TempDcTag x, TempDcTag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(Pq: {Pq}, P: {P}, Q: {Q}, Nonce: {Nonce}, ServerNonce: {ServerNonce}, NewNonce: {NewNonce}, Dc: {Dc}, ExpiresIn: {ExpiresIn})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(Pq, bw, WriteString);
                Write(P, bw, WriteString);
                Write(Q, bw, WriteString);
                Write(Nonce, bw, WriteInt128);
                Write(ServerNonce, bw, WriteInt128);
                Write(NewNonce, bw, WriteInt256);
                Write(Dc, bw, WriteInt);
                Write(ExpiresIn, bw, WriteInt);
            }
            
            internal static TempDcTag DeserializeTag(BinaryReader br)
            {
                var pq = Read(br, ReadString);
                var p = Read(br, ReadString);
                var q = Read(br, ReadString);
                var nonce = Read(br, ReadInt128);
                var serverNonce = Read(br, ReadInt128);
                var newNonce = Read(br, ReadInt256);
                var dc = Read(br, ReadInt);
                var expiresIn = Read(br, ReadInt);
                return new TempDcTag(pq, p, q, nonce, serverNonce, newNonce, dc, expiresIn);
            }
        }

        readonly ITlTypeTag _tag;
        PqInnerData(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator PqInnerData(Tag tag) => new PqInnerData(tag);
        public static explicit operator PqInnerData(DcTag tag) => new PqInnerData(tag);
        public static explicit operator PqInnerData(TempTag tag) => new PqInnerData(tag);
        public static explicit operator PqInnerData(TempDcTag tag) => new PqInnerData(tag);

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
                case DcTag.TypeNumber: return (PqInnerData) DcTag.DeserializeTag(br);
                case TempTag.TypeNumber: return (PqInnerData) TempTag.DeserializeTag(br);
                case TempDcTag.TypeNumber: return (PqInnerData) TempDcTag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber, DcTag.TypeNumber, TempTag.TypeNumber, TempDcTag.TypeNumber });
            }
        }

        public T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null,
            Func<DcTag, T> dcTag = null,
            Func<TempTag, T> tempTag = null,
            Func<TempDcTag, T> tempDcTag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                case DcTag x when dcTag != null: return dcTag(x);
                case TempTag x when tempTag != null: return tempTag(x);
                case TempDcTag x when tempDcTag != null: return tempDcTag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag,
            Func<DcTag, T> dcTag,
            Func<TempTag, T> tempTag,
            Func<TempDcTag, T> tempDcTag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag)),
            dcTag ?? throw new ArgumentNullException(nameof(dcTag)),
            tempTag ?? throw new ArgumentNullException(nameof(tempTag)),
            tempDcTag ?? throw new ArgumentNullException(nameof(tempDcTag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                case DcTag _: return 1;
                case TempTag _: return 2;
                case TempDcTag _: return 3;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(PqInnerData other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is PqInnerData x && Equals(x);
        public static bool operator ==(PqInnerData x, PqInnerData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(PqInnerData x, PqInnerData y) => !(x == y);

        public int CompareTo(PqInnerData other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is PqInnerData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(PqInnerData x, PqInnerData y) => x.CompareTo(y) <= 0;
        public static bool operator <(PqInnerData x, PqInnerData y) => x.CompareTo(y) < 0;
        public static bool operator >(PqInnerData x, PqInnerData y) => x.CompareTo(y) > 0;
        public static bool operator >=(PqInnerData x, PqInnerData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"PqInnerData.{_tag.GetType().Name}{_tag}";
    }
}