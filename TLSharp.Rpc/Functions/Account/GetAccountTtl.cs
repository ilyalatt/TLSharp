using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetAccountTtl : ITlFunc<T.AccountDaysTtl>, IEquatable<GetAccountTtl>, IComparable<GetAccountTtl>, IComparable
    {

        
        public GetAccountTtl(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetAccountTtl other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetAccountTtl x && Equals(x);
        public static bool operator ==(GetAccountTtl x, GetAccountTtl y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAccountTtl x, GetAccountTtl y) => !(x == y);

        public int CompareTo(GetAccountTtl other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetAccountTtl x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAccountTtl x, GetAccountTtl y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAccountTtl x, GetAccountTtl y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAccountTtl x, GetAccountTtl y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAccountTtl x, GetAccountTtl y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x08fc711d);

        }
        
        T.AccountDaysTtl ITlFunc<T.AccountDaysTtl>.DeserializeResult(BinaryReader br) =>
            Read(br, T.AccountDaysTtl.Deserialize);
    }
}