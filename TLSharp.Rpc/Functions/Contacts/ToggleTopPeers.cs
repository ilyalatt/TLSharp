using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ToggleTopPeers : ITlFunc<bool>, IEquatable<ToggleTopPeers>, IComparable<ToggleTopPeers>, IComparable
    {
        public bool Enabled { get; }
        
        public ToggleTopPeers(
            bool enabled
        ) {
            Enabled = enabled;
        }
        
        
        bool CmpTuple =>
            Enabled;

        public bool Equals(ToggleTopPeers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ToggleTopPeers x && Equals(x);
        public static bool operator ==(ToggleTopPeers x, ToggleTopPeers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ToggleTopPeers x, ToggleTopPeers y) => !(x == y);

        public int CompareTo(ToggleTopPeers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ToggleTopPeers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ToggleTopPeers x, ToggleTopPeers y) => x.CompareTo(y) <= 0;
        public static bool operator <(ToggleTopPeers x, ToggleTopPeers y) => x.CompareTo(y) < 0;
        public static bool operator >(ToggleTopPeers x, ToggleTopPeers y) => x.CompareTo(y) > 0;
        public static bool operator >=(ToggleTopPeers x, ToggleTopPeers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Enabled: {Enabled})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8514bdda);
            Write(Enabled, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}