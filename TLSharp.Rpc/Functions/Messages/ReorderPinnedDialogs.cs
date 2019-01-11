using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReorderPinnedDialogs : ITlFunc<bool>, IEquatable<ReorderPinnedDialogs>, IComparable<ReorderPinnedDialogs>, IComparable
    {
        public bool Force { get; }
        public Arr<T.InputPeer> Order { get; }
        
        public ReorderPinnedDialogs(
            bool force,
            Some<Arr<T.InputPeer>> order
        ) {
            Force = force;
            Order = order;
        }
        
        
        (bool, Arr<T.InputPeer>) CmpTuple =>
            (Force, Order);

        public bool Equals(ReorderPinnedDialogs other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReorderPinnedDialogs x && Equals(x);
        public static bool operator ==(ReorderPinnedDialogs x, ReorderPinnedDialogs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReorderPinnedDialogs x, ReorderPinnedDialogs y) => !(x == y);

        public int CompareTo(ReorderPinnedDialogs other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReorderPinnedDialogs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReorderPinnedDialogs x, ReorderPinnedDialogs y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReorderPinnedDialogs x, ReorderPinnedDialogs y) => x.CompareTo(y) < 0;
        public static bool operator >(ReorderPinnedDialogs x, ReorderPinnedDialogs y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReorderPinnedDialogs x, ReorderPinnedDialogs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Force: {Force}, Order: {Order})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x959ff644);
            Write(MaskBit(0, Force), bw, WriteInt);
            Write(Order, bw, WriteVector<T.InputPeer>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}