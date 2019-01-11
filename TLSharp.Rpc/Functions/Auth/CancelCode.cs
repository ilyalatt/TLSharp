using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class CancelCode : ITlFunc<bool>, IEquatable<CancelCode>, IComparable<CancelCode>, IComparable
    {
        public string PhoneNumber { get; }
        public string PhoneCodeHash { get; }
        
        public CancelCode(
            Some<string> phoneNumber,
            Some<string> phoneCodeHash
        ) {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
        }
        
        
        (string, string) CmpTuple =>
            (PhoneNumber, PhoneCodeHash);

        public bool Equals(CancelCode other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is CancelCode x && Equals(x);
        public static bool operator ==(CancelCode x, CancelCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CancelCode x, CancelCode y) => !(x == y);

        public int CompareTo(CancelCode other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is CancelCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CancelCode x, CancelCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(CancelCode x, CancelCode y) => x.CompareTo(y) < 0;
        public static bool operator >(CancelCode x, CancelCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(CancelCode x, CancelCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber}, PhoneCodeHash: {PhoneCodeHash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1f040578);
            Write(PhoneNumber, bw, WriteString);
            Write(PhoneCodeHash, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}