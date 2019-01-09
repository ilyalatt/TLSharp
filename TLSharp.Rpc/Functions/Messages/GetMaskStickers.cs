using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMaskStickers : Record<GetMaskStickers>, ITlFunc<T.Messages.AllStickers>
    {
        public int Hash { get; }
        
        public GetMaskStickers(
            int hash
        ) {
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x65b8c79f);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.AllStickers ITlFunc<T.Messages.AllStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AllStickers.Deserialize);
    }
}