using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SearchGlobal : Record<SearchGlobal>, ITlFunc<T.Messages.Messages>
    {
        public string Q { get; }
        public int OffsetDate { get; }
        public T.InputPeer OffsetPeer { get; }
        public int OffsetId { get; }
        public int Limit { get; }
        
        public SearchGlobal(
            Some<string> q,
            int offsetDate,
            Some<T.InputPeer> offsetPeer,
            int offsetId,
            int limit
        ) {
            Q = q;
            OffsetDate = offsetDate;
            OffsetPeer = offsetPeer;
            OffsetId = offsetId;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9e3cacb0);
            Write(Q, bw, WriteString);
            Write(OffsetDate, bw, WriteInt);
            Write(OffsetPeer, bw, WriteSerializable);
            Write(OffsetId, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}