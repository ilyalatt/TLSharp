using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class CheckPhone : Record<CheckPhone>, ITlFunc<T.Auth.CheckedPhone>
    {
        public string PhoneNumber { get; }
        
        public CheckPhone(
            Some<string> phoneNumber
        ) {
            PhoneNumber = phoneNumber;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6fe51dfb);
            Write(PhoneNumber, bw, WriteString);
        }
        
        T.Auth.CheckedPhone ITlFunc<T.Auth.CheckedPhone>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.CheckedPhone.Deserialize);
    }
}