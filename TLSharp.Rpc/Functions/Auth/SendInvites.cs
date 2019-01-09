using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SendInvites : Record<SendInvites>, ITlFunc<bool>
    {
        public Arr<string> PhoneNumbers { get; }
        public string Message { get; }
        
        public SendInvites(
            Some<Arr<string>> phoneNumbers,
            Some<string> message
        ) {
            PhoneNumbers = phoneNumbers;
            Message = message;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x771c1d97);
            Write(PhoneNumbers, bw, WriteVector<string>(WriteString));
            Write(Message, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}