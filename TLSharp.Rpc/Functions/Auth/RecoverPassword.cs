using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class RecoverPassword : Record<RecoverPassword>, ITlFunc<T.Auth.Authorization>
    {
        public string Code { get; }
        
        public RecoverPassword(
            Some<string> code
        ) {
            Code = code;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4ea56e92);
            Write(Code, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}