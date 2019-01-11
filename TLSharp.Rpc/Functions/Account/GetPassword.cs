using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetPassword : ITlFunc<T.Account.Password>, IEquatable<GetPassword>, IComparable<GetPassword>, IComparable
    {

        
        public GetPassword(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetPassword other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetPassword x && Equals(x);
        public static bool operator ==(GetPassword x, GetPassword y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPassword x, GetPassword y) => !(x == y);

        public int CompareTo(GetPassword other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetPassword x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPassword x, GetPassword y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPassword x, GetPassword y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPassword x, GetPassword y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPassword x, GetPassword y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x548a30f5);

        }
        
        T.Account.Password ITlFunc<T.Account.Password>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.Password.Deserialize);
    }
}