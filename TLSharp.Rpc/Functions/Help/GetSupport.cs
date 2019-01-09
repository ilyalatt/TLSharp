using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetSupport : Record<GetSupport>, ITlFunc<T.Help.Support>
    {

        
        public GetSupport(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9cdf08cd);

        }
        
        T.Help.Support ITlFunc<T.Help.Support>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.Support.Deserialize);
    }
}