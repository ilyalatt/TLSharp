using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetTmpPassword : ITlFunc<T.Account.TmpPassword>, IEquatable<GetTmpPassword>, IComparable<GetTmpPassword>, IComparable
    {
        public Arr<byte> PasswordHash { get; }
        public int Period { get; }
        
        public GetTmpPassword(
            Some<Arr<byte>> passwordHash,
            int period
        ) {
            PasswordHash = passwordHash;
            Period = period;
        }
        
        
        (Arr<byte>, int) CmpTuple =>
            (PasswordHash, Period);

        public bool Equals(GetTmpPassword other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetTmpPassword x && Equals(x);
        public static bool operator ==(GetTmpPassword x, GetTmpPassword y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetTmpPassword x, GetTmpPassword y) => !(x == y);

        public int CompareTo(GetTmpPassword other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetTmpPassword x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetTmpPassword x, GetTmpPassword y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetTmpPassword x, GetTmpPassword y) => x.CompareTo(y) < 0;
        public static bool operator >(GetTmpPassword x, GetTmpPassword y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetTmpPassword x, GetTmpPassword y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PasswordHash: {PasswordHash}, Period: {Period})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4a82327e);
            Write(PasswordHash, bw, WriteBytes);
            Write(Period, bw, WriteInt);
        }
        
        T.Account.TmpPassword ITlFunc<T.Account.TmpPassword>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.TmpPassword.Deserialize);
    }
}