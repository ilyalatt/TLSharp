using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMessageEditData : Record<GetMessageEditData>, ITlFunc<T.Messages.MessageEditData>
    {
        public T.InputPeer Peer { get; }
        public int Id { get; }
        
        public GetMessageEditData(
            Some<T.InputPeer> peer,
            int id
        ) {
            Peer = peer;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfda68d36);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
        }
        
        T.Messages.MessageEditData ITlFunc<T.Messages.MessageEditData>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.MessageEditData.Deserialize);
    }
}