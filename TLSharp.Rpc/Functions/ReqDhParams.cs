using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class ReqDhParams : Record<ReqDhParams>, ITlFunc<T.ServerDhParams>
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