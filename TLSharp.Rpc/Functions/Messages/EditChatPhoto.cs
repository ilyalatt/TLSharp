using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditChatPhoto : Record<EditChatPhoto>, ITlFunc<T.UpdatesType>
    {
        public int ChatId { get; }
        public T.InputChatPhoto Photo { get; }
        
        public EditChatPhoto(
            int chatId,
            Some<T.InputChatPhoto> photo
        ) {
            ChatId = chatId;
            Photo = photo;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xca4c79d8);
            Write(ChatId, bw, WriteInt);
            Write(Photo, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}