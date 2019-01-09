using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetTermsOfService : Record<GetTermsOfService>, ITlFunc<T.Help.TermsOfService>
    {

        
        public GetTermsOfService(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x350170f3);

        }
        
        T.Help.TermsOfService ITlFunc<T.Help.TermsOfService>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.TermsOfService.Deserialize);
    }
}