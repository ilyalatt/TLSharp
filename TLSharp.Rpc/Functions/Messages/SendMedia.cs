using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendMedia : Record<SendMedia>, ITlFunc<T.UpdatesType>
    {
        public bool Silent { get; }
        public bool Background { get; }
        public bool ClearDraft { get; }
        public T.InputPeer Peer { get; }
        public Option<int> ReplyToMsgId { get; }
        public T.InputMedia Media { get; }
        public long RandomId { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        
        public SendMedia(
            bool silent,
            bool background,
            bool clearDraft,
            Some<T.InputPeer> peer,
            Option<int> replyToMsgId,
            Some<T.InputMedia> media,
            long randomId,
            Option<T.ReplyMarkup> replyMarkup
        ) {
            Silent = silent;
            Background = background;
            ClearDraft = clearDraft;
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            Media = media;
            RandomId = randomId;
            ReplyMarkup = replyMarkup;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc8f16791);
            Write(MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(7, ClearDraft) | MaskBit(0, ReplyToMsgId) | MaskBit(2, ReplyMarkup), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(Media, bw, WriteSerializable);
            Write(RandomId, bw, WriteLong);
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}