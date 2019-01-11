using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetAppUpdate : ITlFunc<T.Help.AppUpdate>, IEquatable<GetAppUpdate>, IComparable<GetAppUpdate>, IComparable
    {

        
        public GetAppUpdate(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetAppUpdate other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetAppUpdate x && Equals(x);
        public static bool operator ==(GetAppUpdate x, GetAppUpdate y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAppUpdate x, GetAppUpdate y) => !(x == y);

        public int CompareTo(GetAppUpdate other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetAppUpdate x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAppUpdate x, GetAppUpdate y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAppUpdate x, GetAppUpdate y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAppUpdate x, GetAppUpdate y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAppUpdate x, GetAppUpdate y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xae2de196);

        }
        
        T.Help.AppUpdate ITlFunc<T.Help.AppUpdate>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.AppUpdate.Deserialize);
    }
}