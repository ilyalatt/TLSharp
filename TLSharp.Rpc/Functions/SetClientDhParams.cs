using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class SetClientDhParams : Record<SetClientDhParams>, ITlFunc<T.SetClientDhParamsAnswer>
    {
        public Int128 Nonce { get; }
        public Int128 ServerNonce { get; }
        public Arr<byte> EncryptedData { get; }
        
        public SetClientDhParams(
            Int128 nonce,
            Int128 serverNonce,
            Some<Arr<byte>> encryptedData
        ) {
            Nonce = nonce;
            ServerNonce = serverNonce;
            EncryptedData = encryptedData;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf5045f1f);
            Write(Nonce, bw, WriteInt128);
            Write(ServerNonce, bw, WriteInt128);
            Write(EncryptedData, bw, WriteBytes);
        }
        
        T.SetClientDhParamsAnswer ITlFunc<T.SetClientDhParamsAnswer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.SetClientDhParamsAnswer.Deserialize);
    }
}