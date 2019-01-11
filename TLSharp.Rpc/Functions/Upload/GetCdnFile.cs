using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Upload
{
    public sealed class GetCdnFile : ITlFunc<T.Upload.CdnFile>, IEquatable<GetCdnFile>, IComparable<GetCdnFile>, IComparable
    {
        public Arr<byte> FileToken { get; }
        public int Offset { get; }
        public int Limit { get; }
        
        public GetCdnFile(
            Some<Arr<byte>> fileToken,
            int offset,
            int limit
        ) {
            FileToken = fileToken;
            Offset = offset;
            Limit = limit;
        }
        
        
        (Arr<byte>, int, int) CmpTuple =>
            (FileToken, Offset, Limit);

        public bool Equals(GetCdnFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetCdnFile x && Equals(x);
        public static bool operator ==(GetCdnFile x, GetCdnFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetCdnFile x, GetCdnFile y) => !(x == y);

        public int CompareTo(GetCdnFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetCdnFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetCdnFile x, GetCdnFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetCdnFile x, GetCdnFile y) => x.CompareTo(y) < 0;
        public static bool operator >(GetCdnFile x, GetCdnFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetCdnFile x, GetCdnFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FileToken: {FileToken}, Offset: {Offset}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2000bcc3);
            Write(FileToken, bw, WriteBytes);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Upload.CdnFile ITlFunc<T.Upload.CdnFile>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Upload.CdnFile.Deserialize);
    }
}