using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class JoinChannel : Record<JoinChannel>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        
        public JoinChannel(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x24b524c5);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}