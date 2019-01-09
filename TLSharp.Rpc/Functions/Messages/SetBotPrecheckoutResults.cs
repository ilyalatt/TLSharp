using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetBotPrecheckoutResults : Record<SetBotPrecheckoutResults>, ITlFunc<bool>
    {
        public bool Success { get; }
        public long QueryId { get; }
        public Option<string> Error { get; }
        
        public SetBotPrecheckoutResults(
            bool success,
            long queryId,
            Option<string> error
        ) {
            Success = success;
            QueryId = queryId;
            Error = error;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x09c2dd95);
            Write(MaskBit(1, Success) | MaskBit(0, Error), bw, WriteInt);
            Write(QueryId, bw, WriteLong);
            Write(Error, bw, WriteOption<string>(WriteString));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}