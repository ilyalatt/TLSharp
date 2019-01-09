using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetAuthorizations : Record<GetAuthorizations>, ITlFunc<T.Account.Authorizations>
    {

        
        public GetAuthorizations(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe320c158);

        }
        
        T.Account.Authorizations ITlFunc<T.Account.Authorizations>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.Authorizations.Deserialize);
    }
}