using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetPassword : Record<GetPassword>, ITlFunc<T.Account.Password>
    {

        
        public GetPassword(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x548a30f5);

        }
        
        T.Account.Password ITlFunc<T.Account.Password>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.Password.Deserialize);
    }
}