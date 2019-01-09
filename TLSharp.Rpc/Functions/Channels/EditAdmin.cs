using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditAdmin : Record<EditAdmin>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public T.ChannelParticipantRole Role { get; }
        
        public EditAdmin(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            Some<T.ChannelParticipantRole> role
        ) {
            Channel = channel;
            UserId = userId;
            Role = role;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeb7611d0);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Role, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}