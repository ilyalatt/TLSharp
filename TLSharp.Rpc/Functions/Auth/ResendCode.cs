using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ResendCode : Record<ResendCode>, ITlFunc<T.Auth.SentCode>
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        
        public ResendCode(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3ef1a9bf);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}