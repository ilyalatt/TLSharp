using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ResetWebAuthorization : ITlFunc<bool>, IEquatable<ResetWebAuthorization>, IComparable<ResetWebAuthorization>, IComparable
    {
        public long Hash { get; }
        
        public ResetWebAuthorization(
            long hash
        ) {
            Hash = hash;
        }
        
        
        long CmpTuple =>
            Hash;

        public bool Equals(ResetWebAuthorization other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetWebAuthorization x && Equals(x);
        public static bool operator ==(ResetWebAuthorization x, ResetWebAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetWebAuthorization x, ResetWebAuthorization y) => !(x == y);

        public int CompareTo(ResetWebAuthorization other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetWebAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetWebAuthorization x, ResetWebAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetWebAuthorization x, ResetWebAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetWebAuthorization x, ResetWebAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetWebAuthorization x, ResetWebAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2d01b9ef);
            Write(Hash, bw, WriteLong);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}