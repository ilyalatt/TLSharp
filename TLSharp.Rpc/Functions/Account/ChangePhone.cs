using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ChangePhone : Record<ChangePhone>, ITlFunc<T.User>
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        
        public ChangePhone(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash,
            Some<string> phoneCode
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x70c32edb);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}