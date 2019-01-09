using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditPhoto : Record<EditPhoto>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        public T.InputChatPhoto Photo { get; }
        
        public EditPhoto(
            Some<T.InputChannel> channel,
            Some<T.InputChatPhoto> photo
        ) {
            Channel = channel;
            Photo = photo;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf12e57c9);
            Write(Channel, bw, WriteSerializable);
            Write(Photo, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}