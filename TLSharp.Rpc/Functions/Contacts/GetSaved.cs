using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetSaved : ITlFunc<Arr<T.SavedContact>>, IEquatable<GetSaved>, IComparable<GetSaved>, IComparable
    {

        
        public GetSaved(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetSaved other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetSaved x && Equals(x);
        public static bool operator ==(GetSaved x, GetSaved y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetSaved x, GetSaved y) => !(x == y);

        public int CompareTo(GetSaved other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetSaved x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetSaved x, GetSaved y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetSaved x, GetSaved y) => x.CompareTo(y) < 0;
        public static bool operator >(GetSaved x, GetSaved y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetSaved x, GetSaved y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x82f1e39f);

        }
        
        Arr<T.SavedContact> ITlFunc<Arr<T.SavedContact>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.SavedContact.Deserialize));
    }
}