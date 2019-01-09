using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditTitle : Record<EditTitle>, ITlFunc<T.UpdatesType>
    {
        public T.InputChannel Channel { get; }
        public string Title { get; }
        
        public EditTitle(
            Some<T.InputChannel> channel,
            Some<string> title
        ) {
            Channel = channel;
            Title = title;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x566decd0);
            Write(Channel, bw, WriteSerializable);
            Write(Title, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}