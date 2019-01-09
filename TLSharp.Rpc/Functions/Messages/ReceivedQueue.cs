using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReceivedQueue : Record<ReceivedQueue>, ITlFunc<Arr<long>>
    {
        public int MaxQts { get; }
        
        public ReceivedQueue(
            int maxQts
        ) {
            MaxQts = maxQts;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x55a5bb66);
            Write(MaxQts, bw, WriteInt);
        }
        
        Arr<long> ITlFunc<Arr<long>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadLong));
    }
}