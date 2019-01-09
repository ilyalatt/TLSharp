using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendMessage : Record<SendMessage>, ITlFunc<T.UpdatesType>
    {
        public bool NoWebpage { get; }
        public bool Silent { get; }
        public bool Background { get; }
        public bool ClearDraft { get; }
        public T.InputPeer Peer { get; }
        public Option<int> ReplyToMsgId { get; }
        public string Message { get; }
        public long RandomId { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public SendMessage(
            bool noWebpage,
            bool silent,
            bool background,
            bool clearDraft,
            Some<T.InputPeer> peer,
            Option<int> replyToMsgId,
            Some<string> message,
            long randomId,
            Option<T.ReplyMarkup> replyMarkup,
            Option<Arr<T.MessageEntity>> entities
        ) {
            NoWebpage = noWebpage;
            Silent = silent;
            Background = background;
            ClearDraft = clearDraft;
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            Message = message;
            RandomId = randomId;
            ReplyMarkup = replyMarkup;
            Entities = entities;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfa88427a);
            Write(MaskBit(1, NoWebpage) | MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(7, ClearDraft) | MaskBit(0, ReplyToMsgId) | MaskBit(2, ReplyMarkup) | MaskBit(3, Entities), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(Message, bw, WriteString);
            Write(RandomId, bw, WriteLong);
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}