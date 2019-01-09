using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateNotifySettings : Record<UpdateNotifySettings>, ITlFunc<bool>
    {
        public T.InputNotifyPeer Peer { get; }
        public T.InputPeerNotifySettings Settings { get; }
        
        public UpdateNotifySettings(
            Some<T.InputNotifyPeer> peer,
            Some<T.InputPeerNotifySettings> settings
        ) {
            Peer = peer;
            Settings = settings;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x84be5b93);
            Write(Peer, bw, WriteSerializable);
            Write(Settings, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}