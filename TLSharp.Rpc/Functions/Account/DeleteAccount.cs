using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class DeleteAccount : Record<DeleteAccount>, ITlFunc<bool>
    {
        public string Reason { get; }
        
        public DeleteAccount(
            Some<string> reason
        ) {
            Reason = reason;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x418d4e0b);
            Write(Reason, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}