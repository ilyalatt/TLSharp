using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class UploadProfilePhoto : Record<UploadProfilePhoto>, ITlFunc<T.Photos.Photo>
    {
        public T.InputFile File { get; }
        
        public UploadProfilePhoto(
            Some<T.InputFile> file
        ) {
            File = file;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4f32c098);
            Write(File, bw, WriteSerializable);
        }
        
        T.Photos.Photo ITlFunc<T.Photos.Photo>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Photos.Photo.Deserialize);
    }
}