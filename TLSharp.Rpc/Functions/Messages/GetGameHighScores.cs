using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetGameHighScores : Record<GetGameHighScores>, ITlFunc<T.Messages.HighScores>
    {
        public T.InputPeer Peer { get; }
        public int Id { get; }
        public T.InputUser UserId { get; }
        
        public GetGameHighScores(
            Some<T.InputPeer> peer,
            int id,
            Some<T.InputUser> userId
        ) {
            Peer = peer;
            Id = id;
            UserId = userId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe822649d);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Messages.HighScores ITlFunc<T.Messages.HighScores>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.HighScores.Deserialize);
    }
}