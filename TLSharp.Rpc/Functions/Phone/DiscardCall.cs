using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class DiscardCall : Record<DiscardCall>, ITlFunc<T.UpdatesType>
    {
        public T.InputPhoneCall Peer { get; }
        public int Duration { get; }
        public T.PhoneCallDiscardReason Reason { get; }
        public long ConnectionId { get; }
        
        public DiscardCall(
            Some<T.InputPhoneCall> peer,
            int duration,
            Some<T.PhoneCallDiscardReason> reason,
            long connectionId
        ) {
            Peer = peer;
            Duration = duration;
            Reason = reason;
            ConnectionId = connectionId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x78d413a6);
            Write(Peer, bw, WriteSerializable);
            Write(Duration, bw, WriteInt);
            Write(Reason, bw, WriteSerializable);
            Write(ConnectionId, bw, WriteLong);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}