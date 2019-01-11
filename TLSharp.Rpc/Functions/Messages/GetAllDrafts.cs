using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetAllDrafts : ITlFunc<T.UpdatesType>, IEquatable<GetAllDrafts>, IComparable<GetAllDrafts>, IComparable
    {

        
        public GetAllDrafts(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetAllDrafts other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetAllDrafts x && Equals(x);
        public static bool operator ==(GetAllDrafts x, GetAllDrafts y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAllDrafts x, GetAllDrafts y) => !(x == y);

        public int CompareTo(GetAllDrafts other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetAllDrafts x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAllDrafts x, GetAllDrafts y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAllDrafts x, GetAllDrafts y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAllDrafts x, GetAllDrafts y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAllDrafts x, GetAllDrafts y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6a3f8d65);

        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}