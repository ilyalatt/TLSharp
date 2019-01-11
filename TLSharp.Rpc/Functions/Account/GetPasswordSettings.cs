using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetPasswordSettings : ITlFunc<T.Account.PasswordSettings>, IEquatable<GetPasswordSettings>, IComparable<GetPasswordSettings>, IComparable
    {
        public Arr<byte> CurrentPasswordHash { get; }
        
        public GetPasswordSettings(
            Some<Arr<byte>> currentPasswordHash
        ) {
            CurrentPasswordHash = currentPasswordHash;
        }
        
        
        Arr<byte> CmpTuple =>
            CurrentPasswordHash;

        public bool Equals(GetPasswordSettings other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetPasswordSettings x && Equals(x);
        public static bool operator ==(GetPasswordSettings x, GetPasswordSettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPasswordSettings x, GetPasswordSettings y) => !(x == y);

        public int CompareTo(GetPasswordSettings other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetPasswordSettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPasswordSettings x, GetPasswordSettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPasswordSettings x, GetPasswordSettings y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPasswordSettings x, GetPasswordSettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPasswordSettings x, GetPasswordSettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(CurrentPasswordHash: {CurrentPasswordHash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbc8d11bb);
            Write(CurrentPasswordHash, bw, WriteBytes);
        }
        
        T.Account.PasswordSettings ITlFunc<T.Account.PasswordSettings>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.PasswordSettings.Deserialize);
    }
}