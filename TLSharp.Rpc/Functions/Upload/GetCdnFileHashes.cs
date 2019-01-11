using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetCdnFileHashes : ITlFunc<Arr<T.FileHash>>, IEquatable<GetCdnFileHashes>, IComparable<GetCdnFileHashes>, IComparable
    {
        public Arr<byte> FileToken { get; }
        public int Offset { get; }
        
        public GetCdnFileHashes(
            Some<Arr<byte>> fileToken,
            int offset
        ) {
            FileToken = fileToken;
            Offset = offset;
        }
        
        
        (Arr<byte>, int) CmpTuple =>
            (FileToken, Offset);

        public bool Equals(GetCdnFileHashes other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetCdnFileHashes x && Equals(x);
        public static bool operator ==(GetCdnFileHashes x, GetCdnFileHashes y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetCdnFileHashes x, GetCdnFileHashes y) => !(x == y);

        public int CompareTo(GetCdnFileHashes other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetCdnFileHashes x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetCdnFileHashes x, GetCdnFileHashes y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetCdnFileHashes x, GetCdnFileHashes y) => x.CompareTo(y) < 0;
        public static bool operator >(GetCdnFileHashes x, GetCdnFileHashes y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetCdnFileHashes x, GetCdnFileHashes y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FileToken: {FileToken}, Offset: {Offset})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4da54231);
            Write(FileToken, bw, WriteBytes);
            Write(Offset, bw, WriteInt);
        }
        
        Arr<T.FileHash> ITlFunc<Arr<T.FileHash>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.FileHash.Deserialize));
    }
}