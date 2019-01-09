using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class KickFromChannel : Record<KickFromChannel>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public bool Kicked { get; }
        
        public KickFromChannel(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            bool kicked
        ) {
            Channel = channel;
            UserId = userId;
            Kicked = kicked;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa672de14);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Kicked, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}