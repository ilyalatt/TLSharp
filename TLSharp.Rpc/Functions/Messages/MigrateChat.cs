using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class MigrateChat : Record<MigrateChat>, ITlFunc<T.UpdatesType>
    {
        public int ChatId { get; }
        
        public MigrateChat(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x15a3b8e3);
            Write(ChatId, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}