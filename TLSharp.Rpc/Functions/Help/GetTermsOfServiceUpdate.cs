using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetTermsOfServiceUpdate : ITlFunc<T.Help.TermsOfServiceUpdate>, IEquatable<GetTermsOfServiceUpdate>, IComparable<GetTermsOfServiceUpdate>, IComparable
    {

        
        public GetTermsOfServiceUpdate(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetTermsOfServiceUpdate other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetTermsOfServiceUpdate x && Equals(x);
        public static bool operator ==(GetTermsOfServiceUpdate x, GetTermsOfServiceUpdate y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetTermsOfServiceUpdate x, GetTermsOfServiceUpdate y) => !(x == y);

        public int CompareTo(GetTermsOfServiceUpdate other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetTermsOfServiceUpdate x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetTermsOfServiceUpdate x, GetTermsOfServiceUpdate y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetTermsOfServiceUpdate x, GetTermsOfServiceUpdate y) => x.CompareTo(y) < 0;
        public static bool operator >(GetTermsOfServiceUpdate x, GetTermsOfServiceUpdate y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetTermsOfServiceUpdate x, GetTermsOfServiceUpdate y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2ca51fd1);

        }
        
        T.Help.TermsOfServiceUpdate ITlFunc<T.Help.TermsOfServiceUpdate>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.TermsOfServiceUpdate.Deserialize);
    }
}