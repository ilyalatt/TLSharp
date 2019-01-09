using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class AcceptEncryption : Record<AcceptEncryption>, ITlFunc<T.EncryptedChat>
    {
        public T.InputEncryptedChat Peer { get; }
        public Arr<byte> Gb { get; }
        public long KeyFingerprint { get; }
        
        public AcceptEncryption(
            Some<T.InputEncryptedChat> peer,
            Some<Arr<byte>> gb,
            long keyFingerprint
        ) {
            Peer = peer;
            Gb = gb;
            KeyFingerprint = keyFingerprint;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3dbc0415);
            Write(Peer, bw, WriteSerializable);
            Write(Gb, bw, WriteBytes);
            Write(KeyFingerprint, bw, WriteLong);
        }
        
        T.EncryptedChat ITlFunc<T.EncryptedChat>.DeserializeResult(BinaryReader br) =>
            Read(br, T.EncryptedChat.Deserialize);
    }
}