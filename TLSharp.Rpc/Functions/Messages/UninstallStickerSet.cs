using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class UninstallStickerSet : Record<UninstallStickerSet>, ITlFunc<bool>
    {
        public T.InputStickerSet Stickerset { get; }
        
        public UninstallStickerSet(
            Some<T.InputStickerSet> stickerset
        ) {
            Stickerset = stickerset;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf96e55de);
            Write(Stickerset, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}