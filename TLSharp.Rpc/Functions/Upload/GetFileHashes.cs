using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetFileHashes : ITlFunc<Arr<T.FileHash>>, IEquatable<GetFileHashes>, IComparable<GetFileHashes>, IComparable
    {
        public T.InputFileLocation Location { get; }
        public int Offset { get; }
        
        public GetFileHashes(
            Some<T.InputFileLocation> location,
            int offset
        ) {
            Location = location;
            Offset = offset;
        }
        
        
        (T.InputFileLocation, int) CmpTuple =>
            (Location, Offset);

        public bool Equals(GetFileHashes other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetFileHashes x && Equals(x);
        public static bool operator ==(GetFileHashes x, GetFileHashes y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFileHashes x, GetFileHashes y) => !(x == y);

        public int CompareTo(GetFileHashes other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetFileHashes x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFileHashes x, GetFileHashes y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFileHashes x, GetFileHashes y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFileHashes x, GetFileHashes y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFileHashes x, GetFileHashes y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Location: {Location}, Offset: {Offset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc7025931);
            Write(Location, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
        }
        
        Arr<T.FileHash> ITlFunc<Arr<T.FileHash>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.FileHash.Deserialize));
    }
}