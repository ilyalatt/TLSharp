using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class CheckChatInvite : Record<CheckChatInvite>, ITlFunc<T.ChatInvite>
    {
        public string Hash { get; }
        
        public CheckChatInvite(
            Some<string> hash
        ) {
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3eadb1bb);
            Write(Hash, bw, WriteString);
        }
        
        T.ChatInvite ITlFunc<T.ChatInvite>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ChatInvite.Deserialize);
    }
}