using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class Unblock : ITlFunc<bool>, IEquatable<Unblock>, IComparable<Unblock>, IComparable
    {
        public T.InputUser Id { get; }
        
        public Unblock(
            Some<T.InputUser> id
        ) {
            Id = id;
        }
        
        
        T.InputUser CmpTuple =>
            Id;

        public bool Equals(Unblock other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is Unblock x && Equals(x);
        public static bool operator ==(Unblock x, Unblock y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Unblock x, Unblock y) => !(x == y);

        public int CompareTo(Unblock other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is Unblock x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Unblock x, Unblock y) => x.CompareTo(y) <= 0;
        public static bool operator <(Unblock x, Unblock y) => x.CompareTo(y) < 0;
        public static bool operator >(Unblock x, Unblock y) => x.CompareTo(y) > 0;
        public static bool operator >=(Unblock x, Unblock y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe54100bd);
            Write(Id, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}