using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetWebPage : Record<GetWebPage>, ITlFunc<T.WebPage>
    {
        public string Url { get; }
        public int Hash { get; }
        
        public GetWebPage(
            Some<string> url,
            int hash
        ) {
            Url = url;
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x32ca8f91);
            Write(Url, bw, WriteString);
            Write(Hash, bw, WriteInt);
        }
        
        T.WebPage ITlFunc<T.WebPage>.DeserializeResult(BinaryReader br) =>
            Read(br, T.WebPage.Deserialize);
    }
}