using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetParticipant : Record<GetParticipant>, ITlFunc<T.Channels.ChannelParticipant>
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        
        public GetParticipant(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId
        ) {
            Channel = channel;
            UserId = userId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x546dd7a6);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Channels.ChannelParticipant ITlFunc<T.Channels.ChannelParticipant>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Channels.ChannelParticipant.Deserialize);
    }
}