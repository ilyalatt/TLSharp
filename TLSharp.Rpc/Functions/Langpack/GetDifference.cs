using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Langpack
{
    public sealed class GetDifference : ITlFunc<T.LangPackDifference>, IEquatable<GetDifference>, IComparable<GetDifference>, IComparable
    {
        public int FromVersion { get; }
        
        public GetDifference(
            int fromVersion
        ) {
            FromVersion = fromVersion;
        }
        
        
        int CmpTuple =>
            FromVersion;

        public bool Equals(GetDifference other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetDifference x && Equals(x);
        public static bool operator ==(GetDifference x, GetDifference y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDifference x, GetDifference y) => !(x == y);

        public int CompareTo(GetDifference other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetDifference x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDifference x, GetDifference y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDifference x, GetDifference y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDifference x, GetDifference y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDifference x, GetDifference y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FromVersion: {FromVersion})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0b2e4d7d);
            Write(FromVersion, bw, WriteInt);
        }
        
        T.LangPackDifference ITlFunc<T.LangPackDifference>.DeserializeResult(BinaryReader br) =>
            Read(br, T.LangPackDifference.Deserialize);
    }
}