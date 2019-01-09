using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ReportSpam : Record<ReportSpam>, ITlFunc<bool>
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public Arr<int> Id { get; }
        
        public ReportSpam(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            Some<Arr<int>> id
        ) {
            Channel = channel;
            UserId = userId;
            Id = id;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfe087810);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}