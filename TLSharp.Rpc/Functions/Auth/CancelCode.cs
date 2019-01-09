using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class CancelCode : Record<CancelCode>, ITlFunc<bool>
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        
        public CancelCode(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1f040578);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}