using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetBlocked : ITlFunc<T.Contacts.Blocked>, IEquatable<GetBlocked>, IComparable<GetBlocked>, IComparable
    {
        public int Offset { get; }
        public int Limit { get; }
        
        public GetBlocked(
            int offset,
            int limit
        ) {
            Offset = offset;
            Limit = limit;
        }
        
        
        (int, int) CmpTuple =>
            (Offset, Limit);

        public bool Equals(GetBlocked other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetBlocked x && Equals(x);
        public static bool operator ==(GetBlocked x, GetBlocked y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetBlocked x, GetBlocked y) => !(x == y);

        public int CompareTo(GetBlocked other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetBlocked x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetBlocked x, GetBlocked y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetBlocked x, GetBlocked y) => x.CompareTo(y) < 0;
        public static bool operator >(GetBlocked x, GetBlocked y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetBlocked x, GetBlocked y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Offset: {Offset}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf57c350f);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Contacts.Blocked ITlFunc<T.Contacts.Blocked>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Blocked.Deserialize);
    }
}