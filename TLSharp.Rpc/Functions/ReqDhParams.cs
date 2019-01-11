using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class ReqDhParams : ITlFunc<T.ServerDhParams>, IEquatable<ReqDhParams>, IComparable<ReqDhParams>, IComparable
    {
        public Int128 Nonce { get; }
        public Int128 ServerNonce { get; }
        public Arr<byte> P { get; }
        public Arr<byte> Q { get; }
        public long PublicKeyFingerprint { get; }
        public Arr<byte> EncryptedData { get; }
        
        public ReqDhParams(
            Int128 nonce,
            Int128 serverNonce,
            Some<Arr<byte>> p,
            Some<Arr<byte>> q,
            long publicKeyFingerprint,
            Some<Arr<byte>> encryptedData
        ) {
            Nonce = nonce;
            ServerNonce = serverNonce;
            P = p;
            Q = q;
            PublicKeyFingerprint = publicKeyFingerprint;
            EncryptedData = encryptedData;
        }
        
        
        (Int128, Int128, Arr<byte>, Arr<byte>, long, Arr<byte>) CmpTuple =>
            (Nonce, ServerNonce, P, Q, PublicKeyFingerprint, EncryptedData);

        public bool Equals(ReqDhParams other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReqDhParams x && Equals(x);
        public static bool operator ==(ReqDhParams x, ReqDhParams y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReqDhParams x, ReqDhParams y) => !(x == y);

        public int CompareTo(ReqDhParams other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReqDhParams x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReqDhParams x, ReqDhParams y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReqDhParams x, ReqDhParams y) => x.CompareTo(y) < 0;
        public static bool operator >(ReqDhParams x, ReqDhParams y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReqDhParams x, ReqDhParams y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, P: {P}, Q: {Q}, PublicKeyFingerprint: {PublicKeyFingerprint}, EncryptedData: {EncryptedData})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd712e4be);
            Write(Nonce, bw, WriteInt128);
            Write(ServerNonce, bw, WriteInt128);
            Write(P, bw, WriteBytes);
            Write(Q, bw, WriteBytes);
            Write(PublicKeyFingerprint, bw, WriteLong);
            Write(EncryptedData, bw, WriteBytes);
        }
        
        T.ServerDhParams ITlFunc<T.ServerDhParams>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ServerDhParams.Deserialize);
    }
}