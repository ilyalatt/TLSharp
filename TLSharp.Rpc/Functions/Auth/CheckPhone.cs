using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class CheckPhone : ITlFunc<T.Auth.CheckedPhone>, IEquatable<CheckPhone>, IComparable<CheckPhone>, IComparable
    {
        public string PhoneNumber { get; }
        
        public CheckPhone(
            Some<string> phoneNumber
        ) {
            PhoneNumber = phoneNumber;
        }
        
        
        string CmpTuple =>
            PhoneNumber;

        public bool Equals(CheckPhone other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is CheckPhone x && Equals(x);
        public static bool operator ==(CheckPhone x, CheckPhone y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CheckPhone x, CheckPhone y) => !(x == y);

        public int CompareTo(CheckPhone other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CheckPhone x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CheckPhone x, CheckPhone y) => x.CompareTo(y) <= 0;
        public static bool operator <(CheckPhone x, CheckPhone y) => x.CompareTo(y) < 0;
        public static bool operator >(CheckPhone x, CheckPhone y) => x.CompareTo(y) > 0;
        public static bool operator >=(CheckPhone x, CheckPhone y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumber: {PhoneNumber})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6fe51dfb);
            Write(PhoneNumber, bw, WriteString);
        }
        
        T.Auth.CheckedPhone ITlFunc<T.Auth.CheckedPhone>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.CheckedPhone.Deserialize);
    }
}