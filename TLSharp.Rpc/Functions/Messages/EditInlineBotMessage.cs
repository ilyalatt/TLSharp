using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditInlineBotMessage : Record<EditInlineBotMessage>, ITlFunc<bool>
    {
        public bool NoWebpage { get; }
        public T.InputBotInlineMessageId Id { get; }
        public Option<string> Message { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public EditInlineBotMessage(
            bool noWebpage,
            Some<T.InputBotInlineMessageId> id,
            Option<string> message,
            Option<T.ReplyMarkup> replyMarkup,
            Option<Arr<T.MessageEntity>> entities
        ) {
            NoWebpage = noWebpage;
            Id = id;
            Message = message;
            ReplyMarkup = replyMarkup;
            Entities = entities;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x130c2c85);
            Write(MaskBit(1, NoWebpage) | MaskBit(11, Message) | MaskBit(2, ReplyMarkup) | MaskBit(3, Entities), bw, WriteInt);
            Write(Id, bw, WriteSerializable);
            Write(Message, bw, WriteOption<string>(WriteString));
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}