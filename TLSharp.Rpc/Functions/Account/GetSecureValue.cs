using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetSecureValue : ITlFunc<Arr<T.SecureValue>>, IEquatable<GetSecureValue>, IComparable<GetSecureValue>, IComparable
    {
        public Arr<T.SecureValueType> Types { get; }
        
        public GetSecureValue(
            Some<Arr<T.SecureValueType>> types
        ) {
            Types = types;
        }
        
        
        Arr<T.SecureValueType> CmpTuple =>
            Types;

        public bool Equals(GetSecureValue other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetSecureValue x && Equals(x);
        public static bool operator ==(GetSecureValue x, GetSecureValue y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetSecureValue x, GetSecureValue y) => !(x == y);

        public int CompareTo(GetSecureValue other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetSecureValue x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetSecureValue x, GetSecureValue y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetSecureValue x, GetSecureValue y) => x.CompareTo(y) < 0;
        public static bool operator >(GetSecureValue x, GetSecureValue y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetSecureValue x, GetSecureValue y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Types: {Types})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x73665bc2);
            Write(Types, bw, WriteVector<T.SecureValueType>(WriteSerializable));
        }
        
        Arr<T.SecureValue> ITlFunc<Arr<T.SecureValue>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.SecureValue.Deserialize));
    }
}