using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetTermsOfService : ITlFunc<T.Help.TermsOfService>, IEquatable<GetTermsOfService>, IComparable<GetTermsOfService>, IComparable
    {

        
        public GetTermsOfService(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetTermsOfService other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetTermsOfService x && Equals(x);
        public static bool operator ==(GetTermsOfService x, GetTermsOfService y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetTermsOfService x, GetTermsOfService y) => !(x == y);

        public int CompareTo(GetTermsOfService other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetTermsOfService x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetTermsOfService x, GetTermsOfService y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetTermsOfService x, GetTermsOfService y) => x.CompareTo(y) < 0;
        public static bool operator >(GetTermsOfService x, GetTermsOfService y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetTermsOfService x, GetTermsOfService y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x350170f3);

        }
        
        T.Help.TermsOfService ITlFunc<T.Help.TermsOfService>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.TermsOfService.Deserialize);
    }
}