using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetEncryptedTyping : Record<SetEncryptedTyping>, ITlFunc<bool>
    {
        public T.InputEncryptedChat Peer { get; }
        public bool Typing { get; }
        
        public SetEncryptedTyping(
            Some<T.InputEncryptedChat> peer,
            bool typing
        ) {
            Peer = peer;
            Typing = typing;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x791451ed);
            Write(Peer, bw, WriteSerializable);
            Write(Typing, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}