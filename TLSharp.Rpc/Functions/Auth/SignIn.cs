using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SignIn : ITlFunc<T.Auth.Authorization>, IEquatable<SignIn>, IComparable<SignIn>, IComparable
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        public string PhoneCode { get; }
        
        public SignIn(
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

        public bool Equals(SignIn other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SignIn x && Equals(x);
        public static bool operator ==(SignIn x, SignIn y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SignIn x, SignIn y) => !(x == y);

        public int CompareTo(SignIn other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SignIn x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SignIn x, SignIn y) => x.CompareTo(y) <= 0;
        public static bool operator <(SignIn x, SignIn y) => x.CompareTo(y) < 0;
        public static bool operator >(SignIn x, SignIn y) => x.CompareTo(y) > 0;
        public static bool operator >=(SignIn x, SignIn y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber}, PhoneCodeHash: {PhoneCodeHash}, PhoneCode: {PhoneCode})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbcd51581);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
            Write(PhoneCode, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}