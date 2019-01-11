using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ToggleDialogPin : ITlFunc<bool>, IEquatable<ToggleDialogPin>, IComparable<ToggleDialogPin>, IComparable
    {
        public bool Pinned { get; }
        public T.InputDialogPeer Peer { get; }
        
        public ToggleDialogPin(
            bool pinned,
            Some<T.InputDialogPeer> peer
        ) {
            Pinned = pinned;
            Peer = peer;
        }
        
        
        (bool, T.InputDialogPeer) CmpTuple =>
            (Pinned, Peer);

        public bool Equals(ToggleDialogPin other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ToggleDialogPin x && Equals(x);
        public static bool operator ==(ToggleDialogPin x, ToggleDialogPin y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ToggleDialogPin x, ToggleDialogPin y) => !(x == y);

        public int CompareTo(ToggleDialogPin other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ToggleDialogPin x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ToggleDialogPin x, ToggleDialogPin y) => x.CompareTo(y) <= 0;
        public static bool operator <(ToggleDialogPin x, ToggleDialogPin y) => x.CompareTo(y) < 0;
        public static bool operator >(ToggleDialogPin x, ToggleDialogPin y) => x.CompareTo(y) > 0;
        public static bool operator >=(ToggleDialogPin x, ToggleDialogPin y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Pinned: {Pinned}, Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa731e257);
            Write(MaskBit(0, Pinned), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}