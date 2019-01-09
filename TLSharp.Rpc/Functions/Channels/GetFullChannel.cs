using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetFullChannel : Record<GetFullChannel>, ITlFunc<T.Messages.ChatFull>
    {
        public T.InputChannel Channel { get; }
        
        public GetFullChannel(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x08736a09);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.Messages.ChatFull ITlFunc<T.Messages.ChatFull>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.ChatFull.Deserialize);
    }
}