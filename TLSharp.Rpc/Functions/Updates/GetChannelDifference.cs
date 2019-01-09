using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Updates
{
    public sealed class GetChannelDifference : Record<GetChannelDifference>, ITlFunc<T.Updates.ChannelDifference>
    {
        public bool Force { get; }
        public T.InputChannel Channel { get; }
        public T.ChannelMessagesFilter Filter { get; }
        public int Pts { get; }
        public int Limit { get; }
        
        public GetChannelDifference(
            bool force,
            Some<T.InputChannel> channel,
            Some<T.ChannelMessagesFilter> filter,
            int pts,
            int limit
        ) {
            Force = force;
            Channel = channel;
            Filter = filter;
            Pts = pts;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x03173d78);
            Write(MaskBit(0, Force), bw, WriteInt);
            Write(Channel, bw, WriteSerializable);
            Write(Filter, bw, WriteSerializable);
            Write(Pts, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Updates.ChannelDifference ITlFunc<T.Updates.ChannelDifference>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Updates.ChannelDifference.Deserialize);
    }
}