using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class Search : Record<Search>, ITlFunc<T.Messages.Messages>
    {
        public T.InputPeer Peer { get; }
        public string Q { get; }
        public T.MessagesFilter Filter { get; }
        public int MinDate { get; }
        public int MaxDate { get; }
        public int Offset { get; }
        public int MaxId { get; }
        public int Limit { get; }
        
        public Search(
            Some<T.InputPeer> peer,
            Some<string> q,
            Some<T.MessagesFilter> filter,
            int minDate,
            int maxDate,
            int offset,
            int maxId,
            int limit
        ) {
            Peer = peer;
            Q = q;
            Filter = filter;
            MinDate = minDate;
            MaxDate = maxDate;
            Offset = offset;
            MaxId = maxId;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd4569248);
            Write(0, bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(Q, bw, WriteString);
            Write(Filter, bw, WriteSerializable);
            Write(MinDate, bw, WriteInt);
            Write(MaxDate, bw, WriteInt);
            Write(Offset, bw, WriteInt);
            Write(MaxId, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}