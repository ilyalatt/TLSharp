using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetInlineGameScore : ITlFunc<bool>, IEquatable<SetInlineGameScore>, IComparable<SetInlineGameScore>, IComparable
    {
        public bool EditMessage { get; }
        public bool Force { get; }
        public T.InputBotInlineMessageId Id { get; }
        public T.InputUser UserId { get; }
        public int Score { get; }
        
        public SetInlineGameScore(
            bool editMessage,
            bool force,
            Some<T.InputBotInlineMessageId> id,
            Some<T.InputUser> userId,
            int score
        ) {
            EditMessage = editMessage;
            Force = force;
            Id = id;
            UserId = userId;
            Score = score;
        }
        
        
        (bool, bool, T.InputBotInlineMessageId, T.InputUser, int) CmpTuple =>
            (EditMessage, Force, Id, UserId, Score);

        public bool Equals(SetInlineGameScore other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SetInlineGameScore x && Equals(x);
        public static bool operator ==(SetInlineGameScore x, SetInlineGameScore y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetInlineGameScore x, SetInlineGameScore y) => !(x == y);

        public int CompareTo(SetInlineGameScore other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetInlineGameScore x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetInlineGameScore x, SetInlineGameScore y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetInlineGameScore x, SetInlineGameScore y) => x.CompareTo(y) < 0;
        public static bool operator >(SetInlineGameScore x, SetInlineGameScore y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetInlineGameScore x, SetInlineGameScore y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(EditMessage: {EditMessage}, Force: {Force}, Id: {Id}, UserId: {UserId}, Score: {Score})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x15ad9f64);
            Write(MaskBit(0, EditMessage) | MaskBit(1, Force), bw, WriteInt);
            Write(Id, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Score, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}