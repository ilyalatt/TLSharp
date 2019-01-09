using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SendCode : Record<SendCode>, ITlFunc<T.Auth.SentCode>
    {
        public bool AllowFlashcall { get; }
        public string PhoneNumber { get; }
        public Option<bool> CurrentNumber { get; }
        public int ApiId { get; }
        public string ApiHash { get; }
        
        public SendCode(
            bool allowFlashcall,
            Some<string> phoneNumber,
            Option<bool> currentNumber,
            int apiId,
            Some<string> apiHash
        ) {
            AllowFlashcall = allowFlashcall;
            PhoneNumber = phoneNumber;
            CurrentNumber = currentNumber;
            ApiId = apiId;
            ApiHash = apiHash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x86aef0ec);
            Write(MaskBit(0, AllowFlashcall) | MaskBit(0, CurrentNumber), bw, WriteInt);
            Write(PhoneNumber, bw, WriteString);
            Write(CurrentNumber, bw, WriteOption<bool>(WriteBool));
            Write(ApiId, bw, WriteInt);
            Write(ApiHash, bw, WriteString);
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}