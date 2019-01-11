using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class ReqPq : ITlFunc<T.ResPq>, IEquatable<ReqPq>, IComparable<ReqPq>, IComparable
    {
        public Int128 Nonce { get; }
        
        public ReqPq(
            Int128 nonce
        ) {
            Nonce = nonce;
        }
        
        
        Int128 CmpTuple =>
            Nonce;

        public bool Equals(ReqPq other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReqPq x && Equals(x);
        public static bool operator ==(ReqPq x, ReqPq y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReqPq x, ReqPq y) => !(x == y);

        public int CompareTo(ReqPq other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReqPq x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReqPq x, ReqPq y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReqPq x, ReqPq y) => x.CompareTo(y) < 0;
        public static bool operator >(ReqPq x, ReqPq y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReqPq x, ReqPq y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Nonce: {Nonce})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x60469778);
            Write(Nonce, bw, WriteInt128);
        }
        
        T.ResPq ITlFunc<T.ResPq>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ResPq.Deserialize);
    }
}