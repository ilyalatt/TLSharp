using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetChannels : Record<GetChannels>, ITlFunc<T.Messages.Chats>
    {
        public Arr<T.InputChannel> Id { get; }
        
        public GetChannels(
            Some<Arr<T.InputChannel>> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0a7f6bbb);
            Write(Id, bw, WriteVector<T.InputChannel>(WriteSerializable));
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}