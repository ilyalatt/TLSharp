using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetRecentStickers : Record<GetRecentStickers>, ITlFunc<T.Messages.RecentStickers>
    {
        public bool Attached { get; }
        public int Hash { get; }
        
        public GetRecentStickers(
            bool attached,
            int hash
        ) {
            Attached = attached;
            Hash = hash;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5ea192c9);
            Write(MaskBit(0, Attached), bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.RecentStickers ITlFunc<T.Messages.RecentStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.RecentStickers.Deserialize);
    }
}