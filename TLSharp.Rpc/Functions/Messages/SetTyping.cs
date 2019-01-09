using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetTyping : Record<SetTyping>, ITlFunc<bool>
    {
        public T.InputPeer Peer { get; }
        public T.SendMessageAction Action { get; }
        
        public SetTyping(
            Some<T.InputPeer> peer,
            Some<T.SendMessageAction> action
        ) {
            Peer = peer;
            Action = action;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa3825e50);
            Write(Peer, bw, WriteSerializable);
            Write(Action, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}