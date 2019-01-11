using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateUsername : ITlFunc<T.User>, IEquatable<UpdateUsername>, IComparable<UpdateUsername>, IComparable
    {
        public string Username { get; }
        
        public UpdateUsername(
            Some<string> username
        ) {
            Username = username;
        }
        
        
        string CmpTuple =>
            Username;

        public bool Equals(UpdateUsername other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UpdateUsername x && Equals(x);
        public static bool operator ==(UpdateUsername x, UpdateUsername y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdateUsername x, UpdateUsername y) => !(x == y);

        public int CompareTo(UpdateUsername other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UpdateUsername x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdateUsername x, UpdateUsername y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdateUsername x, UpdateUsername y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdateUsername x, UpdateUsername y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdateUsername x, UpdateUsername y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Username: {Username})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3e0bdd7c);
            Write(Username, bw, WriteString);
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}