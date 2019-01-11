using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UnregisterDevice : ITlFunc<bool>, IEquatable<UnregisterDevice>, IComparable<UnregisterDevice>, IComparable
    {
        public int TokenType { get; }
        public string Token { get; }
        public Arr<int> OtherUids { get; }
        
        public UnregisterDevice(
            int tokenType,
            Some<string> token,
            Some<Arr<int>> otherUids
        ) {
            TokenType = tokenType;
            Token = token;
            OtherUids = otherUids;
        }
        
        
        (int, string, Arr<int>) CmpTuple =>
            (TokenType, Token, OtherUids);

        public bool Equals(UnregisterDevice other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UnregisterDevice x && Equals(x);
        public static bool operator ==(UnregisterDevice x, UnregisterDevice y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UnregisterDevice x, UnregisterDevice y) => !(x == y);

        public int CompareTo(UnregisterDevice other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UnregisterDevice x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UnregisterDevice x, UnregisterDevice y) => x.CompareTo(y) <= 0;
        public static bool operator <(UnregisterDevice x, UnregisterDevice y) => x.CompareTo(y) < 0;
        public static bool operator >(UnregisterDevice x, UnregisterDevice y) => x.CompareTo(y) > 0;
        public static bool operator >=(UnregisterDevice x, UnregisterDevice y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(TokenType: {TokenType}, Token: {Token}, OtherUids: {OtherUids})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3076c4bf);
            Write(TokenType, bw, WriteInt);
            Write(Token, bw, WriteString);
            Write(OtherUids, bw, WriteVector<int>(WriteInt));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}