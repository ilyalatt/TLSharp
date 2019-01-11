using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class CheckPassword : ITlFunc<T.Auth.Authorization>, IEquatable<CheckPassword>, IComparable<CheckPassword>, IComparable
    {
        public Arr<byte> PasswordHash { get; }
        
        public CheckPassword(
            Some<Arr<byte>> passwordHash
        ) {
            PasswordHash = passwordHash;
        }
        
        
        Arr<byte> CmpTuple =>
            PasswordHash;

        public bool Equals(CheckPassword other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is CheckPassword x && Equals(x);
        public static bool operator ==(CheckPassword x, CheckPassword y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CheckPassword x, CheckPassword y) => !(x == y);

        public int CompareTo(CheckPassword other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is CheckPassword x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CheckPassword x, CheckPassword y) => x.CompareTo(y) <= 0;
        public static bool operator <(CheckPassword x, CheckPassword y) => x.CompareTo(y) < 0;
        public static bool operator >(CheckPassword x, CheckPassword y) => x.CompareTo(y) > 0;
        public static bool operator >=(CheckPassword x, CheckPassword y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PasswordHash: {PasswordHash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0a63011e);
            Write(PasswordHash, bw, WriteBytes);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}