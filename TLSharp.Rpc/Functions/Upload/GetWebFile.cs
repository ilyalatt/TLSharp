using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetWebFile : ITlFunc<T.Upload.WebFile>, IEquatable<GetWebFile>, IComparable<GetWebFile>, IComparable
    {
        public T.InputWebFileLocation Location { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetWebFile(
            Some<T.InputWebFileLocation> location,
            int offset,
            int limit
        ) {
            Location = location;
            Offset = offset;
            Limit = limit;
        }
        
        
        (T.InputWebFileLocation, int, int) CmpTuple =>
            (Location, Offset, Limit);

        public bool Equals(GetWebFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetWebFile x && Equals(x);
        public static bool operator ==(GetWebFile x, GetWebFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetWebFile x, GetWebFile y) => !(x == y);

        public int CompareTo(GetWebFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetWebFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetWebFile x, GetWebFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetWebFile x, GetWebFile y) => x.CompareTo(y) < 0;
        public static bool operator >(GetWebFile x, GetWebFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetWebFile x, GetWebFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Location: {Location}, Offset: {Offset}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x24e6818d);
            Write(Location, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Upload.WebFile ITlFunc<T.Upload.WebFile>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Upload.WebFile.Deserialize);
    }
}