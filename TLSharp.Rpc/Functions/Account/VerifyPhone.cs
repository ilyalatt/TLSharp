using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class VerifyPhone : ITlFunc<bool>, IEquatable<VerifyPhone>, IComparable<VerifyPhone>, IComparable
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        
        public VerifyPhone(
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

        public bool Equals(VerifyPhone other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is VerifyPhone x && Equals(x);
        public static bool operator ==(VerifyPhone x, VerifyPhone y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(VerifyPhone x, VerifyPhone y) => !(x == y);

        public int CompareTo(VerifyPhone other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is VerifyPhone x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(VerifyPhone x, VerifyPhone y) => x.CompareTo(y) <= 0;
        public static bool operator <(VerifyPhone x, VerifyPhone y) => x.CompareTo(y) < 0;
        public static bool operator >(VerifyPhone x, VerifyPhone y) => x.CompareTo(y) > 0;
        public static bool operator >=(VerifyPhone x, VerifyPhone y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber}, PhoneCodeHash: {PhoneCodeHash}, PhoneCode: {PhoneCode})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4dd3a7f6);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}