using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetPeerSettings : Record<GetPeerSettings>, ITlFunc<T.PeerSettings>
    {
        public T.InputPeer Peer { get; }
        
        public GetPeerSettings(
            Some<T.InputPeer> peer
        ) {
            Peer = peer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3672e09c);
            Write(Peer, bw, WriteSerializable);
        }
        
        T.PeerSettings ITlFunc<T.PeerSettings>.DeserializeResult(BinaryReader br) =>
            Read(br, T.PeerSettings.Deserialize);
    }
}