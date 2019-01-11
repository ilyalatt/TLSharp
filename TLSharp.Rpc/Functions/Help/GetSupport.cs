using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetSupport : ITlFunc<T.Help.Support>, IEquatable<GetSupport>, IComparable<GetSupport>, IComparable
    {

        
        public GetSupport(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetSupport other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetSupport x && Equals(x);
        public static bool operator ==(GetSupport x, GetSupport y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetSupport x, GetSupport y) => !(x == y);

        public int CompareTo(GetSupport other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetSupport x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetSupport x, GetSupport y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetSupport x, GetSupport y) => x.CompareTo(y) < 0;
        public static bool operator >(GetSupport x, GetSupport y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetSupport x, GetSupport y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9cdf08cd);

        }
        
        T.Help.Support ITlFunc<T.Help.Support>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.Support.Deserialize);
    }
}