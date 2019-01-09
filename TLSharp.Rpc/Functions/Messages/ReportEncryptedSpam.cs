using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReportEncryptedSpam : Record<ReportEncryptedSpam>, ITlFunc<bool>
    {
        public T.InputEncryptedChat Peer { get; }
        
        public ReportEncryptedSpam(
            Some<T.InputEncryptedChat> peer
        ) {
            Peer = peer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4b0c8c0f);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}