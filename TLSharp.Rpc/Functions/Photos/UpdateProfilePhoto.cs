using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class UpdateProfilePhoto : Record<UpdateProfilePhoto>, ITlFunc<T.UserProfilePhoto>
    {
        public T.InputPhoto Id { get; }
        
        public UpdateProfilePhoto(
            Some<T.InputPhoto> id
        ) {
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf0bb5152);
            Write(Id, bw, WriteSerializable);
        }
        
        T.UserProfilePhoto ITlFunc<T.UserProfilePhoto>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UserProfilePhoto.Deserialize);
    }
}