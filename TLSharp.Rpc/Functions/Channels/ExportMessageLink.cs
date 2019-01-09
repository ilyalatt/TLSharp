using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ExportMessageLink : Record<ExportMessageLink>, ITlFunc<T.ExportedMessageLink>
    {
        public T.InputChannel Channel { get; }
        public int Id { get; }
        
        public ExportMessageLink(
            Some<T.InputChannel> channel,
            int id
        ) {
            Channel = channel;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc846d22d);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
        }
        
        T.ExportedMessageLink ITlFunc<T.ExportedMessageLink>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ExportedMessageLink.Deserialize);
    }
}