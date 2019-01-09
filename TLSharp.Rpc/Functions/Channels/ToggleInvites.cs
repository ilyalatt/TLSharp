using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ToggleInvites : Record<ToggleInvites>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        public bool Enabled { get; }
        
        public ToggleInvites(
            Some<T.InputChannel> channel,
            bool enabled
        ) {
            Channel = channel;
            Enabled = enabled;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x49609307);
            Write(Channel, bw, WriteSerializable);
            Write(Enabled, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}