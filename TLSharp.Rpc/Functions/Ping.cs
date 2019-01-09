using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class Ping : Record<Ping>, ITlFunc<T.Pong>
    {
        public long PingId { get; }
        
        public Ping(
            long pingId
        ) {
            PingId = pingId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7abe77ec);
            Write(PingId, bw, WriteLong);
        }
        
        T.Pong ITlFunc<T.Pong>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Pong.Deserialize);
    }
}