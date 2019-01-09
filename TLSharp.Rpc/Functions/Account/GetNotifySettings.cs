using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetNotifySettings : Record<GetNotifySettings>, ITlFunc<T.PeerNotifySettings>
    {
        public T.InputNotifyPeer Peer { get; }
        
        public GetNotifySettings(
            Some<T.InputNotifyPeer> peer
        ) {
            Peer = peer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x12b3ad31);
            Write(Peer, bw, WriteSerializable);
        }
        
        T.PeerNotifySettings ITlFunc<T.PeerNotifySettings>.DeserializeResult(BinaryReader br) =>
            Read(br, T.PeerNotifySettings.Deserialize);
    }
}