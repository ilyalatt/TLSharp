using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SetAccountTtl : ITlFunc<bool>, IEquatable<SetAccountTtl>, IComparable<SetAccountTtl>, IComparable
    {
        public T.AccountDaysTtl Ttl { get; }
        
        public SetAccountTtl(
            Some<T.AccountDaysTtl> ttl
        ) {
            Ttl = ttl;
        }
        
        
        T.AccountDaysTtl CmpTuple =>
            Ttl;

        public bool Equals(SetAccountTtl other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetAccountTtl x && Equals(x);
        public static bool operator ==(SetAccountTtl x, SetAccountTtl y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetAccountTtl x, SetAccountTtl y) => !(x == y);

        public int CompareTo(SetAccountTtl other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetAccountTtl x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetAccountTtl x, SetAccountTtl y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetAccountTtl x, SetAccountTtl y) => x.CompareTo(y) < 0;
        public static bool operator >(SetAccountTtl x, SetAccountTtl y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetAccountTtl x, SetAccountTtl y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Ttl: {Ttl})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2442485e);
            Write(Ttl, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}