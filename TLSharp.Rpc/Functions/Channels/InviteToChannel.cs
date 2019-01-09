using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class InviteToChannel : Record<InviteToChannel>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        public Arr<T.InputUser> Users { get; }
        
        public InviteToChannel(
            Some<T.InputChannel> channel,
            Some<Arr<T.InputUser>> users
        ) {
            Channel = channel;
            Users = users;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x199f3a6c);
            Write(Channel, bw, WriteSerializable);
            Write(Users, bw, WriteVector<T.InputUser>(WriteSerializable));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}