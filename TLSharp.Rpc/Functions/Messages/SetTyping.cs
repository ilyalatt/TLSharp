using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetTyping : ITlFunc<bool>, IEquatable<SetTyping>, IComparable<SetTyping>, IComparable
    {
        public T.InputPeer Peer { get; }
        public T.SendMessageAction Action { get; }
        
        public SetTyping(
            Some<T.InputPeer> peer,
            Some<T.SendMessageAction> action
        ) {
            Peer = peer;
            Action = action;
        }
        
        
        (T.InputPeer, T.SendMessageAction) CmpTuple =>
            (Peer, Action);

        public bool Equals(SetTyping other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetTyping x && Equals(x);
        public static bool operator ==(SetTyping x, SetTyping y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetTyping x, SetTyping y) => !(x == y);

        public int CompareTo(SetTyping other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetTyping x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetTyping x, SetTyping y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetTyping x, SetTyping y) => x.CompareTo(y) < 0;
        public static bool operator >(SetTyping x, SetTyping y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetTyping x, SetTyping y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Action: {Action})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa3825e50);
            Write(Peer, bw, WriteSerializable);
            Write(Action, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}