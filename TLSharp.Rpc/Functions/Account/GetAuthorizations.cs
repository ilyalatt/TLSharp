using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetAuthorizations : ITlFunc<T.Account.Authorizations>, IEquatable<GetAuthorizations>, IComparable<GetAuthorizations>, IComparable
    {

        
        public GetAuthorizations(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetAuthorizations other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetAuthorizations x && Equals(x);
        public static bool operator ==(GetAuthorizations x, GetAuthorizations y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAuthorizations x, GetAuthorizations y) => !(x == y);

        public int CompareTo(GetAuthorizations other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetAuthorizations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAuthorizations x, GetAuthorizations y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAuthorizations x, GetAuthorizations y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAuthorizations x, GetAuthorizations y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAuthorizations x, GetAuthorizations y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe320c158);

        }
        
        T.Account.Authorizations ITlFunc<T.Account.Authorizations>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.Authorizations.Deserialize);
    }
}