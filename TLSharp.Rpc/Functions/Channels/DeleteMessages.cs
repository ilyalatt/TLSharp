using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class DeleteMessages : Record<DeleteMessages>, ITlFunc<T.Messages.AffectedMessages>
    {
        public T.InputChannel Channel { get; }
        public Arr<int> Id { get; }
        
        public DeleteMessages(
            Some<T.InputChannel> channel,
            Some<Arr<int>> id
        ) {
            Channel = channel;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x84c1fd4e);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}