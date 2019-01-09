using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetArchivedStickers : Record<GetArchivedStickers>, ITlFunc<T.Messages.ArchivedStickers>
    {
        public bool Masks { get; }
        public long OffsetId { get; }
        public int Limit { get; }
        
        public GetArchivedStickers(
            bool masks,
            long offsetId,
            int limit
        ) {
            Masks = masks;
            OffsetId = offsetId;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x57f17692);
            Write(MaskBit(0, Masks), bw, WriteInt);
            Write(OffsetId, bw, WriteLong);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.ArchivedStickers ITlFunc<T.Messages.ArchivedStickers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.ArchivedStickers.Deserialize);
    }
}