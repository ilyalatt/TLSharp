using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class GetCallConfig : Record<GetCallConfig>, ITlFunc<T.DataJson>
    {

        
        public GetCallConfig(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x55451fa9);

        }
        
        T.DataJson ITlFunc<T.DataJson>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DataJson.Deserialize);
    }
}