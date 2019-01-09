using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class BindTempAuthKey : Record<BindTempAuthKey>, ITlFunc<bool>
    {
        public long PermAuthKeyId { get; }
        public long Nonce { get; }
        public int ExpiresAt { get; }
        public Arr<byte> EncryptedMessage { get; }
        
        public BindTempAuthKey(
            long permAuthKeyId,
            long nonce,
            int expiresAt,
            Some<Arr<byte>> encryptedMessage
        ) {
            PermAuthKeyId = permAuthKeyId;
            Nonce = nonce;
            ExpiresAt = expiresAt;
            EncryptedMessage = encryptedMessage;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcdd42a05);
            Write(PermAuthKeyId, bw, WriteLong);
            Write(Nonce, bw, WriteLong);
            Write(ExpiresAt, bw, WriteInt);
            Write(EncryptedMessage, bw, WriteBytes);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}