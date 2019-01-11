using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetGameScore : ITlFunc<T.UpdatesType>, IEquatable<SetGameScore>, IComparable<SetGameScore>, IComparable
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
        
        
        (bool, bool, T.InputPeer, int, T.InputUser, int) CmpTuple =>
            (EditMessage, Force, Peer, Id, UserId, Score);

        public bool Equals(SetGameScore other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetGameScore x && Equals(x);
        public static bool operator ==(SetGameScore x, SetGameScore y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetGameScore x, SetGameScore y) => !(x == y);

        public int CompareTo(SetGameScore other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetGameScore x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetGameScore x, SetGameScore y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetGameScore x, SetGameScore y) => x.CompareTo(y) < 0;
        public static bool operator >(SetGameScore x, SetGameScore y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetGameScore x, SetGameScore y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(EditMessage: {EditMessage}, Force: {Force}, Peer: {Peer}, Id: {Id}, UserId: {UserId}, Score: {Score})";
        
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