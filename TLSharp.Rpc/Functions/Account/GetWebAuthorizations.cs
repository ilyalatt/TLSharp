using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetWebAuthorizations : ITlFunc<T.Account.WebAuthorizations>, IEquatable<GetWebAuthorizations>, IComparable<GetWebAuthorizations>, IComparable
    {

        
        public GetWebAuthorizations(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetWebAuthorizations other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetWebAuthorizations x && Equals(x);
        public static bool operator ==(GetWebAuthorizations x, GetWebAuthorizations y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetWebAuthorizations x, GetWebAuthorizations y) => !(x == y);

        public int CompareTo(GetWebAuthorizations other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetWebAuthorizations x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetWebAuthorizations x, GetWebAuthorizations y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetWebAuthorizations x, GetWebAuthorizations y) => x.CompareTo(y) < 0;
        public static bool operator >(GetWebAuthorizations x, GetWebAuthorizations y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetWebAuthorizations x, GetWebAuthorizations y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x182e6d6f);

        }
        
        T.Account.WebAuthorizations ITlFunc<T.Account.WebAuthorizations>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.WebAuthorizations.Deserialize);
    }
}