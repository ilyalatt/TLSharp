using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class RegisterDevice : Record<RegisterDevice>, ITlFunc<bool>
    {
        public int TokenType { get; }
        public string Token { get; }
        
        public RegisterDevice(
            int tokenType,
            Some<string> token
        ) {
            TokenType = tokenType;
            Token = token;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x637ea878);
            Write(TokenType, bw, WriteInt);
            Write(Token, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}