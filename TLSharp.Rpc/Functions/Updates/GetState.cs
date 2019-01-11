using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Updates
{
    public sealed class GetState : ITlFunc<T.Updates.State>, IEquatable<GetState>, IComparable<GetState>, IComparable
    {

        
        public GetState(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetState other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetState x && Equals(x);
        public static bool operator ==(GetState x, GetState y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetState x, GetState y) => !(x == y);

        public int CompareTo(GetState other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetState x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetState x, GetState y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetState x, GetState y) => x.CompareTo(y) < 0;
        public static bool operator >(GetState x, GetState y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetState x, GetState y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xedd4882a);

        }
        
        T.Updates.State ITlFunc<T.Updates.State>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Updates.State.Deserialize);
    }
}