using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class CreateChannel : Record<CreateChannel>, ITlFunc<T.UpdatesType>
    {
        public bool Broadcast { get; }
        public bool Megagroup { get; }
        public string Title { get; }
        public string About { get; }
        
        public CreateChannel(
            bool broadcast,
            bool megagroup,
            Some<string> title,
            Some<string> about
        ) {
            Broadcast = broadcast;
            Megagroup = megagroup;
            Title = title;
            About = about;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf4893d7f);
            Write(MaskBit(0, Broadcast) | MaskBit(1, Megagroup), bw, WriteInt);
            Write(Title, bw, WriteString);
            Write(About, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}