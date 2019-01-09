using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetInlineGameHighScores : Record<GetInlineGameHighScores>, ITlFunc<T.Messages.HighScores>
    {
        public T.InputBotInlineMessageId Id { get; }
        public T.InputUser UserId { get; }
        
        public GetInlineGameHighScores(
            Some<T.InputBotInlineMessageId> id,
            Some<T.InputUser> userId
        ) {
            Id = id;
            UserId = userId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0f635e1b);
            Write(Id, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Messages.HighScores ITlFunc<T.Messages.HighScores>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.HighScores.Deserialize);
    }
}