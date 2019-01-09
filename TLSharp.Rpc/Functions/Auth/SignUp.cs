using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SignUp : Record<SignUp>, ITlFunc<T.Auth.Authorization>
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        public string FirstName { get; }
        public string LastName { get; }
        
        public SignUp(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash,
            Some<string> phoneCode,
            Some<string> firstName,
            Some<string> lastName
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
            FirstName = firstName;
            LastName = lastName;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1b067634);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
            Write(FirstName, bw, WriteString);
            Write(LastName, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}