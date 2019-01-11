using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ResetSaved : ITlFunc<bool>, IEquatable<ResetSaved>, IComparable<ResetSaved>, IComparable
    {

        
        public ResetSaved(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(ResetSaved other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetSaved x && Equals(x);
        public static bool operator ==(ResetSaved x, ResetSaved y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetSaved x, ResetSaved y) => !(x == y);

        public int CompareTo(ResetSaved other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetSaved x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetSaved x, ResetSaved y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetSaved x, ResetSaved y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetSaved x, ResetSaved y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetSaved x, ResetSaved y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x879537f1);

        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}