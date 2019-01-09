using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetAppUpdate : Record<GetAppUpdate>, ITlFunc<T.Help.AppUpdate>
    {

        
        public GetAppUpdate(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xae2de196);

        }
        
        T.Help.AppUpdate ITlFunc<T.Help.AppUpdate>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.AppUpdate.Deserialize);
    }
}