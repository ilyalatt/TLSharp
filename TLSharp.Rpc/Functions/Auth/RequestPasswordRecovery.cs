using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class RequestPasswordRecovery : Record<RequestPasswordRecovery>, ITlFunc<T.Auth.PasswordRecovery>
    {

        
        public RequestPasswordRecovery(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd897bc66);

        }
        
        T.Auth.PasswordRecovery ITlFunc<T.Auth.PasswordRecovery>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.PasswordRecovery.Deserialize);
    }
}