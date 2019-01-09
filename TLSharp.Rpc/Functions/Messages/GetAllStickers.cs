using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetAllStickers : Record<GetAllStickers>, ITlFunc<T.Messages.AllStickers>
    {
        public int Hash { get; }
        
        public GetAllStickers(
            int hash
        ) {
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1c9618b1);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.AllStickers ITlFunc<T.Messages.AllStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AllStickers.Deserialize);
    }
}