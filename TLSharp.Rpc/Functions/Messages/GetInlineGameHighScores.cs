using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetInlineGameHighScores : ITlFunc<T.Messages.HighScores>, IEquatable<GetInlineGameHighScores>, IComparable<GetInlineGameHighScores>, IComparable
    {
        public T.InputBotInlineMessageId Id { get; }
        public T.InputUser UserId { get; }
        
        public GetInlineGameHighScores(
            Some<T.InputBotInlineMessageId> id,
            Some<T.InputUser> userId
        ) {
            Id = id;
            UserId = userId;
        }
        
        
        (T.InputBotInlineMessageId, T.InputUser) CmpTuple =>
            (Id, UserId);

        public bool Equals(GetInlineGameHighScores other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetInlineGameHighScores x && Equals(x);
        public static bool operator ==(GetInlineGameHighScores x, GetInlineGameHighScores y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetInlineGameHighScores x, GetInlineGameHighScores y) => !(x == y);

        public int CompareTo(GetInlineGameHighScores other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetInlineGameHighScores x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetInlineGameHighScores x, GetInlineGameHighScores y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetInlineGameHighScores x, GetInlineGameHighScores y) => x.CompareTo(y) < 0;
        public static bool operator >(GetInlineGameHighScores x, GetInlineGameHighScores y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetInlineGameHighScores x, GetInlineGameHighScores y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id}, UserId: {UserId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0f635e1b);
            Write(Id, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Messages.HighScores ITlFunc<T.Messages.HighScores>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.HighScores.Deserialize);
    }
}