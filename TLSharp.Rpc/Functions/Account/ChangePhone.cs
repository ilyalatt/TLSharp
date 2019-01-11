using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ChangePhone : ITlFunc<T.User>, IEquatable<ChangePhone>, IComparable<ChangePhone>, IComparable
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        
        public ChangePhone(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash,
            Some<string> phoneCode
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
        }
        
        
        (string, string, string) CmpTuple =>
            (PhoneNumber, PhoneCodeHash, PhoneCode);

        public bool Equals(ChangePhone other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ChangePhone x && Equals(x);
        public static bool operator ==(ChangePhone x, ChangePhone y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ChangePhone x, ChangePhone y) => !(x == y);

        public int CompareTo(ChangePhone other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ChangePhone x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ChangePhone x, ChangePhone y) => x.CompareTo(y) <= 0;
        public static bool operator <(ChangePhone x, ChangePhone y) => x.CompareTo(y) < 0;
        public static bool operator >(ChangePhone x, ChangePhone y) => x.CompareTo(y) > 0;
        public static bool operator >=(ChangePhone x, ChangePhone y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber}, PhoneCodeHash: {PhoneCodeHash}, PhoneCode: {PhoneCode})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x70c32edb);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}