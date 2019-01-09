using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class DestroySession : Record<DestroySession>, ITlFunc<T.DestroySessionRes>
    {
        public long SessionId { get; }
        
        public DestroySession(
            long sessionId
        ) {
            SessionId = sessionId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe7512126);
            Write(SessionId, bw, WriteLong);
        }
        
        T.DestroySessionRes ITlFunc<T.DestroySessionRes>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DestroySessionRes.Deserialize);
    }
}