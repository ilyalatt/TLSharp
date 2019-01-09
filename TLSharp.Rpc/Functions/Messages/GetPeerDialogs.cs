using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetPeerDialogs : Record<GetPeerDialogs>, ITlFunc<T.Messages.PeerDialogs>
    {
        public Arr<T.InputPeer> Peers { get; }
        
        public GetPeerDialogs(
            Some<Arr<T.InputPeer>> peers
        ) {
            Peers = peers;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2d9776b9);
            Write(Peers, bw, WriteVector<T.InputPeer>(WriteSerializable));
        }
        
        T.Messages.PeerDialogs ITlFunc<T.Messages.PeerDialogs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.PeerDialogs.Deserialize);
    }
}