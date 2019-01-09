using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ExportChatInvite : Record<ExportChatInvite>, ITlFunc<T.ExportedChatInvite>
    {
        public int ChatId { get; }
        
        public ExportChatInvite(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7d885289);
            Write(ChatId, bw, WriteInt);
        }
        
        T.ExportedChatInvite ITlFunc<T.ExportedChatInvite>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ExportedChatInvite.Deserialize);
    }
}