using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class InstallStickerSet : Record<InstallStickerSet>, ITlFunc<T.Messages.StickerSetInstallResult>
    {
        public T.InputStickerSet Stickerset { get; }
        public bool Archived { get; }
        
        public InstallStickerSet(
            Some<T.InputStickerSet> stickerset,
            bool archived
        ) {
            Stickerset = stickerset;
            Archived = archived;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc78fe460);
            Write(Stickerset, bw, WriteSerializable);
            Write(Archived, bw, WriteBool);
        }
        
        T.Messages.StickerSetInstallResult ITlFunc<T.Messages.StickerSetInstallResult>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.StickerSetInstallResult.Deserialize);
    }
}