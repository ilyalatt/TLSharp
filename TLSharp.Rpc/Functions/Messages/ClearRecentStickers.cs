using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ClearRecentStickers : ITlFunc<bool>, IEquatable<ClearRecentStickers>, IComparable<ClearRecentStickers>, IComparable
    {
        public bool Attached { get; }
        
        public ClearRecentStickers(
            bool attached
        ) {
            Attached = attached;
        }
        
        
        bool CmpTuple =>
            Attached;

        public bool Equals(ClearRecentStickers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ClearRecentStickers x && Equals(x);
        public static bool operator ==(ClearRecentStickers x, ClearRecentStickers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ClearRecentStickers x, ClearRecentStickers y) => !(x == y);

        public int CompareTo(ClearRecentStickers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ClearRecentStickers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ClearRecentStickers x, ClearRecentStickers y) => x.CompareTo(y) <= 0;
        public static bool operator <(ClearRecentStickers x, ClearRecentStickers y) => x.CompareTo(y) < 0;
        public static bool operator >(ClearRecentStickers x, ClearRecentStickers y) => x.CompareTo(y) > 0;
        public static bool operator >=(ClearRecentStickers x, ClearRecentStickers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Attached: {Attached})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8999602d);
            Write(MaskBit(0, Attached), bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}