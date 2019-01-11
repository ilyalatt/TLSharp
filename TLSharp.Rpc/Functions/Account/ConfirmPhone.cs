using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ConfirmPhone : ITlFunc<bool>, IEquatable<ConfirmPhone>, IComparable<ConfirmPhone>, IComparable
    {
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        
        public ConfirmPhone(
            Some<string> phoneCodeHash,
            Some<string> phoneCode
        ) {
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
        }
        
        
        (string, string) CmpTuple =>
            (PhoneCodeHash, PhoneCode);

        public bool Equals(ConfirmPhone other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ConfirmPhone x && Equals(x);
        public static bool operator ==(ConfirmPhone x, ConfirmPhone y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ConfirmPhone x, ConfirmPhone y) => !(x == y);

        public int CompareTo(ConfirmPhone other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ConfirmPhone x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ConfirmPhone x, ConfirmPhone y) => x.CompareTo(y) <= 0;
        public static bool operator <(ConfirmPhone x, ConfirmPhone y) => x.CompareTo(y) < 0;
        public static bool operator >(ConfirmPhone x, ConfirmPhone y) => x.CompareTo(y) > 0;
        public static bool operator >=(ConfirmPhone x, ConfirmPhone y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneCodeHash: {PhoneCodeHash}, PhoneCode: {PhoneCode})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5f2178c3);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}