using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ClearRecentStickers : Record<ClearRecentStickers>, ITlFunc<bool>
    {
        public bool Attached { get; }
        
        public ClearRecentStickers(
            bool attached
        ) {
            Attached = attached;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8999602d);
            Write(MaskBit(0, Attached), bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}