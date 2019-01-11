using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ResetWebAuthorizations : ITlFunc<bool>, IEquatable<ResetWebAuthorizations>, IComparable<ResetWebAuthorizations>, IComparable
    {

        
        public ResetWebAuthorizations(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(ResetWebAuthorizations other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetWebAuthorizations x && Equals(x);
        public static bool operator ==(ResetWebAuthorizations x, ResetWebAuthorizations y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetWebAuthorizations x, ResetWebAuthorizations y) => !(x == y);

        public int CompareTo(ResetWebAuthorizations other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetWebAuthorizations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetWebAuthorizations x, ResetWebAuthorizations y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetWebAuthorizations x, ResetWebAuthorizations y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetWebAuthorizations x, ResetWebAuthorizations y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetWebAuthorizations x, ResetWebAuthorizations y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x682d2594);

        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}