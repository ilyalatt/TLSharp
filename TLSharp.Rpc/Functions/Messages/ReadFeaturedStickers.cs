using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadFeaturedStickers : Record<ReadFeaturedStickers>, ITlFunc<bool>
    {
        public Arr<long> Id { get; }
        
        public ReadFeaturedStickers(
            Some<Arr<long>> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5b118126);
            Write(Id, bw, WriteVector<long>(WriteLong));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}