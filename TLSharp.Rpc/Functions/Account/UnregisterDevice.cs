using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UnregisterDevice : Record<UnregisterDevice>, ITlFunc<bool>
    {
        public int TokenType { get; }
        public string Token { get; }
        
        public UnregisterDevice(
            int tokenType,
            Some<string> token
        ) {
            TokenType = tokenType;
            Token = token;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x65c55b40);
            Write(TokenType, bw, WriteInt);
            Write(Token, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}