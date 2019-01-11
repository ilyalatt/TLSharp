using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class VerifyEmail : ITlFunc<bool>, IEquatable<VerifyEmail>, IComparable<VerifyEmail>, IComparable
    {
        public string Email { get; }
        public string Code { get; }
        
        public VerifyEmail(
            Some<string> email,
            Some<string> code
        ) {
            Email = email;
            Code = code;
        }
        
        
        (string, string) CmpTuple =>
            (Email, Code);

        public bool Equals(VerifyEmail other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is VerifyEmail x && Equals(x);
        public static bool operator ==(VerifyEmail x, VerifyEmail y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(VerifyEmail x, VerifyEmail y) => !(x == y);

        public int CompareTo(VerifyEmail other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is VerifyEmail x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(VerifyEmail x, VerifyEmail y) => x.CompareTo(y) <= 0;
        public static bool operator <(VerifyEmail x, VerifyEmail y) => x.CompareTo(y) < 0;
        public static bool operator >(VerifyEmail x, VerifyEmail y) => x.CompareTo(y) > 0;
        public static bool operator >=(VerifyEmail x, VerifyEmail y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Email: {Email}, Code: {Code})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xecba39db);
            Write(Email, bw, WriteString);
            Write(Code, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}