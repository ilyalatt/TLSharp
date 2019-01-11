using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ResolveUsername : ITlFunc<T.Contacts.ResolvedPeer>, IEquatable<ResolveUsername>, IComparable<ResolveUsername>, IComparable
    {
        public string Username { get; }
        
        public ResolveUsername(
            Some<string> username
        ) {
            Username = username;
        }
        
        
        string CmpTuple =>
            Username;

        public bool Equals(ResolveUsername other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResolveUsername x && Equals(x);
        public static bool operator ==(ResolveUsername x, ResolveUsername y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResolveUsername x, ResolveUsername y) => !(x == y);

        public int CompareTo(ResolveUsername other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResolveUsername x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResolveUsername x, ResolveUsername y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResolveUsername x, ResolveUsername y) => x.CompareTo(y) < 0;
        public static bool operator >(ResolveUsername x, ResolveUsername y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResolveUsername x, ResolveUsername y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Username: {Username})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf93ccba3);
            Write(Username, bw, WriteString);
        }
        
        T.Contacts.ResolvedPeer ITlFunc<T.Contacts.ResolvedPeer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.ResolvedPeer.Deserialize);
    }
}