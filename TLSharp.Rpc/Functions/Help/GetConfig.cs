using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetConfig : Record<GetConfig>, ITlFunc<T.Config>
    {

        
        public GetConfig(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc4f9186b);

        }
        
        T.Config ITlFunc<T.Config>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Config.Deserialize);
    }
}