using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ResetTopPeerRating : Record<ResetTopPeerRating>, ITlFunc<bool>
    {
        public T.TopPeerCategory Category { get; }
        public T.InputPeer Peer { get; }
        
        public ResetTopPeerRating(
            Some<T.TopPeerCategory> category,
            Some<T.InputPeer> peer
        ) {
            Category = category;
            Peer = peer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1ae373ac);
            Write(Category, bw, WriteSerializable);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}