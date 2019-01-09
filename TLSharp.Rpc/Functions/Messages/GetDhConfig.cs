using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDhConfig : Record<GetDhConfig>, ITlFunc<T.Messages.DhConfig>
    {
        public int Version { get; }
        public int RandomLength { get; }
        
        public GetDhConfig(
            int version,
            int randomLength
        ) {
            Version = version;
            RandomLength = randomLength;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x26cf8950);
            Write(Version, bw, WriteInt);
            Write(RandomLength, bw, WriteInt);
        }
        
        T.Messages.DhConfig ITlFunc<T.Messages.DhConfig>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.DhConfig.Deserialize);
    }
}