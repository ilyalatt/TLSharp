using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetBotCallbackAnswer : Record<SetBotCallbackAnswer>, ITlFunc<bool>
    {
        public bool Alert { get; }
        public long QueryId { get; }
        public Option<string> Message { get; }
        public Option<string> Url { get; }
        public int CacheTime { get; }
        
        public SetBotCallbackAnswer(
            bool alert,
            long queryId,
            Option<string> message,
            Option<string> url,
            int cacheTime
        ) {
            Alert = alert;
            QueryId = queryId;
            Message = message;
            Url = url;
            CacheTime = cacheTime;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd58f130a);
            Write(MaskBit(1, Alert) | MaskBit(0, Message) | MaskBit(2, Url), bw, WriteInt);
            Write(QueryId, bw, WriteLong);
            Write(Message, bw, WriteOption<string>(WriteString));
            Write(Url, bw, WriteOption<string>(WriteString));
            Write(CacheTime, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}