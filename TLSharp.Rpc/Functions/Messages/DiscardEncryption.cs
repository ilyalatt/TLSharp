using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DiscardEncryption : Record<DiscardEncryption>, ITlFunc<bool>
    {
        public int ChatId { get; }
        
        public DiscardEncryption(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xedd923c5);
            Write(ChatId, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}