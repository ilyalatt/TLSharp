using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetGameScore : Record<SetGameScore>, ITlFunc<T.UpdatesType>
    {
        public bool EditMessage { get; }
        public bool Force { get; }
        public T.InputPeer Peer { get; }
        public int Id { get; }
        public T.InputUser UserId { get; }
        public int Score { get; }
        
        public SetGameScore(
            bool editMessage,
            bool force,
            Some<T.InputPeer> peer,
            int id,
            Some<T.InputUser> userId,
            int score
        ) {
            EditMessage = editMessage;
            Force = force;
            Peer = peer;
            Id = id;
            UserId = userId;
            Score = score;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8ef8ecc0);
            Write(MaskBit(0, EditMessage) | MaskBit(1, Force), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
            Write(UserId, bw, WriteSerializable);
            Write(Score, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}