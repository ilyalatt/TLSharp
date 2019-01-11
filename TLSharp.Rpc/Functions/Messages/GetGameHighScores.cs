using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetGameHighScores : ITlFunc<T.Messages.HighScores>, IEquatable<GetGameHighScores>, IComparable<GetGameHighScores>, IComparable
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
        
        
        (T.InputPeer, int, T.InputUser) CmpTuple =>
            (Peer, Id, UserId);

        public bool Equals(GetGameHighScores other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetGameHighScores x && Equals(x);
        public static bool operator ==(GetGameHighScores x, GetGameHighScores y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetGameHighScores x, GetGameHighScores y) => !(x == y);

        public int CompareTo(GetGameHighScores other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetGameHighScores x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetGameHighScores x, GetGameHighScores y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetGameHighScores x, GetGameHighScores y) => x.CompareTo(y) < 0;
        public static bool operator >(GetGameHighScores x, GetGameHighScores y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetGameHighScores x, GetGameHighScores y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Id: {Id}, UserId: {UserId})";
        
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