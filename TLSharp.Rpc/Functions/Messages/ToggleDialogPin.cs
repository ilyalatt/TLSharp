using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ToggleDialogPin : Record<ToggleDialogPin>, ITlFunc<bool>
    {
        public bool Pinned { get; }
        public T.InputPeer Peer { get; }
        
        public ToggleDialogPin(
            bool pinned,
            Some<T.InputPeer> peer
        ) {
            Pinned = pinned;
            Peer = peer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3289be6a);
            Write(MaskBit(0, Pinned), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}