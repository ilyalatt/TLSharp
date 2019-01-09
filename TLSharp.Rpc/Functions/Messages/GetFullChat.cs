using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetFullChat : Record<GetFullChat>, ITlFunc<T.Messages.ChatFull>
    {
        public int ChatId { get; }
        
        public GetFullChat(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3b831c66);
            Write(ChatId, bw, WriteInt);
        }
        
        T.Messages.ChatFull ITlFunc<T.Messages.ChatFull>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.ChatFull.Deserialize);
    }
}