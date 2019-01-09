using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ReportPeer : Record<ReportPeer>, ITlFunc<bool>
    {
        public T.InputPeer Peer { get; }
        public T.ReportReason Reason { get; }
        
        public ReportPeer(
            Some<T.InputPeer> peer,
            Some<T.ReportReason> reason
        ) {
            Peer = peer;
            Reason = reason;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xae189d5f);
            Write(Peer, bw, WriteSerializable);
            Write(Reason, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}