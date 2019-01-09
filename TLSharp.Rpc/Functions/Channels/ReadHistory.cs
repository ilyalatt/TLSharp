using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ReadHistory : Record<ReadHistory>, ITlFunc<bool>
    {
        public T.InputChannel Channel { get; }
        public int MaxId { get; }
        
        public ReadHistory(
            Some<T.InputChannel> channel,
            int maxId
        ) {
            Channel = channel;
            MaxId = maxId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcc104937);
            Write(Channel, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}