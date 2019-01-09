using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DeleteHistory : Record<DeleteHistory>, ITlFunc<T.Messages.AffectedHistory>
    {
        public bool JustClear { get; }
        public T.InputPeer Peer { get; }
        public int MaxId { get; }
        
        public DeleteHistory(
            bool justClear,
            Some<T.InputPeer> peer,
            int maxId
        ) {
            JustClear = justClear;
            Peer = peer;
            MaxId = maxId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1c015b09);
            Write(MaskBit(0, JustClear), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(MaxId, bw, WriteInt);
        }
        
        T.Messages.AffectedHistory ITlFunc<T.Messages.AffectedHistory>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedHistory.Deserialize);
    }
}