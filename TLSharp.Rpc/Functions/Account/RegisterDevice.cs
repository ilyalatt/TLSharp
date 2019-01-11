using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class RegisterDevice : ITlFunc<bool>, IEquatable<RegisterDevice>, IComparable<RegisterDevice>, IComparable
    {
        public int TokenType { get; }
        public string Token { get; }
        
        public RegisterDevice(
            int tokenType,
            Some<string> token
        ) {
            TokenType = tokenType;
            Token = token;
        }
        
        
        (int, string) CmpTuple =>
            (TokenType, Token);

        public bool Equals(RegisterDevice other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is RegisterDevice x && Equals(x);
        public static bool operator ==(RegisterDevice x, RegisterDevice y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RegisterDevice x, RegisterDevice y) => !(x == y);

        public int CompareTo(RegisterDevice other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is RegisterDevice x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RegisterDevice x, RegisterDevice y) => x.CompareTo(y) <= 0;
        public static bool operator <(RegisterDevice x, RegisterDevice y) => x.CompareTo(y) < 0;
        public static bool operator >(RegisterDevice x, RegisterDevice y) => x.CompareTo(y) > 0;
        public static bool operator >=(RegisterDevice x, RegisterDevice y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(TokenType: {TokenType}, Token: {Token})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x637ea878);
            Write(TokenType, bw, WriteInt);
            Write(Token, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}