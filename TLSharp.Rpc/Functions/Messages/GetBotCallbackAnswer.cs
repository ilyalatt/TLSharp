using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetBotCallbackAnswer : Record<GetBotCallbackAnswer>, ITlFunc<T.Messages.BotCallbackAnswer>
    {
        public bool Game { get; }
        public T.InputPeer Peer { get; }
        public int MsgId { get; }
        public Option<Arr<byte>> Data { get; }
        
        public GetBotCallbackAnswer(
            bool game,
            Some<T.InputPeer> peer,
            int msgId,
            Option<Arr<byte>> data
        ) {
            Game = game;
            Peer = peer;
            MsgId = msgId;
            Data = data;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x810a9fec);
            Write(MaskBit(1, Game) | MaskBit(0, Data), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(MsgId, bw, WriteInt);
            Write(Data, bw, WriteOption<Arr<byte>>(WriteBytes));
        }
        
        T.Messages.BotCallbackAnswer ITlFunc<T.Messages.BotCallbackAnswer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.BotCallbackAnswer.Deserialize);
    }
}