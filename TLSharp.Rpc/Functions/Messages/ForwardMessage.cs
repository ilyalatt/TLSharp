using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ForwardMessage : Record<ForwardMessage>, ITlFunc<T.UpdatesType>
    {
        public T.InputPeer Peer { get; }
        public int Id { get; }
        public long RandomId { get; }
        
        public ForwardMessage(
            Some<T.InputPeer> peer,
            int id,
            long randomId
        ) {
            Peer = peer;
            Id = id;
            RandomId = randomId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x33963bf9);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
            Write(RandomId, bw, WriteLong);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}