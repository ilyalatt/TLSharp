using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SaveDraft : Record<SaveDraft>, ITlFunc<bool>
    {
        public bool NoWebpage { get; }
        public Option<int> ReplyToMsgId { get; }
        public T.InputPeer Peer { get; }
        public string Message { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public SaveDraft(
            bool noWebpage,
            Option<int> replyToMsgId,
            Some<T.InputPeer> peer,
            Some<string> message,
            Option<Arr<T.MessageEntity>> entities
        ) {
            NoWebpage = noWebpage;
            ReplyToMsgId = replyToMsgId;
            Peer = peer;
            Message = message;
            Entities = entities;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbc39e14b);
            Write(MaskBit(1, NoWebpage) | MaskBit(0, ReplyToMsgId) | MaskBit(3, Entities), bw, WriteInt);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(Peer, bw, WriteSerializable);
            Write(Message, bw, WriteString);
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}