using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DeleteChatUser : Record<DeleteChatUser>, ITlFunc<T.UpdatesType>
    {
        public int ChatId { get; }
        public T.InputUser UserId { get; }
        
        public DeleteChatUser(
            int chatId,
            Some<T.InputUser> userId
        ) {
            ChatId = chatId;
            UserId = userId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe0611f16);
            Write(ChatId, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}