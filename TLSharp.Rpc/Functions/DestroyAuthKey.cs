using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class DestroyAuthKey : ITlFunc<T.DestroyAuthKeyRes>, IEquatable<DestroyAuthKey>, IComparable<DestroyAuthKey>, IComparable
    {

        
        public DestroyAuthKey(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(DestroyAuthKey other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DestroyAuthKey x && Equals(x);
        public static bool operator ==(DestroyAuthKey x, DestroyAuthKey y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DestroyAuthKey x, DestroyAuthKey y) => !(x == y);

        public int CompareTo(DestroyAuthKey other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DestroyAuthKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DestroyAuthKey x, DestroyAuthKey y) => x.CompareTo(y) <= 0;
        public static bool operator <(DestroyAuthKey x, DestroyAuthKey y) => x.CompareTo(y) < 0;
        public static bool operator >(DestroyAuthKey x, DestroyAuthKey y) => x.CompareTo(y) > 0;
        public static bool operator >=(DestroyAuthKey x, DestroyAuthKey y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd1435160);

        }
        
        T.DestroyAuthKeyRes ITlFunc<T.DestroyAuthKeyRes>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DestroyAuthKeyRes.Deserialize);
    }
}