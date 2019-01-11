using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetStatuses : ITlFunc<Arr<T.ContactStatus>>, IEquatable<GetStatuses>, IComparable<GetStatuses>, IComparable
    {

        
        public GetStatuses(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetStatuses other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetStatuses x && Equals(x);
        public static bool operator ==(GetStatuses x, GetStatuses y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetStatuses x, GetStatuses y) => !(x == y);

        public int CompareTo(GetStatuses other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetStatuses x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetStatuses x, GetStatuses y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetStatuses x, GetStatuses y) => x.CompareTo(y) < 0;
        public static bool operator >(GetStatuses x, GetStatuses y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetStatuses x, GetStatuses y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc4a353ee);

        }
        
        Arr<T.ContactStatus> ITlFunc<Arr<T.ContactStatus>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.ContactStatus.Deserialize));
    }
}