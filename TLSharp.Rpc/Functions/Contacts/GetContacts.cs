using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetContacts : ITlFunc<T.Contacts.Contacts>, IEquatable<GetContacts>, IComparable<GetContacts>, IComparable
    {
        public string Hash { get; }
        
        public GetContacts(
            Some<string> hash
        ) {
            Hash = hash;
        }
        
        
        string CmpTuple =>
            Hash;

        public bool Equals(GetContacts other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetContacts x && Equals(x);
        public static bool operator ==(GetContacts x, GetContacts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetContacts x, GetContacts y) => !(x == y);

        public int CompareTo(GetContacts other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetContacts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetContacts x, GetContacts y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetContacts x, GetContacts y) => x.CompareTo(y) < 0;
        public static bool operator >(GetContacts x, GetContacts y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetContacts x, GetContacts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x22c6aa08);
            Write(Hash, bw, WriteString);
        }
        
        T.Contacts.Contacts ITlFunc<T.Contacts.Contacts>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Contacts.Deserialize);
    }
}