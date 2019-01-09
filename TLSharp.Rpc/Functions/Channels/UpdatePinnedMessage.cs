using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class UpdatePinnedMessage : Record<UpdatePinnedMessage>, ITlFunc<T.UpdatesType>
    {
        public bool Silent { get; }
        public T.InputChannel Channel { get; }
        public int Id { get; }
        
        public UpdatePinnedMessage(
            bool silent,
            Some<T.InputChannel> channel,
            int id
        ) {
            Silent = silent;
            Channel = channel;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa72ded52);
            Write(MaskBit(0, Silent), bw, WriteInt);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}