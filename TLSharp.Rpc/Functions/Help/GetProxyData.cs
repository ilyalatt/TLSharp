using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetProxyData : ITlFunc<T.Help.ProxyData>, IEquatable<GetProxyData>, IComparable<GetProxyData>, IComparable
    {

        
        public GetProxyData(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetProxyData other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetProxyData x && Equals(x);
        public static bool operator ==(GetProxyData x, GetProxyData y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetProxyData x, GetProxyData y) => !(x == y);

        public int CompareTo(GetProxyData other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetProxyData x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetProxyData x, GetProxyData y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetProxyData x, GetProxyData y) => x.CompareTo(y) < 0;
        public static bool operator >(GetProxyData x, GetProxyData y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetProxyData x, GetProxyData y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3d7758e1);

        }
        
        T.Help.ProxyData ITlFunc<T.Help.ProxyData>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.ProxyData.Deserialize);
    }
}