using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class DeleteUserHistory : Record<DeleteUserHistory>, ITlFunc<T.Messages.AffectedHistory>
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        
        public DeleteUserHistory(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId
        ) {
            Channel = channel;
            UserId = userId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd10dd71b);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Messages.AffectedHistory ITlFunc<T.Messages.AffectedHistory>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedHistory.Deserialize);
    }
}