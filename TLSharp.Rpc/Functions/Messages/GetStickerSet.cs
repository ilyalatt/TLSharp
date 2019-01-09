using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetStickerSet : Record<GetStickerSet>, ITlFunc<T.Messages.StickerSet>
    {
        public T.InputStickerSet Stickerset { get; }
        
        public GetStickerSet(
            Some<T.InputStickerSet> stickerset
        ) {
            Stickerset = stickerset;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2619a90e);
            Write(Stickerset, bw, WriteSerializable);
        }
        
        T.Messages.StickerSet ITlFunc<T.Messages.StickerSet>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSet.Deserialize);
    }
}