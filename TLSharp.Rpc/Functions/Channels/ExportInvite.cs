using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ExportInvite : Record<ExportInvite>, ITlFunc<T.ExportedChatInvite>
    {
        public T.InputChannel Channel { get; }
        
        public ExportInvite(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc7560885);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.ExportedChatInvite ITlFunc<T.ExportedChatInvite>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ExportedChatInvite.Deserialize);
    }
}