using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class ReqPqMulti : ITlFunc<T.ResPq>, IEquatable<ReqPqMulti>, IComparable<ReqPqMulti>, IComparable
    {
        public Int128 Nonce { get; }
        
        public ReqPqMulti(
            Int128 nonce
        ) {
            Nonce = nonce;
        }
        
        
        Int128 CmpTuple =>
            Nonce;

        public bool Equals(ReqPqMulti other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReqPqMulti x && Equals(x);
        public static bool operator ==(ReqPqMulti x, ReqPqMulti y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReqPqMulti x, ReqPqMulti y) => !(x == y);

        public int CompareTo(ReqPqMulti other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReqPqMulti x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReqPqMulti x, ReqPqMulti y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReqPqMulti x, ReqPqMulti y) => x.CompareTo(y) < 0;
        public static bool operator >(ReqPqMulti x, ReqPqMulti y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReqPqMulti x, ReqPqMulti y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Nonce: {Nonce})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbe7e8ef1);
            Write(Nonce, bw, WriteInt128);
        }
        
        T.ResPq ITlFunc<T.ResPq>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ResPq.Deserialize);
    }
}