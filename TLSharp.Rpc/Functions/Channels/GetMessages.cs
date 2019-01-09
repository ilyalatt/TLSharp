using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetMessages : Record<GetMessages>, ITlFunc<T.Messages.Messages>
    {
        public T.InputChannel Channel { get; }
        public Arr<int> Id { get; }
        
        public GetMessages(
            Some<T.InputChannel> channel,
            Some<Arr<int>> id
        ) {
            Channel = channel;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x93d7b347);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}