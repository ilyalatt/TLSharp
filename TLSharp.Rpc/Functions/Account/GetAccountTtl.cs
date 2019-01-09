using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetAccountTtl : Record<GetAccountTtl>, ITlFunc<T.AccountDaysTtl>
    {

        
        public GetAccountTtl(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x08fc711d);

        }
        
        T.AccountDaysTtl ITlFunc<T.AccountDaysTtl>.DeserializeResult(BinaryReader br) =>
            Read(br, T.AccountDaysTtl.Deserialize);
    }
}