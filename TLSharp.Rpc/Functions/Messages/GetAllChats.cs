using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetAllChats : Record<GetAllChats>, ITlFunc<T.Messages.Chats>
    {
        public Arr<int> ExceptIds { get; }
        
        public GetAllChats(
            Some<Arr<int>> exceptIds
        ) {
            ExceptIds = exceptIds;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeba80ff0);
            Write(ExceptIds, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}