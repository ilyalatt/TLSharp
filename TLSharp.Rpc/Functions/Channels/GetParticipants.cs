using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetParticipants : Record<GetParticipants>, ITlFunc<T.Channels.ChannelParticipants>
    {
        public T.InputChannel Channel { get; }
        public T.ChannelParticipantsFilter Filter { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetParticipants(
            Some<T.InputChannel> channel,
            Some<T.ChannelParticipantsFilter> filter,
            int offset,
            int limit
        ) {
            Channel = channel;
            Filter = filter;
            Offset = offset;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x24d98f92);
            Write(Channel, bw, WriteSerializable);
            Write(Filter, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Channels.ChannelParticipants ITlFunc<T.Channels.ChannelParticipants>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Channels.ChannelParticipants.Deserialize);
    }
}