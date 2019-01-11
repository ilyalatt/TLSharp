using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetBotPrecheckoutResults : ITlFunc<bool>, IEquatable<SetBotPrecheckoutResults>, IComparable<SetBotPrecheckoutResults>, IComparable
    {
        public bool Success { get; }
        public long QueryId { get; }
        public Option<string> Error { get; }
        
        public SetBotPrecheckoutResults(
            bool success,
            long queryId,
            Option<string> error
        ) {
            Success = success;
            QueryId = queryId;
            Error = error;
        }
        
        
        (bool, long, Option<string>) CmpTuple =>
            (Success, QueryId, Error);

        public bool Equals(SetBotPrecheckoutResults other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetBotPrecheckoutResults x && Equals(x);
        public static bool operator ==(SetBotPrecheckoutResults x, SetBotPrecheckoutResults y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetBotPrecheckoutResults x, SetBotPrecheckoutResults y) => !(x == y);

        public int CompareTo(SetBotPrecheckoutResults other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetBotPrecheckoutResults x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetBotPrecheckoutResults x, SetBotPrecheckoutResults y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetBotPrecheckoutResults x, SetBotPrecheckoutResults y) => x.CompareTo(y) < 0;
        public static bool operator >(SetBotPrecheckoutResults x, SetBotPrecheckoutResults y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetBotPrecheckoutResults x, SetBotPrecheckoutResults y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Success: {Success}, QueryId: {QueryId}, Error: {Error})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x09c2dd95);
            Write(MaskBit(1, Success) | MaskBit(0, Error), bw, WriteInt);
            Write(QueryId, bw, WriteLong);
            Write(Error, bw, WriteOption<string>(WriteString));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}