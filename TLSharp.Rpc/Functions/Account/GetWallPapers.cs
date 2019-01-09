using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetWallPapers : Record<GetWallPapers>, ITlFunc<Arr<T.WallPaper>>
    {

        
        public GetWallPapers(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc04cfac2);

        }
        
        Arr<T.WallPaper> ITlFunc<Arr<T.WallPaper>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.WallPaper.Deserialize));
    }
}