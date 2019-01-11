using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetCdnConfig : ITlFunc<T.CdnConfig>, IEquatable<GetCdnConfig>, IComparable<GetCdnConfig>, IComparable
    {

        
        public GetCdnConfig(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetCdnConfig other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetCdnConfig x && Equals(x);
        public static bool operator ==(GetCdnConfig x, GetCdnConfig y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetCdnConfig x, GetCdnConfig y) => !(x == y);

        public int CompareTo(GetCdnConfig other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetCdnConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetCdnConfig x, GetCdnConfig y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetCdnConfig x, GetCdnConfig y) => x.CompareTo(y) < 0;
        public static bool operator >(GetCdnConfig x, GetCdnConfig y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetCdnConfig x, GetCdnConfig y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x52029342);

        }
        
        T.CdnConfig ITlFunc<T.CdnConfig>.DeserializeResult(BinaryReader br) =>
            Read(br, T.CdnConfig.Deserialize);
    }
}