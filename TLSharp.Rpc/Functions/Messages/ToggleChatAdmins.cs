using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ToggleChatAdmins : Record<ToggleChatAdmins>, ITlFunc<T.UpdatesType>
    {
        public int ChatId { get; }
        public bool Enabled { get; }
        
        public ToggleChatAdmins(
            int chatId,
            bool enabled
        ) {
            ChatId = chatId;
            Enabled = enabled;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xec8bd9e1);
            Write(ChatId, bw, WriteInt);
            Write(Enabled, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}