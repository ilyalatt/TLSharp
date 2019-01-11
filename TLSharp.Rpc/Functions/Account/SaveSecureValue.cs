using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SaveSecureValue : ITlFunc<T.SecureValue>, IEquatable<SaveSecureValue>, IComparable<SaveSecureValue>, IComparable
    {
        public T.InputSecureValue Value { get; }
        public long SecureSecretId { get; }
        
        public SaveSecureValue(
            Some<T.InputSecureValue> value,
            long secureSecretId
        ) {
            Value = value;
            SecureSecretId = secureSecretId;
        }
        
        
        (T.InputSecureValue, long) CmpTuple =>
            (Value, SecureSecretId);

        public bool Equals(SaveSecureValue other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SaveSecureValue x && Equals(x);
        public static bool operator ==(SaveSecureValue x, SaveSecureValue y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveSecureValue x, SaveSecureValue y) => !(x == y);

        public int CompareTo(SaveSecureValue other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SaveSecureValue x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveSecureValue x, SaveSecureValue y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveSecureValue x, SaveSecureValue y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveSecureValue x, SaveSecureValue y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveSecureValue x, SaveSecureValue y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Value: {Value}, SecureSecretId: {SecureSecretId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x899fe31d);
            Write(Value, bw, WriteSerializable);
            Write(SecureSecretId, bw, WriteLong);
        }
        
        T.SecureValue ITlFunc<T.SecureValue>.DeserializeResult(BinaryReader br) =>
            Read(br, T.SecureValue.Deserialize);
    }
}