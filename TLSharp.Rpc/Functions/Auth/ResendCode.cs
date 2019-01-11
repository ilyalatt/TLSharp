using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ResendCode : ITlFunc<T.Auth.SentCode>, IEquatable<ResendCode>, IComparable<ResendCode>, IComparable
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        
        public ResendCode(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
        }
        
        
        (string, string) CmpTuple =>
            (PhoneNumber, PhoneCodeHash);

        public bool Equals(ResendCode other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResendCode x && Equals(x);
        public static bool operator ==(ResendCode x, ResendCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResendCode x, ResendCode y) => !(x == y);

        public int CompareTo(ResendCode other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResendCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResendCode x, ResendCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResendCode x, ResendCode y) => x.CompareTo(y) < 0;
        public static bool operator >(ResendCode x, ResendCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResendCode x, ResendCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber}, PhoneCodeHash: {PhoneCodeHash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3ef1a9bf);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}