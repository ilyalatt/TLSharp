using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDialogs : Record<GetDialogs>, ITlFunc<T.Messages.Dialogs>
    {
        public bool ExcludePinned { get; }
        public int OffsetDate { get; }
        public int OffsetId { get; }
        public T.InputPeer OffsetPeer { get; }
        public int Limit { get; }
        
        public GetDialogs(
            bool excludePinned,
            int offsetDate,
            int offsetId,
            Some<T.InputPeer> offsetPeer,
            int limit
        ) {
            ExcludePinned = excludePinned;
            OffsetDate = offsetDate;
            OffsetId = offsetId;
            OffsetPeer = offsetPeer;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x191ba9c5);
            Write(MaskBit(0, ExcludePinned), bw, WriteInt);
            Write(OffsetDate, bw, WriteInt);
            Write(OffsetId, bw, WriteInt);
            Write(OffsetPeer, bw, WriteSerializable);
            Write(Limit, bw, WriteInt);
        }
        
        T.Messages.Dialogs ITlFunc<T.Messages.Dialogs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Dialogs.Deserialize);
    }
}