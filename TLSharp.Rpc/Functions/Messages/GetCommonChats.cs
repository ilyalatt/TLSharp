using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetCommonChats : Record<GetCommonChats>, ITlFunc<T.Messages.Chats>
    {
        public T.InputUser UserId { get; }
        public int MaxId { get; }
        public int Limit { get; }
        
        public GetCommonChats(
            Some<T.InputUser> userId,
            int maxId,
            int limit
        ) {
            UserId = userId;
            MaxId = maxId;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0d0a48c4);
            Write(UserId, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}