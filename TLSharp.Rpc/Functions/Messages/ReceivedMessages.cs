using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReceivedMessages : Record<ReceivedMessages>, ITlFunc<Arr<T.ReceivedNotifyMessage>>
    {
        public int MaxId { get; }
        
        public ReceivedMessages(
            int maxId
        ) {
            MaxId = maxId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x05a954c0);
            Write(MaxId, bw, WriteInt);
        }
        
        Arr<T.ReceivedNotifyMessage> ITlFunc<Arr<T.ReceivedNotifyMessage>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.ReceivedNotifyMessage.Deserialize));
    }
}