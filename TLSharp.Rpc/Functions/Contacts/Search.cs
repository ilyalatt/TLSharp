using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class Search : ITlFunc<T.Contacts.Found>, IEquatable<Search>, IComparable<Search>, IComparable
    {
        public string Q { get; }
        public int Limit { get; }
        
        public Search(
            Some<string> q,
            int limit
        ) {
            Q = q;
            Limit = limit;
        }
        
        
        (string, int) CmpTuple =>
            (Q, Limit);

        public bool Equals(Search other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is Search x && Equals(x);
        public static bool operator ==(Search x, Search y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Search x, Search y) => !(x == y);

        public int CompareTo(Search other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is Search x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Search x, Search y) => x.CompareTo(y) <= 0;
        public static bool operator <(Search x, Search y) => x.CompareTo(y) < 0;
        public static bool operator >(Search x, Search y) => x.CompareTo(y) > 0;
        public static bool operator >=(Search x, Search y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Q: {Q}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x11f812d8);
            Write(Q, bw, WriteString);
            Write(Limit, bw, WriteInt);
        }
        
        T.Contacts.Found ITlFunc<T.Contacts.Found>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Found.Deserialize);
    }
}