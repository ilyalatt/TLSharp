using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetFeaturedStickers : Record<GetFeaturedStickers>, ITlFunc<T.Messages.FeaturedStickers>
    {
        public int Hash { get; }
        
        public GetFeaturedStickers(
            int hash
        ) {
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2dacca4f);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.FeaturedStickers ITlFunc<T.Messages.FeaturedStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.FeaturedStickers.Deserialize);
    }
}