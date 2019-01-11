using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class DeleteAccount : ITlFunc<bool>, IEquatable<DeleteAccount>, IComparable<DeleteAccount>, IComparable
    {
        public string Reason { get; }
        
        public DeleteAccount(
            Some<string> reason
        ) {
            Reason = reason;
        }
        
        
        string CmpTuple =>
            Reason;

        public bool Equals(DeleteAccount other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is DeleteAccount x && Equals(x);
        public static bool operator ==(DeleteAccount x, DeleteAccount y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteAccount x, DeleteAccount y) => !(x == y);

        public int CompareTo(DeleteAccount other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is DeleteAccount x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteAccount x, DeleteAccount y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteAccount x, DeleteAccount y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteAccount x, DeleteAccount y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteAccount x, DeleteAccount y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Reason: {Reason})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x418d4e0b);
            Write(Reason, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}