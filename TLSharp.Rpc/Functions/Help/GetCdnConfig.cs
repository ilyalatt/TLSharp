using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetCdnConfig : Record<GetCdnConfig>, ITlFunc<T.CdnConfig>
    {

        
        public GetCdnConfig(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x52029342);

        }
        
        T.CdnConfig ITlFunc<T.CdnConfig>.DeserializeResult(BinaryReader br) =>
            Read(br, T.CdnConfig.Deserialize);
    }
}