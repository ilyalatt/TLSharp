using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReorderStickerSets : Record<ReorderStickerSets>, ITlFunc<bool>
    {
        public bool Masks { get; }
        public Arr<long> Order { get; }
        
        public ReorderStickerSets(
            bool masks,
            Some<Arr<long>> order
        ) {
            Masks = masks;
            Order = order;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x78337739);
            Write(MaskBit(0, Masks), bw, WriteInt);
            Write(Order, bw, WriteVector<long>(WriteLong));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}