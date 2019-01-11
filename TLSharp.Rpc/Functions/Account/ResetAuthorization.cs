using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ResetAuthorization : ITlFunc<bool>, IEquatable<ResetAuthorization>, IComparable<ResetAuthorization>, IComparable
    {
        public long Hash { get; }
        
        public ResetAuthorization(
            long hash
        ) {
            Hash = hash;
        }
        
        
        long CmpTuple =>
            Hash;

        public bool Equals(ResetAuthorization other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetAuthorization x && Equals(x);
        public static bool operator ==(ResetAuthorization x, ResetAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetAuthorization x, ResetAuthorization y) => !(x == y);

        public int CompareTo(ResetAuthorization other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetAuthorization x, ResetAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetAuthorization x, ResetAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetAuthorization x, ResetAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetAuthorization x, ResetAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdf77f3bc);
            Write(Hash, bw, WriteLong);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}