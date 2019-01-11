using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class GetCallConfig : ITlFunc<T.DataJson>, IEquatable<GetCallConfig>, IComparable<GetCallConfig>, IComparable
    {

        
        public GetCallConfig(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetCallConfig other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetCallConfig x && Equals(x);
        public static bool operator ==(GetCallConfig x, GetCallConfig y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetCallConfig x, GetCallConfig y) => !(x == y);

        public int CompareTo(GetCallConfig other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetCallConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetCallConfig x, GetCallConfig y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetCallConfig x, GetCallConfig y) => x.CompareTo(y) < 0;
        public static bool operator >(GetCallConfig x, GetCallConfig y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetCallConfig x, GetCallConfig y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x55451fa9);

        }
        
        T.DataJson ITlFunc<T.DataJson>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DataJson.Deserialize);
    }
}