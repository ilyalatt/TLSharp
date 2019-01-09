using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SearchGifs : Record<SearchGifs>, ITlFunc<T.Messages.FoundGifs>
    {
        public string Q { get; }
        public int Offset { get; }
        
        public SearchGifs(
            Some<string> q,
            int offset
        ) {
            Q = q;
            Offset = offset;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbf9a776b);
            Write(Q, bw, WriteString);
            Write(Offset, bw, WriteInt);
        }
        
        T.Messages.FoundGifs ITlFunc<T.Messages.FoundGifs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.FoundGifs.Deserialize);
    }
}