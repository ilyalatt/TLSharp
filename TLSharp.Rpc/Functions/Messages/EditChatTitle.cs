using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditChatTitle : Record<EditChatTitle>, ITlFunc<T.UpdatesType>
    {
        public int ChatId { get; }
        public string Title { get; }
        
        public EditChatTitle(
            int chatId,
            Some<string> title
        ) {
            ChatId = chatId;
            Title = title;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdc452855);
            Write(ChatId, bw, WriteInt);
            Write(Title, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}