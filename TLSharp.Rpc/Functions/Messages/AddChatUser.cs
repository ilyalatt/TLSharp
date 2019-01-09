using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class AddChatUser : Record<AddChatUser>, ITlFunc<T.UpdatesType>
    {
        public int ChatId { get; }
        public T.InputUser UserId { get; }
        public int FwdLimit { get; }
        
        public AddChatUser(
            int chatId,
            Some<T.InputUser> userId,
            int fwdLimit
        ) {
            ChatId = chatId;
            UserId = userId;
            FwdLimit = fwdLimit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf9a0aa09);
            Write(ChatId, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
            Write(FwdLimit, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}