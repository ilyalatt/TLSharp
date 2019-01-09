using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ConfirmPhone : Record<ConfirmPhone>, ITlFunc<bool>
    {
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        
        public ConfirmPhone(
            Some<string> phoneCodeHash,
            Some<string> phoneCode
        ) {
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5f2178c3);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}