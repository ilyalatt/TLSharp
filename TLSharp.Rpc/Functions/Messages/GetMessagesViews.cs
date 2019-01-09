using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMessagesViews : Record<GetMessagesViews>, ITlFunc<Arr<int>>
    {
        public T.InputPeer Peer { get; }
        public Arr<int> Id { get; }
        public bool Increment { get; }
        
        public GetMessagesViews(
            Some<T.InputPeer> peer,
            Some<Arr<int>> id,
            bool increment
        ) {
            Peer = peer;
            Id = id;
            Increment = increment;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc4c8a55d);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
            Write(Increment, bw, WriteBool);
        }
        
        Arr<int> ITlFunc<Arr<int>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadInt));
    }
}