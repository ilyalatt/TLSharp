using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class DeleteSecureValue : ITlFunc<bool>, IEquatable<DeleteSecureValue>, IComparable<DeleteSecureValue>, IComparable
    {
        public Arr<T.SecureValueType> Types { get; }
        
        public DeleteSecureValue(
            Some<Arr<T.SecureValueType>> types
        ) {
            Types = types;
        }
        
        
        Arr<T.SecureValueType> CmpTuple =>
            Types;

        public bool Equals(DeleteSecureValue other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteSecureValue x && Equals(x);
        public static bool operator ==(DeleteSecureValue x, DeleteSecureValue y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteSecureValue x, DeleteSecureValue y) => !(x == y);

        public int CompareTo(DeleteSecureValue other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteSecureValue x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteSecureValue x, DeleteSecureValue y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteSecureValue x, DeleteSecureValue y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteSecureValue x, DeleteSecureValue y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteSecureValue x, DeleteSecureValue y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Types: {Types})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb880bc4b);
            Write(Types, bw, WriteVector<T.SecureValueType>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}