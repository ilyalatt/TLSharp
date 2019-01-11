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
        public bool AppSandbox { get; }
        public Arr<byte> Secret { get; }
        public Arr<int> OtherUids { get; }
        
        public RegisterDevice(
            int tokenType,
            Some<string> token,
            bool appSandbox,
            Some<Arr<byte>> secret,
            Some<Arr<int>> otherUids
        ) {
            TokenType = tokenType;
            Token = token;
            AppSandbox = appSandbox;
            Secret = secret;
            OtherUids = otherUids;
        }
        
        
        (int, string, bool, Arr<byte>, Arr<int>) CmpTuple =>
            (TokenType, Token, AppSandbox, Secret, OtherUids);

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

        public override string ToString() => $"(TokenType: {TokenType}, Token: {Token}, AppSandbox: {AppSandbox}, Secret: {Secret}, OtherUids: {OtherUids})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5cbea590);
            Write(TokenType, bw, WriteInt);
            Write(Token, bw, WriteString);
            Write(AppSandbox, bw, WriteBool);
            Write(Secret, bw, WriteBytes);
            Write(OtherUids, bw, WriteVector<int>(WriteInt));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}