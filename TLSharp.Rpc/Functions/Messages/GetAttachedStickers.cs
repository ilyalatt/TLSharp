using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetAttachedStickers : Record<GetAttachedStickers>, ITlFunc<Arr<T.StickerSetCovered>>
    {
        public T.InputStickeredMedia Media { get; }
        
        public GetAttachedStickers(
            Some<T.InputStickeredMedia> media
        ) {
            Media = media;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcc5b67cc);
            Write(Media, bw, WriteSerializable);
        }
        
        Arr<T.StickerSetCovered> ITlFunc<Arr<T.StickerSetCovered>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.StickerSetCovered.Deserialize));
    }
}