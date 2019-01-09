using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditChatAdmin : Record<EditChatAdmin>, ITlFunc<bool>
    {
        public int ChatId { get; }
        public T.InputUser UserId { get; }
        public bool IsAdmin { get; }
        
        public EditChatAdmin(
            int chatId,
            Some<T.InputUser> userId,
            bool isAdmin
        ) {
            ChatId = chatId;
            UserId = userId;
            IsAdmin = isAdmin;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa9e69f2e);
            Write(ChatId, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
            Write(IsAdmin, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}