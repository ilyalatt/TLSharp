using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadHistory : Record<ReadHistory>, ITlFunc<T.Messages.AffectedMessages>
    {
        public T.InputPeer Peer { get; }
        public int MaxId { get; }
        
        public ReadHistory(
            Some<T.InputPeer> peer,
            int maxId
        ) {
            Peer = peer;
            MaxId = maxId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0e306d3a);
            Write(Peer, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}