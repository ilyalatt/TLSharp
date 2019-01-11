using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetFile : ITlFunc<T.Upload.File>, IEquatable<GetFile>, IComparable<GetFile>, IComparable
    {
        public T.InputFileLocation Location { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetFile(
            Some<T.InputFileLocation> location,
            int offset,
            int limit
        ) {
            Location = location;
            Offset = offset;
            Limit = limit;
        }
        
        
        (T.InputFileLocation, int, int) CmpTuple =>
            (Location, Offset, Limit);

        public bool Equals(GetFile other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetFile x && Equals(x);
        public static bool operator ==(GetFile x, GetFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFile x, GetFile y) => !(x == y);

        public int CompareTo(GetFile other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFile x, GetFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFile x, GetFile y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFile x, GetFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFile x, GetFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Location: {Location}, Offset: {Offset}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe3a6cfb5);
            Write(Location, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Upload.File ITlFunc<T.Upload.File>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Upload.File.Deserialize);
    }
}