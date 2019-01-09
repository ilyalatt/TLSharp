using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class PingDelayDisconnect : Record<PingDelayDisconnect>, ITlFunc<T.Pong>
    {
        public long PingId { get; }
        public int DisconnectDelay { get; }
        
        public PingDelayDisconnect(
            long pingId,
            int disconnectDelay
        ) {
            PingId = pingId;
            DisconnectDelay = disconnectDelay;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf3427b8c);
            Write(PingId, bw, WriteLong);
            Write(DisconnectDelay, bw, WriteInt);
        }
        
        T.Pong ITlFunc<T.Pong>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Pong.Deserialize);
    }
}