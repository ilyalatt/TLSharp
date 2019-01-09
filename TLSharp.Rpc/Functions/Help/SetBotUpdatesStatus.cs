using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class SetBotUpdatesStatus : Record<SetBotUpdatesStatus>, ITlFunc<bool>
    {
        public int PendingUpdatesCount { get; }
        public string Message { get; }
        
        public SetBotUpdatesStatus(
            int pendingUpdatesCount,
            Some<string> message
        ) {
            PendingUpdatesCount = pendingUpdatesCount;
            Message = message;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xec22cfcd);
            Write(PendingUpdatesCount, bw, WriteInt);
            Write(Message, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}