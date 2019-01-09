using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetInlineGameScore : Record<SetInlineGameScore>, ITlFunc<bool>
    {
        public bool EditMessage { get; }
        public bool Force { get; }
        public T.InputBotInlineMessageId Id { get; }
        public T.InputUser UserId { get; }
        public int Score { get; }
        
        public SetInlineGameScore(
            bool editMessage,
            bool force,
            Some<T.InputBotInlineMessageId> id,
            Some<T.InputUser> userId,
            int score
        ) {
            EditMessage = editMessage;
            Force = force;
            Id = id;
            UserId = userId;
            Score = score;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x15ad9f64);
            Write(MaskBit(0, EditMessage) | MaskBit(1, Force), bw, WriteInt);
            Write(Id, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Score, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}