using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SendConfirmPhoneCode : Record<SendConfirmPhoneCode>, ITlFunc<T.Auth.SentCode>
    {
        public bool AllowFlashcall { get; }
        public string Hash { get; }
        public Option<bool> CurrentNumber { get; }
        
        public SendConfirmPhoneCode(
            bool allowFlashcall,
            Some<string> hash,
            Option<bool> currentNumber
        ) {
            AllowFlashcall = allowFlashcall;
            Hash = hash;
            CurrentNumber = currentNumber;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1516d7bd);
            Write(MaskBit(0, AllowFlashcall) | MaskBit(0, CurrentNumber), bw, WriteInt);
            Write(Hash, bw, WriteString);
            Write(CurrentNumber, bw, WriteOption<bool>(WriteBool));
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}