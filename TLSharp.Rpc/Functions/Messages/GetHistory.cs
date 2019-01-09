using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetHistory : Record<GetHistory>, ITlFunc<T.Messages.Messages>
    {
        public T.InputPeer Peer { get; }
        public int OffsetId { get; }
        public int OffsetDate { get; }
        public int AddOffset { get; }
        public int Limit { get; }
        public int MaxId { get; }
        public int MinId { get; }
        
        public GetHistory(
            Some<T.InputPeer> peer,
            int offsetId,
            int offsetDate,
            int addOffset,
            int limit,
            int maxId,
            int minId
        ) {
            Peer = peer;
            OffsetId = offsetId;
            OffsetDate = offsetDate;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xafa92846);
            Write(Peer, bw, WriteSerializable);
            Write(OffsetId, bw, WriteInt);
            Write(OffsetDate, bw, WriteInt);
            Write(AddOffset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
            Write(MaxId, bw, WriteInt);
            Write(MinId, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}