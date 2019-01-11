using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ResetAuthorizations : ITlFunc<bool>, IEquatable<ResetAuthorizations>, IComparable<ResetAuthorizations>, IComparable
    {

        
        public ResetAuthorizations(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(ResetAuthorizations other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetAuthorizations x && Equals(x);
        public static bool operator ==(ResetAuthorizations x, ResetAuthorizations y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetAuthorizations x, ResetAuthorizations y) => !(x == y);

        public int CompareTo(ResetAuthorizations other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetAuthorizations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetAuthorizations x, ResetAuthorizations y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetAuthorizations x, ResetAuthorizations y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetAuthorizations x, ResetAuthorizations y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetAuthorizations x, ResetAuthorizations y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9fab0d1a);

        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}