using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetDhConfig : ITlFunc<T.Messages.DhConfig>, IEquatable<GetDhConfig>, IComparable<GetDhConfig>, IComparable
    {
        public int Version { get; }
        public int RandomLength { get; }
        
        public GetDhConfig(
            int version,
            int randomLength
        ) {
            Version = version;
            RandomLength = randomLength;
        }
        
        
        (int, int) CmpTuple =>
            (Version, RandomLength);

        public bool Equals(GetDhConfig other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetDhConfig x && Equals(x);
        public static bool operator ==(GetDhConfig x, GetDhConfig y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetDhConfig x, GetDhConfig y) => !(x == y);

        public int CompareTo(GetDhConfig other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetDhConfig x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetDhConfig x, GetDhConfig y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetDhConfig x, GetDhConfig y) => x.CompareTo(y) < 0;
        public static bool operator >(GetDhConfig x, GetDhConfig y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetDhConfig x, GetDhConfig y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Version: {Version}, RandomLength: {RandomLength})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x26cf8950);
            Write(Version, bw, WriteInt);
            Write(RandomLength, bw, WriteInt);
        }
        
        T.Messages.DhConfig ITlFunc<T.Messages.DhConfig>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.DhConfig.Deserialize);
    }
}