using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadEncryptedHistory : Record<ReadEncryptedHistory>, ITlFunc<bool>
    {
        public T.InputEncryptedChat Peer { get; }
        public int MaxDate { get; }
        
        public ReadEncryptedHistory(
            Some<T.InputEncryptedChat> peer,
            int maxDate
        ) {
            Peer = peer;
            MaxDate = maxDate;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7f4b690a);
            Write(Peer, bw, WriteSerializable);
            Write(MaxDate, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}