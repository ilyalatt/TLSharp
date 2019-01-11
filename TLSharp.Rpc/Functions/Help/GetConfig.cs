using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetConfig : ITlFunc<T.Config>, IEquatable<GetConfig>, IComparable<GetConfig>, IComparable
    {

        
        public GetConfig(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetConfig other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetConfig x && Equals(x);
        public static bool operator ==(GetConfig x, GetConfig y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetConfig x, GetConfig y) => !(x == y);

        public int CompareTo(GetConfig other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetConfig x, GetConfig y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetConfig x, GetConfig y) => x.CompareTo(y) < 0;
        public static bool operator >(GetConfig x, GetConfig y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetConfig x, GetConfig y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc4f9186b);

        }
        
        T.Config ITlFunc<T.Config>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Config.Deserialize);
    }
}