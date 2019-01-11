using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class MarkDialogUnread : ITlFunc<bool>, IEquatable<MarkDialogUnread>, IComparable<MarkDialogUnread>, IComparable
    {
        public bool Unread { get; }
        public T.InputDialogPeer Peer { get; }
        
        public MarkDialogUnread(
            bool unread,
            Some<T.InputDialogPeer> peer
        ) {
            Unread = unread;
            Peer = peer;
        }
        
        
        (bool, T.InputDialogPeer) CmpTuple =>
            (Unread, Peer);

        public bool Equals(MarkDialogUnread other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is MarkDialogUnread x && Equals(x);
        public static bool operator ==(MarkDialogUnread x, MarkDialogUnread y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MarkDialogUnread x, MarkDialogUnread y) => !(x == y);

        public int CompareTo(MarkDialogUnread other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is MarkDialogUnread x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MarkDialogUnread x, MarkDialogUnread y) => x.CompareTo(y) <= 0;
        public static bool operator <(MarkDialogUnread x, MarkDialogUnread y) => x.CompareTo(y) < 0;
        public static bool operator >(MarkDialogUnread x, MarkDialogUnread y) => x.CompareTo(y) > 0;
        public static bool operator >=(MarkDialogUnread x, MarkDialogUnread y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Unread: {Unread}, Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc286d98f);
            Write(MaskBit(0, Unread), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}