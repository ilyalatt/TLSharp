using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SignUp : ITlFunc<T.Auth.Authorization>, IEquatable<SignUp>, IComparable<SignUp>, IComparable
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        public string FirstName { get; }
        public string LastName { get; }
        
        public SignUp(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash,
            Some<string> phoneCode,
            Some<string> firstName,
            Some<string> lastName
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
            FirstName = firstName;
            LastName = lastName;
        }
        
        
        (string, string, string, string, string) CmpTuple =>
            (PhoneNumber, PhoneCodeHash, PhoneCode, FirstName, LastName);

        public bool Equals(SignUp other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SignUp x && Equals(x);
        public static bool operator ==(SignUp x, SignUp y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SignUp x, SignUp y) => !(x == y);

        public int CompareTo(SignUp other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SignUp x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SignUp x, SignUp y) => x.CompareTo(y) <= 0;
        public static bool operator <(SignUp x, SignUp y) => x.CompareTo(y) < 0;
        public static bool operator >(SignUp x, SignUp y) => x.CompareTo(y) > 0;
        public static bool operator >=(SignUp x, SignUp y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber}, PhoneCodeHash: {PhoneCodeHash}, PhoneCode: {PhoneCode}, FirstName: {FirstName}, LastName: {LastName})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1b067634);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
            Write(FirstName, bw, WriteString);
            Write(LastName, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}