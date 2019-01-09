using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetWebPagePreview : Record<GetWebPagePreview>, ITlFunc<T.MessageMedia>
    {
        public string Message { get; }
        
        public GetWebPagePreview(
            Some<string> message
        ) {
            Message = message;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x25223e24);
            Write(Message, bw, WriteString);
        }
        
        T.MessageMedia ITlFunc<T.MessageMedia>.DeserializeResult(BinaryReader br) =>
            Read(br, T.MessageMedia.Deserialize);
    }
}