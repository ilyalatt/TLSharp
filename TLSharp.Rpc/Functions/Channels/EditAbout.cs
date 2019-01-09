using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditAbout : Record<EditAbout>, ITlFunc<bool>
    {
        public T.InputChannel Channel { get; }
        public string About { get; }
        
        public EditAbout(
            Some<T.InputChannel> channel,
            Some<string> about
        ) {
            Channel = channel;
            About = about;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x13e27f1e);
            Write(Channel, bw, WriteSerializable);
            Write(About, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}