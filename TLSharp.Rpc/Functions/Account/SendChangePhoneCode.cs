using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SendChangePhoneCode : Record<SendChangePhoneCode>, ITlFunc<T.Auth.SentCode>
    {
        public bool AllowFlashcall { get; }
        public string PhoneNumber { get; }
        public Option<bool> CurrentNumber { get; }
        
        public SendChangePhoneCode(
            bool allowFlashcall,
            Some<string> phoneNumber,
            Option<bool> currentNumber
        ) {
            AllowFlashcall = allowFlashcall;
            PhoneNumber = phoneNumber;
            CurrentNumber = currentNumber;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x08e57deb);
            Write(MaskBit(0, AllowFlashcall) | MaskBit(0, CurrentNumber), bw, WriteInt);
            Write(PhoneNumber, bw, WriteString);
            Write(CurrentNumber, bw, WriteOption<bool>(WriteBool));
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}